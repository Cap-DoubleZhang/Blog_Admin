using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
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
        public async Task<string[]> UploadFile(List<IFormFile> files, string filePathName)
        {
            if (files == null || files.Count() <= 0)
                throw Oops.Oh(FileEnum.InputFileNonExist);
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine($"{App.WebHostEnvironment.WebRootPath}\\images\\{filePathName}\\");
            //用于存储对应文件的网络路径
            string[] paths = new string[files.Count()];
            foreach (var file in files)
            {
                FileHelper.GetMD5HashFromFile(file.FileName);
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
                    Id = YitIdHelper.NextId(),
                    FileName = file.FileName,
                    RealPath = $"/images/{filePathName}/{finalName}",
                    FileSize = fileSize,
                };
                await _sysFileRepository.InsertNowAsync(sysFile);
                paths.Append($"{_filePathOptions.UploadLocalhost}/images/{filePathName}/{finalName}");
            }
            //返回文件的网络路径(应写在配置文件中或自动获取)
            return paths;
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
