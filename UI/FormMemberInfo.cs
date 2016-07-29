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

            }
        }
    }
}
