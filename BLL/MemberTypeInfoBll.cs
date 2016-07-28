using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    class MemberTypeInfoBll
    {
        //定义数据对象，用于调用进行数据操作的方法
        private MemberTypeInfoDal mtiDal;

        public MemberTypeInfoBll()
        {
            mtiDal = new MemberTypeInfoDal();
        }

        public List<MemberTypeInfo> GetList()
        {
            return mtiDal.GetList();
        }

    }
}
