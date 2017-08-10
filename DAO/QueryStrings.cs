using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCSEMatrix.DAO
{
    public class QueryStrings
    {
        public string InsertLearnerResults(Int32 Person_Code, string Student_Name, string ULI_Number, string UCI_Number, string Grade_Name, string Subject_Code, string Subject_Name, string Results_Status, string Created_By)
        {

           string Query = @"INSERT INTO ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS
                    (PERSON_CODE, ACYR, STUDENT_NAME, ULI_NUMBER, UCI_NUMBER, GRADE_NAME, SUBJECT_CODE,
                    SUBJECT_NAME, RESULTS_STATUS,CREATED_DATE, CREATED_BY)
                    VALUES (" + Person_Code + @",
                   '1718',
                    '" + Student_Name + @"',
                    '" + ULI_Number + @"',
                    '" + UCI_Number + @"',
                    '" + Grade_Name + @"',
                    '" + Subject_Code + @"',
                    '" + Subject_Name + @"',
                    '" + Results_Status + @"',
                    to_timestamp ('" + DateTime.Now + @"', 'DD/MM/YYYY HH24:MI:SS'),
                    '" + Created_By + @"')";

            return Query;
        }

        public string DeleteLearnerResults(Int32 Person_Code)
        {
            string Query = @"DELETE FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS WHERE PERSON_CODE =" + Person_Code;

            return Query;
        }


    }
}