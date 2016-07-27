using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //将当前应用程序退出，而不仅仅只是关闭当前窗体
            Application.Exit();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            //将当前应用程序退出
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //判断登陆进来的员工级别，以确定是否显示menuManager图标
            int type = Convert.ToInt32(this.Tag);
            if (type==0)
            {
                //登陆进来的人是店员，管理员菜单不需要显示,隐藏menuManager图标
                menuManagerInfo.Visible = false;
            }
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FormManageInfo formManagerInfo = FormManageInfo.Create();
            formManagerInfo.Show();//显示窗体
            formManagerInfo.Focus();//获得焦点
        }
    }
}
