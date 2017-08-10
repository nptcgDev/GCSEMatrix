using System;
namespace GCSEMatrix
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Int32 personCode = Convert.ToInt32(txtperson_code.Text);
        }

    }
}