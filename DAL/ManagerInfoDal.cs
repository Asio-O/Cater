using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial class ManagerInfoDal
    {
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
                    Mid =Convert.ToInt32(row["mid"]),
                    MName=row["mname"].ToString(),
                    MPwd=row["mpwd"].ToString(),
                    Mtype=row["mtype"].ToString()
                });
            }
            //将集合返回
            return list;
        }
    }
}
