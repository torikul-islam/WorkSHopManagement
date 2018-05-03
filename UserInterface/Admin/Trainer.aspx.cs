using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;

namespace UserInterface.Admin
{
    public partial class Trainer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetTrainers();
            }

        }

        private void GetTrainers()
        {
           try
            {
                UserBusiness Ub = new UserBusiness();
                List<tbl_User> Ls = Ub.GetTrainers();
                grdTrainers.DataSource = Ls;
                grdTrainers.DataBind();
            }
            catch
            {
                throw;
            }
        }




        protected void grdTrainers_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txtSave_Click1(object sender, EventArgs e)
        {
            try
            {
                tbl_User U = new tbl_User();
                U.UserName_Email = txtEmail.Text;
                U.FirstName = txtTrainerFirstName.Text;
                U.LastName = txtLastName.Text;
                U.RoleId = 3;
                UserBusiness Ub = new UserBusiness();
                Ub.CreateTrainer(U);
                GetTrainers();
            }
            catch
            {
                throw;
            }
        }
    }
}