using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class DoctorWeeklySchedule : System.Web.UI.Page
{
    DateTime startDate, endDate, date2, date3, date4, date5, date6;
    DataSet ds, ds1;
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();

    DWS.DoctorWeeklyShedule dws = new DWS.DoctorWeeklyShedule();
    string ToTimeMor, FormTimeMor;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Doctor"] == null && Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            DateTime todayDate = DateTime.Today;
            txtDate.Text = String.Format("{0:yyyy-MM-dd}", todayDate);
            

            if (Session["Doctor"] != null)
            {
                lbldoctor.Visible = false;
                ddlDoctorName.Visible = false;
                setWeekDatesStartAndEndForDoctor();
            }
            else if (Session["Receptionist"] != null)
            {
                lbldoctor.Visible = true;
                ddlDoctorName.Visible = true;
                BindDoctor();
                setWeekDatesStartAndEnd();
            }
        }
    }

    protected void setWeekDatesStartAndEnd()
    {
        DateTime baseDate = Convert.ToDateTime(txtDate.Text);

        string today = Convert.ToString(baseDate.Date);

        string yesterday = Convert.ToString(baseDate.AddDays(-1));
        string thisWeekStart = Convert.ToString(baseDate.AddDays(-(int)baseDate.DayOfWeek));
        string thisWeekEnd = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddDays(7).AddSeconds(-1));
        //string thisWeekEnd = Convert.ToString(thisWeekStart.AddDays(7).AddSeconds(-1));
        string lastWeekStart = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddDays(-7));

        string lastWeekEnd = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddSeconds(-1));

        string thisMonthStart = Convert.ToString(baseDate.AddDays(1 - baseDate.Day));

        string thisMonthEnd = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddMonths(1).AddSeconds(-1));

        string lastMonthStart = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddMonths(-1));

        string lastMonthEnd = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddSeconds(-1));


        startDate = Convert.ToDateTime(thisWeekStart).AddDays(1).Date;
        date2 = Convert.ToDateTime(thisWeekStart).AddDays(2).Date;
        date3 = Convert.ToDateTime(thisWeekStart).AddDays(3).Date;
        date4 = Convert.ToDateTime(thisWeekStart).AddDays(4).Date;
        date5 = Convert.ToDateTime(thisWeekStart).AddDays(5).Date;
        date6 = Convert.ToDateTime(thisWeekStart).AddDays(6).Date;
        endDate = Convert.ToDateTime(thisWeekEnd).Date;

        lblday1.Text = Convert.ToString(startDate.ToString("dd/MM/yyyy"));
        lblday2.Text = Convert.ToString(date2.ToString("dd/MM/yyyy"));
        lblday3.Text = Convert.ToString(date3.ToString("dd/MM/yyyy"));
        lblday4.Text = Convert.ToString(date4.ToString("dd/MM/yyyy"));
        lblday5.Text = Convert.ToString(date5.ToString("dd/MM/yyyy"));
        lblday6.Text = Convert.ToString(date6.ToString("dd/MM/yyyy"));

        DateTime day1 = Convert.ToDateTime(lblday1.Text);
        lbldaynm1.Text = day1.ToString("ddd");

        DateTime day2 = Convert.ToDateTime(lblday2.Text);
        lbldaynm2.Text = day2.ToString("ddd");

        DateTime day3 = Convert.ToDateTime(lblday3.Text);
        lbldaynm3.Text = day3.ToString("ddd");

        DateTime day4 = Convert.ToDateTime(lblday4.Text);
        lbldaynm4.Text = day4.ToString("ddd");

        DateTime day5 = Convert.ToDateTime(lblday5.Text);
        lbldaynm5.Text = day5.ToString("ddd");

        DateTime day6 = Convert.ToDateTime(lblday6.Text);
        lbldaynm6.Text = day6.ToString("ddd");

        string weekstartDateandEndDate = Convert.ToString(lblday1.Text) + "  TO  " + Convert.ToString(lblday6.Text);

        if (ddlDoctorName.SelectedValue != "")
        {
                DataSet ds = new DataSet();
            ds = dws.GetDoctorWeeklyByWeekDetail(Convert.ToInt32(ddlDoctorName.SelectedValue), weekstartDateandEndDate);
            if(ds.Tables[0].Rows.Count>0)
            {
                Add.Text = "Update";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday1.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday1mor.Text = ToTimeMor;
                        txtday1tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday1eve.Text = ToTimeEve;
                        txtday1toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday2.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday2mor.Text = ToTimeMor;
                        txtday2tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday2eve.Text = ToTimeEve;
                        txtday2toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday3.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday3mor.Text = ToTimeMor;
                        txtday3tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday3eve.Text = ToTimeEve;
                        txtday3toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday4.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday4mor.Text = ToTimeMor;
                        txtday4tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday4eve.Text = ToTimeEve;
                        txtday4toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday5.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday5mor.Text = ToTimeMor;
                        txtday5tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday5eve.Text = ToTimeEve;
                        txtday5toeve.Text = FormTimeEve;
                    }
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday6.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday6mor.Text = ToTimeMor;
                        txtday6tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday6eve.Text = ToTimeEve;
                        txtday6toeve.Text = FormTimeEve;
                    }


                }

               
            }

            else
            {
                Add.Text = "Add";
                clear();
            }
           
           
        }
    }



    protected void setWeekDatesStartAndEndForDoctor()
    {
        DateTime baseDate = Convert.ToDateTime(txtDate.Text);

        string today = Convert.ToString(baseDate.Date);

        string yesterday = Convert.ToString(baseDate.AddDays(-1));
        string thisWeekStart = Convert.ToString(baseDate.AddDays(-(int)baseDate.DayOfWeek));
        string thisWeekEnd = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddDays(7).AddSeconds(-1));
        //string thisWeekEnd = Convert.ToString(thisWeekStart.AddDays(7).AddSeconds(-1));
        string lastWeekStart = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddDays(-7));

        string lastWeekEnd = Convert.ToString(Convert.ToDateTime(thisWeekStart).AddSeconds(-1));

        string thisMonthStart = Convert.ToString(baseDate.AddDays(1 - baseDate.Day));

        string thisMonthEnd = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddMonths(1).AddSeconds(-1));

        string lastMonthStart = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddMonths(-1));

        string lastMonthEnd = Convert.ToString(Convert.ToDateTime(thisMonthStart).AddSeconds(-1));


        startDate = Convert.ToDateTime(thisWeekStart).AddDays(1).Date;
        date2 = Convert.ToDateTime(thisWeekStart).AddDays(2).Date;
        date3 = Convert.ToDateTime(thisWeekStart).AddDays(3).Date;
        date4 = Convert.ToDateTime(thisWeekStart).AddDays(4).Date;
        date5 = Convert.ToDateTime(thisWeekStart).AddDays(5).Date;
        date6 = Convert.ToDateTime(thisWeekStart).AddDays(6).Date;
        endDate = Convert.ToDateTime(thisWeekEnd).Date;

        lblday1.Text = Convert.ToString(startDate.ToString("dd/MM/yyyy"));
        lblday2.Text = Convert.ToString(date2.ToString("dd/MM/yyyy"));
        lblday3.Text = Convert.ToString(date3.ToString("dd/MM/yyyy"));
        lblday4.Text = Convert.ToString(date4.ToString("dd/MM/yyyy"));
        lblday5.Text = Convert.ToString(date5.ToString("dd/MM/yyyy"));
        lblday6.Text = Convert.ToString(date6.ToString("dd/MM/yyyy"));

        DateTime day1 = Convert.ToDateTime(lblday1.Text);
        lbldaynm1.Text = day1.ToString("ddd");

        DateTime day2 = Convert.ToDateTime(lblday2.Text);
        lbldaynm2.Text = day2.ToString("ddd");

        DateTime day3 = Convert.ToDateTime(lblday3.Text);
        lbldaynm3.Text = day3.ToString("ddd");

        DateTime day4 = Convert.ToDateTime(lblday4.Text);
        lbldaynm4.Text = day4.ToString("ddd");

        DateTime day5 = Convert.ToDateTime(lblday5.Text);
        lbldaynm5.Text = day5.ToString("ddd");

        DateTime day6 = Convert.ToDateTime(lblday6.Text);
        lbldaynm6.Text = day6.ToString("ddd");

        string weekstartDateandEndDate = Convert.ToString(lblday1.Text) + "  TO  " + Convert.ToString(lblday6.Text);

        if (Session["Doctor"] != null)
        {
            DataSet ds = new DataSet();
            int doctorid =Convert.ToInt32( Session["DoctorId"].ToString());
            ds = dws.GetDoctorWeeklyByWeekDetail(doctorid, weekstartDateandEndDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Add.Text = "Update";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday1.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday1mor.Text = ToTimeMor;
                        txtday1tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday1eve.Text = ToTimeEve;
                        txtday1toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday2.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday2mor.Text = ToTimeMor;
                        txtday2tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday2eve.Text = ToTimeEve;
                        txtday2toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday3.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday3mor.Text = ToTimeMor;
                        txtday3tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday3eve.Text = ToTimeEve;
                        txtday3toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday4.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday4mor.Text = ToTimeMor;
                        txtday4tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday4eve.Text = ToTimeEve;
                        txtday4toeve.Text = FormTimeEve;
                    }

                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday5.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday5mor.Text = ToTimeMor;
                        txtday5tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday5eve.Text = ToTimeEve;
                        txtday5toeve.Text = FormTimeEve;
                    }
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToShortDateString() == lblday6.Text)
                    {
                        string[] spaceSeparator = new string[] { " To " };
                        string[] resultMorning;
                        resultMorning = ds.Tables[0].Rows[i]["Morning"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        ToTimeMor = resultMorning[0];
                        FormTimeMor = resultMorning[1]; ;
                        txtday6mor.Text = ToTimeMor;
                        txtday6tomor.Text = FormTimeMor;

                        string[] resultEvening;
                        resultEvening = ds.Tables[0].Rows[i]["Evening"].ToString().Split(spaceSeparator, StringSplitOptions.None);
                        string ToTimeEve = resultEvening[0];
                        string FormTimeEve = resultEvening[1];
                        txtday6eve.Text = ToTimeEve;
                        txtday6toeve.Text = FormTimeEve;
                    }


                }


            }

            else
            {
                Add.Text = "Add";
                clear();
            }


        }
    }
    protected void BindDoctor()
    {
        ds = new DataSet();

        ds = doctors.GetDoctorDetail();
        ddlDoctorName.DataSource = ds;
        ddlDoctorName.Items.Clear();
        ddlDoctorName.DataTextField = "DoctorName";
        ddlDoctorName.DataValueField = "DoctorId";
        ddlDoctorName.DataBind();
        ddlDoctorName.Items.Insert(0, new ListItem("--Select Doctor Name--", ""));

    }
    protected void txtDte_TextChanged(object sender, EventArgs e)
    {
       
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

            if (Session["Doctor"] != null)
            {
               
                setWeekDatesStartAndEndForDoctor();
            }
            else if (Session["Receptionist"] != null)
            {
                
                setWeekDatesStartAndEnd();
            }
        }
       
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
          

            if (Add.Text == "Add")
            {

                Label[] Date = new Label[] { lblday1, lblday2, lblday3, lblday4, lblday5, lblday6 };
                Label[] days = new Label[] { lbldaynm1, lbldaynm2, lbldaynm3, lbldaynm4, lbldaynm5, lbldaynm6 };
                string day1mor = txtday1mor.Text + " To " + txtday1tomor.Text;
                string day2mor = txtday2mor.Text + " To " + txtday2tomor.Text;
                string day3mor = txtday3mor.Text + " To " + txtday3tomor.Text;
                string day4mor = txtday4mor.Text + " To " + txtday4tomor.Text;
                string day5mor = txtday5mor.Text + " To " + txtday5tomor.Text;
                string day6mor = txtday6mor.Text + " To " + txtday6tomor.Text;

                string[] morning = new string[] { day1mor, day2mor, day3mor, day4mor, day5mor, day6mor };

                string day1eve = txtday1eve.Text + " To " + txtday1toeve.Text;
                string day2eve = txtday2eve.Text + " To " + txtday2toeve.Text;
                string day3eve = txtday3eve.Text + " To " + txtday3toeve.Text;
                string day4eve = txtday4eve.Text + " To " + txtday4toeve.Text;
                string day5eve = txtday5eve.Text + " To " + txtday5toeve.Text;
                string day6eve = txtday6eve.Text + " To " + txtday6toeve.Text;

                string[] evening = new string[] { day1eve, day2eve, day3eve, day4eve, day5eve, day6eve };

                string weekstartDateandEndDate = Convert.ToString(lblday1.Text) + "  TO  " + Convert.ToString(lblday6.Text);
                if (Session["Doctor"] != null)
                {
                    int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());
                    for (int i = 0; i <= 5; i++)
                    {
                        dws.InsertDoctorWeeklyScheduleDetail(doctorId, weekstartDateandEndDate, Convert.ToDateTime(Date[i].Text), Convert.ToString(days[i].Text), Convert.ToString(morning[i]), Convert.ToString(evening[i]));

                    }

                }
                else if (Session["Receptionist"] != null)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        dws.InsertDoctorWeeklyScheduleDetail(Convert.ToInt32(ddlDoctorName.SelectedValue.ToString()), weekstartDateandEndDate, Convert.ToDateTime(Date[i].Text), Convert.ToString(days[i].Text), Convert.ToString(morning[i]), Convert.ToString(evening[i]));

                    }

                }

                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "alertscipt", "alert('Insert Successfully')", true);
                clear();
            }
            else if (Add.Text == "Update")
            {

                Label[] Date = new Label[] { lblday1, lblday2, lblday3, lblday4, lblday5, lblday6 };
                Label[] days = new Label[] { lbldaynm1, lbldaynm2, lbldaynm3, lbldaynm4, lbldaynm5, lbldaynm6 };
                string day1mor = txtday1mor.Text + " To " + txtday1tomor.Text;
                string day2mor = txtday2mor.Text + " To " + txtday2tomor.Text;
                string day3mor = txtday3mor.Text + " To " + txtday3tomor.Text;  
                string day4mor = txtday4mor.Text + " To " + txtday4tomor.Text;
                string day5mor = txtday5mor.Text + " To " + txtday5tomor.Text;
                string day6mor = txtday6mor.Text + " To " + txtday6tomor.Text;

                string[] morning = new string[] { day1mor, day2mor, day3mor, day4mor, day5mor, day6mor };

                string day1eve = txtday1eve.Text + " To " + txtday1toeve.Text;
                string day2eve = txtday2eve.Text + " To " + txtday2toeve.Text;
                string day3eve = txtday3eve.Text + " To " + txtday3toeve.Text;
                string day4eve = txtday4eve.Text + " To " + txtday4toeve.Text;
                string day5eve = txtday5eve.Text + " To " + txtday5toeve.Text;
                string day6eve = txtday6eve.Text + " To " + txtday6toeve.Text;

                string[] evening = new string[] { day1eve, day2eve, day3eve, day4eve, day5eve, day6eve };

                string weekstartDateandEndDate = Convert.ToString(lblday1.Text) + "  TO  " + Convert.ToString(lblday6.Text);
                if (Session["Doctor"] != null)
                {
                    

                }
                else if (Session["Receptionist"] != null)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        DataSet ds = new DataSet();
                        ds = dws.GetDoctorWeeklyByWeekDetail(Convert.ToInt32(ddlDoctorName.SelectedValue), weekstartDateandEndDate);

                        dws.EditDoctorWeeklyScheduleDetail(Convert.ToInt32(ds.Tables[0].Rows[i]["DoctorWeeklyScheduleId"].ToString()), Convert.ToInt32(ddlDoctorName.SelectedValue.ToString()), weekstartDateandEndDate, Convert.ToDateTime(Date[i].Text), Convert.ToString(days[i].Text), Convert.ToString(morning[i]), Convert.ToString(evening[i]));

                    }

                }

                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "alertscipt", "alert('Update Successfully')", true);
                clear();
                Response.Redirect("DoctorWeeklySchedule.aspx");
            }
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
           
        }

        if (ddlDoctorName.SelectedValue == "")
        {
            lblDoctorName.Text = "Select Doctor Name";
            lblDoctorName.Visible = true;
            flag = false;
           
        }
        else
        {
            lblDoctorName.Visible = false;
          
        }


        if (flag == false)
        {
            return false;
        }
        return true;
    }

    public void clear()
    {
        txtday1mor.Text = "";
        txtday1tomor.Text = "";
        txtday1eve.Text = "";
        txtday1toeve.Text = "";

        txtday2mor.Text = "";
        txtday2tomor.Text = "";
        txtday2eve.Text = "";
        txtday2toeve.Text = "";

        txtday3mor.Text = "";
        txtday3tomor.Text = "";
        txtday3eve.Text = "";
        txtday3toeve.Text = "";

        txtday4mor.Text = "";
        txtday4tomor.Text = "";
        txtday4eve.Text = "";
        txtday4toeve.Text = "";

        txtday5mor.Text = "";
        txtday5tomor.Text = "";
        txtday5eve.Text = "";
        txtday5toeve.Text = "";

        txtday6mor.Text = "";
        txtday6tomor.Text = "";
        txtday6eve.Text = "";
        txtday6toeve.Text = "";
    }
    protected void ddlDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        setWeekDatesStartAndEnd();
    }
}