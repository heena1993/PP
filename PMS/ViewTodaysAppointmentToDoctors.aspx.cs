using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewTodaysAppointmentToDoctors : System.Web.UI.Page
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

                getTodayAppointmentDetailsDoctorsWise();
            }
            else if (Session["Receptionist"] != null)
            {
                getTodayAppointmentDetailsToAdmin();
            }


        }
    }

    protected void getTodayAppointmentDetailsDoctorsWise()
    {
         DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
           string todaydate = String.Format("{0:yyyy-MM-dd}", jdt);
        try
        {
            int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = appoint.GetAppointmentDetailsByTodayDateDoctorwise(Convert.ToDateTime(todaydate) , doctorId);
            GridTodayAppointmntTODoctors.Visible = true;
            GridTodayAppointmntTOAdmin.Visible = false;
            GridTodayAppointmntTODoctors.DataSource = ds;
            GridTodayAppointmntTODoctors.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }

    protected void getTodayAppointmentDetailsToAdmin()
    {
        DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
        string todaydate = String.Format("{0:yyyy-MM-dd}", jdt);
        try
        {
            //int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = appoint.GetAppointmentDetailsByTodayDate(Convert.ToDateTime(todaydate));
            GridTodayAppointmntTODoctors.Visible = false;
            GridTodayAppointmntTOAdmin.Visible = true;
            GridTodayAppointmntTOAdmin.DataSource = ds;
            GridTodayAppointmntTOAdmin.DataBind();
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
            GridTodayAppointmntTODoctors.Visible = true;
            GridTodayAppointmntTOAdmin.Visible = false;
            GridTodayAppointmntTODoctors.PageIndex = e.NewPageIndex;
            getTodayAppointmentDetailsDoctorsWise();
            GridTodayAppointmntTODoctors.DataBind();
        }
        else if (Session["Receptionist"] != null)
        {
            GridTodayAppointmntTODoctors.Visible = false;
            GridTodayAppointmntTOAdmin.Visible = true;
            GridTodayAppointmntTOAdmin.PageIndex = e.NewPageIndex;
            getTodayAppointmentDetailsToAdmin();
            GridTodayAppointmntTOAdmin.DataBind();
        }
    }
}