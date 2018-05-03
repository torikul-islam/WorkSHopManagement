using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;


namespace UserInterface.Student
{
    public partial class Material : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMaterials();
            }
        }

        public void GetMaterials()
        {
            MaterialBusiness Mt = new MaterialBusiness();
            grdMaterial.DataSource = Mt.GetMaterials();
            grdMaterial.DataBind();
        }
    }
}