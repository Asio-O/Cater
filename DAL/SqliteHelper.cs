﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace Dal
{
    class SqliteHelper
    {
        //从配置文件中读取连接字符串
        private static string connStr = ConfigurationManager.ConnectionStrings["Cater"].ConnectionString;

        //执行命令的方法：insert，update，delete 
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns>受影响的行数</returns>

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            //使用Params可变参数，省略手动构造数组的过程 ，直接指定对象，编译器自动为我们构造数组，并将对象加入数组中传递过来
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

        /// <summary>
        /// 获取首行首列的方法
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">sql语句参数数组</param>
        /// <returns>首行首列</returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] ps)
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

        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">sql语句参数数组</param>
        /// <returns>结果集</returns>
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
