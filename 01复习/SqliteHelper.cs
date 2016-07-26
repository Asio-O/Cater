using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace _01复习
{
    class SqliteHelper
    {
        //从配置文件中读取连接字符串
        private static string connStr = ConfigurationManager.ConnectionStrings["Cater"].ConnectionString;

        //执行命令的方法：insert，update，delete 
        public static int ExecuteNonQuery(string sql,params SQLiteParameter[] ps)//使用Params可变参数，省略手动构造数组的过程 ，直接指定对象，编译器自动为我们构造数组，并将对象加入数组中传递过来
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //创建连接对象
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //添加参数
                cmd.Parameters.AddRange(ps);
                //打开链接
                conn.Open();
                //执行命令，返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        }

        //获取首行首列的方法
        public static object ExecuteScalar(string sql,params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                //执行命令，获得查询结果中首行首列的值，将之返回
                return cmd.ExecuteScalar();
            }
        }

        //获取结果集
        public static DataTable GetDataTable(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //构造适配器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                //构造数据表
                DataTable dt = new DataTable();
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                //执行命令填充数据表
                adapter.Fill(dt);
                //返回结果集
                return dt;
            }
        }
    }
}
