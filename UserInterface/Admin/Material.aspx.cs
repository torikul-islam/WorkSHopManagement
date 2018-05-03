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
    public partial class Material : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetWorkShop();
                    GetMaterials();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        

        public void GetWorkShop()
        {
            try
            {
                WorkShopBusiness Wb = new WorkShopBusiness();
                ddlWorkshop.DataSource = Wb.GetWorkShop();
                ddlWorkshop.DataTextField = "WorkShopTitle";
                ddlWorkshop.DataValueField = "WorkShopId";
                ddlWorkshop.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void GetMaterials()
        {
            try
            {
                MaterialBusiness MB = new MaterialBusiness();
                List<WorkShopMaterial> Ls = MB.GetMaterials();
                grdMaterial.DataSource = Ls;
                grdMaterial.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (MaterialUpload.HasFile)
            {
                try
                {
                    string path = Server.MapPath("~//Material//");
                    MaterialUpload.SaveAs(path + MaterialUpload.FileName);
                    tbl_Material M = new tbl_Material();
                    M.WorkShopId = int.Parse(ddlWorkshop.SelectedValue);
                    M.MaterialPath = "~//Material//" + MaterialUpload.FileName;
                    MaterialBusiness MB = new MaterialBusiness();
                    MB.CreateMaterial(M);
                    GetMaterials();
                    Response.Write("<script> alert('Uploaded Material Successfully.'); </script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}