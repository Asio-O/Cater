using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public partial class ManagerInfoBll
    {
        public List<ManagerInfo> GetList()
        {
            //创建数据层对象
            ManagerInfoDal miDal = new ManagerInfoDal();
            //调用查询方法
            return miDal.GetList();
        }
    }
}
