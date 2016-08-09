using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// DeleteManagerInfo 的摘要说明
    /// </summary>
    public class DeleteManagerInfo : IHttpHandler
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id =Convert.ToInt32( context.Request.Params["id"]);

            if (miBll.Remove(id))
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}