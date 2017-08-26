using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AppoinmentApproval : System.Web.UI.Page
{
    AppoinmentTemp.AppoinmentBookTemp AppointTemp = new AppoinmentTemp.AppoinmentBookTemp();
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAppointmentApprovalDetails();
        }
    }

    protected void getAppointmentApprovalDetails()
    {
    
        try
        {
            
            ds = new DataSet();
            ds = AppointTemp.GetAppointmentDetailTempDetail();

            GridAppoinmentApproval.DataSource = ds;
            GridAppoinmentApproval.DataBind();
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

    protected void GridAppoinmentApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridAppoinmentApproval.PageIndex = e.NewPageIndex;
        getAppointmentApprovalDetails();
        GridAppoinmentApproval.DataBind();
    }
    protected void LinkApproval_Command(object sender, CommandEventArgs e)
    {
          int regid = Convert.ToInt32(Session["RegId"].ToString());

          string[] args = new string[3];
          args = e.CommandArgument.ToString().Split(';');

       
         int id = Convert.ToInt32(args[0]);
         int PatientId = Convert.ToInt32(args[1]);
        string Status=args[2];
        if (Status == "Pendding")
        {
          AppointTemp.EditAppointmentStatus(id, "Approve", regid);
          ds = new DataSet();
          ds = AppointTemp.GetAppointmentDetailTempDetailByPatientId(PatientId);
          DateTime Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"].ToString());
          string Time = ds.Tables[0].Rows[0]["Time"].ToString();
        
          int DoctorId = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorId"].ToString());
          string AppoinmentStatus = "Pendding";
          appoint.InsertAppointmentDetail(Date, Time, PatientId, DoctorId, AppoinmentStatus,regid,regid);
          ShowMessageBox("Insert Successfully in Appoinment Table");
          getAppointmentApprovalDetails();
        }
        else
        {

        }
    }
   
}   