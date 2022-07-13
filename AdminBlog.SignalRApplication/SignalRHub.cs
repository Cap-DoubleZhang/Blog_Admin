using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AdminBlog.SignalRApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class SignalRHub : Hub
    {
        /// <summary>
        /// 客户连接成功时触发
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var cid = Context.ConnectionId;

            await base.OnConnectedAsync();
        }
    }
}
