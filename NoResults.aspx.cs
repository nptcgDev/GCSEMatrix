using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCSEMatrix
{
    public partial class NoResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnReturnToOntrack_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://ebsontrackhub.ad.nptcgroup.ac.uk");
        }
    }
}