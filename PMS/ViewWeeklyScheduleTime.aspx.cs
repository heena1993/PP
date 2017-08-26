using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewWeeklyScheduleTime : System.Web.UI.Page
{
    DWS.DoctorWeeklyShedule dws = new DWS.DoctorWeeklyShedule();
    DataSet ds,ds1;
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
                bindWeeklyscheduleDataByDostorID();
               
            }
            else if (Session["Receptionist"] != null)
            {

                bindWeeklyscheduleData();
            }

        }
    }

    protected void bindWeeklyscheduleData()
    {
        try
        {
            //int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = dws.GetDoctorsWeeklyScheDuleDetail();

            GridWeeklySchedule.DataSource = ds;
            GridWeeklySchedule.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }
    }

    protected void bindWeeklyscheduleDataByDostorID()
    {
        try
        {
            //int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
            ds = new DataSet();
            ds = dws.GetDoctorsWeeklyScheDuleDetailByDoctorsID(Convert.ToInt32(Session["DoctorId"]));

            GridWeeklySchedule.DataSource = ds;
            GridWeeklySchedule.DataBind();
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


    protected void GridWeeklySchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        if (Session["Doctor"] != null)
        {
            e.Row.Cells[0].Visible = false;
            GridWeeklySchedule.Columns[1].Visible = false; 
          //  e.Row.Cells[2].Visible = false;

        }
        else if (Session["Receptionist"] != null)
        {

            
        }
        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.DataItem != null))
        {
            HiddenField hfWeekStartDateEndDate = (HiddenField)e.Row.FindControl("hfWeekStartDateEndDate");
            GridView GridWeeklyScheduleByStartDateAndEndDate = e.Row.FindControl("GridWeeklyScheduleByStartDateAndEndDate") as GridView;

            ds1 = new DataSet();
            ds1 = dws.GetDoctorsWeeklyScheDuleDetailByWeekStartDateEndDate(hfWeekStartDateEndDate.Value);

            GridWeeklyScheduleByStartDateAndEndDate.DataSource = ds1;
            GridWeeklyScheduleByStartDateAndEndDate.DataBind();
        }
    }
    protected void GridWeeklySchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
    }
}