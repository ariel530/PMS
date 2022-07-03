using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.IO;

namespace PMS.DAL
{
    [Authorize]
    public class CountryDAL
    {

        public string[] InsertCountryData(string countryCode, string CountryName, string addedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into Country (CountryCode,CountryName,AddedBy,AddedOn) values(@countryCode,@countryName,@addedBy,@addedOn)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("countryCode", countryCode);
                SqlParameter p2 = new SqlParameter("countryName", CountryName);
                SqlParameter p3 = new SqlParameter("addedBy", addedBy);
                SqlParameter p4 = new SqlParameter("addedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Country " + CountryName + " with code " + countryCode + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Country " + CountryName + " with code " + countryCode + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateCountryData(string countryCode, string CountryName, string modifiedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update Country Set CountryName =@countryName ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where CountryCode=@CountryCode";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("countryCode", countryCode);
                SqlParameter p2 = new SqlParameter("countryName", CountryName);
                SqlParameter p3 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p4 = new SqlParameter("lastModifiedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Country " + CountryName + " with code " + countryCode + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Country " + CountryName + " with code " + countryCode + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteCountryData(string countryCode, string deletedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update Country Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where CountryCode=@CountryCode";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("countryCode", countryCode);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Country with code " + countryCode + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Country  with code " + countryCode + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public Country GetCountryDataByCountryCode(string countryCode)
        {
            Country country = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from Country where CountryCode=@countryCode and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("countryCode", countryCode);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    country = new Country(dr["CountryCode"].ToString(), dr["CountryName"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return country;

        }
        public List<Country> GetCountryDataList()
        {
            List<Country> country = new List<Country>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from Country where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    Country tempCountry = new Country(dr["CountryCode"].ToString(), dr["CountryName"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    country.Add(tempCountry);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return country;

        }
        public List<Country> GetCountryDataListForDropDown()
        {
            List<Country> country = new List<Country>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select CountryCode,CountryName from Country where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Country tempCountry = new Country(dr["CountryCode"].ToString(), dr["CountryName"].ToString());
                    country.Add(tempCountry);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return country;

        }
        public List<Country> GetCountryDataListForDropDownAllIncludedDeleted()
        {
            List<Country> country = new List<Country>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select CountryCode,CountryName from Country ";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Country tempCountry = new Country(dr["CountryCode"].ToString(), dr["CountryName"].ToString());
                    country.Add(tempCountry);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return country;

        }
        public void AddAllCountriesToDatabase(string userName)
        {
            using (var reader = new StreamReader(@"C:\Users\SSC\Downloads\Compressed\country-list_zip\data\CountriesList.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("\""))
                    {

                        var name = line.Substring(0, line.LastIndexOf("\"")).Replace("\"", "");

                        var code = line.Substring(line.LastIndexOf("\"") + 2);
                        InsertCountryData(code, name, userName);
                    }
                    else
                    {
                        var values = line.Split(',');
                        InsertCountryData(values[1], values[0], userName);
                    }


                }
            }
        }


    }
}

