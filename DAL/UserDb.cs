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
    public class UserDb : DALBase
    {
        public List<tbl_User> GetTrainers()
        {
            try
            {
                List<tbl_User> Ls = new List<tbl_User>();
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(@"Select tbl_User.UserId, tbl_User.FirstName, tbl_User.LastName FROM tbl_User 
                                                INNER JOIN
                                            tbl_Role ON tbl_User.RoleId = tbl_Role.RoleId
                                            WHERE (tbl_Role.RoleName = 'Trainer')", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tbl_User Tr = new tbl_User();
                    Tr.UserId = Convert.ToInt16(dr["UserId"].ToString());
                    Tr.FirstName = dr["FirstName"].ToString();
                    Tr.LastName = dr["LastName"].ToString();
                    Ls.Add(Tr);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch
            {
                throw;
            }

        }

        public bool CreateUserRequest(tbl_User U, int WorkShopId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction sqlTransaction = con.BeginTransaction();
            string cmdStr = "INSERT INTO tbl_User (UserName_Email, RoleId) values(@UserName_Email, 2); SELECT SCOPE_IDENTITY() As Id ";
            string smdStr2 = "INSERT INTO tbl_Student_WorkShop_Mapping values (@StudentId, @WorkShopId, null)";

            try
            {
                //Inserting Workshop
                SqlCommand cmd = new SqlCommand(cmdStr, con, sqlTransaction);
                cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
                SqlDataReader dr = cmd.ExecuteReader();

                // Reading StudentId Returned from Scope_identity
                int StudentId = 0;
                if (dr.Read())
                {
                    StudentId = Convert.ToInt16(dr[0].ToString());
                }
                dr.Close();

                // Inserting Record in tbl_Student_WorkShop_Mapping
                // With Retrived StudentId From Scope_identity

                SqlCommand cmd2 = new SqlCommand(smdStr2, con, sqlTransaction);
                cmd2.Parameters.AddWithValue("@StudentId", StudentId);
                cmd2.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                cmd2.ExecuteNonQuery();

                // If Every Thing is Successful then Commiting the Transaction
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

        public bool ValidateUser(tbl_User U)
        {
           try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_User WHERE (UserName_Email =@UserName_Email AND Password=@Password)", con);
                cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
                cmd.Parameters.AddWithValue("@Password", U.Password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    U.UserId = Convert.ToInt16(dr["UserId"].ToString());
                    U.UserName_Email = dr["UserName_Email"].ToString();
                    U.Password = dr["Password"].ToString();
                    U.RoleId = Convert.ToInt16(dr["RoleId"].ToString());
                }
                dr.Close();
                con.Close();
                if (U.UserId != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CreateTrainer(tbl_User U)
        {
            SqlConnection con = new SqlConnection(conStr);

           // try
           // {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_User (UserName_Email, FirstName, LastName, RoleId) values (@UserName_Email, @FirstName, @LastName , @RoleId)", con);
                cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
                cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
                cmd.Parameters.AddWithValue("@LastName", U.LastName);
                cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
                 
            //}
            //catch
            //{

            //    return false;
            //}


        }

    }
}
