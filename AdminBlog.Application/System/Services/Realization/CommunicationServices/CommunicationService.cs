using Furion.DynamicApiController;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminBlog.SignalRApplication;
using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using Furion;
using Furion.DatabaseAccessor;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlog.Application
{
    /// <summary>
    /// 实时通讯
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class CommunicationService
    {
        #region 依赖注入
        private readonly IHubContext<SignalRHub> _hubContext;
        public CommunicationService(IHubContext<SignalRHub> hubContext)
        {
            _hubContext = hubContext;
        }
        #endregion

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("message")]
        public async Task<bool> PushMessage(string content)
        {
            await _hubContext.Clients.All.SendAsync("ShouMsg", new MsgInfo { Title = "Title", Content = content });
            return true;
        }

        /// <summary>
        /// 发送信息给某个用户
        /// </summary>
        /// <param name="uid">接收方ID</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> SendMessageToUser(long uid,string content=null)
        {
            return true;
        }

        //public async Task<bool> Disconnected()
        //{
        //    _hubContext.
        //}
    }

    public class MsgInfo
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
