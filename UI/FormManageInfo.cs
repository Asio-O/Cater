﻿using Bll;
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
        private FormManageInfo()
        {
            InitializeComponent();
        }

        //实现窗体的单例
        private static FormManageInfo _form;
        public static FormManageInfo Create()
        {
            if (_form == null)
            {
                _form = new FormManageInfo();
            }
            return _form;
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
                Mtype = rb1.Checked ? 1 : 0//经理值为1，店员值为0
            };
            //判断是添加还是修改
            if (btnSave.Text == "添加")
            {
                #region 添加
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
                #endregion
            }
            else
            {
                #region 修改
                mi.Mid = Convert.ToInt32(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                    //清除文本框与按钮的值
                    txtName.Text = "";
                    txtPwd.Text = "";
                    rb2.Checked = true;
                    btnSave.Text = "添加";
                    txtId.Text = "自动添加编号";

                }
                #endregion
            }


        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //对类型列进行格式化处理
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "店员";
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前双击的单元格的行值
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            //通过索引从行中获取列的值
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;//值为1，选中经理
            }
            else
            {
                rb2.Checked = true;//值为0，选中店员
            }
            //为密码框填入不可能成为密码的值
            txtPwd.Text = "这永远不可能是一个密码";
            //更改按钮显示的文字
            btnSave.Text = "修改";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "自动添加编号";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中行的集合
            var rows = dgvList.SelectedRows;
            //判断集合中是否有元素
            if (rows.Count > 0)
            {
                //删除前的确认提示
                DialogResult result = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                //获取选中行的编号
                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                if (miBll.Remove(id))
                {
                    //删除成功，重新加载数据
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的行");
            }
        }

        private void FormManageInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //与单例保持一致
            //出现这种代码的原因：Form的close()会释放当前窗体对象
            _form = null;
        }
    }
}
