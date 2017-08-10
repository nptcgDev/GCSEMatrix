using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
using GCSEMatrix.DAO;
using Microsoft.Reporting.WebForms;
namespace GCSEMatrix
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
           {
                 try
                 {
                     string Person_Code = this.getPersonCodeFromURL();
                     txtStudentID.Text = Person_Code;
                     Int32 person_code = Convert.ToInt32(txtStudentID.Text);
                     get_user_details(person_code);
                     ValidatesUserFields();
                  }
                 catch (Exception ex)
                 {
                     ex.ToString();
                 }
            }
        }

        protected string getPersonCodeFromURL()
        {
            string Person_Code = Request.QueryString["person_code"];
            // redirect to index page if  user did not get here via search
            if (string.IsNullOrEmpty(Person_Code))
            {
                this.Response.Redirect("~/Index.aspx");
            }

            return Person_Code;
        }

        public void ValidatesUserFields()
        {
            //enables UCI, ULI textboxes if none can be found in EBS
            if (txtUCI.Text == "")
            {
                txtUCI.Enabled = true;
            }
            else
            {
                txtUCI.Enabled = false;
            }

            if (txtULI.Text == "")
            {
                txtULI.Enabled = true;
            }
            else
            {
                txtULI.Enabled = false;
            }
        }
        protected void BtnSaveResults_Click(object sender, EventArgs e)
        {

            foreach (RepeaterItem ri in Repeater1.Items)
            {            

                Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
                string StudentName = txtStudentName.Text;
                string ULI = txtULI.Text;
                string UCI = txtUCI.Text;
                Label Subject_Code = ri.FindControl("lblSubjectType") as Label;
                Label Subject_Name = ri.FindControl("lblSubjectName") as Label;
                DropDownList Grade_Name = ri.FindControl("DDLGCSEGRADE") as DropDownList;
                string Results_Status =rdiolstResults_Status.SelectedValue;

                if (Grade_Name.Text == "Select Grade")
                {
                    // dont insert row
                }
                else {
                 InsertQueryString insertGCSEs = new InsertQueryString();
                 insertGCSEs.InsertLearnerResults(Person_Code, StudentName, ULI, UCI, Grade_Name.SelectedValue, Subject_Code.Text, Subject_Name.Text, Results_Status, HttpContext.Current.User.Identity.Name);

                }


            }
            insertVocationalResults();
            BtnSaveResults.Visible = false;
            BtnUpdateResults.Visible = true;
            BtnViewReport.Visible = true;

        }

        public void insertVocationalResults()
        {
            Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
            // if a subject or a grade has not been selected for this DDL do not insert this data
            if (DDLVocationalSubject1.Text != "Select Subject" && DDLVocationalGrade1.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade1.SelectedValue, DDLVocationalSubject1.SelectedValue, DDLVocationalSubject1.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
                // Ignore this and carry on below
            }

            if (DDLVocationalSubject2.Text != "Select Subject" && DDLVocationalGrade2.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade2.SelectedValue, DDLVocationalSubject2.SelectedValue, DDLVocationalSubject2.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
            }
            if (DDLVocationalSubject3.Text != "Select Subject" && DDLVocationalGrade3.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade3.SelectedValue, DDLVocationalSubject3.SelectedValue, DDLVocationalSubject3.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
            }
            if (DDLVocationalSubject4.Text != "Select Subject" && DDLVocationalGrade4.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade4.SelectedValue, DDLVocationalSubject4.SelectedValue, DDLVocationalSubject4.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
            }
            if (DDLVocationalSubject5.Text != "Select Subject" && DDLVocationalGrade5.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade5.SelectedValue, DDLVocationalSubject5.SelectedValue, DDLVocationalSubject5.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {

            }
            if (DDLVocationalSubject6.Text != "Select Subject" && DDLVocationalGrade6.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade6.SelectedValue, DDLVocationalSubject6.SelectedValue, DDLVocationalSubject6.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
                // Ignore this and carry on below
            }

            if (DDLVocationalSubject7.Text != "Select Subject" && DDLVocationalGrade7.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULI.Text, txtUCI.Text, DDLVocationalGrade7.SelectedValue, DDLVocationalSubject7.SelectedValue, DDLVocationalSubject7.SelectedItem.Text,rdiolstResults_Status.SelectedValue, HttpContext.Current.User.Identity.Name);

            }
            else
            {
            }
        }
        public void get_user_details(Int32 person_code)
        {
            string strConn = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            string strSQL = "SELECT person_code, forename || ' ' || surname AS full_name, GC_UCI, ULI FROM fes.people WHERE person_code =" + person_code;
            ReturnData learner = new ReturnData();
            
            OracleConnection conn = new OracleConnection(strConn);
            OracleCommand cmd = new OracleCommand(strSQL, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txtStudentName.Text = (dr[1].ToString());
                txtUCI.Text = (dr[2]).ToString();
                txtULI.Text = (dr[3]).ToString();
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public void FilterGrades(DropDownList ddlSubject, DropDownList ddlGrade)
        {
            ddlGrade.Items.Clear();

            ddlGrade.Items.Insert(0, new ListItem("DIST*", "DIST*"));
            ddlGrade.Items.Insert(0, new ListItem("DIST", "DIST"));
            ddlGrade.Items.Insert(0, new ListItem("MERIT", "MERIT"));
            ddlGrade.Items.Insert(0, new ListItem("PASS", "PASS"));
            ddlGrade.Items.Insert(0, new ListItem("Select Grade", "SELECT"));

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

        protected void BtnUpdateResults_Click(object sender, EventArgs e)
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
                string UCI = txtUCI.Text;
                Label Subject_Code = ri.FindControl("lblSubjectType") as Label;
                Label Subject_Name = ri.FindControl("lblSubjectName") as Label;
                DropDownList Grade_Name = ri.FindControl("DDLGCSEGRADE") as DropDownList;
                string Results_Status = rdiolstResults_Status.SelectedValue;

                if (Grade_Name.Text == "Select Grade")
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
        }

        protected void BtnViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://10.100.36.24/ReportServer/Pages/ReportViewer.aspx?%2fColeg+Powys%2fSkills+Matrix%2fmatrix&rs:Format=PDF&PERSON_CODE=" + txtStudentID.Text);

        }

        }
    }
