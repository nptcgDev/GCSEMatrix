using GCSEMatrix.DAO;
using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.WebControls;
namespace GCSEMatrix
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CommonCode getPersonCode = new CommonCode();
              // lbPersonCode.Text = "255577";
                lbPersonCode.Text = getPersonCode.GetPersonCodeFromUrl();
                modalPopupEx.Show();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            

        }


        protected void btnSearchForAnotherLearner_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://ebsontrackhub.ad.nptcgroup.ac.uk/Page");
        }

        protected void BtnYesResults_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddResults.aspx?person_code=" + lbPersonCode.Text);
        }

        protected void BtnNoResults_Click(object sender, EventArgs e)
        {

            var insertNoResults = new Methods();

            insertNoResults.InsertNoResults(Convert.ToInt32(lbPersonCode.Text), DateTime.Now, HttpContext.Current.User.Identity.Name);

            Response.Redirect("NoResults.aspx");

        }

        protected void RptSearchResults_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {

            foreach (RepeaterItem ri in RptSearchResults.Items)
            {
                var learnerHasNoResultsCheck = (Label)ri.FindControl("lblResultsStatus");
                var resultsPageLink = (HyperLink)ri.FindControl("lnkAddResults");
                var noResultsCheckMessage = (Label)ri.FindControl("lblNoResultsMessage");

                if (learnerHasNoResultsCheck.Text == "0")
                {

                    resultsPageLink.Visible = false;
                    noResultsCheckMessage.Visible = true;
                }

            }

        }
    }
}