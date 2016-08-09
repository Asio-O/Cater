using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bll;
using Model;

namespace WebApp
{
    /// <summary>
    /// AddManagerInfo 的摘要说明
    /// </summary>
    public class AddManagerInfo : IHttpHandler
    {
        ManagerInfoBll mibll = new ManagerInfoBll();
        ManagerInfo mi = new ManagerInfo();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            mi.MName = context.Request.Form["name"];
            mi.MPwd = context.Request.Form["pwd"];
            mi.Mtype =Convert.ToInt32( context.Request.Form["type"]);
            if (mibll.Add(mi))
            {
                context.Response.Write("操作成功");
            }
            else
            {
                context.Response.Write("操作失败");
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