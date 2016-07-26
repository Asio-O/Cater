using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial class ManagerInfoDal
    {
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns></returns>
        public List<ManagerInfo> GetList()
        {
            //构造将要查询的sql语句
            string sql = "select * from ManagerInfo";
            //使用helper进行查询，得到结果
            DataTable dt = SqliteHelper.GetDataTable(sql);
            //将dt中的数据转存到list中
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    Mid = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPwd = row["mpwd"].ToString(),
                    Mtype = Convert.ToInt32(row["mtype"])
                });
            }
            //将集合返回
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="mi">ManagerInfo类型的对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(ManagerInfo mi)
        {
            //构造Insert语句
            string sql = "insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            //构造sql语句的参数
            SQLiteParameter[] ps =//使用数组
            {
               new SQLiteParameter("@name", mi.MName),
               new SQLiteParameter("@pwd",Md5Help.EncryptString(mi.MPwd)),//将密码进行MD5加密
               new SQLiteParameter("@type",mi.Mtype),
            };
            //执行插入操作
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="mi">ManagerInfo类型的对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(ManagerInfo mi)
        {
            //构造UPdate的sql语句
            string sql = "update ManagerInfo set mname=@name,mpwd=@pwd,mtype=@type where mid=@id";
            //构造语句的参数
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",mi.MPwd),
                new SQLiteParameter("@type",mi.Mtype),
                new SQLiteParameter("@mid",mi.Mid)
            };
            //执行语句并返回结果
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

    }
}
