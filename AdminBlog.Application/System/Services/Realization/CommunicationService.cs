using Furion.DynamicApiController;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminBlog.SignalRApplication;

namespace AdminBlog.Application.System.Services.Realization
{
    /// <summary>
    /// 实时通讯
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class CommunicationService
    {
        #region 依赖注入
        private readonly IHubContext<SignalRHub> hub;
        public CommunicationService(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }
        #endregion
    }
}
