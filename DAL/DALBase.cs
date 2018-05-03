using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DALBase
    {
        protected string conStr;
        public DALBase()
        {
           try
            {
                conStr = ConfigurationManager.ConnectionStrings["WorkShopCON"].ToString();
            }
            catch
            {
                throw;
            }
            
        }
    }
}
