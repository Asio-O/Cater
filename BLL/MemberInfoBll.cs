using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public partial class MemberInfoBll
    {
        MemberInfoDal miDll;
        public MemberInfoBll()
        {
            miDll = new MemberInfoDal();
        }
        public List<MemberInfo> GetList(Dictionary<string,string> dic)
        {
            return miDll.GetList(dic);
        }

        public bool Add(MemberInfo mi)
        {
            return miDll.Insert(mi)>0;
        }
    }
}
