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
    public partial class FormMemberInfo : Form
    {
        MemberInfoBll miBll;
        MemberTypeInfoBll mitBll;
        public FormMemberInfo()
        {
            InitializeComponent();
            miBll = new MemberInfoBll();
            mitBll = new MemberTypeInfoBll();
        }

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            //加载会员信息
            LoadList();
            //加载会员类型信息
            LoadTypeList();
        }

        private void LoadList()
        {
            //使用键值对存储条件
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //收集用户名信息
            if (txtNameSearch.Text != "")
            {
                //需要根据用户名称进行搜索
                dic.Add("MName", txtNameSearch.Text);
            }
            //手机用户电话信息
            if (txtPhoneSearch.Text != "")
            {
                //需要根据用户电话进行搜索
                dic.Add("MPhone", txtPhoneSearch.Text);
            }
            //禁用列表的自动生成
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList(dic);
            //设置某行选中
            if (dgvSelectedIndex==-1)
            {
                return;
            }
            dgvList.Rows[dgvSelectedIndex].Selected = true;
        }
        private void LoadTypeList()
        {
            List<MemberTypeInfo> list = mitBll.GetList();
            //设置下拉菜单的值
            ddlType.DataSource = list;
            //设置显示值
            ddlType.DisplayMember = "mtitle";
            //设置value值
            ddlType.ValueMember = "mid";
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            //内容改变事件
            LoadList();
        }

        private void txtPhoneSearch_TextChanged(object sender, EventArgs e)
        {
            //内容改变事件
            LoadList();
        }


        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            //清空搜索输入框并重新加载列表
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //值的有效性判断
            if (txtNameAdd.Text == "")
            {
                MessageBox.Show("请输入姓名");
                //使输入框获得焦点  
                txtNameAdd.Focus();
                return;
            }
            //无论是添加还是修改都需要一个对象接受用户输入的数据
            MemberInfo mi = new MemberInfo()
            {
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MMoney = Convert.ToInt32(txtMoney.Text),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue)

            };
            if (btnSave.Text == "添加")
            {
                if (miBll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else//修改
            {
                mi.MId = Convert.ToInt32(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            //恢复各控件为默认值
            txtId.Text = "自动添加编号";
            txtNameAdd.Text = "";
            ddlType.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            btnSave.Text = "添加";
        }

        private int dgvSelectedIndex=-1;
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //记录被点击的行
            dgvSelectedIndex = e.RowIndex;
            //获取被双击的行
            var row = dgvList.Rows[e.RowIndex];
            //获取被双击行 各列的值
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString();
            txtPhoneAdd.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            //将添加按钮改为修改
            btnSave.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //恢复各控件为默认值
            txtId.Text = "自动添加编号";
            txtNameAdd.Text = "";
            ddlType.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show("确定要删除吗","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            if (miBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo formMti = new FormMemberTypeInfo();
            //以模态窗口的方式打开分类管理
            DialogResult result= formMti.ShowDialog();
            //根据返回值进行判断是否更新下拉列表
            if (result==DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }
    }
}
