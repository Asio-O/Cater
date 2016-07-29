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
    public partial class MemberInfoDal
    {
        /// <summary>
        /// 获取所有未删除的行
        /// </summary>
        /// <param name="dic">参数键值对</param>
        /// <returns>List<MemberInfo></returns>
        public List<MemberInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = @"select MemberInfo.*,MemberTypeInfo.MTitle as MTypeTitle
                            from MemberInfo
                            inner join MemberTypeInfo
                            on MemberInfo.MTypeId = MemberTypeInfo.MId
                            where MemberInfo.MIsDelete=0";
            //参数化，构造参数集合
            List<SQLiteParameter> listp = new List<SQLiteParameter>();
            //拼接条件
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sql += " and " + pair.Key + " like @" + pair.Key;
                    listp.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }

            //执行得到结果集
            DataTable dt = SqliteHelper.GetDataTable(sql, listp.ToArray());
            //定义list,完成转型
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MMoney = Convert.ToInt32(row["mmoney"]),
                    MTypeId = Convert.ToInt32(row["mtypeid"]),
                    MTypeTitle = row["mtypetitle"].ToString()
                });
            }
            return list;
        }
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="mi">MemberInfo类型</param>
        /// <returns>受影响的行</returns>
        public int Insert(MemberInfo mi)
        {
            string sql = "insert into MemberInfo(MTypeId,MName,MPhone,MMoney) values(@typeId,@name,@phone,@money)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@typeId",mi.MTypeId),
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="mi">需要更新的对象</param>
        /// <returns>被更新的行数</returns>
        public int Update(MemberInfo mi)
        {
            string sql = "update MemberInfo set MName=@name,MPhone=@phone,MMoney=@money,MTypeId=@typeId where MId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney),
                new SQLiteParameter("@typeId",mi.MTypeId),
                new SQLiteParameter("@id",mi.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }

        public int Delete(int id)
        {
            string sql = "update MemberInfo set MIsDelete=1 where MId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
