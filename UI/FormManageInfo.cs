using Bll;
using Model;
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
    public partial class FormManageInfo : Form
    {
        public FormManageInfo()
        {
            InitializeComponent();
        }

        //创建业务逻辑层对象
        ManagerInfoBll miBll = new ManagerInfoBll();

        private void FormManageInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            //禁用列表的自动生成
            dgvList.AutoGenerateColumns = false;
            //调用GetList方法获取数据，绑定到列表的数据源上
            dgvList.DataSource = miBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //接受用户输入
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                Mtype = rb1.Checked?1:0//经理值为1，店员值为0
            };
            //调用Bll的Add方法
            if (miBll.Add(mi))
            {
                //如果添加成功，则重新加载数据
                LoadList();
                //清除文本框中的值
                txtName.Text = "";
                txtPwd.Text = "";
                rb2.Checked = true;
            }
            else
            {
                MessageBox.Show("添加失败，请重试");
            }

        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //对类型列进行格式化处理
            if (e.ColumnIndex==2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "店员";
            }
        }
    }
}
