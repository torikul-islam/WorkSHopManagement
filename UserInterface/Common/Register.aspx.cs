using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

namespace UserInterface.Common
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitWorkShop_Click(object sender, EventArgs e)
        {
            int WorkShopId = Convert.ToInt16(HttpContext.Current.Request.QueryString["WorkShopId"].ToString());
            string email = txtEmail.Text;
            tbl_User U = new tbl_User();       /* Other Way { UserName_Email = email}*/
            U.UserName_Email = email;
            UserBusiness Ub = new UserBusiness();
            Ub.CreateUserRequest(U, WorkShopId);
        }
    }
}