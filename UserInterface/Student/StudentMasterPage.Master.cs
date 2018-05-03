using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface.Student
{
    public partial class StudentMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           try
            {
                if (!IsPostBack)
                {
                    if (Session["UserID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        if (Session["RoleId"].ToString() != "2")
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                        else
                        {
                            lblWlcStudent.Text = "Welcome: " + Session["UserName_Email"].ToString();
                        }
                    }
                }
            }
            catch
            {
                Response.Write("Authentication Problem. Please contact Administrator!");
            }
        }

        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            catch
            {
                Response.Write("Authentication Problem. Please contact Administrator!");
            }
        }
    }
}