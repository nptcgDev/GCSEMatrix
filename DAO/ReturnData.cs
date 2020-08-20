using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace GCSEMatrix.DAO
{
    public class ReturnData
    {
        private string connectionStringLive = ConfigurationManager.ConnectionStrings["ebsliveRWConnectionString"].ConnectionString;
        private string connectionStringTrain = ConfigurationManager.ConnectionStrings["ebstrainRWConnectionString"].ConnectionString;

        public DataTable GetGcseSubjectList()
        {
            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);

            OracleCommand cmd = new OracleCommand("SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM FES.NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE IN ('GCSEFULL','GCSESHORT','WELSHBACCNAT', 'WELSHBACCFOUND') AND SUBJECT_GROUP IS NOT NULL AND CORE_SUBJECT = 'N' ORDER BY SUBJECT_GROUP, SUBJECT_ID ASC", con);
            using (con)
            {
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                DataTable dt = null;

                if (dr.HasRows)
                {
                    dt = new DataTable("FES.NPTCG_MATRIX_SUBJECT");
                    dt.Load(dr);
                }

                return dt;
            }
        }

        public DataTable GetVocationalSubjectList()
        {
            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);

            OracleCommand cmd = new OracleCommand("SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM FES.NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE NOT IN ('GCSEFULL','GCSESHORT','WELSHBACCNAT', 'WELSHBACCFOUND', 'GCSEFULL-DOUBLE','GCSEFULL-TRIPLE') ORDER BY SUBJECT_GROUP ASC", con);
            
            using (con)
            {
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                DataTable dt = null;

                if (dr.HasRows)
                {
                    dt = new DataTable("FES.NPTCG_MATRIX_SUBJECT");
                    dt.Load(dr);
                }

                return dt;
            }
        }

        public DataTable GetCoreGcseSubjectList()
        {
            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);

            OracleCommand cmd = new OracleCommand("SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM FES.NPTCG_MATRIX_SUBJECT WHERE CORE_SUBJECT = 'Y' ORDER BY SUBJECT_ID ASC", con);

            using (con)
            {
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();

                DataTable dt = null;

                if (dr.HasRows)
                {
                    dt = new DataTable("FES.NPTCG_MATRIX_SUBJECT");
                    dt.Load(dr);
                }

                return dt;
            }
        }

        public DataSet GetLearnerDetailsFromHub(string personCode)
        {
            DataSet LearnerDetails = new DataSet();

            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);

            con.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.CommandText =
                                @"select distinct people.person_code, p.full_name, people.date_of_birth, lr.record_exists from fes.people people
                                                    LEFT OUTER JOIN (
                                                    select person_code,
                                                    forename || ' ' || surname as full_name
                                                    FROM fes.PEOPLE
                                                    ) P ON (P.PERSON_CODE = PEOPLE.PERSON_CODE)
                                                    LEFT OUTER JOIN(
                                                     SELECT LR.PERSON_CODE,
                                                     LR.RECORD_EXISTS
                                                     FROM
                                                     FES.NPTCG_MATRIX_LEARNER_RESULTS LR
                                                    )LR ON (LR.PERSON_CODE = PEOPLE.PERSON_CODE)
                                                    where to_char(people.person_code) = :personCode";
            cmd.Parameters.Add(":personCode", personCode);
            cmd.Connection = con;
            OracleDataAdapter LearnerDA = new OracleDataAdapter(cmd);
            LearnerDetails = new DataSet();
            LearnerDA.Fill(LearnerDetails);

            con.Close();
            return LearnerDetails;
        }

        public DataSet GetLearnerDetails(string person_code)
        {
            DataSet LearnerDetails = new DataSet();

            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);

            con.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.CommandText =
                @"SELECT DISTINCT
                        p.person_code,
                        fn.full_name,
                        p.date_of_birth,
                        nores.results_status,
                        res.existing_entries
                        FROM  fes.people p
        
                        LEFT JOIN 
                                (
                                SELECT 
                                person_code,
                                forename || ' ' || surname AS full_name
                                FROM fes.people
                                ) fn ON (fn.person_code = P.person_code)

                        LEFT JOIN
                                (
                                SELECT
                                nore.person_code,
                                nore.results_status
                                FROM fes.nptcg_matrix_no_results nore 
                                ) nores ON (nores.person_code = P.person_code)
                        LEFT JOIN
                                (
                                SELECT distinct
                                res.person_code,
                                case when res.person_code is null then 0 else 1 end as existing_entries
                                from fes.nptcg_matrix_learner_results res
                
                                ) res ON (res.person_code = p.person_code)
                        WHERE to_char(p.PERSON_CODE) = :personCode order by p.date_of_birth DESC";
            
            cmd.Parameters.Add(":personCode", person_code);
            cmd.Connection = con;
            OracleDataAdapter LearnerDA = new OracleDataAdapter(cmd);
            LearnerDetails = new DataSet();
            LearnerDA.Fill(LearnerDetails);

            con.Close();
            return LearnerDetails;          
        }

        public DataSet GetGCSELearnerResults(Int32 person_code)
        {
            DataSet GCSELearnerResults = new DataSet();

            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            //get all the subjects from the subjects table and all the gcses subjects and grades that the student has
            cmd.CommandText = @"SELECT 
                                        SUBJECTS.SUBJECT_NAME,
                                        SUBJECTS.SUBJECT_CODE,
                                        Learner_Results.*
                            FROM
                                FES.NPTCG_MATRIX_SUBJECT Subjects
                            LEFT OUTER JOIN
                                            (
                                                SELECT
                                                NPTC_R.PERSON_CODE,
                                                NPTC_R.STUDENT_NAME,
                                                nptc_R.UCI_NUMBER,
                                                NPTC_R.GRADE_NAME,
                                                NPTC_R.SUBJECT_NAME AS SUBJECT_TAKEN,
                                                NPTC_R.SUBJECT_CODE AS CODE_OF_SUBJECT,
                                                NPTC_R.RECORD_EXISTS
                                                
                                                FROM
                                                    FES.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R
                                            ) Learner_Results on (Learner_Results.SUBJECT_TAKEN = subjects.subject_name and subjects.subject_code = learner_results.code_of_subject and Learner_Results.person_code =:person_code)
                            WHERE 
                                SUBJECTS.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT','WELSHBACCNAT', 'WELSHBACCFOUND')
                                ";

            cmd.Connection = con;
            cmd.Parameters.Add(":person_code", person_code);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            GCSELearnerResults = new DataSet();
            da.Fill(GCSELearnerResults);
            con.Close();
            return GCSELearnerResults;
        }

        public DataSet GetVocationalLearnerResults(Int32 person_code)
        {
            DataSet VocationalLearnerResults = new DataSet();

            string connectionString;

            if (ConfigurationManager.AppSettings["Current_DB_Environment"] == "Live")
            {
                connectionString = connectionStringLive;
            }
            else
            {
                connectionString = connectionStringTrain;
            }

            OracleConnection con = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            //get all the subjects from the subjects table and all the gcses subjects and grades that the student has
            cmd.CommandText = @"SELECT SUBJECTS.SUBJECT_NAME, SUBJECTS.SUBJECT_CODE,
                            Learner_Results.*
                            FROM FES.NPTCG_MATRIX_SUBJECT Subjects
                            LEFT OUTER JOIN(
                            SELECT
                            NPTC_R.PERSON_CODE,
                            NPTC_R.STUDENT_NAME,
                            nptc_R.UCI_NUMBER,
                            NPTC_R.GRADE_NAME,
                            NPTC_R.SUBJECT_NAME AS SUBJECT_TAKEN,
                            NPTC_R.SUBJECT_CODE AS CODE_OF_SUBJECT,
                            NPTC_R.RECORD_EXISTS,
                            NPTC_R.ACYR
                            FROM FES.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R
                            ) Learner_Results on (Learner_Results.SUBJECT_TAKEN = subjects.subject_name and subjects.subject_code = learner_results.code_of_subject and Learner_Results.person_code =:person_code)
                            WHERE SUBJECTS.SUBJECT_CODE NOT IN ('GCSEFULL','GCSESHORT', 'WELSHBACCNAT', 'WELSHBACCFOUND') AND Learner_Results.ACYR = '1819'";
            cmd.Connection = con;
            cmd.Parameters.Add(":person_code", person_code);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            VocationalLearnerResults = new DataSet();
            da.Fill(VocationalLearnerResults);
            con.Close();
            return VocationalLearnerResults;
        }
    }
}