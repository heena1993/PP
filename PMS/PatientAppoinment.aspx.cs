using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PatientAppoinment : System.Web.UI.Page
{
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    AppoinmentTemp.AppoinmentBookTemp AppointmentTemp = new AppoinmentTemp.AppoinmentBookTemp();
    DWS.DoctorWeeklyShedule dws = new DWS.DoctorWeeklyShedule();
   
    DataSet ds, ds1;
    DateTime tblDate, startTimeMor, endTimeMor, startTimeEve, endTimeEve;
    int DoctorId, tblDoctorId;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Patient"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            DateTime jdt = Convert.ToDateTime(DateTime.Now.ToString());
            txtDate.Text = String.Format("{0:yyyy-MM-dd}", jdt);
            txtPatient.Text = Session["FullName"].ToString();
         
            BindDoctors();

        }
    }
    protected void BindDoctors()
    {
        DataSet ds = new DataSet();
        DateTime Date =Convert.ToDateTime(txtDate.Text);
        ds = doctors.GetDoctorDetailExistbyDate(Date);
        ddlDoctors.DataSource = ds;
        ddlDoctors.Items.Clear();
        ddlDoctors.DataTextField = "DoctorName";
        ddlDoctors.DataValueField = "DoctorId";
        ddlDoctors.DataBind();
        ddlDoctors.Items.Insert(0, new ListItem("--Select Doctors Name--", ""));

    }

    public void SplitData()
    {
        try
        {
            ds = new DataSet();

            if (ddlDoctors.SelectedIndex == 0)
            {
                DoctorId = 0;

            }
            else
            {
                DoctorId = Convert.ToInt32(ddlDoctors.SelectedValue.ToString());
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

                   // TimeSpan diff = TimeSpan.Parse(FormTimeEve) - TimeSpan.Parse(ToTimeEve);

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

                }

            }

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if(ValidatePage())
        {
            if (btnSubmit.Text == "Submit")
            {
                int PatientId = Convert.ToInt32(Session["PatientId"].ToString());
                AppointmentTemp.InsertAppointmentDetailTemp(Convert.ToDateTime(txtDate.Text), ddlFromTime.SelectedValue.ToString(), PatientId, Convert.ToInt32(ddlDoctors.SelectedValue), "Pendding", PatientId, PatientId);
                ShowMessageBox("INSERT SUCCESSFULLY");
            }
        }
        else
        {
            ShowMessageBox("please fill the form");
        }
    }
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

        if (txtPatient.Text == "")
        {
            lblPatient.Text = "Select Patient";
            lblPatient.Visible = true;
            flag = false;
            txtPatient.Focus();

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
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtDate.Text) < DateTime.Now.Date)
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
   
    protected void txtPatient_TextChanged(object sender, EventArgs e)
    {
        lblPatient.Visible = false;
        ddlDoctors.Focus();
    }
}