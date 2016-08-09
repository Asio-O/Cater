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
        ManagerInfo mi = new ManagerInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            mi.Mid = Convert.ToInt32(Request.Params["id"]);
            miBll.GetList();
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
            mi.MName = Request.Form["name"];
            mi.MPwd = Request.Form["pwd"];
            mi.Mtype = Convert.ToInt32(Request.Form["type"]);
            if (miBll.Edit(mi))
            {
                Response.Write("修改成功");
            }
            else
            {
                Response.Write("修改失败");
            }
        }
        private void NotPost()
        {
           
        }
    }
}