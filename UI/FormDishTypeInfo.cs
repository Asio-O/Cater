using Bll;
using Cater.Model;
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
    public partial class FormDishTypeInfo : Form
    {
        //创建业务逻辑层对象
        DishTypeInfoBll dtiBll;
        //记录被点击的行
        int dgvSelectedIndex;
        public FormDishTypeInfo()
        {
            InitializeComponent();
            dtiBll = new DishTypeInfoBll();
            dgvSelectedIndex = -1;
        }

        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            loadList();
        }
        public void loadList()
        {
            dgvList.DataSource = dtiBll.Getlist();
            if (dgvSelectedIndex < 0)
            {
                return;
            }
            dgvList.Rows[dgvSelectedIndex].Selected = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //获取用户输入，构造对象
            DishTypeInfo dti = new DishTypeInfo()
            {
                DTitle = txtTitle.Text
            };
            //判断操作类型
            if (btnSave.Text == "添加")
            {
                if (dtiBll.Add(dti))
                {
                    loadList();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                //修改
                dti.DId = Convert.ToInt32(txtId.Text);
                if (dtiBll.Edit(dti))
                {
                    loadList();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }

            //各控件还原默认
            txtId.Text = "自动添加编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //记录选中行的index
            dgvSelectedIndex = e.RowIndex;
            //将该行的各数据显示到控件中
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();

            btnSave.Text = "修改";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //各控件还原默认
            txtId.Text = "自动添加编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //获取选中行的id
            int id=Convert.ToInt32( dgvList.SelectedRows[0].Cells[0].Value);
            if (dtiBll.Remove(id))
            {
                loadList();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
