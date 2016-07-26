using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _01复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /**
             * 操作数据库的类：
             * 连接Connecting
             * 命令Command
             * 适配器DataAdapter
             * DataReader
             * DataSet
             * DataTable
             */

            #region 手动查询代码
            ////从数据库表ManagerInfo中查询数据
            ////0、构造接受数据的集合
            //List<ManagerInfo> list = new List<ManagerInfo>();
            ////1、链接字符串
            //string connStr = @"data source=C:\Users\yangf\Documents\Visual Studio 2015\Projects\ItcastCater\lib\ItcastCater.db;version=3;";
            ////2、创建链接对象
            //using (SQLiteConnection conn = new SQLiteConnection(connStr))
            //{
            //    //3、创建Command对象
            //    SQLiteCommand cmd = new SQLiteCommand("select * from ManagerInfo", conn);
            //    //4、打开链接
            //    conn.Open();
            //    //5、执行命令
            //    SQLiteDataReader reader = cmd.ExecuteReader();
            //    //6、读取
            //    if (reader.HasRows)
            //    {
            //        //将一行数据构造成对象加入集合
            //        while (reader.Read())
            //        {
            //            list.Add(new ManagerInfo()
            //            {
            //                Mid = Convert.ToInt32(reader["mid"]),
            //                Mname = reader["mname"].ToString(),
            //                Mpwd = reader["mpwd"].ToString(),
            //                Mtyoe = Convert.ToInt32(reader["mtype"])
            //            });
            //        }
            //    }
            //    //7、将显示到DataGridView上
            //    dataGridView1.DataSource = list; 
            #endregion

            #region 使用Helper
            dataGridView1.DataSource = SqliteHelper.GetDataTable("select * from ManagerInfo");
            #endregion
        }
        
    }

}