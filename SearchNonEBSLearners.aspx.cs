using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCSEMatrix
{
    public partial class SearchNonEBSLearners : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RptSearchNonEBSLearners_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpt = sender as Repeater;
            if (rpt.Items.Count == 0)
            {
                // Execute the following if statement for Footer only.
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label NoResults = (Label)e.Item.FindControl("NoResults");
                    NoResults.Visible = true;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string full_name = txtstudent_name.Text;

        }

    }
}