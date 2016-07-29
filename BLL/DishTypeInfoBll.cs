using Cater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
    public partial class DishTypeInfoBll
    {
        DishTitleInfoDal dtiDal;
        public DishTypeInfoBll()
        {
            dtiDal = new DishTitleInfoDal();
        }
        public List<DishTypeInfo> Getlist()
        {
            return dtiDal.Getlist();
        }

        public bool Add(DishTypeInfo dti)
        {
            return dtiDal.Insert(dti) > 0;
        }

        public bool Edit(DishTypeInfo dti)
        {
            return dtiDal.Update(dti) > 0;
        }

        public bool Remove(int id)
        {
            return dtiDal.Delete(id)>0;
        }
    }
}
