using GCSEMatrix.DAO;
using System;
using System.Configuration;
using System.Data;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Web.UI.WebControls;
namespace GCSEMatrix
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //   Int32 personCode = Convert.ToInt32(txtperson_code.Text);
            string full_name = txtstudent_name.Text;

        }

        protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                Label lblRecordExists = (Label)ri.FindControl("lblRecordExists");
                // if a record of this person exists in learner results table, hide the add results button
                if (lblRecordExists.Text == "Y")
                {
                    HyperLink lnkDetails = (HyperLink)ri.FindControl("lnkDetails");
                    lnkDetails.Visible = false;
                }
            }
        }

        protected void btnSearchNonEBSPeople_Click(object sender, EventArgs e)
        {

        }


    }
}