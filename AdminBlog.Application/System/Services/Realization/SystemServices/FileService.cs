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

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        [HttpPost("file")]
        public async Task<string> UploadFile(IFormFile files, string filePathName)
        {
            if (files == null || files.Length <= 0)
                throw Oops.Oh(FileEnum.InputFileNonExist);
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine($"{_filePathOptions.RealFilePath}\\wwwroot\\Uploads\\{filePathName}\\");
            //上传的文件大小  KB
            long fileSize = files.Length / 1024;

            var fileSuffix = Path.GetExtension(files.FileName).ToLower(); // 文件后缀
            var finalName = YitIdHelper.NextId() + fileSuffix; // 生成文件的最终名称

            //创建本地文件夹
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //将上传的文件保存到本地
            using (var stream = File.Create(filePath + finalName))
            {
                await files.CopyToAsync(stream);
                await stream.FlushAsync();
            }

            SysFile file = new SysFile
            {
                FileName = files.FileName,
                RealPath = filePath + finalName,
                FileSize = fileSize,
            };
            await _sysFileRepository.InsertNowAsync(file);
            //返回文件的网络路径
            return App.WebHostEnvironment.WebRootPath + file.Id;
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
    }
}
