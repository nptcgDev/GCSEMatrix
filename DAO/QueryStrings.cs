using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCSEMatrix.DAO
{
    public class QueryStrings
    {
        public string InsertLearnerResults()
        {
            var query = "";
                query = @"INSERT INTO FES.NPTCG_MATRIX_LEARNER_RESULTS
                            (PERSON_CODE, ACYR, STUDENT_NAME, ULI_NUMBER, UCI_NUMBER, GRADE_NAME, SUBJECT_CODE,
                            SUBJECT_NAME, RESULTS_STATUS,CREATED_DATE, CREATED_BY, RECORD_EXISTS)
                            VALUES (:Person_Code,'2021', :Full_Name, :ULI_Number,
                            :UCI_Number, :Grade_Name, :Subject_Code, :Subject_Name,
                            :Results_Status, :Created_Date, :Created_By,'Y')";
            return query;
        }


        public string InsertNoResults()
        {
            var query = "";
            query = @"INSERT INTO FES.NPTCG_MATRIX_NO_RESULTS
                            (PERSON_CODE, CREATED_DATE, CREATED_BY)
                            VALUES (:Person_Code, :Created_Date, :Created_By)";
            return query;
        }

        public string UpdateLearnerResults(Int32 personCode)
        {
            var query = "";
            query = @"UPDATE FES.NPTCG_MATRIX_LEARNER_RESULTS                        
                    SET
                    PERSON_CODE =:Person_Code,
                    STUDENT_NAME =:Student_Name,
                    ULI_NUMBER =:ULI_Number,
                    UCI_Number =:UCI_Number,
                    Grade_Name =:Grade_Name,
                    Subject_Code =:Subject_Code,
                    Subject_Name =:Subject_Name,
                    Results_Status =:Results_Status,
                    Updated_Date =:Updated_Date,
                    Updated_By =:Updated_By
                    WHERE
                    PERSON_CODE =:Person_Code";            
            return query;
        }

        public string DeleteLearnerResults()
        {
            var query = "";
            query = @"DELETE FROM FES.NPTCG_MATRIX_LEARNER_RESULTS WHERE PERSON_CODE =:PERSON_CODE AND ACYR='2021' ";
            return query;
        }
    }
}