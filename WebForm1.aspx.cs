using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
namespace GCSEMatrix
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OracleCommand cmd;
        OracleDataAdapter da;
        DataSet ds;

        string strConn = ConfigurationManager.ConnectionStrings["ebstrainROConnectionString"].ConnectionString;
        OracleConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadingDataToParentRepeater();
        }

        private void LoadingDataToParentRepeater()
        {
            con = new OracleConnection(strConn);
            con.Open();
            try
            {
                string sql = "SELECT SUBJECT_NAME, SUBJECT_CODE, SUBJECT_VALUE FROM NPTCG_MATRIX_SUBJECT WHERE SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')";
                cmd = new OracleCommand(sql, con);
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                rptParent.DataSource = ds;
                rptParent.DataBind();

                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var rptchild = (Repeater)e.Item.FindControl("rptChild");
                string sql = @"SELECT NPTC_R.PERSON_CODE, NPTC_R.ULI_NUMBER, nptc_r.UCI_NUMBER, NPTC_R.STUDENT_NAME, nptc_R.UCI_NUMBER, nptc_r.Grade_NAME, nptc_r.SUBJECT_NAME, NPTC_R.SUBJECT_CODE FROM ROBERTW.NPTCG_MATRIX_LEARNER_RESULTS NPTC_R WHERE NPTC_R.PERSON_CODE = 236948 AND NPTC_R.SUBJECT_CODE IN ('GCSEFULL','GCSESHORT')";
                cmd = new OracleCommand(sql,con);
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                rptchild.DataSource = ds;
                rptchild.DataBind();

                cmd.Dispose();
                con.Close();
            }
        }

    }
}