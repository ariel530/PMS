using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class TeamInfoOverviewDAL
    {
        private TeamInfoMemberDetailDAL teamInfoMemberDetailDAL;
        public TeamInfoOverviewDAL()
        {
            teamInfoMemberDetailDAL = new TeamInfoMemberDetailDAL();
        }
        public string[] InsertTeamInfoData(TeamInfoOverview teamInfoOverview, List<TeamInfoMemberDetail> teamInfoMemberDetailsRecord)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            SqlTransaction sqlTransaction = null;
            try
            {
                DateTime dateTime = DateTime.Now;
                con.Open();
                sqlTransaction = con.BeginTransaction();
              int teamId=  AddTeamInfoOverviewData(teamInfoOverview, dateTime, con, sqlTransaction);
                teamInfoMemberDetailDAL.AddTeamInfoMemberDetail(teamInfoMemberDetailsRecord, teamId,dateTime, con, sqlTransaction);
                sqlTransaction.Commit();
                result[0] = "Team  with name " + teamInfoOverview.TeamName + " created successfully.";
                result[1] = "success";
                result[2] = "Created Successfully !";

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion !";

            }
            finally
            {
                con.Close();
            }

            return result;

        }
        public int AddTeamInfoOverviewData(TeamInfoOverview teamInfoOverview, DateTime addedDateTime, SqlConnection con, SqlTransaction sqlTransaction)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TeamInfoDetail_Insertion";
            cmd.Parameters.Add("@TeamName", SqlDbType.NVarChar).Value = teamInfoOverview.TeamName;
            cmd.Parameters.Add("@TeamDescription", SqlDbType.NVarChar).Value = teamInfoOverview.TeamDescription;
            cmd.Parameters.Add("@TeamTotalMember", SqlDbType.Int).Value = teamInfoOverview.TeamTotalMember;
            cmd.Parameters.Add("@AddedOn", SqlDbType.DateTime).Value = addedDateTime;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = teamInfoOverview.AddedBy;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = teamInfoOverview.CompanyId;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Connection = con;
            cmd.Transaction = sqlTransaction;
            int effectedRows = cmd.ExecuteNonQuery();
            int teamId = int.Parse(cmd.Parameters["@Id"].Value.ToString());
            return teamId;
        }
        public List<TeamInfoOverview_UserImageId_ForDisplay> GetTeamInfoOverviewData(int companyId)
        {
           
            List<TeamInfoOverview_UserImageId_ForDisplay> teamInfoData = new List<TeamInfoOverview_UserImageId_ForDisplay>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "SELECT "
  + "  TeamInfoOverview.Id , TeamInfoOverview.TeamName,TeamInfoOverview.TeamDescription,TeamInfoOverview.TeamTotalMember , TeamInfoOverview.TeamIsActivated,  "
  + "  TeamInfoOverview.AddedBy,TeamInfoOverview.AddedOn, TeamInfoOverview.LastModifiedBy, TeamInfoOverview.LastModifiedOn,   "
  + "  STUFF((SELECT '; ' + UserInfo.ImagePath + ':' + UserInfo.UserName "
          + "  FROM UserInfo, TeamInfoMemberDetail "
         + "   WHERE UserInfo.UserName = TeamInfoMemberDetail.TeamMemberId "
         + "   and TeamInfoMemberDetail.TeamId = TeamInfoOverview.Id "
         + "   and TeamInfoMemberDetail.CompanyId = @CompanyId "
         + "   FOR XML PATH('')), 1, 1, '')  [TeamMemberImages] "
          + "        FROM TeamInfoOverview "
           + "  Where TeamInfoOverview.IsDeleted=0  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    teamInfoData.Add(new TeamInfoOverview_UserImageId_ForDisplay(int.Parse(dr["Id"].ToString()), dr["TeamName"].ToString()
                        , dr["TeamDescription"].ToString(), int.Parse(dr["TeamTotalMember"].ToString())
                        , bool.Parse(dr["TeamIsActivated"].ToString()), dr["TeamMemberImages"].ToString()
                        , dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamInfoData;

        }
        public TeamMemberOverview_Detail_ForViewUpdate GetTeamCompleteDetailById(int teamId)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "TeamInfoOverview";
            TeamMemberOverview_Detail_ForViewUpdate teamInfoDetail = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,TeamName, TeamDescription from " + tableName + " where Id=@Id and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", teamId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    teamInfoDetail = new TeamMemberOverview_Detail_ForViewUpdate(int.Parse(dr["Id"].ToString()), dr["TeamName"].ToString(), dr["TeamDescription"].ToString());                  
                }
                teamInfoDetail.TeamMemberDetails= teamInfoMemberDetailDAL.GetTeamInfoOverviewData(teamId);
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamInfoDetail;

        }

        public string[] DeleteTeamInfoData(int teamId, string deletedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            SqlTransaction sqlTransaction = null;
            try
            {
                DateTime dateTime = DateTime.Now;
                con.Open();
                sqlTransaction = con.BeginTransaction();
                 DeleteTeamInfoOverViewData(teamId,deletedBy, dateTime, con, sqlTransaction);
                teamInfoMemberDetailDAL.DeleteTeamInfoMemberDetailData(teamId,deletedBy, dateTime, con, sqlTransaction);
                sqlTransaction.Commit();
                result[0] = "Team  with id " + teamId + " created successfully.";
                result[1] = "success";
                result[2] = "Created Successfully !";

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion !";

            }
            finally
            {
                con.Close();
            }

            return result;

        }

        public void DeleteTeamInfoOverViewData(int teamId, string deletedBy, DateTime deletedDateTime, SqlConnection con, SqlTransaction sqlTransaction)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "TeamInfoOverview";
          
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con, sqlTransaction);
            SqlParameter p1 = new SqlParameter("Id", teamId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", deletedDateTime);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                int effectedRows = cmd.ExecuteNonQuery();
              

        }



        public string[] UpdateStaffDesignationData(string staffDesignationName, string staffDesignationDescription, int staffDesignationRank, int id, string modifiedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set StaffDesignationName =@StaffDesignationName,StaffDesignationDescription =@StaffDesignationDescription ,StaffDesignationRank=@StaffDesignationRank     ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("StaffDesignationDescription", staffDesignationDescription);
                SqlParameter p3 = new SqlParameter("StaffDesignationName", staffDesignationName);
                SqlParameter p4 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p5 = new SqlParameter("lastModifiedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("StaffDesignationRank", staffDesignationRank);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "StaffDesignation " + staffDesignationName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffDesignation " + staffDesignationName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public StaffDesignation GetStaffDesignationDataByStaffDesignationCode(int userTypeId, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            StaffDesignation staffDesignation = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@Id and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", userTypeId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    staffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
             int.Parse(dr["StaffDesignationRank"].ToString()), dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDown(string userName)
        {
            //  string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;
        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDown(int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;
        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDownAllIncludedDeleted(int companyId)
        {
            //string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataList(string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
                int.Parse(dr["StaffDesignationRank"].ToString()), dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataList(int companyId)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
                  int.Parse(dr["StaffDesignationRank"].ToString()), dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }


        public Tuple<int, string> GetStaffDesignationInfoByStaffId(string staffId, int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            Tuple<int, string> staffList = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = " select StaffDesignation.Id,  StaffDesignation.StaffDesignationName"
 + " from StaffDesignation , StaffDetail "

   + "  where StaffDetail.IsDeleted = 0  "
 + "    and  StaffDetail.StaffInfoId =@StaffId "
 + "    and StaffDetail.StaffDesignationId = StaffDesignation.Id "
+ "and StaffDetail.CompanyId = @CompanyId  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                SqlParameter p2 = new SqlParameter("StaffId", staffId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    staffList = (new Tuple<int, string>(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString()));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffList;
        }



    }
}