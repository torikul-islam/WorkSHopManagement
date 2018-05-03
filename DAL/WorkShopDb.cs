using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class WorkShopDb : DALBase
    {
       
        public bool InsertWorkShopDAL(tbl_WorkShop Wp, List<int> Ls)
        {

            SqlConnection con = new SqlConnection(conStr);
            string cmdStr = @"INSERT INTO tbl_WorkShop Values(@WorkShopTitle, @WorkShopDate, @WorkShopDuration,
                                    @WorkShopTopics, null, null, null, null); SELECT SCOPE_IDENTITY() AS Id";

            string cmdStr2 = "INSERT INTO tbl_Trainer_WorkShop_Mapping VALUES(@TrainerId, @WorkShopId, null, null, null, null)";
            con.Open();
            SqlTransaction sqlTransaction = con.BeginTransaction();

            try
            {
                //Inserting WorkShop
                SqlCommand cmd = new SqlCommand(cmdStr, con, sqlTransaction);
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkShopTopics", Wp.WorkShopTopics);
                SqlDataReader dr = cmd.ExecuteReader();

                int WorkShopId = 0;
                if (dr.Read())
                {
                    WorkShopId = Convert.ToInt16(dr[0].ToString());
                }
                dr.Close();

                if (WorkShopId != 0)
                {
                    foreach (var TrainerId in Ls)
                    {
                        SqlCommand cmd2 = new SqlCommand(cmdStr2, con, sqlTransaction);
                        cmd2.Parameters.AddWithValue("@TrainerId", TrainerId);
                        cmd2.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                        cmd2.ExecuteNonQuery();
                    }
                }

                sqlTransaction.Commit();
                con.Close();
                return true;
            }
            catch
            {
                sqlTransaction.Rollback();
                return false;

            }

        }

        //write a methods which returns list of workshop ...... 
        public List<tbl_WorkShop> GetWorkShops()
        {
           try
            {
                List<tbl_WorkShop> Ls;
                Ls = new List<tbl_WorkShop>();
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_WorkShop", con);
                con.Open();
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    tbl_WorkShop Wp = new tbl_WorkShop();
                    Wp.WorkShopId = Convert.ToInt16(Dr["WorkShopId"].ToString());
                    Wp.WorkShopTitle = Dr["WorkShopTitle"].ToString();
                    Wp.WorkShopDate = Convert.ToDateTime(Dr["WorkShopDate"].ToString());
                    Wp.WorkShopDuration = Dr["WorkShopDuration"].ToString();
                    Wp.WorkShopTopics = Dr["WorkShopTopics"].ToString();
                    Ls.Add(Wp);

                }
                Dr.Close();
                con.Close();
                return Ls;
            }
            catch
            {
                throw;
            }
        }

        // Update, Delete, edit WorkShop
        public tbl_WorkShop GetWorkShopById(int WorkShopId)
        {
            try
            {
                tbl_WorkShop Wp = null;
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_WorkShop WHERE WorkShopId=@WorkShopId", con);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    Wp = new tbl_WorkShop();
                    Wp.WorkShopId = Convert.ToInt16(Dr["WorkShopId"].ToString());
                    Wp.WorkShopTitle = Dr["WorkShopTitle"].ToString();
                    Wp.WorkShopDate = Convert.ToDateTime(Dr["WorkShopDate"].ToString());
                    Wp.WorkShopDuration = Dr["WorkShopDuration"].ToString();
                    Wp.WorkShopTopics = Dr["WorkShopTopics"].ToString();


                }
                Dr.Close();
                con.Close();
                return Wp;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateWorkShopById(tbl_WorkShop Wp, int WorkShopId)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string cmdStr = "UPDATE tbl_WorkShop SET WorkShopTitle=@WorkShopTitle, WorkShopDate=@WorkShopDate, WorkShopDuration=@WorkShopDuration, WorkShopTopics=@WorkShopTopics WHERE WorkShopId=@WorkShopId";
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkShopTopics", Wp.WorkShopTopics);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteWorkShopById(int WorkShopId)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string cmdStr = "DELETE FROM tbl_WorkShop WHERE WorkShopId=@WorkShopId";
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {

                foreach (var item in Ls)
                {
                    string cmdStr = "INSERT INTO tbl_Trainer_WorkShop_Mapping VALUES(@TrainerId, @WorkShopId, null, null, null, null)";
                    SqlCommand cmd = new SqlCommand(cmdStr, con, sqlTransaction);
                    cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    cmd.Parameters.AddWithValue("@WorkShopId", item.WorkShopId);
                    cmd.ExecuteNonQuery();

                }
                sqlTransaction.Commit();
                con.Close();
                return true;
            }
            catch
            {
                sqlTransaction.Rollback();
                return false;
            }
        }

        public List<WorkShopRequest> GetWorkShopRequest()
        {
            try
            {
                List<WorkShopRequest> Ls = new List<WorkShopRequest>();
                SqlConnection con = new SqlConnection(conStr);
                string cmdStr = @"SELECT tbl_User.UserId, tbl_User.UserName_Email, tbl_WorkShop.WorkShopId, tbl_WorkShop.WorkShopTitle,
                          tbl_Student_WorkShop_Mapping.IsApproved From tbl_Student_WorkShop_Mapping Left outer join tbl_User
                            ON tbl_User.UserId = tbl_Student_WorkShop_Mapping.StudentId LEFT outer JOIN tbl_WorkShop ON
                            tbl_Student_WorkShop_Mapping.WorkShopId = tbl_WorkShop.WorkShopId";

                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    WorkShopRequest WPR = new WorkShopRequest();
                    WPR.UserId = Convert.ToInt16(dr["UserId"].ToString());
                    WPR.UserName_Email = dr["UserName_Email"].ToString();
                    WPR.WorkShopId = Convert.ToInt16(dr["WorkShopId"].ToString());
                    WPR.WorkShopTitle = dr["WorkShopTitle"].ToString();
                    // WPR.IsApproved = dr["IsApproved"].ToString() == "" ? false : Convert.ToBoolean(dr["IsApproved"].ToString());
                    WPR.IsApproved = dr["IsApproved"].ToString();

                    //string Reject;
                    //if (dr["IsApproved"].ToString() != "")
                    //{
                        
                    //    WPR.IsApproved = dr["IsApproved"].ToString();
                    //}
                    //else
                    //{
                    //    WPR.IsApproved = Reject;
                    //}

                    Ls.Add(WPR);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

       public bool AppOrRejectWorkShopRequest(tbl_Student_WorkShop_Mapping SWP)
        {
            try
            {
                string cmdStr = "UPDATE tbl_Student_WorkShop_Mapping SET IsApproved = @IsApproved WHERE WorkShopId=@WorkShopId AND StudentId=@StudentId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                //cmd.Parameters.AddWithValue("IsApproved", SWP.IsApproved == true? 1:0);
                cmd.Parameters.AddWithValue("IsApproved", SWP.IsApproved.ToString());
                cmd.Parameters.AddWithValue("WorkShopId", SWP.WorkShopId);
                cmd.Parameters.AddWithValue("StudentId", SWP.StudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }




 }
        



}
        
   


