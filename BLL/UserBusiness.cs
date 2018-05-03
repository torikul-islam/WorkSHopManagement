using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class UserBusiness
    {
        public List<tbl_User> GetTrainers()
        {
           try
            {
                UserDb Ud = new UserDb();
                List<tbl_User> Ls = Ud.GetTrainers();
                return Ls;
            }
            catch
            {
                throw;
            }
        }

        

        public bool CreateUserRequest(tbl_User U, int workShopId)
        {
            try
            {
                UserDb Ud = new UserDb();
                Ud.CreateUserRequest(U, workShopId);
                return true;
            }
            catch
            {
                throw;
            }

        }

        public bool ValidateUser(tbl_User U)
        {
            try
            {
                UserDb Ud = new UserDb();
                return Ud.ValidateUser(U);
            }
            catch
            {
                throw;
            }
        }

        public bool CreateTrainer(tbl_User U)
        {
            UserDb UD = new UserDb();
            return UD.CreateTrainer(U);
        }
    }

    
}
