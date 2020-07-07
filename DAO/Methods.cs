using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace GCSEMatrix.DAO
{
    public class Methods
    {
        public string conString = ConfigurationManager.ConnectionStrings["ebsliveRWConnectionString"].ConnectionString;

        public void InsertLearnerResults(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, DateTime Created_Date, string Created_By)
        {
            QueryStrings insertResults = new QueryStrings();

            string query = insertResults.InsertLearnerResults();

            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(":Person_Code", Person_Code);
            cmd.Parameters.Add(":Student_Name", Student_Name);
            cmd.Parameters.Add(":ULI_Number", ULI_Number);
            cmd.Parameters.Add(":UCI_Number", UCI_Number);
            cmd.Parameters.Add(":Grade_Name", Grade_Name);
            cmd.Parameters.Add(":Subject_Code", Subject_Code);
            cmd.Parameters.Add(":Subject_Name", Subject_Name);
            cmd.Parameters.Add(":Results_Status", Results_Status);
            cmd.Parameters.Add(":Created_Date", Created_Date);
            cmd.Parameters.Add(":Created_By", Created_By);

            cmd.Connection = con;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void InsertNoResults(Int32 Person_Code, DateTime Created_Date, string Created_By)
        {
            QueryStrings insertResults = new QueryStrings();

            string query = insertResults.InsertNoResults();

            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(":Person_Code", Person_Code);
            cmd.Parameters.Add(":Created_Date", Created_Date);
            cmd.Parameters.Add(":Created_By", Created_By);

            cmd.Connection = con;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        public void UpdateLearnerResults(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, DateTime Updated_Date, string Updated_By)
        {
            QueryStrings UpdateResults = new QueryStrings();

            string query = UpdateResults.UpdateLearnerResults(Person_Code);

            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Parameters.Add(":Person_Code", Person_Code);
            cmd.Parameters.Add(":Student_Name", Student_Name);
            cmd.Parameters.Add(":ULI_Number", ULI_Number);
            cmd.Parameters.Add(":UCI_Number", UCI_Number);
            cmd.Parameters.Add(":Grade_Name", Grade_Name);
            cmd.Parameters.Add(":Subject_Code", Subject_Code);
            cmd.Parameters.Add(":Subject_Name", Subject_Name);
            cmd.Parameters.Add(":Results_Status", Results_Status);
            cmd.Parameters.Add(":Updated_Date", Updated_Date);
            cmd.Parameters.Add(":Updated_By", Updated_By);
            cmd.Connection = con;
            using (con) { 
            con.Open();
            cmd.ExecuteNonQuery();
            }
        }
        public void DeleteLearnerResults(Int32 person_code)
        {
            QueryStrings delete = new QueryStrings();
            string query = delete.DeleteLearnerResults();
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Parameters.Add(":PERSON_CODE", person_code);
            cmd.Connection = con;
            using (con) { 
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
        }

    }
}