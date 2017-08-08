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
                     get_user(person_code);
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

        protected void BtnSaveResults_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in Repeater1.Items )
            {
                Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
                string StudentName = txtStudentName.Text;
                string ULI = txtULN.Text;
                string UCI = txtUCI.Text;
                Label Subject_Code = ri.FindControl("lblSubjectType") as Label;
                Label Subject_Name = ri.FindControl("lblSubjectName") as Label;
                DropDownList Grade_Name = ri.FindControl("DDLGCSEGRADE") as DropDownList;
                string Created_By = lblUsername.Text;
                string Results_Supplied_True = lbltrue.Text;
                string Results_To_Be_Checked = lblplr.Text;

                if (Grade_Name.Text == "Select Grade")
                {

                }
                else {
              //      InsertQueryString delete = new InsertQueryString();
            //        delete.DeleteLearnerResults(Person_Code);
                InsertQueryString insertGCSEs = new InsertQueryString();
                insertGCSEs.InsertLearnerResults(Person_Code,StudentName,ULI,UCI,Grade_Name.SelectedValue,Subject_Code.Text,Subject_Name.Text,Results_Supplied_True,Results_To_Be_Checked,Created_By);
                }
            }

            insertVocs();

        }
        public void insertVocs()
        {
            Int32 Person_Code = Convert.ToInt32(txtStudentID.Text);
            if (DDLVocationalSubject1.Text != "Select Subject" && DDLVocationalGrade1.Text != "Select Grade")
            {
                InsertQueryString insertVocs = new InsertQueryString();
                insertVocs.InsertLearnerResults(Person_Code, txtStudentName.Text, txtULN.Text, txtUCI.Text, DDLVocationalGrade1.SelectedValue, DDLVocationalSubject1.SelectedValue, DDLVocationalSubject1.SelectedItem.Text, lbltrue.Text, lblplr.Text, lblUsername.Text);

            }
            else
            {
            }
        }
        public void get_user(Int32 person_code)
        {
            string strConn = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
            string strSQL = "SELECT person_code, forename || ' ' || surname AS full_name FROM fes.people WHERE person_code =" + person_code;
            ReturnSubjects learner = new ReturnSubjects();
            
            OracleConnection conn = new OracleConnection(strConn);
            OracleCommand cmd = new OracleCommand(strSQL, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txtStudentName.Text = (dr["full_name"].ToString());

            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

        }
    }
 }