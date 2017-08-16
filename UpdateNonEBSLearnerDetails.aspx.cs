using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using GCSEMatrix.DAO;

namespace GCSEMatrix
{
    public partial class UpdateNonEBSLearnerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string GetUCIValue = this.getUCINumberFromURL();
                    txtUCINumber.Text = GetUCIValue;
                    string UCI_NUMBER = txtUCINumber.Text;
                    getExsitingVocationalResults(UCI_NUMBER);
                    get_user_details(UCI_NUMBER);

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        protected string getUCINumberFromURL()
        {
            string UCI_NUMBER = Request.QueryString["UCI_NUMBER"];
            // redirect to index page if  user did not get here via search
            if (string.IsNullOrEmpty(UCI_NUMBER))
            {
                this.Response.Redirect("~/SearchNonEBSLearners.aspx");
            }
            return UCI_NUMBER;
        }

        public void get_user_details(string UCI_NUMBER)
        {
            string strConn = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            string strSQL = "SELECT person_code, student_name, ULI_NUMBER, UCI_NUMBER FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS WHERE UCI_NUMBER = '" + UCI_NUMBER.ToString() + "'";

            OracleConnection conn = new OracleConnection(strConn);
            OracleCommand cmd = new OracleCommand(strSQL, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtStudentID.Text = (dr[0].ToString());
                txtStudentName.Text = (dr[1].ToString());
                txtULI.Text = (dr[2]).ToString();
                txtUCINumber.Text = (dr[3]).ToString();
            }
            dr.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        public void getExsitingVocationalResults(string UCI_NUMBER)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
                OracleConnection conn = new OracleConnection(strConn);
                OracleDataAdapter sda = new OracleDataAdapter("SELECT subject_name, subject_code, grade_name FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS WHERE UCI_NUMBER = '" + UCI_NUMBER + "' AND SUBJECT_CODE IN ('ONAT-FA2','BTEC-AW2','BTEC-CE2','BTEC-EC2','BTEC-D12','ONAT-AW2','ONAT-FC2')", strConn);
                DataTable d = new DataTable();
                sda.Fill(d);
                conn.Open();

                if (d.Rows.Count == 1)
                {
                    DataRow row1 = d.Rows[0];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject1.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();
                }

                else if (d.Rows.Count == 2)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject1.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();
                }
                else if (d.Rows.Count == 3)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];
                    DataRow row3 = d.Rows[2];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject1.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();

                    DDLVocationalSubject3.Text = row3["subject_name"].ToString();
                    DDLVocationalSubject3.SelectedValue = row3["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade3.Text = row3["grade_name"].ToString();
                }


                else if (d.Rows.Count == 4)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];
                    DataRow row3 = d.Rows[2];
                    DataRow row4 = d.Rows[3];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject1.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();

                    DDLVocationalSubject3.Text = row3["subject_name"].ToString();
                    DDLVocationalSubject3.SelectedValue = row3["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade3.Text = row3["grade_name"].ToString();

                    DDLVocationalSubject4.Text = row4["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row4["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade4.Text = row4["grade_name"].ToString();
                }


                else if (d.Rows.Count == 5)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];
                    DataRow row3 = d.Rows[2];
                    DataRow row4 = d.Rows[3];
                    DataRow row5 = d.Rows[4];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject1.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();

                    DDLVocationalSubject3.Text = row3["subject_name"].ToString();
                    DDLVocationalSubject3.SelectedValue = row3["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade3.Text = row3["grade_name"].ToString();

                    DDLVocationalSubject4.Text = row4["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row4["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade4.Text = row4["grade_name"].ToString();

                    DDLVocationalSubject5.Text = row5["subject_name"].ToString();
                    DDLVocationalSubject5.SelectedValue = row5["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade5.Text = row5["grade_name"].ToString();
                }


                else if (d.Rows.Count == 6)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];
                    DataRow row3 = d.Rows[2];
                    DataRow row4 = d.Rows[3];
                    DataRow row5 = d.Rows[4];
                    DataRow row6 = d.Rows[5];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();

                    DDLVocationalSubject3.Text = row3["subject_name"].ToString();
                    DDLVocationalSubject3.SelectedValue = row3["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade3.Text = row3["grade_name"].ToString();

                    DDLVocationalSubject4.Text = row4["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row4["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade4.Text = row4["grade_name"].ToString();

                    DDLVocationalSubject5.Text = row5["subject_name"].ToString();
                    DDLVocationalSubject5.SelectedValue = row5["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade5.Text = row5["grade_name"].ToString();

                    DDLVocationalSubject6.Text = row6["subject_name"].ToString();
                    DDLVocationalSubject6.SelectedValue = row6["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade6.Text = row6["grade_name"].ToString();
                }

                else if (d.Rows.Count == 7)
                {
                    DataRow row1 = d.Rows[0];
                    DataRow row2 = d.Rows[1];
                    DataRow row3 = d.Rows[2];
                    DataRow row4 = d.Rows[3];
                    DataRow row5 = d.Rows[4];
                    DataRow row6 = d.Rows[5];
                    DataRow row7 = d.Rows[6];

                    DDLVocationalSubject1.Text = row1["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row1["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade1.Text = row1["grade_name"].ToString();

                    DDLVocationalSubject2.Text = row2["subject_name"].ToString();
                    DDLVocationalSubject2.SelectedValue = row2["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade2.Text = row2["grade_name"].ToString();

                    DDLVocationalSubject3.Text = row3["subject_name"].ToString();
                    DDLVocationalSubject3.SelectedValue = row3["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade3.Text = row3["grade_name"].ToString();

                    DDLVocationalSubject4.Text = row4["subject_name"].ToString();
                    DDLVocationalSubject4.SelectedValue = row4["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade4.Text = row4["grade_name"].ToString();

                    DDLVocationalSubject5.Text = row5["subject_name"].ToString();
                    DDLVocationalSubject5.SelectedValue = row5["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade5.Text = row5["grade_name"].ToString();

                    DDLVocationalSubject6.Text = row6["subject_name"].ToString();
                    DDLVocationalSubject6.SelectedValue = row6["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade6.Text = row6["grade_name"].ToString();

                    DDLVocationalSubject7.Text = row7["subject_name"].ToString();
                    DDLVocationalSubject6.SelectedValue = row6["SUBJECT_CODE"].ToString();
                    DDLVocationalGrade7.Text = row7["grade_name"].ToString();

                }

                else
                {
                    // show default choices
                }
                conn.Close();
                conn.Dispose();
            }
           catch (Exception ex)
           {
                ex.ToString();
            }
        }

        protected void DDLVocationalSubject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject1, DDLVocationalGrade1);
        }

        protected void DDLVocationalSubject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject2, DDLVocationalGrade2);
        }

        protected void DDLVocationalSubject3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject3, DDLVocationalGrade3);
        }

        protected void DDLVocationalSubject4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject4, DDLVocationalGrade4);
        }

        protected void DDLVocationalSubject5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject5, DDLVocationalGrade5);
        }

        protected void DDLVocationalSubject6_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject6, DDLVocationalGrade6);
        }

        protected void DDLVocationalSubject7_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrades(DDLVocationalSubject7, DDLVocationalGrade7);
        }

        public void FilterGrades(DropDownList ddlSubject, DropDownList ddlGrade)
        {
            ddlGrade.Items.Clear();
            ddlGrade.Items.Insert(0, new ListItem("Select Grade", "SELECT"));
            ddlGrade.Items.Insert(1, new ListItem("PASS", "PASS"));
            ddlGrade.Items.Insert(2, new ListItem("MERIT", "MERIT"));
            ddlGrade.Items.Insert(3, new ListItem("DIST", "DIST"));
            ddlGrade.Items.Insert(4, new ListItem("DIST*", "DIST*"));


            if (ddlSubject.SelectedValue == "BTEC-AW2")
            {
                ddlGrade.Items.FindByValue("MERIT").Enabled = false;
                ddlGrade.Items.FindByValue("DIST").Enabled = false;
                ddlGrade.Items.FindByValue("DIST*").Enabled = false;

            }

            else if (ddlSubject.SelectedValue == "BTEC-EC2" || ddlSubject.SelectedValue == "BTEC-CE2" || ddlSubject.SelectedValue == "BTEC-D12")
            {
                ddlGrade.Items.FindByValue("MERIT").Enabled = true;
                ddlGrade.Items.FindByValue("DIST").Enabled = true;
                ddlGrade.Items.FindByValue("DIST*").Enabled = true;
            }

            else if (ddlSubject.SelectedValue == "ONAT-FA2" || ddlSubject.SelectedValue == "ONAT-AW2" || ddlSubject.SelectedValue == "ONAT-FC2")
            {
                ddlGrade.Items.FindByValue("MERIT").Enabled = true;
                ddlGrade.Items.FindByValue("DIST").Enabled = true;
                ddlGrade.Items.FindByValue("DIST*").Enabled = true;
                ddlGrade.Items.FindByValue("DIST*").Enabled = false;

            }

        }

        public void insertVocationalResults()
        {
            Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
            // if a subject or a grade has not been selected for this DDL do not insert this data
            if (DDLVocationalSubject1.SelectedValue == "SELECT" || DDLVocationalGrade1.SelectedValue == "SELECT")
            {
                // Ignore this and carry on below
            }
            else
            {

                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade1.SelectedValue, DDLVocationalSubject1.SelectedValue, DDLVocationalSubject1.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }

            if (DDLVocationalSubject2.SelectedValue == "SELECT" || DDLVocationalGrade2.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade2.SelectedValue, DDLVocationalSubject2.SelectedValue, DDLVocationalSubject2.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            if (DDLVocationalSubject3.SelectedValue == "SELECT" || DDLVocationalGrade3.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade3.SelectedValue, DDLVocationalSubject3.SelectedValue, DDLVocationalSubject3.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            if (DDLVocationalSubject4.SelectedValue == "SELECT" || DDLVocationalGrade4.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade4.SelectedValue, DDLVocationalSubject4.SelectedValue, DDLVocationalSubject4.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            if (DDLVocationalSubject5.SelectedValue == "SELECT" || DDLVocationalGrade5.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade5.SelectedValue, DDLVocationalSubject5.SelectedValue, DDLVocationalSubject5.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            if (DDLVocationalSubject6.SelectedValue == "SELECT" || DDLVocationalGrade6.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade6.SelectedValue, DDLVocationalSubject6.SelectedValue, DDLVocationalSubject6.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }

            if (DDLVocationalSubject7.SelectedValue == "SELECT" || DDLVocationalGrade7.SelectedValue == "SELECT")
            {

            }
            else
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCINumber.Text, DDLVocationalGrade7.SelectedValue, DDLVocationalSubject7.SelectedValue, DDLVocationalSubject7.SelectedItem.Text, rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
        }

        protected void BtnSaveResults_Click(object sender, EventArgs e)
        {
            Int32 Person_Code_Parameter = Convert.ToInt32(txtStudentID.Text);

            // delete everything in the learner results first, then insert new values (to stop duplicate data)
            InsertQueryString delete = new InsertQueryString();
            delete.DeleteLearnerResults(Person_Code_Parameter);

            foreach (RepeaterItem ri in Repeater1.Items)
            {

                Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
                string StudentName = txtStudentName.Text;
                string ULI = txtULI.Text;
                string UCI = txtUCINumber.Text;
                DateTime Updated_Date = DateTime.Now;
                Label Subject_Code = ri.FindControl("lblsubjectcode") as Label;
                Label Subject_Name = ri.FindControl("lblSubjectName") as Label;
                DropDownList Grade_Name = ri.FindControl("DDLGCSEGRADE") as DropDownList;
                string Results_Status = rdiolstResults_Status.SelectedValue;

                if (Grade_Name.SelectedItem.Text == "Select Grade")
                {
                    // dont insert subjects with no grade
                }
                else
                {
                    InsertQueryString insertGCSEs = new InsertQueryString();
                    insertGCSEs.InsertLearnerResults(Person_Code, StudentName, ULI, UCI, Grade_Name.SelectedValue, Subject_Code.Text, Subject_Name.Text, Results_Status, HttpContext.Current.User.Identity.Name);
                }
            }
            insertVocationalResults();
            //            Response.Write("<script>alert('Results Have Been Updated.');</script>");
            Response.Write("<div class='container'><div class='alert alert-success'><p>Results have been Updated</p></div></div>");

            BtnViewReport.Visible = true;
        }
        protected void BtnRedirectToIndex_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/SearchNonEBSLearners.aspx");
        }


        protected void BtnViewReport_Click(object sender, EventArgs e)
        {
            string pageurl = "http://10.100.36.24/ReportServer/Pages/ReportViewer.aspx?%2fColeg+Powys%2fSkills+Matrix%2fmatrix&UCI_NUMBER=" + txtUCINumber.Text;
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");

        }
    }
}