using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoctorWiseViewPatientDetails : System.Web.UI.Page
{
    PatientCheckUp.PatientChecup pCheckUP = new PatientCheckUp.PatientChecup();

    DataSet ds;

    DataSet ds1, ds2, ds3, ds4;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Doctor"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            getPatientCheckUPDetailsDoctorsWise();
        }
    }


    protected void getPatientCheckUPDetailsDoctorsWise()
    {
        try
        {
            int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = pCheckUP.GetPatientCheckUPDetailsByDoctorsId(doctorId);
            GridPatientCheckUp.DataSource = ds;
            GridPatientCheckUp.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }

    private void ShowMessageBox(string sMessage)
    {
        try
        {
            Page p = (Page)System.Web.HttpContext.Current.Handler;
            p.ClientScript.RegisterStartupScript(p.GetType(), "OnLoad", "<script>alert('" + sMessage + "');</script>");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void GridPatientCheckUp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.DataItem != null))
        {
            Label lblDieasesId = (Label)e.Row.FindControl("lblDieasesId") as Label;
            Label lblTestId = (Label)e.Row.FindControl("lblTestId") as Label;
            Label lblPatientCheckupId = (Label)e.Row.FindControl("lblPatientId") as Label;
            // Label lblTestReport = (Label)e.Row.FindControl("lblTestReport") as Label;
            HiddenField hfPatientId = (HiddenField)e.Row.FindControl("hfPatientId");

            lblDieasesId.Text = "";
            HiddenField hfCaseNo = (HiddenField)e.Row.FindControl("hfCaseNo");

            ds1 = new DataSet();

            ds1 = pCheckUP.GetPatientDieasesDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNo.Value), Convert.ToInt32(hfPatientId.Value));

            for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
            {
                lblDieasesId.Text = lblDieasesId.Text + ds1.Tables[0].Rows[i]["DieasesName"].ToString();
                lblDieasesId.Text = lblDieasesId.Text + ",";
            }

            ds2 = new DataSet();
            ds2 = pCheckUP.GetPatientTestDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNo.Value), Convert.ToInt32(hfPatientId.Value));

            for (int i = 0; ds2.Tables[0].Rows.Count > i; i++)
            {
                lblTestId.Text = lblTestId.Text + ds2.Tables[0].Rows[i]["TestName"].ToString();
                lblTestId.Text = lblTestId.Text + ",";

                //lblTestReport.Text = lblTestReport.Text + ds2.Tables[0].Rows[i]["TestReport"].ToString();
                //lblTestReport.Text = lblTestReport.Text + ",";
            }


        }
    }
    protected void GridPatientCheckUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridPatientCheckUp.PageIndex = e.NewPageIndex;
        getPatientCheckUPDetailsDoctorsWise();
        GridPatientCheckUp.DataBind();
    }
}