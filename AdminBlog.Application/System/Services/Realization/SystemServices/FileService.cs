using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yitter.IdGenerator;

namespace AdminBlog.Application
{
    /// <summary>
    /// 系统文件
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class FileService
    {
        #region 依赖注入
        private readonly IRepository<SysFile> _sysFileRepository;
        private readonly FilePathOptions _filePathOptions;
        public FileService(IRepository<SysFile> sysFileRepository, IOptions<FilePathOptions> filePathOptions)
        {
            _sysFileRepository = sysFileRepository;
            _filePathOptions = filePathOptions.Value;
        }
        #endregion

        #region 文件操作
        /// <summary>
        /// 获取系统文件分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("files")]
        public async Task<PagedList<ResultSysFileDto>> GetPagedDictionariesAsync([FromQuery] SearchSysFileDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<SysFile, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
                if (!string.IsNullOrWhiteSpace(keys[0]))
                {
                    foreach (var item in keys)
                    {
                        if (item == keys[0])
                        {
                            expression = expression.And(x => x.FileName.Contains(item)
                                                          || x.FileType.Contains(item));
                        }
                        else
                        {
                            expression = expression.Or(x => x.FileName.Contains(item)
                                                          || x.FileType.Contains(item));
                        }
                    }
                }
            }
            #endregion

            PagedList<SysFile> files = await _sysFileRepository.Where(expression).OrderByDescending(x => x.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return files.Adapt<PagedList<ResultSysFileDto>>();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        [HttpPost("file")]
        public async Task<string> UploadFile(IFormFile file, string filePathName)
        {
            if (file == null || file.Length <= 0)
                throw Oops.Oh(FileEnum.InputFileNonExist);
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine($"{App.WebHostEnvironment.WebRootPath}\\Uploads\\{filePathName}\\");
            //上传的文件大小  KB
            long fileSize = file.Length / 1024;

            var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
            var finalName = YitIdHelper.NextId() + fileSuffix; // 生成文件的最终名称

            //创建本地文件夹
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //将上传的文件保存到本地
            using (var stream = File.Create(filePath + finalName))
            {
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
            }

            SysFile sysFile = new SysFile
            {
                FileName = file.FileName,
                RealPath = filePath + finalName,
                FileSize = fileSize,
            };
            await _sysFileRepository.InsertNowAsync(sysFile);
            //返回文件的网络路径(应写在配置文件中或自动获取)
            return $"https://localhost:5001/Uploads/" + filePathName + "/" + finalName;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownFile(long id)
        {
            if (id <= 0)
                throw Oops.Oh("必要参数为空.");
            SysFile sysFile = await _sysFileRepository.FindOrDefaultAsync(id);
            if (sysFile == null || sysFile.Id <= 0)
                throw Oops.Oh(FileEnum.FileNonExist);
            //更新下载次数
            sysFile.DownTimes += 1;
            await _sysFileRepository.UpdateAsync(sysFile);

            return new FileStreamResult(new FileStream(sysFile.RealPath, FileMode.Open), "application/octet-stream") { FileDownloadName = sysFile.FileName };
        }
        #endregion
    }
}
