using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewFutureAppointmentToDoctors : System.Web.UI.Page
{
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();

    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Doctor"] == null && Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            if (Session["Doctor"] != null)
            {

                getFutureAppointmentDetailsDoctorsWise();
            }
            else if (Session["Receptionist"] != null)
            {
                getFutureAppointmentDetailsToAdmin();
            }

        }
    }

    protected void getFutureAppointmentDetailsDoctorsWise()
    {
        DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
        string todaydate = String.Format("{0:yyyy-MM-dd}", jdt);
        try
        {
            int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = appoint.GetAppointmentDetailsByFutureDateDoctorwise(Convert.ToDateTime(todaydate), doctorId);
            GridFutureAppointmntTODoctors.Visible = true;
            GridFutureAppointmntTOAdmin.Visible = false;
            GridFutureAppointmntTODoctors.DataSource = ds;
            GridFutureAppointmntTODoctors.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }

    protected void getFutureAppointmentDetailsToAdmin()
    {
        DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
        string todaydate = String.Format("{0:yyyy-MM-dd}", jdt);
        try
        {
            //int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = appoint.GetAppointmentDetailsByFutureDate(Convert.ToDateTime(todaydate));
            GridFutureAppointmntTODoctors.Visible = false;
            GridFutureAppointmntTOAdmin.Visible = true;
            GridFutureAppointmntTOAdmin.DataSource = ds;
            GridFutureAppointmntTOAdmin.DataBind();
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


    protected void GridPatientCheckUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       

        if (Session["Doctor"] != null)
        {
            GridFutureAppointmntTODoctors.Visible = true;
            GridFutureAppointmntTOAdmin.Visible = false;
            GridFutureAppointmntTODoctors.PageIndex = e.NewPageIndex;
            getFutureAppointmentDetailsDoctorsWise();
            GridFutureAppointmntTODoctors.DataBind();
        }
        else if (Session["Receptionist"] != null)
        {
            GridFutureAppointmntTODoctors.Visible = false;
            GridFutureAppointmntTOAdmin.Visible = true;
            GridFutureAppointmntTOAdmin.PageIndex = e.NewPageIndex;
            getFutureAppointmentDetailsToAdmin();
            GridFutureAppointmntTOAdmin.DataBind();
        }

    }
}