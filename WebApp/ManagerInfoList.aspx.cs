using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ManagerInfoList : System.Web.UI.Page
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        public string listStr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder miListSB = new StringBuilder();
            List<ManagerInfo> miList = new List<ManagerInfo>();
            miList = miBll.GetList();
            foreach (ManagerInfo mi in miList)
            {
                miListSB.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='EditManagerInfo.aspx?id={0}'>编辑</a></td><td><a href='DeleteManagerInfo.ashx?id={0}'>删除</a></td></tr>", mi.Mid, mi.MName, mi.MPwd, mi.Mtype == 1 ? "经理" : "店员");
            }
            listStr = miListSB.ToString();
        }
    }
}