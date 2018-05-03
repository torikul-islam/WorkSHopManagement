using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
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
                        if (Session["RoleId"].ToString() != "1")
                        {
                            Response.Redirect("~/Default.aspx");
                            
                        }
                        else
                        {
                            lblWlcAdmin.Text = "Welcome: " + Session["UserName_Email"].ToString();
                        }
                    }
                }
            }
            catch
            {
                Response.Write("Authentication Problem. Please contact Administrator!");
            }
        }

        protected void lnkbtnLogout_Click(object sender, EventArgs e)
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