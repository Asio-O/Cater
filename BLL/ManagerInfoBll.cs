using Common;
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
        //创建数据层对象
        ManagerInfoDal miDal = new ManagerInfoDal();

        public List<ManagerInfo> GetList()
        {
            //调用查询方法
            return miDal.GetList();
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="mi">ManagerInfo对象</param>
        /// <returns>布尔值，操作是否成功</returns>
        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }

        public bool Remove(int id)
        {
            return miDal.Delete(id) > 0;
        }

        public ManagerInfo GetById(int id)
        {
            return miDal.GetById(id);
        }

        public LoginState Login(string name, string pwd, out int type)
        {
            //根据用户名进行对象的查询
            ManagerInfo mi = miDal.GetByName(name);

            //设置type默认值，如果为此值时，不会使用
            type = -1;
            if (mi == null)
            {
                //用户名错误
                return LoginState.NameError;
            }
            else
            {
                //用户名正确
                if (mi.MPwd.Equals(Md5Helper.EncryptString(pwd)))
                {
                    //密码正确登陆成功
                    type = mi.Mtype;
                    return LoginState.Ok;
                }
                else
                {
                    //密码错误
                    return LoginState.PwdError;
                }
            }
        }
    }
}
