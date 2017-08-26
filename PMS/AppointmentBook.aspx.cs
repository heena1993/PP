using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppointmentBook : System.Web.UI.Page
{
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    DWS.DoctorWeeklyShedule dws = new DWS.DoctorWeeklyShedule();
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();
    int DoctorId, tblDoctorId;
    DateTime tblDate, startTimeMor, endTimeMor, startTimeEve, endTimeEve;
    DataSet ds,ds1;
    
    private static int AppoinmentId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
            txtDate.Text = String.Format("{0:yyyy-MM-dd}", jdt);

            BindPatient();
            BindDoctors();

            loaddata();

        }

    }
    public void SplitData()
    {
        try
        {
            ds = new DataSet();

            if (ddlDoctors.SelectedIndex == 0 )
            {
                DoctorId = 0;

            }
            else
            {
                DoctorId =Convert.ToInt32( ddlDoctors.SelectedValue.ToString());
                DateTime theDate = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                string Date = theDate.ToString("dd-MM-yyyy");
                DateTime Date1 = Convert.ToDateTime(Date);
                ds = dws.GetTimeDetail(DoctorId, Date1);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string Morning = ds.Tables[0].Rows[0]["Morning"].ToString();
                    string Evening = ds.Tables[0].Rows[0]["Evening"].ToString();

                    string[] spaceSeparator = new string[] { " To " };
                    string[] resultMorning;
                    resultMorning = Morning.Split(spaceSeparator, StringSplitOptions.None);
                    string ToTimeMor = resultMorning[0];
                    string FormTimeMor = resultMorning[1];

                    if (ToTimeMor != "")
                    {
                         startTimeMor = DateTime.Parse(ToTimeMor);
                    }
                    if (FormTimeMor != "")
                    {
                         endTimeMor = DateTime.Parse(FormTimeMor);
                    }

                    while (startTimeMor < endTimeMor)
                    {
                        DateTime startTime1Mor = startTimeMor;
                        // System.Console.WriteLine(startTime.ToShortTimeString());

                        startTimeMor = startTimeMor.AddMinutes(30);
                        ddlFromTime.Items.Add(startTime1Mor.ToString("hh:mm tt") + " To " + startTimeMor.ToString("hh:mm tt"));
                       
                    }
                  

                    string[] resultEvening;
                    resultEvening = Evening.Split(spaceSeparator, StringSplitOptions.None);
                    string ToTimeEve = resultEvening[0];
                    string FormTimeEve = resultEvening[1];

                    //TimeSpan diff = TimeSpan.Parse(FormTimeEve) - TimeSpan.Parse(ToTimeEve);

                    if (ToTimeEve != "")
                    {
                       startTimeEve = DateTime.Parse(ToTimeEve);
                    }
                     if (FormTimeEve != "")
                    {
                        endTimeEve = DateTime.Parse(FormTimeEve);
                    }
                    if ((ToTimeMor == "" && FormTimeMor == "") && (ToTimeEve == "" && FormTimeEve == ""))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "alertscipt", "alert('Doctor Not Available')", true);
                    }
                   
                   
                    while (startTimeEve < endTimeEve)
                    {
                        DateTime startTime1Eve = startTimeEve;
                        // System.Console.WriteLine(startTime.ToShortTimeString());

                        startTimeEve = startTimeEve.AddMinutes(30);
                        ddlFromTime.Items.Add(startTime1Eve.ToString("hh:mm tt") + " To " + startTimeEve.ToString("hh:mm tt"));
                    }

                  
                }
                else
                {
                    ShowMessageBox("Doctor Not Available");
                }

            }
          
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }
    }

    public void loaddata()
    {

        try
        {
            ds = new DataSet();
            ds = appoint.GetAppointmentDetails();
            GridAppointment.DataSource = ds;
            GridAppointment.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }

    protected void BindPatient()
    {
        DataSet ds = new DataSet();

        ds = patient.GetPatientDetails();
        ddlPatient.DataSource = ds;
        ddlPatient.Items.Clear();
        ddlPatient.DataTextField = "FullName";
        ddlPatient.DataValueField = "PatientId";
        ddlPatient.DataBind();
        ddlPatient.Items.Insert(0, new ListItem("--Select Patient Name--", ""));

    }

    protected void BindDoctors()
    {
        DataSet ds = new DataSet();
        DateTime Date = Convert.ToDateTime(txtDate.Text);
        ds = doctors.GetDoctorDetailExistbyDate(Date);
        ddlDoctors.DataSource = ds;
        ddlDoctors.Items.Clear();
        ddlDoctors.DataTextField = "DoctorName";
        ddlDoctors.DataValueField = "DoctorId";
        ddlDoctors.DataBind();
        ddlDoctors.Items.Insert(0, new ListItem("--Select Doctors Name--", ""));

    }
    #region All Text Change Event

   
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

        if(Convert.ToDateTime(txtDate.Text) < DateTime.Now.Date)
        {
            lblDateError.Text = "Select  valid Date";
            lblDateError.Visible = true;
           
            txtDate.Focus();
            txtDate.Text = "";
        }
        else
        {
            lblDateError.Visible = false;
            ddlFromTime.Focus();
            BindDoctors();
            SplitData();
           
        }
      
    }
    protected void ddlFromTime_TextChanged(object sender, EventArgs e)
    {
        lblFromtime.Visible = false;
       
    }

   
    protected void ddlPatient_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblPatient.Visible = false;
        ddlDoctors.Focus();
    }
    protected void ddlDoctors_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDoctors.Visible = false;
        ddlFromTime.Focus();
        ddlFromTime.Items.Clear();
        ddlFromTime.SelectedValue = "";
        SplitData();
    }

    protected void ddlFromTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFromtime.Visible = false;
        btnSubmit.Focus();
       
    }
    #endregion


    protected bool ValidatePage()
    {
        bool flag = true;

        if (txtDate.Text.Trim() == "")
        {
            lblDateError.Text = "Select Date";
            lblDateError.Visible = true;
            flag = false;
            txtDate.Focus();
            txtDate.Text = "";
        }
        else
        {
            lblDateError.Visible = false;
            //flag = true;
        }

        if (ddlFromTime.Text.Trim() == "")
        {
            lblFromtime.Text = "Enter Time";
            lblFromtime.Visible = true;
            flag = false;
            ddlFromTime.Focus();
            ddlFromTime.Text = "";
        }
        else
        {
            lblFromtime.Visible = false;
            //flag = true;
        }

        


        if (ddlPatient.SelectedValue == "")
        {
            lblPatient.Text = "Select Patient";
            lblPatient.Visible = true;
            flag = false;
            ddlPatient.Focus();
           
        }
        else
        {
            lblPatient.Visible = false;
            //flag = true;
        }

        if (ddlDoctors.SelectedValue == "")
        {
            lblDoctors.Text = "Select Doctors";
            lblDoctors.Visible = true;
            flag = false;
            ddlDoctors.Focus();
            
        }
        else
        {
            lblDoctors.Visible = false;
            //flag = true;
        }

        if (ddlFromTime.SelectedValue == "")
        {
            lblFromtime.Text = "Select FromTime";
            lblFromtime.Visible = true;
            flag = false;
            ddlDoctors.Focus();

        }
        else
        {
            lblFromtime.Visible = false;
            //flag = true;
        }


        if (flag == false)
        {
            return false;
        }
        return true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            if (btnSubmit.Text == "Submit")
            {
                int regid = Convert.ToInt32(Session["RegId"].ToString());
                appoint.InsertAppointmentDetail(Convert.ToDateTime(txtDate.Text), ddlFromTime.SelectedValue.ToString(), Convert.ToInt32(ddlPatient.SelectedValue), Convert.ToInt32(ddlDoctors.SelectedValue),"Pendding", regid, regid);
                ShowMessageBox("insert Successfully");
                loaddata();
                clear();
            }
            else if (btnSubmit.Text == "Update")
            {
                
            }
        }
        else
        {
            ShowMessageBox("please fill the form");
        }
    }

    public void clear()
    {
       
        ddlFromTime.Items.Clear();
        ddlPatient.SelectedValue = "";
        ddlDoctors.SelectedValue = "";
        btnSubmit.Text = "Submit";
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

    protected void GridAppointment_SelectedIndexChanged(object sender, EventArgs e)
    {
        AppoinmentId = Convert.ToInt32(GridAppointment.SelectedRow.Cells[2].Text);
        //txtDate.Text = GridAppointment.SelectedRow.Cells[3].Text;

        DateTime date = Convert.ToDateTime(GridAppointment.SelectedRow.Cells[3].Text);
        txtDate.Text = String.Format("{0:yyyy-MM-dd}", date);

        ddlFromTime.Text = GridAppointment.SelectedRow.Cells[4].Text;
      
        ddlPatient.SelectedValue = GridAppointment.SelectedRow.Cells[7].Text;
        ddlDoctors.SelectedValue = GridAppointment.SelectedRow.Cells[9].Text;

        txtDate.Focus();
        btnSubmit.Text = "Update";
    }
    #region All Text Change Event
    protected void GridAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridAppointment.PageIndex = e.NewPageIndex;
        loaddata();
        GridAppointment.DataBind();
    }

    #endregion
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList arr;
        if (ViewState["SelectedRecords"] != null)
            arr = (ArrayList)ViewState["SelectedRecords"];
        else
            arr = new ArrayList();
        CheckBox chkAll = (CheckBox)GridAppointment.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < GridAppointment.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                if (!arr.Contains(GridAppointment.DataKeys[i].Value))
                {
                    arr.Add(GridAppointment.DataKeys[i].Value);
                    appoint.DeleteAppointmentDetails(Convert.ToInt32(GridAppointment.DataKeys[i].Value.ToString()));
                    clear();
                }
            }
            else
            {
                CheckBox chk = (CheckBox)GridAppointment.Rows[i]
                                   .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    if (!arr.Contains(GridAppointment.DataKeys[i].Value))
                    {
                        arr.Add(GridAppointment.DataKeys[i].Value);

                        appoint.DeleteAppointmentDetails(Convert.ToInt32(GridAppointment.DataKeys[i].Value.ToString()));
                        clear();
                    }
                }
                else
                {
                    if (arr.Contains(GridAppointment.DataKeys[i].Value))
                    {
                        arr.Remove(GridAppointment.DataKeys[i].Value);
                    }
                }
            }
        }
        ViewState["SelectedRecords"] = arr;
        loaddata();
    }

    #region GridAppointment Event

    protected void GridAppointment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridAppointment.EditIndex = e.NewEditIndex;
        loaddata();
        
    }
    protected void GridAppointment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int AppoitnmentId = Convert.ToInt32(GridAppointment.DataKeys[e.RowIndex].Values[0]);
        TextBox txtDate = (TextBox)GridAppointment.Rows[e.RowIndex].FindControl("txtDate");
        DropDownList ddlFromTime = (DropDownList)GridAppointment.Rows[e.RowIndex].FindControl("ddlFromTime");
        TextBox txtToTime = (TextBox)GridAppointment.Rows[e.RowIndex].FindControl("txtToTime");
        DropDownList ddlPatientId = (DropDownList)GridAppointment.Rows[e.RowIndex].FindControl("ddlPatientId");
        DropDownList ddlDoctorId = (DropDownList)GridAppointment.Rows[e.RowIndex].FindControl("ddlDoctorId");

        int regid = Convert.ToInt32(Session["RegId"].ToString());
        appoint.EditAppointmentDetail(AppoitnmentId, Convert.ToDateTime(txtDate.Text),ddlFromTime.SelectedValue.ToString(), Convert.ToInt32(ddlPatientId.SelectedValue), Convert.ToInt32(ddlDoctorId.SelectedValue), regid);
        ShowMessageBox("Update Successfully");
        GridAppointment.EditIndex = -1;
        loaddata();
    }
    protected void GridAppointment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridAppointment.Rows[e.RowIndex];
        int AppointmentId = Convert.ToInt32(GridAppointment.DataKeys[e.RowIndex].Values[0]);
        appoint.DeleteAppointmentDetails(AppointmentId);
        ShowMessageBox("Delete Successfully");

        GridAppointment.EditIndex = -1;
        loaddata();
    }
    protected void GridAppointment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridAppointment.EditIndex = -1;

        loaddata();
    }
    protected void GridAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
    protected void GridAppointment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowState.HasFlag(DataControlRowState.Edit) && (e.Row.DataItem != null)))
        {
            DropDownList ddlPatientId = (DropDownList)e.Row.FindControl("ddlPatientId") as DropDownList;
            DropDownList ddlDoctorId = (DropDownList)e.Row.FindControl("ddlDoctorId") as DropDownList;
            HiddenField HiddenPatientId = (HiddenField)e.Row.FindControl("HiddenPatientId") as HiddenField;
            HiddenField HiddenDoctorId = (HiddenField)e.Row.FindControl("HiddenDoctorId") as HiddenField;
            ds = new DataSet();

            ds = patient.GetPatientDetails();
            ddlPatientId.DataSource = ds;
          //  ddlPatientId.Items.Clear();
            ddlPatientId.DataTextField = "FullName";
            ddlPatientId.DataValueField = "PatientId";
            ddlPatientId.DataBind();
            ddlPatientId.Items.Insert(0, new ListItem("--Select Patient Name--", ""));
            ddlPatientId.Items.FindByValue(HiddenPatientId.Value).Selected = true;


            ds1 = new DataSet();

            ds1 = doctors.GetDoctorDetail();
            ddlDoctorId.DataSource = ds1;
           // ddlDoctorId.Items.Clear();
            ddlDoctorId.DataTextField = "DoctorName";
            ddlDoctorId.DataValueField = "DoctorId";
            ddlDoctorId.DataBind();
            ddlDoctorId.Items.Insert(0, new ListItem("--Select Doctors Name--", ""));
            ddlDoctorId.Items.FindByValue(HiddenDoctorId.Value).Selected = true;

        }
    }

    #endregion

   
}