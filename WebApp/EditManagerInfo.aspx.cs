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
    public partial class EditManagerInfo : System.Web.UI.Page
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        public  ManagerInfo mi = new ManagerInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (IsPostBack)
            {
                IsPost();
            }
            else
            {
                NotPost();
            }
        }
        private void IsPost()
        {
            mi.Mid =Convert.ToInt32( Request.Form["id"]);
            mi.MName = Request.Form["name"];
            mi.MPwd = Request.Form["pwd"];
            mi.Mtype = Convert.ToInt32(Request.Form["type"]);
            if (miBll.Edit(mi))
            {
                Response.Write("修改成功  <a href='ManagerInfoList.aspx'>返回信息列表</a>");
            }
            else
            {
                Response.Write("修改失败");
            }
        }
        private void NotPost()
        {
            mi.Mid = Convert.ToInt32(Request.Params["id"]);
            mi = miBll.GetById(mi.Mid);
            if (mi==null)
            {
                Response.Redirect("Error.html");
            }
        }
    }
}