using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace Image.Application
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
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        [HttpPost("file")]
        public async Task<List<string>> UploadFile(List<IFormFile> files, string filePathName)
        {
            if (files == null || files.Count() <= 0)
                throw Oops.Oh(FileEnum.InputFileNonExist);
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine($"{App.WebHostEnvironment.WebRootPath}/{filePathName}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/");
            //用于存储对应文件的网络路径
            List<string> paths = new List<string>(files.Count());
            foreach (var file in files)
            {

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

                    //根据MD5值判断当前文件是否已经存在
                    string MD5Value = FileHelper.GetMD5HashFromFile(stream);
                    SysFile sysFileOld = await _sysFileRepository.SingleOrDefaultAsync(a => a.MD5Value == MD5Value);
                    if (sysFileOld != null && sysFileOld.Id > 0)
                    {
                        File.Delete(filePath + finalName);
                        paths.Append($"{_filePathOptions.UploadLocalhost}/{sysFileOld.Id}{sysFileOld.FileType}");
                    }
                    else
                    {
                        SysFile sysFile = new SysFile
                        {
                            Id = YitIdHelper.NextId(),
                            FileName = file.FileName,
                            RealPath = $"/{filePathName}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/{finalName}",
                            FileSize = fileSize,
                            MD5Value = string.Empty,
                            FileType = fileSuffix,
                            Site = filePathName,
                        };
                        await _sysFileRepository.InsertNowAsync(sysFile);
                        paths.Add($"{_filePathOptions.UploadLocalhost}/{sysFile.Id}{sysFile.FileType}");
                    }
                }
            }
            //返回文件的网络路径(应写在配置文件中或自动获取)
            return paths;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public async Task<IActionResult> look(string id)
        {
            if (id.Length <= 0)
                throw Oops.Oh("必要参数为空.");
            string[] fileName = id.Split('.');
            if (fileName.Length != 2)
                throw Oops.Oh(FileEnum.FileNonExist);
            long.TryParse(fileName[0], out long fileId);
            if (fileId <= 0)
                throw Oops.Oh(FileEnum.FileNonExist);
            //获取文件
            SysFile sysFile = await _sysFileRepository.SingleOrDefaultAsync(x => x.Id == fileId && x.FileType == $".{fileName[1]}");
            if (sysFile == null || sysFile.Id <= 0)
                throw Oops.Oh(FileEnum.FileNonExist);

            //获取图片的返回类型
            var contentTypDict = new Dictionary<string, string>
            {
                { ".jpg", "image/jpeg"},
                { ".jpeg", "image/jpeg"},
                { ".jpe", "image/jpeg"},
                { ".png", "image/png"},
                { ".gif", "image/gif"},
                { ".ico", "image/x-ico"},
                { ".tif", "image/tiff"},
                { ".tiff", "image/tiff"},
                { ".fax", "image/fax"},
                { ".wbmp", "image/nd.wap.wbmp"},
                { ".rp", "imagend.rn-realpix"},
            };
            string fileTypeStr = sysFile.FileType;
            //非图片进行下载，图片进行预览
            if (!contentTypDict.ContainsKey(fileTypeStr))
            {
                //更新下载次数
                sysFile.DownTimes += 1;
                await _sysFileRepository.UpdateAsync(sysFile);
                return new FileStreamResult(new FileStream($"{App.WebHostEnvironment.WebRootPath}/{sysFile.RealPath}", FileMode.Open), "application/octet-stream") { FileDownloadName = sysFile.FileName };
            }
            else
            {
                using (FileStream fs = new FileStream($"{App.WebHostEnvironment.WebRootPath}/{sysFile.RealPath}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    return new FileContentResult(bytes, contentTypDict[fileTypeStr]);
                }
            }
        }

        /// <summary>
        ///  获取所有二次元图片
        /// </summary>
        /// <returns></returns>
        [HttpGet("acgn")]
        public async Task<List<ResultSysImagesDto>> GetACGNImages([FromQuery] SearchWaterfallImageDto dto)
        {
            PagedList<SysFile> files = await _sysFileRepository.Entities.OrderByDescending(a => a.CreatedTime).ToPagedListAsync(dto.pageIndex, 30);
            //获取图片的返回类型
            var contentTypDict = new Dictionary<string, string>
            {
                { ".jpg", "image/jpeg"},
                { ".jpeg", "image/jpeg"},
                { ".jpe", "image/jpeg"},
                { ".png", "image/png"},
                { ".gif", "image/gif"},
                { ".ico", "image/x-ico"},
                { ".tif", "image/tiff"},
                { ".tiff", "image/tiff"},
                { ".fax", "image/fax"},
                { ".wbmp", "image/nd.wap.wbmp"},
                { ".rp", "imagend.rn-realpix"},
            };
            List<ResultSysImagesDto> result = new List<ResultSysImagesDto>();
            foreach (var item in files.Items)
            {
                using (FileStream fs = new FileStream($"{App.WebHostEnvironment.WebRootPath}/{item.RealPath}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    result.Add(new ResultSysImagesDto
                    {
                        image = new FileContentResult(bytes, contentTypDict[item.FileType]),
                    });
                }
            }
            return result;
        }
        #endregion
    }
}
