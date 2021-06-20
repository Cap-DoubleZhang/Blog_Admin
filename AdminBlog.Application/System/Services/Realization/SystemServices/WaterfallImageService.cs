using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using EFCore.BulkExtensions;
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
    /// 瀑布流图片
    /// </summary>
    [DynamicApiController]
    [Route("/api/waterfallImage")]
    public class WaterfallImageService
    {
        #region 依赖注入
        private readonly IRepository<SysWaterfallImages> _sysFileRepository;
        private readonly FilePathOptions _filePathOptions;
        public WaterfallImageService(IRepository<SysWaterfallImages> sysFileRepository, IOptions<FilePathOptions> filePathOptions)
        {
            _sysFileRepository = sysFileRepository;
            _filePathOptions = filePathOptions.Value;
        }
        #endregion

        #region 图片操作
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("image")]
        public async Task SaveImage(List<IFormFile> file)
        {
            if (file == null || file.Count() <= 0)
                throw Oops.Oh(FileEnum.InputFileNonExist);
            //要保存到哪个路径(本地的真实路径)
            var filePath = Path.Combine($"{App.WebHostEnvironment.WebRootPath}\\Uploads\\WaterfallImage\\");
            List<SysWaterfallImages> lst = new List<SysWaterfallImages>();
            string port = App.HttpContext.Connection.LocalPort == 80 ? "" : ":" + App.HttpContext.Connection.LocalPort.ToString();
            string ip = App.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() == "0.0.0.1" ? "localhost" : App.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
            string IpStr = $"https://{ip}{port}";
            foreach (var item in file)
            {
                //上传的文件大小  KB
                long fileSize = item.Length / 1024;

                var fileSuffix = Path.GetExtension(item.FileName).ToLower(); // 文件后缀
                var finalName = YitIdHelper.NextId() + fileSuffix; // 生成文件的最终名称

                //创建本地文件夹
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                //将上传的文件保存到本地
                using (var stream = File.Create(filePath + finalName))
                {
                    await item.CopyToAsync(stream);
                    await stream.FlushAsync();
                }
                SysWaterfallImages images = new SysWaterfallImages
                {
                    //Name = dto.name,
                    //Remark = dto.remark,
                    Src = $"{IpStr}/Uploads/WaterfallImage/{finalName}",
                };
                lst.Add(images);
            }
            await _sysFileRepository.Context.BulkInsertAsync(lst);

        }

        /// <summary>
        ///  获取所有瀑布流图片
        /// </summary>
        /// <returns></returns>
        [HttpGet("images")]
        public async Task<PagedList<ResultWaterfallImagesDto>> GetWaterfallImages([FromQuery] SearchWaterfallImageDto dto)
        {
            PagedList<SysWaterfallImages> files = await _sysFileRepository.Entities.OrderByDescending(a => a.CreatedTime).ToPagedListAsync(dto.pageIndex, 30);
            return files.Adapt<PagedList<ResultWaterfallImagesDto>>();
        }
        #endregion
    }
}
