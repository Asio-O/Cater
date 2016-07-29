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
    public partial class FormMemberTypeInfo : Form
    {
        private DialogResult result;
        public FormMemberTypeInfo()
        {
            InitializeComponent();
            result = DialogResult.Cancel;
        }
        //创建业务逻辑层对象
        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = mtiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //获取用户输入
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text),
            };
            if (btnSave.Text == "添加")//调用添加方法
            {
                //调用业务逻辑层的添加方法
                if (mtiBll.Add(mti))
                {
                    LoadList();
                    result = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试");
                }
            }
            else//调用修改方法
            {
                mti.MId = Convert.ToInt32(txtId.Text);
                if (mtiBll.Edit(mti))
                {
                    LoadList();
                    result = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            //将控件还原
            txtId.Text = "自动添加编号";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "添加";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //将控件还原
            txtId.Text = "自动添加编号";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取点击的行
            var row = dgvList.Rows[e.RowIndex];
            //将行中的值赋给文本框
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            //将按钮的text改为“修改”
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取列表中选中的行
            var row= dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            if (mtiBll.Remove(id))
            {
                LoadList();
                result = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            
        }

        private void FormMemberTypeInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
