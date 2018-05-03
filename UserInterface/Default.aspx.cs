using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;


namespace UserInterface
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            tbl_User U = new tbl_User();
            U.UserName_Email = txtUserName.Text;
            U.Password = txtPassword.Text;

            UserBusiness Ub = new UserBusiness();
            bool flag = Ub.ValidateUser(U);
            if(flag == true)
            {
                Session.Add("UserId", U.UserId);
                Session.Add("UserName_Email", U.UserName_Email);
                Session.Add("RoleId", U.RoleId);

                if (U.RoleId == 1)
                {
                    Response.Redirect("Admin/Home.aspx");
                }

                else if (U.RoleId == 2)
                {
                    Response.Redirect("Student/Home.aspx");
                }
                else if (U.RoleId == 3)
                {
                    Response.Write("<script> alert('User Not valid!'); </script>");
                }

            }
            else
            {
                Response.Write("<script> alert('UserName or Password not Valid'); </script>");
            }
        }
    }
}