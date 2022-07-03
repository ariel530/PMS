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
    public class TeamInfoMemberDetailDAL
    {
        public void AddTeamInfoMemberDetail(List<TeamInfoMemberDetail> teamInfoMemberDetailRecord, int teamId, DateTime addedDateTimed, SqlConnection con, SqlTransaction sqlTransaction)
        {
            //string tableName="CI_" + userName + "_StaffInfo";
            string tableName = "TeamInfoMemberDetail";
            foreach (TeamInfoMemberDetail teamInfoMemberDetail in teamInfoMemberDetailRecord)
            {
                string qry = "insert into " + tableName + " (TeamMemberId,TeamMemberDesignationId," +
                    "TeamMemberDesignationType, TeamId,  AddedBy,AddedOn,CompanyId) values(@TeamMemberId,@TeamMemberDesignationId," +
                    "@TeamMemberDesignationType, @TeamId,  @AddedBy,@AddedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con, sqlTransaction);
                SqlParameter p1 = new SqlParameter("TeamMemberId", teamInfoMemberDetail.TeamMemberId);
                SqlParameter p2 = new SqlParameter("TeamMemberDesignationId", teamInfoMemberDetail.TeamMemberDesignationId);
                SqlParameter p3 = new SqlParameter("TeamMemberDesignationType", teamInfoMemberDetail.TeamMemberDesignationType);
                SqlParameter p4 = new SqlParameter("AddedBy", teamInfoMemberDetail.AddedBy);
                SqlParameter p5 = new SqlParameter("AddedOn", addedDateTimed);
                SqlParameter p6 = new SqlParameter("CompanyId", teamInfoMemberDetail.CompanyId);
                SqlParameter p7 = new SqlParameter("TeamId", teamId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);

                int effectedRows = cmd.ExecuteNonQuery();

            }
        }

        public List<TeamMemberDetail_ForViewUpdate> GetTeamInfoOverviewData(int teamId)
        {

            List<TeamMemberDetail_ForViewUpdate> teamInfoData = new List<TeamMemberDetail_ForViewUpdate>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = " SELECT distinct  UserInfo.UserName as 'TeamMemberUserName', UserInfo.FirstName + ' '+ UserInfo.LastName as 'TeamMemberFullName'  "
                           + "    , UserInfo.ImagePath as 'TeamMemberImagePath',  TeamInfoMemberDetail.TeamMemberDesignationType as  'TeamMemberDesignationType',  "
                           + "       TeamInfoMemberDetail.AddedOn,TeamInfoMemberDetail.AddedBy,StaffCategory.StaffCategoryName as 'TeamMemberCategoryName',  "
                           + "       TeamInfoMemberDetail.TeamMemberDesignationId as 'TeamMemberDesignationId' , StaffCategory.Id as 'TeamMemberCategoryId',  "
 + "       TeamInfoMemberDetail.Id,  "
 + "       TeamInfoMemberDetail.LastModifiedBy,TeamInfoMemberDetail.LastModifiedOn,  "
 + "       CASE  "
 + "       WHEN TeamInfoMemberDetail.TeamMemberDesignationType = 'ACTUAL'  "
 + "        THEN StaffDesignation.StaffDesignationName  "
 + "       ELSE TeamWiseStaffDesignation.TeamWiseStaffDesignationName  "
+ "    END as 'TeamMemberDesignationName'  "
+ "    FROM UserInfo, TeamInfoMemberDetail, StaffDesignation, TeamWiseStaffDesignation, StaffCategory, StaffDetail  "
+ "    where  "
+ "    UserInfo.UserName = TeamInfoMemberDetail.TeamMemberId  "
+ "    and( "
+ "        TeamInfoMemberDetail.TeamMemberDesignationId =case  "
 + "       WHEN TeamInfoMemberDetail.TeamMemberDesignationType = 'ACTUAL'  "
 + "        THEN  StaffDesignation.Id  "
    + "     ELSE TeamWiseStaffDesignation.Id  "
+ "    END  "
+ "    )  "
+ "    and StaffCategory.Id = StaffDetail.StaffCategoryId  "
+ "    and StaffDetail.StaffInfoId = TeamInfoMemberDetail.TeamMemberId  "
+ "    and TeamInfoMemberDetail.TeamId =@TeamId   ";


                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("TeamId", teamId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    teamInfoData.Add(new TeamMemberDetail_ForViewUpdate(int.Parse(dr["Id"].ToString()), dr["TeamMemberUserName"].ToString()
                        , dr["TeamMemberFullName"].ToString(), dr["TeamMemberImagePath"].ToString(), int.Parse(dr["TeamMemberDesignationId"].ToString()),dr["TeamMemberDesignationName"].ToString()
                      , dr["TeamMemberDesignationType"].ToString(), int.Parse(dr["TeamMemberCategoryId"].ToString())
                      , dr["TeamMemberCategoryName"].ToString()
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

        public void DeleteTeamInfoMemberDetailData(int teamId, string deletedBy, DateTime deletedDateTime, SqlConnection con, SqlTransaction sqlTransaction)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "TeamInfoMemberDetail";

            string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where teamId=@Id";
            SqlCommand cmd = new SqlCommand(qry, con, sqlTransaction);
            SqlParameter p1 = new SqlParameter("Id", teamId);
            SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
            SqlParameter p3 = new SqlParameter("deletedOn", deletedDateTime);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            int effectedRows = cmd.ExecuteNonQuery();


        }


    }
}