using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{

    public partial class AddManager : System.Web.UI.Page
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        ManagerInfo mi = new ManagerInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                mi.MName = Request.Form["name"];
                mi.MPwd = Request.Form["pwd"];
                mi.Mtype = Convert.ToInt32(Request.Form["type"]);
                if (miBll.Add(mi))
                {
                    Response.Write("操作成功  <a href='ManagerInfoList.aspx'>返回信息列表</a>");
                }
                else
                {
                    Response.Write("添加失败");
                }
            }


        }
    }
}