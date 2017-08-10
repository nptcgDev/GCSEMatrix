using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
namespace GCSEMatrix.DAO
{
    public class ReturnData
    {
        public static DataTable GetVocationalSubjectList()
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            
            OracleConnection con = new OracleConnection(conString);


            OracleCommand cmd = new OracleCommand("SELECT * FROM ROBERTW.NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE IN ('BTEC-AW2','BTEC-CE2','BTEC-EC2','BTEC-D12','ONAT-FA2','ONAT-AW2','ONAT-FC2') ORDER BY SUBJECT_CODE ASC", con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("ROBERTW.NPTCG_MATRIX_SUBJECT");
                dt.Load(dr);

                return dt;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            return dt;
        }

        public static DataTable GetVocationalGradesList(string Subject_Code)
        {

            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand("SELECT GRADE_NAME,GRADE_CODE FROM ROBERTW.NPTCG_MATRIX_GRADE Where GRADE_CODE=:Subject_Code", con);
            
            con.Open();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue(":Subject_Code", Subject_Code);
            
            OracleDataReader dr = cmd.ExecuteReader();
            
            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("ROBERTW.NPTCG_MATRIX_GRADE");
                dt.Load(dr);

                return dt;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            return dt;

        }

        public static DataTable GetGCSESubjectList()
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;

            OracleConnection con = new OracleConnection(conString);


            OracleCommand cmd = new OracleCommand("SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE IN ('GCSEFULL','GCSESHORT') ORDER BY SUBJECT_ID ASC", con);
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("ROBERTW.NPTCG_MATRIX_SUBJECT");
                dt.Load(dr);

                return dt;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            return dt;
        }

        public static DataTable GetLearnerDetails(Int32 person_code)
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand("SELECT person_code, forename || ' ' || surname AS full_name FROM fes.people Where person_code=:person_code", con);

            con.Open();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue(":person_code",person_code);

            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("fes.people");
                dt.Load(dr);

                return dt;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            return dt;

        }

        public DataTable GetLearnerResults()
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string query = @"SELECT NPTC_R.PERSON_CODE, NPTC_R.ULI_NUMBER, nptc_r.UCI_NUMBER, NPTC_R.STUDENT_NAME, nptc_R.UCI_NUMBER, nptc_r.Grade_NAME, nptc_r.SUBJECT_NAME, NPTC_R.SUBJECT_CODE FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R WHERE NPTC_R.PERSON_CODE = 236948 AND NPTC_R.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')";

            OracleCommand cmd = new OracleCommand(query, con);

            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("ROBERTW.nPTCG_MATRIX_LEARNER_RESULTS");
                dt.Load(dr);

                return dt;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            return dt;

        }
    }
}