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
    public partial class WorkShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetWorkShopInUI();
                    GetTrainers();
                }
            }
            catch
            {
                throw;
            }

        }
        public void GetTrainers()
        {
           try
            {
                UserBusiness Ub = new UserBusiness();
                List<tbl_User> Ls = Ub.GetTrainers();
                ckbLTrainer.DataSource = Ls;
                ckbLTrainer.DataTextField = "FirstName";
                ckbLTrainer.DataValueField = "UserId";
                ckbLTrainer.DataBind();
            }
            catch
            {
                throw;
            }
        }
        public void GetWorkShopInUI()
        {
            try
            {
                WorkShopBusiness Wb = new WorkShopBusiness();
                List<tbl_WorkShop> Ls = Wb.GetWorkShop();
                GridView1.DataSource = Ls;
                GridView1.DataBind();
            }
            catch
            {
                throw;
            }

        }
        protected void btnCreateWs_Click(object sender, EventArgs e)
        {
           try
            {
                tbl_WorkShop Wp = new tbl_WorkShop();
                Wp.WorkShopTitle = txtWorkShopTitle.Text;
                Wp.WorkShopDate = DateTime.ParseExact(txtWorkShopDate.Text, "dd/MM/yyyy", null);
                Wp.WorkShopDuration = txtWorkShopDuration.Text;
                Wp.WorkShopTopics = txtWorkShopTopics.Text;

                List<int> Ls = new List<int>();
                foreach (ListItem item in ckbLTrainer.Items)
                {
                    int TrainerId;
                    if (item.Selected)
                    {
                        TrainerId = Convert.ToInt16(item.Value);
                        Ls.Add(TrainerId);
                    }
                }

                WorkShopBusiness Wb = new WorkShopBusiness();
                Wb.InsertWorkShop(Wp, Ls);
                GetWorkShopInUI();
                ckbLTrainer.ClearSelection();
                txtWorkShopTitle.Text = txtWorkShopDate.Text = txtWorkShopDuration.Text = txtWorkShopTopics.Text = string.Empty;
                Response.Write("<script> alert('WorkShop Created Successfully!'); </script>");

            }
            catch
            {
                throw;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(GridView1.SelectedValue.ToString());
                WorkShopBusiness Wb = new WorkShopBusiness();
                tbl_WorkShop Wp = Wb.GetWorkShopById(id);
                txtWorkShopTitle.Text = Wp.WorkShopTitle;
                txtWorkShopDate.Text = Wp.WorkShopDate.ToString("dd/MM/yyyy");
                txtWorkShopDuration.Text = Wp.WorkShopDuration;
                txtWorkShopTopics.Text = Wp.WorkShopTopics;
            }
            catch
            {
                throw;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_WorkShop Wp = new tbl_WorkShop();
                Wp.WorkShopTitle = txtWorkShopTitle.Text;
                Wp.WorkShopDate = DateTime.ParseExact(txtWorkShopDate.Text, "dd/MM/yyyy", null);
                Wp.WorkShopDuration = txtWorkShopDuration.Text;
                Wp.WorkShopTopics = txtWorkShopTopics.Text;

                WorkShopBusiness Wb = new WorkShopBusiness();
                int Id = Convert.ToInt16(GridView1.SelectedValue.ToString());
                Wb.UpdateWorkShopById(Wp, Id);
                GetWorkShopInUI();
                txtWorkShopTitle.Text = txtWorkShopDate.Text = txtWorkShopDuration.Text = txtWorkShopTopics.Text = string.Empty;

                Response.Write("<script> alert('Successfully Update Information'); </script>");
            }
            catch
            {
                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           try
            {
                WorkShopBusiness Wb = new WorkShopBusiness();
                int Id = Convert.ToInt16(GridView1.SelectedValue.ToString());
                Wb.DeleteWorkShopById(Id);
                GetWorkShopInUI();
                txtWorkShopTitle.Text = txtWorkShopDate.Text = txtWorkShopDuration.Text = txtWorkShopTopics.Text = string.Empty;
                Response.Write("<script> alert('Successfully Delete Information'); </script>");
            }
            catch
            {
                throw;
            }
        }

        protected void btnAssaignTrainer_Click(object sender, EventArgs e)
        {
           try
            {
                List<tbl_Trainer_WorkShop_Mapping> Ls = new List<tbl_Trainer_WorkShop_Mapping>();
                int WorkShopId = Convert.ToInt16(GridView1.SelectedValue.ToString());

                foreach (ListItem item in ckbLTrainer.Items)
                {
                    if (item.Selected)
                    {
                        int TrainerId = Convert.ToInt16(item.Value);
                        tbl_Trainer_WorkShop_Mapping TWM = new tbl_Trainer_WorkShop_Mapping();
                        TWM.WorkShopId = WorkShopId;
                        TWM.TrainerId = TrainerId;
                        Ls.Add(TWM);
                    }
                }
                if (Ls.Count > 0)
                {
                    WorkShopBusiness Wb = new WorkShopBusiness();
                    Wb.AssignTrainersToWorkShop(Ls);
                    Response.Write("<script> alert('Trainer Assign Successfully'); </script>");
                }
            }
            catch
            {
                throw;
            }
          
        }
    }
}