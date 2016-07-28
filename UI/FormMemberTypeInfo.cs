using Dal;
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
    public partial class FormMemberTypeInfo : Form
    {
        public FormMemberTypeInfo()
        {
            InitializeComponent();
        }

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            MemberTypeInfoDal mtilBll = new MemberTypeInfoDal();
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource= mtilBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
