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

        }

        private void LoadList()
        {
            //创建业务逻辑层对象
            ManagerInfoBll miBll = new ManagerInfoBll();
            //调用GetList方法
            dgvList.DataSource = miBll.GetList();
        }
    }
}
