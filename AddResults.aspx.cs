using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using GCSEMatrix.DAO;
using System.Web.UI;

namespace GCSEMatrix
{
    [Serializable]
    public class Courses
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string GradeName { get; set; }
    }

    public partial class Default : System.Web.UI.Page
    {

        List<Courses> otherGCSEdata = null;        
        List<Courses> vocData = null;

        protected MasterPage PageMaster
        {
            get
            {
                return this.Master as MasterPage;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            otherGCSEdata = ViewState["_otherGCSEdata"] as List<Courses> ?? new List<Courses>();
            vocData = ViewState["_vocData"] as List<Courses> ?? new List<Courses>();
            // check if the page is loaded for the first time, 
            if (!IsPostBack)
            {
                try
                {
                    var getPersonCode = new CommonCode();
                    txtStudentID.Text = getPersonCode.GetPersonCodeFromUrl();
                    var personCode = Convert.ToInt32(txtStudentID.Text);
                    GetUserDetails(personCode);
                    EnableUserFields();
                }
                catch (Exception ex)
                {

                }
            }
        }

        #region Event Handlers for buttons

        protected void BtnViewReport_Click(object sender, EventArgs e)
        {
            var pageurl = "http://nth-mis-app-01/ReportServer/Pages/ReportViewer.aspx?%2fColeg+Powys%2fSkills+Matrix%2fmatrix-slip-1920&PERSON_CODE=" + txtStudentID.Text;// + "&rs:Format=PDF";
                                                                                                                                                                             //  Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
            Response.Redirect(pageurl);
        }

        protected void BtnUpdateResults_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                InsertLearnerResults();
                Response.Write("<div class='container'><div class='alert alert-success'><p>Results have been Updated</p></div></div>");
            }
        }

        protected void BtnRedirectToIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://ebsontrackhub.ad.nptcgroup.ac.uk/Page");
        }

        protected void BtnSaveResults_Click(object sender, EventArgs e)
        {

            if (CheckErrors())
            {

                InsertLearnerResults();
                BtnSaveResults.Visible = false;
                BtnUpdateResults.Visible = true;
                BtnViewReport.Visible = true;
                BtnRedirectToIndex.Visible = true;

                // overrides the maintainscrollback setting
                this.ResetScrollPosition();
                Response.Write("<div class='container'><div class='alert alert-success'><p>Results have been Added</p></div></div>");


            }
        }

        #endregion

        #region Event Handlers for Lists
        protected void DDLVocationalSubject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtergrade = new CommonCode();
            filtergrade.FilterVocationalGrades(DDLVocationalSubject1, DDLVocationalGrade1);
        }

        protected void BtnAddOther_Click(object sender, EventArgs e)
        {
            var subjectName = DDLOther.SelectedItem.Text;
            var subjectCode = lblOtherSubjectCode.Text;
            var gradeName = DDLOtherGCSEGrade.SelectedItem.Text;

            var other = new Courses();

            other.SubjectName = subjectName;
            other.SubjectCode = subjectCode;
            other.GradeName = gradeName;

            otherGCSEdata.Add(other);

            ViewState["_otherGCSEdata"] = otherGCSEdata;

            grdvwOther.DataSource = otherGCSEdata;
            grdvwOther.DataBind();
        }

        protected void BtnAddVoc_Click(object sender, EventArgs e)
        {
            try
            {
                var subjectName = DDLVocationalSubject1.SelectedItem.Text;
                var subjectCode = DDLVocationalSubject1.SelectedValue;
                var gradeName = DDLVocationalGrade1.SelectedItem.Text;

                var vocCourse = new Courses();

                vocCourse.SubjectName = subjectName;
                vocCourse.SubjectCode = subjectCode;
                vocCourse.GradeName = gradeName;

                // don't add qualification unless a grade has been specified
                if (string.IsNullOrEmpty(vocCourse.GradeName) || vocCourse.GradeName == "Select Grade")
                {

                }
                else
                {
                    vocData.Add(vocCourse);

                    ViewState["_vocData"] = vocData;

                    gvVocationalQual.DataSource = vocData;
                    gvVocationalQual.DataBind();
                }
            }
            catch (NullReferenceException ex)
            {
              ex.ToString();

            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            // get the link button of the row to be deleted
            var btn = (LinkButton)(sender);

            var Outrow = (GridViewRow)btn.NamingContainer;

            // get the unique ID of the row to be deleted
            var HFGV = Outrow.FindControl("HFGV") as HiddenField;

            //Convert the id  
            var itemToRemove = Convert.ToInt32(HFGV.Value);

            otherGCSEdata.RemoveAt(itemToRemove);
            //rebind the gridview to show added data
            grdvwOther.DataSource = otherGCSEdata;
            grdvwOther.DataBind();
        }

        protected void RemoveVoc_Click(object sender, EventArgs e)
        {
            // get the link button of the row to be deleted
            var btn = (LinkButton)(sender);

            var outRow = (GridViewRow)btn.NamingContainer;

            // get the unique ID of the row to be deleted
            var HFGV = outRow.FindControl("HFGV_Voc") as HiddenField;

            //Convert the id  
            var itemToRemove = Convert.ToInt32(HFGV.Value);

            vocData.RemoveAt(itemToRemove);
            //rebind the gridview to show added data
            gvVocationalQual.DataSource = vocData;
            gvVocationalQual.DataBind();
        }

        protected void rptGcseSubjectList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Foreach loop added to filter the grades available to welsh baccularetes
            // Forced upon me by circumstance!!! - RW 25-08-17

            foreach (RepeaterItem ri in rptGcseSubjectList.Items)
            {
                var lblSubjectName = (Label)ri.FindControl("lblSubjectName");
                var DDLGrade = (DropDownList)ri.FindControl("DDLGCSEGrade");
                var filterGCSEGrades = new CommonCode();
                filterGCSEGrades.FilterGcseGrades(lblSubjectName, DDLGrade);
            }

        }

        protected void gvVocationalQual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var HFGV = e.Row.FindControl("HFGV_Voc") as HiddenField;
                var LBLDeleteOther = e.Row.FindControl("LBLDeleteVoc") as LinkButton;
                HFGV.Value = e.Row.RowIndex.ToString();
            }
        }

        protected void grdvwOther_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var HFGV = e.Row.FindControl("HFGV") as HiddenField;
                var LBLDeleteOther = e.Row.FindControl("LBLDeleteOther") as LinkButton;
                HFGV.Value = e.Row.RowIndex.ToString();
            }
        }
        #endregion

        #region Methods for this page only
        protected void GetUserDetails(Int32 person_code)
        {
            var strConn = ConfigurationManager.ConnectionStrings["ebsliveRWConnectionString"].ConnectionString;
            var strSQL = "SELECT person_code, forename || ' ' || surname AS full_name, GC_UCI, UNIQUE_LEARN_NO  FROM fes.people WHERE person_code =:person_code";
            var learner = new ReturnData();

            var conn = new OracleConnection(strConn);
            var cmd = new OracleCommand(strSQL, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(":person_code", person_code);
            using (conn)
            {
                conn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtStudentName.Text = (dr[1].ToString());
                    txtUCI.Text = (dr[2]).ToString();
                    txtULI.Text = (dr[3]).ToString();
                }

                cmd.Dispose();
            }
        }
        public String ValidationGroup
        {
            set
            {
                valSummary.ValidationGroup = value;
            }
        }

        public bool CheckErrors()
        {

            Page.Validate(valSummary.ValidationGroup);

            if (!Page.IsValid)
            {
                modalPopupEx.Show();
                return false;
            }
            return true;
        }  
        protected void InsertLearnerResults()
        {
            // delete everything in the learner results first, then insert new values (to stop duplicate data)
            var personCode = Convert.ToInt32(txtStudentID.Text);
            var delete = new Methods();
            delete.DeleteLearnerResults(personCode);

            var studentName = txtStudentName.Text;
            var ULI = txtULI.Text;
            var UCI = txtUCI.Text;
            var createdDate = DateTime.Now;
            var resultsStatus = rdiolstResults_Status.SelectedValue;

            var insertCoreGsceEnglish = new Methods();
            var insertCoreGcseMaths = new Methods();
            var insertCoreGcseNumeracy = new Methods();
            var insertCoreGcseWelsh =  new Methods();

            insertCoreGsceEnglish.InsertLearnerResults(personCode, studentName, ULI, UCI, DDLCoreGCSEGrade1.SelectedValue, "GCSEFULL", lblGCSEEnglish.Text, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);
            insertCoreGcseMaths.InsertLearnerResults(personCode, studentName, ULI, UCI, DDLCoreGCSEGrade2.SelectedValue, "GCSEFULL", lblGCSEMaths.Text, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);
            insertCoreGcseNumeracy.InsertLearnerResults(personCode, studentName, ULI, UCI, DDLCoreGCSEGrade3.SelectedValue, "GCSEFULL", lblGCSENumeracy.Text, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);


            foreach (RepeaterItem ri in rptGcseSubjectList.Items)
            {

                var subjectCode = ri.FindControl("lblSubjectType") as Label;
                var subjectName = ri.FindControl("lblSubjectName") as Label;
                var gradeName = ri.FindControl("DDLGCSEGRADE") as DropDownList;
                if (gradeName.Text == "Select Grade")
                {
                    // dont insert row
                }
                else
                {
                    var insertGCSEs = new Methods();
                    insertGCSEs.InsertLearnerResults(personCode, studentName, ULI, UCI, gradeName.SelectedValue, subjectCode.Text, subjectName.Text, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);
                    insertCoreGcseWelsh.InsertLearnerResults(personCode, studentName, ULI, UCI, DDLCoreGCSEGrade4.SelectedValue, "GCSEFULL", lblGCSEWelsh.Text, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);

                }

            }

            // Add the 'other' qualifications if they exist in the gridview
            foreach (GridViewRow Row in gvVocationalQual.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {
                    var subjectName = gvVocationalQual.Rows[Row.RowIndex].Cells[0].Text;
                    var subjectCode = gvVocationalQual.Rows[Row.RowIndex].Cells[1].Text;
                    var gradeName = gvVocationalQual.Rows[Row.RowIndex].Cells[2].Text;

                    var insertVocationals = new Methods();
                    if (gradeName == "Select Grade")
                    {

                    }

                    else
                    {
                        insertVocationals.InsertLearnerResults(personCode, studentName, ULI, UCI, gradeName, subjectCode, subjectName, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);
                    }

                }
                //ignore the gridview if no data exists
            }

            foreach (GridViewRow Row in grdvwOther.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {
                    var subjectName = grdvwOther.Rows[Row.RowIndex].Cells[0].Text;
                    var subjectCode = grdvwOther.Rows[Row.RowIndex].Cells[1].Text;
                    var gradeName = grdvwOther.Rows[Row.RowIndex].Cells[2].Text;

                    var insertOtherGCSEs = new Methods();
                    insertOtherGCSEs.InsertLearnerResults(personCode, studentName, ULI, UCI, gradeName, subjectCode, subjectName, resultsStatus, createdDate, HttpContext.Current.User.Identity.Name);
                }
                //ignore the gridview if no data exists
            }
           }
 
        /// <summary>
        /// Forces page scroll position back to top, 
        /// overriding any active MaintainScrollPositionOnPostback setting.
        /// </summary>
        /// <remarks>
        /// Code from: http://www.4guysfromrolla.com/articles/111407-1.aspx
        /// </remarks>
        protected void ResetScrollPosition()
        {
            if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "CreateResetScrollPosition"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateResetScrollPosition",
                    "function ResetScrollPosition() {\r\n"
                    + "  var scrollX = document.getElementById('__SCROLLPOSITIONX');\r\n"
                    + "  var scrollY = document.getElementById('__SCROLLPOSITIONY');\r\n"
                    + "  if (scrollX && scrollY) {\r\n"
                    + "    scrollX.value = 0;\r\n"
                    + "    scrollY.value = 0;\r\n"
                    + "  }\r\n"
                    + "}\r\n"
                    , true);

                this.ClientScript.RegisterStartupScript(this.GetType(), "CallResetScrollPosition", "ResetScrollPosition();", true);
            }
        }

        protected void EnableUserFields()
        {
            //enables UCI, ULI textboxes if data cannot be found in EBS
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

            if (txtStudentName.Text == "")
            {
                txtStudentName.Enabled = true;
            }
            else
            {
                txtStudentName.Enabled = false;
            }
            // hides this field if learner does not exist in EBS
            if (txtStudentID.Text == "0")
            {
                lblStudentID.Visible = false;
                txtStudentID.Visible = false;
            }
        }

        #endregion
    }

}
