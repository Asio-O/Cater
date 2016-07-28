using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial class MemberTypeInfoDal
    {
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
    }
}
