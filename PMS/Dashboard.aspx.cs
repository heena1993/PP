using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Dashboard : System.Web.UI.Page
{
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();
    int DoctorId, tblDoctorId;
    DateTime tblDate;
    DataSet ds, ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        getTodayAppointmentDetailsToAdmin();

       
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

            GridAppointment.DataSource = ds;
            GridAppointment.DataBind();
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
   
    protected void GridAppointment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow)  && (e.Row.DataItem != null))
        {
            //for (int i = 0; i <ds.Tables[0].Rows.Count;i++)
            //{
            //    if (ds.Tables[0].Rows[i]["AppoinmentStatus"].ToString() == "Done")
            //    {
            //        LinkButton Linkcheckup = (LinkButton)e.Row.FindControl("Linkcheckup") as LinkButton;
            //        Linkcheckup.Enabled = false;
            //    }
            //    else
            //    {
            //        LinkButton Linkcheckup = (LinkButton)e.Row.FindControl("Linkcheckup") as LinkButton;
            //        Linkcheckup.Enabled = true;
            //    }
            //}
        }
    }
   
    protected void Linkcheckup_Command1(object sender, CommandEventArgs e)
    {
       
           
                string[] args = new string[3];
                args = e.CommandArgument.ToString().Split(';');

                int PatientId = Convert.ToInt32(args[0]);
                int AppoinmentId = Convert.ToInt32(args[1]);
                string Date = args[2];
                string Time = args[3];

                Response.Redirect("AddPatientCheckUPDetails.aspx?PatientId=" + PatientId + "&AppoinmentId=" + AppoinmentId + " &Date=" + Date + "&Time=" + Time + "");

    }
}