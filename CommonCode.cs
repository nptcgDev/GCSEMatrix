using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace GCSEMatrix
{
    public class CommonCode

    {
        // Method used to filter the grades available to vocational subjects based on their subject code
        public void FilterVocationalGrades(DropDownList ddlSubject, DropDownList ddlGrade)
        {
            ddlGrade.Items.Clear();
            ddlGrade.Items.Insert(0, new ListItem("Select Grade", "SELECT"));
            ddlGrade.Items.Insert(1, new ListItem("PASS", "PASS"));
            ddlGrade.Items.Insert(2, new ListItem("MERIT", "MERIT"));
            ddlGrade.Items.Insert(3, new ListItem("DIST", "DIST"));
            ddlGrade.Items.Insert(4, new ListItem("DIST*", "DIST*"));
            ddlGrade.Items.Insert(5, new ListItem("A*", "A*"));
            ddlGrade.Items.Insert(6, new ListItem("A", "A"));
            ddlGrade.Items.Insert(7, new ListItem("B", "B"));
            ddlGrade.Items.Insert(8, new ListItem("C", "C"));


            switch (ddlSubject.SelectedValue)
            {
                case "SELECT":
                    ddlGrade.Items.FindByValue("PASS").Enabled = false;
                    ddlGrade.Items.FindByValue("MERIT").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST*").Enabled = false;
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;
                    break;
                case "BTEC-AW2":
                case "ASDAN-L1-AW":
                case "ASDAN-L2-AW":
                case "ASDAN-L1-CERT":
                case "PRINCE-L2-CERT":
                case "EAL-L2":
                case "EDEXCEL-L2":
                case "SPORTLEAD-L1":
                case "SPORTLEAD-L2":
                case "CANDG-L2":
                case "BTEC-AW-L1-OG":
                    ddlGrade.Items.FindByValue("SELECT").Enabled = false;
                    ddlGrade.Items.FindByValue("MERIT").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST*").Enabled = false;
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;
                    break;


                case "BTEC-EC2":
                case "BTEC-CE2":
                case "BTEC-D12":
                case "L1L2/B":
                case "WJEC-CE2":
                case "TLM-L1":
                case "TLM-L2":
                case "LIBF-L2":
                    ddlGrade.Items.FindByValue("SELECT").Enabled = false;
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;
                    break;


                case "ONAT-FA2":
                case "ONAT-AW2":
                case "ONAT-FC2":
                    ddlGrade.Items.FindByValue("SELECT").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST*").Enabled = false;
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;
                    break;


                case "WJEC-L2-MATHS":
                    ddlGrade.Items.FindByValue("SELECT").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST*").Enabled = false;
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;

                    break;


                case "NCFE-L2":
                    ddlGrade.Items.FindByValue("SELECT").Enabled = false;
                    ddlGrade.Items.FindByValue("PASS").Enabled = false;
                    ddlGrade.Items.FindByValue("MERIT").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST").Enabled = false;
                    ddlGrade.Items.FindByValue("DIST*").Enabled = false;
                    break;
            }

        }
        
        public void FilterGcseGrades(Label lblSubject, DropDownList ddlGrade)
        {
            switch (lblSubject.Text)
            {
                // checks if records of this learner exists in learner results table 
                case "WBQ/1&2 - Skills Challenge Welsh Bacc National":
                    ddlGrade.Items.FindByValue("D").Enabled = false;
                    ddlGrade.Items.FindByValue("E").Enabled = false;
                    ddlGrade.Items.FindByValue("F").Enabled = false;
                    ddlGrade.Items.FindByValue("G").Enabled = false;
                    ddlGrade.Items.FindByValue("P*").Enabled = false;
                    ddlGrade.Items.FindByValue("P").Enabled = false;
                    break;
                case "WBQ/1&2 - Skills Challenge Welsh Bacc Foundation":
                    ddlGrade.Items.FindByValue("A*").Enabled = false;
                    ddlGrade.Items.FindByValue("A").Enabled = false;
                    ddlGrade.Items.FindByValue("B").Enabled = false;
                    ddlGrade.Items.FindByValue("C").Enabled = false;
                    ddlGrade.Items.FindByValue("D").Enabled = false;
                    ddlGrade.Items.FindByValue("E").Enabled = false;
                    ddlGrade.Items.FindByValue("F").Enabled = false;
                    ddlGrade.Items.FindByValue("G").Enabled = false;
                    break;
                default:
                    // this applies to GCSE Grades (GCSEFULL, GCSESHORT)
                    ddlGrade.Items.FindByValue("P*").Enabled = false;
                    ddlGrade.Items.FindByValue("P").Enabled = false;
                    break;
            }
        }

        public string GetPersonCodeFromUrl()
        {
            string personCode = HttpContext.Current.Request.QueryString["personCode"];

            // redirect to FACE if the url does not contain a person code

            if (string.IsNullOrEmpty(personCode))
            {
              //  personCode = "236948";
                HttpContext.Current.Response.Redirect("http://ebsontrackhub.ad.nptcgroup.ac.uk/Page");

               // HttpContext.Current.Response.Redirect("Index.aspx");
            }

            return personCode;
        }
    }
}