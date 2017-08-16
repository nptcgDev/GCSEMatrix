using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
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


        public static DataTable GetGCSESubjectList()
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;

            OracleConnection con = new OracleConnection(conString);


            OracleCommand cmd = new OracleCommand("SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM ROBERTW.NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE IN ('GCSEFULL','GCSESHORT') ORDER BY SUBJECT_ID ASC", con);
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

        public DataSet GetLearnerDetails(string full_name)
        {
            DataSet LearnerDetails = new DataSet();


            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            con.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = @"select distinct people.person_code, p.full_name, people.date_of_birth, lr.record_exists from fes.people people
                                                    LEFT OUTER JOIN (
                                                    select person_code,
                                                    forename || ' ' || surname as full_name
                                                    FROM fes.PEOPLE
                                                    ) P ON (P.PERSON_CODE = PEOPLE.PERSON_CODE)
                                                    LEFT OUTER JOIN(
                                                     SELECT LR.PERSON_CODE,
                                                     LR.RECORD_EXISTS
                                                     FROM
                                                     NPTCG_MATRIX_LEARNER_RESULTS LR
                                                    )LR ON (LR.PERSON_CODE = PEOPLE.PERSON_CODE)
                                                    where lower(p.full_name) LIKE lower('" + full_name + @"') order by people.date_of_birth DESC";
            cmd.Connection = con;
            OracleDataAdapter LearnerDA = new OracleDataAdapter(cmd);
            LearnerDetails = new DataSet();
            LearnerDA.Fill(LearnerDetails);

            con.Close();
            return LearnerDetails;
        }

        public DataSet GetGCSELearnerResults(Int32 person_code)
        {
            DataSet GCSELeanerResults = new DataSet();
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            
                OracleCommand cmd = new OracleCommand();
                //get all the subjects from the subjects table and all the gcses subjects and grades that the student has
                cmd.CommandText = @"SELECT SUBJECTS.SUBJECT_NAME, SUBJECTS.SUBJECT_CODE,
                            Learner_Results.*
                            FROM ROBERTW.NPTCG_MATRIX_SUBJECT Subjects
                            LEFT OUTER JOIN(
                            SELECT
                            NPTC_R.PERSON_CODE,
                            NPTC_R.STUDENT_NAME,
                            nptc_R.UCI_NUMBER,
                            NPTC_R.GRADE_NAME,
                            NPTC_R.SUBJECT_NAME AS SUBJECT_TAKEN,
                            NPTC_R.SUBJECT_CODE AS CODE_OF_SUBJECT,
                            NPTC_R.RECORD_EXISTS
                            FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R
                            ) Learner_Results on (Learner_Results.SUBJECT_TAKEN = subjects.subject_name and subjects.subject_code = learner_results.code_of_subject and Learner_Results.person_code = " + person_code.ToString() + ") WHERE SUBJECTS.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')";
                cmd.Connection = con;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                GCSELeanerResults = new DataSet();
                da.Fill(GCSELeanerResults);
                con.Close();
                return GCSELeanerResults;
        }
        public DataTable GetVocationalLearnerResults(Int32 person_code)
        {
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string query = @"SELECT subject_name, subject_code, grade FROM NPTCG_MATRIX_LEARNER_RESULTS WHERE person_code =" + person_code + " AND SUBJECT_CODE IN ('ONAT-FA2','BTEC-AW2','BTEC-CE2','BTEC-EC2','BTEC-D12','ONAT-AW2','ONAT-FC2')";

            OracleCommand cmd = new OracleCommand(query, con);

            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = null;

            if (dr.HasRows)
            {

                dt = new DataTable("ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS");
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


        public DataSet GetExistingNonEBSLearnerDetails(string full_name)
        {
            DataSet NonEBSLearnerDetailsSet = new DataSet();


            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = @"select distinct UCI_NUMBER, student_name, PERSON_CODE from robertw.nptcg_matrix_learner_results where lower(student_name) LIKE lower('" + full_name + @"') AND person_code = 0";
            cmd.Connection = con;
            OracleDataAdapter LearnerDA = new OracleDataAdapter(cmd);
            NonEBSLearnerDetailsSet = new DataSet();
            LearnerDA.Fill(NonEBSLearnerDetailsSet);

            con.Close();
            return NonEBSLearnerDetailsSet;
        }

        public DataSet GetNonEBSLearnerGCSEResults(string UCI_NUMBER)
        {
            DataSet NonGCSELearnerResultSet = new DataSet();
            string conString = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);

            OracleCommand cmd = new OracleCommand();
            //get all the subjects from the subjects table and all the gcses subjects and grades that the student has
            cmd.CommandText = @"SELECT SUBJECTS.SUBJECT_NAME, SUBJECTS.SUBJECT_CODE,
                            Learner_Results.person_code, Learner_Results.student_name, Learner_Results.UCI_Number,
                            Learner_Results.SUBJECT_TAKEN, Learner_Results.Grade_Name, Learner_Results.Subject_Taken, Learner_Results.Code_Of_Subject
                            FROM ROBERTW.NPTCG_MATRIX_SUBJECT Subjects
                            LEFT OUTER JOIN(
                            SELECT
                            NPTC_R.PERSON_CODE,
                            NPTC_R.STUDENT_NAME,
                            nptc_R.UCI_NUMBER,
                            NPTC_R.GRADE_NAME,
                            NPTC_R.SUBJECT_NAME AS SUBJECT_TAKEN,
                            NPTC_R.SUBJECT_CODE AS CODE_OF_SUBJECT
                            FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R
                            ) Learner_Results on (Learner_Results.SUBJECT_TAKEN = subjects.subject_name and subjects.subject_code = learner_results.code_of_subject and Learner_Results.UCI_NUMBER = '" + UCI_NUMBER.ToString() + "')  WHERE SUBJECTS.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')";
            cmd.Connection = con;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            NonGCSELearnerResultSet = new DataSet();
            da.Fill(NonGCSELearnerResultSet);
            con.Close();
            return NonGCSELearnerResultSet;
        }
    }


}