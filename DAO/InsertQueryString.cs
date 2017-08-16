using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace GCSEMatrix.DAO
{
    public class InsertQueryString
    {
        public string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;

        public void InsertLearnerResults(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, string Created_By)
        {
            QueryStrings insertResults = new QueryStrings();

            string query = insertResults.InsertLearnerResults(Person_Code, Student_Name, ULI_Number, UCI_Number, Grade_Name, Subject_Code, Subject_Name, Results_Status, Created_By);

            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateLearnerResults(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, string Updated_By)
        {
            QueryStrings UpdateResults = new QueryStrings();

            string query = UpdateResults.UpdateLearnerResults(Person_Code, Student_Name, ULI_Number, UCI_Number, Grade_Name, Subject_Code, Subject_Name, Results_Status, Updated_By);

            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteLearnerResults(Int32 Person_Code)
        {
            QueryStrings delete = new QueryStrings();
            string query = delete.DeleteLearnerResults(Person_Code);
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();           
        }

    }
}