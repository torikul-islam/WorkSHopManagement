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
    public partial class WorkShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetWorkShopInUI();
            }
        }
        private void GetWorkShopInUI()
        {
            WorkShopBusiness Wb = new WorkShopBusiness();
            List<tbl_WorkShop> Ls= Wb.GetWorkShop();
            GridView1.DataSource = Ls;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int WorkShopId = Convert.ToInt16(GridView1.SelectedValue.ToString());
            Response.Redirect("Register.aspx?WorkShopId=" + WorkShopId);
        }
    }
}