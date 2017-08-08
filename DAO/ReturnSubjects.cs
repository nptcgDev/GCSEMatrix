using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
namespace GCSEMatrix.DAO
{
    public class ReturnSubjects
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

            cmd.Parameters.AddWithValue(":person_code", SqlDbType.Int).Value = person_code;

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

        public DataSet GetLearnerResults(Int32 person_code)
        {
            DataSet LearnerResultsDataSet = new DataSet();
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;

            OracleConnection oraCon = new OracleConnection(conString);
                
            oraCon.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = @"SELECT
                        NPTC_R.PERSON_CODE,
                        NPTC_R.STUDENT_NAME,
                        NPTC_R.ULI_NUMBER,
                        nptc_R.UCI_NUMBER,
                        nptc_r.Grade_NAME,
                        nptc_r.SUBJECT_NAME,
                        nptc_r.SUBJECT_CODE,
                        GCSE_Results.No_of_GCSEs,
                        GCSE_Results.Total_GCSE_Points,
                        GCSE_Results.Average_GCSE_SCORE,
                        nvl(Voc_Scores_Results.No_of_Vocs,0) AS No_of_Vocs,
                        nvl(Voc_Scores_Results.Voc_Total_Points,0) AS Voc_Total_Points,
                        nvl(Voc_Scores_Results.Average_Voc_Score,0) AS Average_Voc_Score,
                        Maths.Grade_NAME as maths_grade,
                        MATHS.GRADE_VALUE AS MATHS_GRADE_VALUE,
                        English.Grade_NAME as english_grade,
                        English.grade_value as english_grade_value,

                        -- Add points and qualifications of GCSEs and Vocs to get combined Sums
                        GCSE_Results.Total_GCSE_Points + nvl(Voc_Scores_Results.Voc_Total_Points,0) AS Combined_Total_points,
                        GCSE_Results.No_of_GCSEs + nvl(Voc_Scores_Results.No_of_Vocs,0) As Combined_Total_Quals

                        FROM NPTCG_MATRIX_LEARNER_RESULTS nptc_r
                        JOIN NPTCG_MATRIX_GRADE nptc_g on (nptc_g.GRADE_CODE = nptc_r.SUBJECT_CODE AND nptc_g.GRADE_NAME = NPTC_R.Grade_NAME)
                        JOIN NPTCG_MATRIX_SUBJECT nptc_s on (nptc_s.SUBJECT_CODE = nptc_r.SUBJECT_CODE AND nptc_s.SUBJECT_NAME = NPTC_R.SUBJECT_NAME)


                        -- get the GCSE Average Score
                        LEFT OUTER JOIN (
                        SELECT

                        SUM(GCSE_SCORES.NUMBER_OF_GCSES) AS NO_OF_GCSES,
                        SUM(GCSE_Scores.total_gcse_points) as Total_GCSE_Points,
                        ROUND(SUM(GCSE_Scores.total_gcse_points) / sum (GCSE_Scores.number_of_gcses),2) AS Average_GCSE_SCORE,
                        GCSE_Scores.PERSON_CODE
                        FROM
                        (
                        select
                        nptc_r.PERSON_CODE,
                        nptc_g.GRADE_VALUE as total_gcse_points,
                        nptc_s.SUBJECT_VALUE as number_of_gcses

                        FROM NPTCG_MATRIX_LEARNER_RESULTS nptc_r
                        JOIN NPTCG_MATRIX_GRADE nptc_g on (nptc_g.GRADE_CODE = nptc_r.SUBJECT_CODE AND nptc_g.GRADE_NAME = NPTC_R.Grade_NAME)
                        JOIN NPTCG_MATRIX_SUBJECT nptc_s on (nptc_s.SUBJECT_CODE = nptc_r.SUBJECT_CODE AND nptc_s.SUBJECT_NAME = NPTC_R.SUBJECT_NAME)
                        where
                        NPTC_R.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')
                        ) GCSE_Scores
                        group by GCSE_Scores.PERSON_CODE
                        ) GCSE_Results on (GCSE_Results.PERSON_CODE = nptc_r.PERSON_CODE)


                        -- get the average vocational scores
                        LEFT OUTER JOIN (
                        SELECT
                        SUM(Voc_Scores.number_of_vocs) as No_of_Vocs,
                        SUM(Voc_Scores.total_voc_points) as Voc_Total_Points,
                        ROUND(SUM(Voc_Scores.total_voc_points) / SUM (Voc_Scores.number_of_vocs),2) AS Average_Voc_Score,
                        Voc_Scores.PERSON_CODE
                        FROM
                        (
                        select
                        nptc_r.PERSON_CODE,
                        nptc_g.GRADE_VALUE as total_voc_points,
                        NPTC_s.SUBJECT_VALUE as number_of_vocs

                        from NPTCG_MATRIX_LEARNER_RESULTS nptc_r
                        join NPTCG_MATRIX_GRADE nptc_g on (nptc_g.GRADE_CODE = nptc_r.SUBJECT_CODE AND nptc_g.GRADE_NAME = NPTC_R.Grade_NAME)
                        join NPTCG_MATRIX_SUBJECT nptc_s on (nptc_s.SUBJECT_CODE = nptc_r.SUBJECT_CODE AND nptc_s.SUBJECT_NAME = NPTC_R.SUBJECT_NAME)
                        where
                        NPTC_R.SUBJECT_CODE IN ('BTEC-AW2', 'BTEC-CE2', 'BTEC-EC2', 'ONAT-FA2', 'ONAT-AW2', 'ONAT-FC2')
                        ) Voc_Scores
                        group by Voc_Scores.PERSON_CODE
                        ) Voc_Scores_Results on (Voc_Scores_Results.PERSON_CODE = nptc_r.PERSON_CODE)


                        LEFT OUTER JOIN(
                        select
                        nptc_r.person_code,
                        nptc_r.Grade_NAME,
                        nptc_g.GRADE_VALUE

                        from NPTCG_MATRIX_LEARNER_RESULTS nptc_r
                        JOIN NPTCG_MATRIX_GRADE nptc_g on (nptc_g.GRADE_CODE = nptc_r.SUBJECT_CODE AND nptc_g.GRADE_NAME = NPTC_R.Grade_NAME)
                        JOIN NPTCG_MATRIX_SUBJECT nptc_s on (nptc_s.SUBJECT_CODE = nptc_r.SUBJECT_CODE AND nptc_s.SUBJECT_NAME = NPTC_R.SUBJECT_NAME)
                        where
                        NPTC_R.SUBJECT_CODE = 'GCSEFULL' AND
                        NPTC_R.SUBJECT_NAME = 'Mathematics'
                        ) Maths ON (Maths.person_code = nptc_r.person_code)

                        LEFT OUTER JOIN(
                        select
                        NPTC_R.PERSON_CODE,
                        nptc_r.Grade_NAME,
                        nptc_g.GRADE_VALUE

                        FROM NPTCG_MATRIX_LEARNER_RESULTS NPTC_R
                        JOIN NPTCG_MATRIX_GRADE nptc_g on (nptc_g.GRADE_CODE = nptc_r.SUBJECT_CODE AND nptc_g.GRADE_NAME = NPTC_R.GRADE_NAME)
                        JOIN NPTCG_MATRIX_SUBJECT nptc_s on (nptc_s.SUBJECT_CODE = nptc_r.SUBJECT_CODE AND nptc_s.SUBJECT_NAME = NPTC_R.SUBJECT_NAME)
                        where
                        NPTC_R.SUBJECT_CODE = 'GCSEFULL' AND
                        NPTC_R.SUBJECT_NAME = 'English Language'
                        ) English ON (English.person_code = nptc_r.person_code)

                        WHERE
                        (nptc_r.PERSON_CODE = =:Person_Code)";

            cmd.Connection = oraCon;

            OracleDataAdapter oraAdapter = new OracleDataAdapter(cmd);
            LearnerResultsDataSet = new DataSet();
            oraAdapter.Fill(LearnerResultsDataSet);
            oraCon.Close();

            return LearnerResultsDataSet;
        }
    }
}