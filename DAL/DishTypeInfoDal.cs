using Cater.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Dal
{
    public partial class DishTitleInfoDal
    {
        /// <summary>
        /// 获取所有未删除列
        /// </summary>
        /// <returns>DishTypeInfo的集合</returns>
        public List<DishTypeInfo> Getlist()
        {
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            string sql = "select * from DishTypeInfo where DIsDelete=0";
            DataTable dt= SqliteHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId =Convert.ToInt32( row[0]),
                    DTitle=row[1].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// 插入一行数据
        /// </summary>
        /// <param name="dti">DishTypeInfo对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(DishTypeInfo dti)
        {
            string sql = "insert into DishtypeInfo(DTitle) values(@title)";
            SQLiteParameter[] ps = {
                new SQLiteParameter( "@id",dti.DId),
                new SQLiteParameter("@title",dti.DTitle)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(DishTypeInfo dti)
        {
            string sql = "update DishTypeInfo set DTitle=@title where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dti.DTitle),
                new SQLiteParameter("@id",dti.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "update DishTypeInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
