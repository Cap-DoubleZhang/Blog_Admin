using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Bucket;
using COSXML.Model.Object;
using COSXML.Transfer;
//using EFCore.BulkExtensions;
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
        /// 批量上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("images")]
        public async Task<string> SaveImage(List<IFormFile> file)
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
                    Id = YitIdHelper.NextId(),
                    //Name = dto.name,
                    //Remark = dto.remark,
                    Src = $"{IpStr}/Uploads/WaterfallImage/{finalName}",
                };
                lst.Add(images);
            }
            await _sysFileRepository.Context.BulkInsertAsync(lst);

            return lst[0].Src;
        }

        /// <summary>
        /// 上传单张图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("image")]
        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null)
                throw Oops.Oh(FileEnum.InputFileNonExist);

            string secretId = "AKIDvgJfkZ7PQAdroVv60dz4tRiiSw95lAI9"; //"云 API 密钥 SecretId";
            string secretKey = "bvykFUS9ZiaCYeaGfnfGaeSzFEwOZS4Q";//"云 API 密钥 secretKey";
            string region = "ap-shanghai";

            CosXmlConfig config = new CosXmlConfig.Builder()
                                    .IsHttps(true)  //设置默认 HTTPS 请求
                                    .SetRegion(region)  //设置一个默认的存储桶地域
                                    .SetDebugLog(true)  //显示日志
                                    .Build();

            long durationSecond = 600;  //每次请求签名有效时长，单位为秒
            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(
              secretId, secretKey, durationSecond);

            #region 创建存储桶
            CosXml cosXml = new CosXmlServer(config, cosCredentialProvider);
            //string bucket = ""; //格式：BucketName-APPID
            //PutBucketRequest request = new PutBucketRequest(bucket);
            ////执行请求
            //PutBucketResult result = cosXml.PutBucket(request);
            ////请求成功
            //Console.WriteLine(result.GetResultInfo());
            #endregion

            #region 上传文件
            // 初始化 TransferConfig
            TransferConfig transferConfig = new TransferConfig();

            // 初始化 TransferManager
            TransferManager transferManager = new TransferManager(cosXml, transferConfig);

            string appid = "1305151950";
            string bucket = "blog-image-1305151950";
            string key = "exampleobject"; //对象在存储桶中的名称
            var stream = File.Create("test.jpg");
            await file.CopyToAsync(stream);

            PutObjectRequest request = new PutObjectRequest(bucket, key, stream);
            //执行请求
            PutObjectResult result = cosXml.PutObject(request);
            //对象的 eTag
            string eTag = result.eTag;

            #endregion
            return null;
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
