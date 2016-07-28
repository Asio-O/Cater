using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Dal
{
    public partial class MemberTypeInfoDal
    {
        /// <summary>
        /// 查询所有未删除数据
        /// </summary>
        /// <returns>List<MemberTypeInfo></returns>
        public List<MemberTypeInfo> GetList()
        {
            //查询未删除的数据
            string sql = "select * from memberTypeInfo where mIsDelete=0";
            //执行查询返回表格
            DataTable dt = SqliteHelper.GetDataTable(sql);
            //定义集合对象
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            //遍历表格,将数据转存到集合中
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId=Convert.ToInt32(row["mid"]),
                    MTitle=row["mtitle"].ToString(),
                    MDiscount=Convert.ToDecimal(row["mdiscount"])
                });
            }
            //返回集合
            return list;

        }

        public int Update(MemberTypeInfo mti)
        {
            //构造update语句
            string sql = "update memberTypeInfo set mtitle=@title,mdiscount=@discount where mId=@id";
            //构造参数
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount),
                new SQLiteParameter("@id",mti.MId)
            };
            //返回SqliteHelp执行结果
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Insert(MemberTypeInfo mti)
        {
            //构造insert语句
            string sql = "insert into MemberTypeInfo(MTitle,MDiscount) values(@title,@discount)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int mtiId)
        {
            //构造delete语句
            string sql = "update memberTypeInfo set MIsDelete=1 where MId=@id ";
            SQLiteParameter sp = new SQLiteParameter("@id", mtiId);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }

}
