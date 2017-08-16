using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace GCSEMatrix.DAO
{
    public class Methods
    {
        string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;

        public void UpdateLearnerResulsts(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, DateTime Updated_Date, string Updated_By)
        {
            InsertQueryString UpdateResults = new InsertQueryString();

            string Query = UpdateResults.UpdateLearnerResults();

            DataTable dt = new DataTable();

            OracleConnection con = default(OracleConnection);

            con = new OracleConnection(conString);

            using (con)
            {
                Updated_Date = DateTime.Now;

                OracleCommand cmd = con.CreateCommand();

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue(":PERSON_CODE", Person_Code);
                cmd.Parameters.AddWithValue(":STUDENT_NAME", Student_Name);
                cmd.Parameters.AddWithValue(":ULI_NUMBER", ULI_Number);
                cmd.Parameters.AddWithValue(":UCI_NUMBER", UCI_Number);
                cmd.Parameters.AddWithValue(":GRADE_NAME", Grade_Name);
                cmd.Parameters.AddWithValue(":SUBJECT_CODE", Subject_Code);
                cmd.Parameters.AddWithValue(":RESULTS_STATUS", Results_Status);
                cmd.Parameters.AddWithValue(":UPDATED_BY", Updated_Date);
                cmd.Parameters.AddWithValue(":UPDATED_BY", Updated_By);

                cmd.CommandText = Query;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}