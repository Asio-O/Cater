using Bll;
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

        private void FormManageInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            //创建业务逻辑层对象
            ManagerInfoBll miBll = new ManagerInfoBll();
            //禁用列表的自动生成
            dgvList.AutoGenerateColumns = false;
            //调用GetList方法获取数据，绑定到列表的数据源上
            dgvList.DataSource = miBll.GetList();
        }
    }
}
