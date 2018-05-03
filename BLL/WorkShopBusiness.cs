using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class WorkShopBusiness
    {
        public bool InsertWorkShop(tbl_WorkShop Wp, List<int> Ls)
        {
            try
            {
                if (Wp.WorkShopDate > DateTime.Now)
                {
                    WorkShopDb Wd = new WorkShopDb();
                    return Wd.InsertWorkShopDAL(Wp, Ls);

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public List<tbl_WorkShop> GetWorkShop()
        {
            try
            {
                WorkShopDb Wd = new WorkShopDb();
                return Wd.GetWorkShops();
            }
            catch
            {
                throw;
            }
        }
        public tbl_WorkShop GetWorkShopById(int WorkShopId)
        {
           try
            {
                WorkShopDb Wd = new WorkShopDb();
                tbl_WorkShop Wp = Wd.GetWorkShopById(WorkShopId);
                return Wp;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateWorkShopById(tbl_WorkShop Wp, int WorkShopId)
        {
            try
            {
                WorkShopDb Wd = new WorkShopDb();
                if (Wp.WorkShopDate > DateTime.Now)
                {

                    Wd.UpdateWorkShopById(Wp, WorkShopId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteWorkShopById(int WorkShopId)
        {
            try
            {
                WorkShopDb Wd = new WorkShopDb();
                Wd.DeleteWorkShopById(WorkShopId);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
        {
            try
            {
                WorkShopDb Wd = new WorkShopDb();
                Wd.AssignTrainersToWorkShop(Ls);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<WorkShopRequest> GetWorkShopRequest()
        {
            try
            {
                WorkShopDb Wd = new WorkShopDb();
                return Wd.GetWorkShopRequest();
            }
            catch
            {
                throw;
            }
        }

        public bool AppOrRejectWorkShopRequest(tbl_Student_WorkShop_Mapping SWP)
        {
          try
            {
                WorkShopDb Wd = new WorkShopDb();
                return Wd.AppOrRejectWorkShopRequest(SWP);
            }
            catch
            {
                throw;
            }
        }




    }

}
