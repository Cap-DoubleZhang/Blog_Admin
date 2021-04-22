using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Dtos;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Furion.Snowflake;
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
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine(_filePathOptions.RealFilePath + "\\" + filePathName + "\\");
            //上传的文件大小  KB
            long fileSize = files.Length / 1024;

            var fileSuffix = Path.GetExtension(files.FileName).ToLower(); // 文件后缀
            var finalName = IDGenerator.NextId() + fileSuffix; // 生成文件的最终名称

            //创建本地文件夹
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //将上传的文件保存到本地
            using (var stream = File.Create(filePath + finalName))
            {
                await files.CopyToAsync(stream);
            }

            SysFile file = new SysFile
            {
                FileName = finalName,
                RealPath = filePath + finalName,
                FileSize = fileSize,
            };
            await _sysFileRepository.InsertNowAsync(file);
            //返回文件的网络路径
            return App.WebHostEnvironment.WebRootPath + file.Id;
        }

        [HttpGet]
        public async Task<string> DownFile()
        {
            return null;
        }
    }
}
