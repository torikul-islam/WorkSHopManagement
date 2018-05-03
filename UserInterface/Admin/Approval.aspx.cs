using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

namespace UserInterface.Admin
{
    public partial class Approval : System.Web.UI.Page
    {
        public string IsAppOrRej;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetWorkShopRequest();
                }
            }
            catch
            {
                //throw;
                Response.Write("Error Occured ! Please Contacts with Admin");
            }
        }

        public void GetWorkShopRequest()
        {
            try
            {
                WorkShopBusiness Wb = new WorkShopBusiness();
                List<WorkShopRequest> Ls = Wb.GetWorkShopRequest();
                grdWorkShopRequest.DataSource = Ls;
                grdWorkShopRequest.DataBind();
            }
            catch
            {
                throw;
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int Sid = Convert.ToInt16(grdWorkShopRequest.DataKeys[grdWorkShopRequest.SelectedIndex].Values["UserId"].ToString());
                int Wid = Convert.ToInt16(grdWorkShopRequest.DataKeys[grdWorkShopRequest.SelectedIndex].Values["WorkShopId"].ToString());
                // bool IsAppOrRej = bool.Parse(rblApproveReject.SelectedValue.ToString());

                
                if (rblApproveReject.SelectedValue !=null)
                {
                    IsAppOrRej = rblApproveReject.SelectedItem.Text; 
                }

                tbl_Student_WorkShop_Mapping SWP = new tbl_Student_WorkShop_Mapping();
                SWP.StudentId = Sid;
                SWP.WorkShopId = Wid;
                SWP.IsApproved = IsAppOrRej;
                WorkShopBusiness Wb = new WorkShopBusiness();
                Wb.AppOrRejectWorkShopRequest(SWP);
                Response.Write("<script> alert('Submit Successfully!'); </script>");
                GetWorkShopRequest();
            }
            catch
            {
                Response.Write("Oops! Error: Please contact With Admin 00-00-0000");
            }
        }

        protected void rblApproveReject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}