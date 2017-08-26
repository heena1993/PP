using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPatientCheckUPDetails : System.Web.UI.Page
{
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();
    DM.MedicalDiagnosis dm = new DM.MedicalDiagnosis();
    PatientCheckUp.PatientChecup pCheckUp = new PatientCheckUp.PatientChecup();
    DateTime today;


    public static int caseno = 1;
    public static string casestr = "Case-";

    public static string caseid = "";

    DataSet ds, ds1, ds2, ds3, ds4;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            today = Convert.ToDateTime(DateTime.Now.ToString());
            txtdate.Text = String.Format("{0:dd-MMM-yyyy}", today);

            BindDieases();
            BindTest();
          

            if (Request.QueryString["PatientId"] != null)
            {
                BindPatient();
                string PatientId =Convert.ToString(Request.QueryString["PatientId"]);
                ddlPatientName.SelectedValue = PatientId;
                bindpatientDetailsById();
               
            }
            else
            {
                BindPatient();
            }

            if (Request.QueryString["Date"] != null && Request.QueryString["Time"] != null)
            {
                string AppoinmentId = Convert.ToString(Request.QueryString["AppoinmentId"]);
                string Date = Convert.ToString(Request.QueryString["Date"]);
                string Time = Convert.ToString(Request.QueryString["Time"]);
                string datetime = Convert.ToString(Date + "--" + Time);
                ddlAppointmentTime.Items.Add(new ListItem(datetime, AppoinmentId));
               
                bindAppointmentDetailsById();
            }
            else
            {
                BindAppointment();
            }
           
        }
    }

    #region Bind Patient Dieases Test
    protected void BindPatient()
    {
        DataSet ds = new DataSet();

        ds = patient.GetPatientDetails();
        ddlPatientName.DataSource = ds;
        ddlPatientName.Items.Clear();
        ddlPatientName.DataTextField = "FullName";
        ddlPatientName.DataValueField = "PatientId";
        ddlPatientName.DataBind();
        ddlPatientName.Items.Insert(0, new ListItem("--Select Patient Name--", ""));

    }

    protected void BindDieases()
    {
        DataSet ds = new DataSet();

        ds = dm.GetDieasesDetails();
        chklistdieases.DataSource = ds;
        chklistdieases.Items.Clear();
        chklistdieases.DataTextField = "DieasesName";
        chklistdieases.DataValueField = "DieasesId";
        chklistdieases.DataBind();
        //chklistdieases.Items.Insert(0, new ListItem("--Select Dieases Name--", ""));

    }

    protected void BindTest()
    {
        DataSet ds = new DataSet();

        ds = dm.GetTestDetails();
        chklistTest.DataSource = ds;
        chklistTest.Items.Clear();
        chklistTest.DataTextField = "TestName";
        chklistTest.DataValueField = "TestId";
        chklistTest.DataBind();
        //chklistTest.Items.Insert(0, new ListItem("--Select Test Name--", ""));

    }

    protected void BindAppointment()
    {
        DataSet ds = new DataSet();

        ds = appoint.GetAppointmentDetails();
        ddlAppointmentTime.DataSource = ds;
        DateTime t1;
        string date,time;
        string AppoinmentId;
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            AppoinmentId = ds.Tables[0].Rows[i]["AppoinmentId"].ToString();
            t1 =Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
            date = t1.ToShortDateString();
            time =ds.Tables[0].Rows[i]["Time"].ToString();
            string datetime =Convert.ToString( date + "--" + time);
            ddlAppointmentTime.Items.Add(new ListItem(datetime, AppoinmentId));
        }

        //ddlAppointmentTime.Items.Clear();
        //ddlAppointmentTime.DataTextField = "Date";
        //ddlAppointmentTime.DataValueField = "AppoinmentId";
        //ddlAppointmentTime.DataBind();

        //ddlAppointmentTime.Items.Insert(0, new ListItem("--Select Appointment Date--", ""));
    }

    #endregion


    protected void bindpatientDetailsById()
    {
        ds1 = new DataSet();

        ds1 = patient.GetPatientDetailByID(Convert.ToInt32(ddlPatientName.SelectedValue));

        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblPatientName.Text = "   " + ds1.Tables[0].Rows[0]["FullName"].ToString();

            lblAddress.Text = "  " + ds1.Tables[0].Rows[0]["Address"].ToString()
                            + "City  : " + ds1.Tables[0].Rows[0]["CityName"].ToString()
                            + " - " + ds1.Tables[0].Rows[0]["Pincode"].ToString()
                            + "<br />State  : " + ds1.Tables[0].Rows[0]["StateName"].ToString()
                            + "<br />Country  : " + ds1.Tables[0].Rows[0]["name"].ToString();
            lblBDate.Text = "  " + ds1.Tables[0].Rows[0]["BirthDate"].ToString();
            lblAge.Text = "  " + ds1.Tables[0].Rows[0]["Age"].ToString();

            patientimage.ImageUrl = ("Profile/Patients/" + ds1.Tables[0].Rows[0]["Photo"].ToString());
        }
        ds1.Clear();
    }

    protected void bindAppointmentDetailsById()
    {
        ds1 = new DataSet();

        ds1 = appoint.GetAppointmentDetailsByPatientID(Convert.ToInt32(ddlPatientName.SelectedValue), Convert.ToDateTime(txtdate.Text));

        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblAppointmentDate.Text = ds1.Tables[0].Rows[0]["Date"].ToString();
            lblFromTime.Text = ds1.Tables[0].Rows[0]["Time"].ToString();
            //lblToTime.Text = ds1.Tables[0].Rows[0]["ToTime"].ToString();
            ddlAppointmentTime.SelectedValue = ds1.Tables[0].Rows[0]["AppoinmentId"].ToString();

        }
        ds1.Clear();
    }

    protected bool ValidatePage()
    {
        bool flag = true;

        if (ddlPatientName.SelectedValue == "")
        {
            lblPatientNameError.Text = "Select Patient";
            lblPatientNameError.Visible = true;
            flag = false;
            ddlPatientName.Focus();

        }
        else
        {
            lblPatientNameError.Visible = false;
            //flag = true;
        }

        if (ddlAppointmentTime.SelectedValue == "")
        {
            lblAppointError.Text = "Select Appointment Date";
            lblAppointError.Visible = true;
            flag = false;
            ddlAppointmentTime.Focus();
        }
        else
        {
            lblAppointError.Visible = false;
        }

       
        if (rbthistory.SelectedValue == "")
        {
            lblhistory.Text = "Select History";
            lblhistory.Visible = true;
            flag = false;
            rbthistory.Focus();
        }
        else
        {
            lblhistory.Visible = false;
        }

        if (chklistdieases.SelectedValue == "")
        {
            lbldiseases.Text = "Select Dieases";
            lbldiseases.Visible = true;
            flag = false;
            chklistdieases.Focus();
        }
        else
        {
            lbldiseases.Visible = false;
        }


        if (txtSymptoms.Text == "")
        {
            lblsymptoms.Text = "Enter Symptoms";
            lblsymptoms.Visible = true;
            flag = false;
            txtSymptoms.Focus();
            txtSymptoms.Text = "";
        }
        else
        {
            lblsymptoms.Visible = false;
        }


        if (txtMedician.Text == "")
        {
            lblMedician.Text = "Enter Medician";
            lblMedician.Visible = true;
            flag = false;
            txtMedician.Focus();
            txtMedician.Text = "";
        }
        else
        {
            lblMedician.Visible = false;
        }

        if (txtMedicineDay.Text == "")
        {
            lblMedicineDay.Text = "Enter Medician For No of Days";
            lblMedicineDay.Visible = true;
            flag = false;
            txtMedicineDay.Focus();
            txtMedicineDay.Text = "";
        }
        else
        {
            lblMedicineDay.Visible = false;
        }


        if (txtConsultingCharges.Text == "")
        {
            lblConsultingCharges.Text = "Enter Consulting  Charges";
            lblConsultingCharges.Visible = true;
            flag = false;
            txtConsultingCharges.Focus();
            txtConsultingCharges.Text = "";
        }
        else
        {
            lblConsultingCharges.Visible = false;
        }


        if (rbtPaymentType.SelectedValue == "")
        {
            lblPaymentType.Text = "Select Payment";
            lblPaymentType.Visible = true;
            flag = false;
            rbtPaymentType.Focus();
        }
        else
        {
            lblPaymentType.Visible = false;
        }

        if (flag == false)
            return false;

        return flag;



    }


    #region All Chnaged Event
    protected void ddlPatientName_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlPatientName.SelectedValue == "")
        {
            lblPatientNameError.Text = "please Select Patient Name";
            lblPatientNameError.Visible = true;
            ddlPatientName.Focus();
        }
        else
        {
            //lblPatientNameError.Text = "";
            lblPatientNameError.Visible = false;
            bindpatientDetailsById();
            bindAppointmentDetailsById();
        }
        lblPatientNameError.Visible = false;
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void rbthistory_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblhistory.Visible = false;
        chklistdieases.Focus();

        if (rbthistory.SelectedValue == "New History")
        {
            int length = 1;
            int r = (new Random()).Next(1, 1000);
            caseno += caseno;
            caseid = casestr + Convert.ToString(r);
            txtCaseNo.Text = caseid;
            txtCaseNo.Visible = true;
            ddlAllCaseNoByPatientID.Visible = false;
            for (int i = 0; i < chklistdieases.Items.Count; i++)
            {
                chklistdieases.Items[i].Selected = false;
            }
            txtSymptoms.Text = "";
            txtHistorySymtoms.Text = "";
            txtMedician.Text = "";
            txtMedicineDay.Text = "";
            txtAppoinmentDate.Text = "";
            txtConsultingCharges.Text = "";
            rbtPaymentType.SelectedIndex = 0;
            for (int i = 0; chklistTest.Items.Count > i; i++)
            {
                chklistTest.Items[i].Selected = false;
            }
        }
        else if (rbthistory.SelectedValue == "Previous History")
        {
            ds = new DataSet();
            ds = pCheckUp.GetPatientCheckupDetailsBYPatientId(Convert.ToInt32(ddlPatientName.SelectedValue));
            ddlAllCaseNoByPatientID.Visible = true;
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                txtCaseNo.Visible = false;
                ddlAllCaseNoByPatientID.DataSource = ds;
                ddlAllCaseNoByPatientID.Items.Clear();
                ddlAllCaseNoByPatientID.DataTextField = "CaseId";
                ddlAllCaseNoByPatientID.DataValueField = "CaseId";
                ddlAllCaseNoByPatientID.DataBind();
                ddlAllCaseNoByPatientID.SelectedValue = ds.Tables[0].Rows[0]["CaseId"].ToString();

                ds2 = pCheckUp.GetPatientDieasesDetails(Convert.ToInt32(ds.Tables[0].Rows[0]["PatientCheckupId"].ToString()), ddlAllCaseNoByPatientID.SelectedValue, Convert.ToInt32(ddlPatientName.SelectedValue));

                for (int i = 0; i < chklistdieases.Items.Count; i++)
                {
                    for (int j = 0; ds2.Tables[0].Rows.Count > j; j++)
                    {
                        if (ds2.Tables[0].Rows[j]["DieasesId"].ToString() == chklistdieases.Items[i].Value)
                        {
                            chklistdieases.Items[i].Selected = true;
                        }
                    }
                }


                txtSymptoms.Text = ds.Tables[0].Rows[0]["Symtoms"].ToString();
                txtHistorySymtoms.Text = ds.Tables[0].Rows[0]["HistoryDescriprtion"].ToString();
                txtMedician.Text = ds.Tables[0].Rows[0]["MedicineDetails"].ToString();
                txtMedicineDay.Text = ds.Tables[0].Rows[0]["MedicineForDay"].ToString();
                DateTime appointdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AgainAppoinmentDate"].ToString());
                txtAppoinmentDate.Text = String.Format("{0:yyyy-MM-dd}", appointdate);
                txtConsultingCharges.Text = ds.Tables[0].Rows[0]["ConsutancyCharge"].ToString();
                rbtPaymentType.SelectedValue = ds.Tables[0].Rows[0]["PaymentType"].ToString();
                ds3 = new DataSet();

                ds3 = pCheckUp.GetPatientTestDetails(Convert.ToInt32(ds.Tables[0].Rows[0]["PatientCheckupId"].ToString()),ddlAllCaseNoByPatientID.SelectedValue, Convert.ToInt32(ddlPatientName.SelectedValue));

                for (int i = 0; i < chklistTest.Items.Count; i++)
                {
                    for (int j = 0; ds3.Tables[0].Rows.Count > j; j++)
                    {
                        if (ds3.Tables[0].Rows[j]["TestId"].ToString() == chklistTest.Items[i].Value)
                        {
                            chklistTest.Items[i].Selected = true;
                        }
                    }
                }
            }
            else
            {
                txtCaseNo.Visible = true;
                ddlAllCaseNoByPatientID.Visible = false;
            }



        }
    }
    protected void chklistdieases_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbldiseases.Visible = false;
        txtSymptoms.Focus();
    }
    protected void txtCaseNo_TextChanged(object sender, EventArgs e)
    {
        //String caseno = "^[a-zA-Z0-9]*$";

        //if (Regex.IsMatch(txtCaseNo.Text, caseno))
        //{
        //    lblCaseNo.Visible = false;
        //    rbthistory.Focus();
        //}
        //else
        //{
        //    lblCaseNo.Visible = true;
        //    lblCaseNo.Text = "Please Enter Valid Case no";
        //    txtCaseNo.Text = "";
        //    txtCaseNo.Focus();
        //}
    }

    protected void ddlAllCaseNoByPatientID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtSymptoms_TextChanged(object sender, EventArgs e)
    {
        String symptoms = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtSymptoms.Text, symptoms))
        {
            lblsymptoms.Visible = false;
            txtHistorySymtoms.Focus();
        }
        else
        {
            lblsymptoms.Visible = true;
            lblsymptoms.Text = "Please Enter symtoms";
            txtSymptoms.Text = "";
            txtSymptoms.Focus();
        }

    }
    protected void txtHistorySymtoms_TextChanged(object sender, EventArgs e)
    {
        String historysymtoms = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtHistorySymtoms.Text, historysymtoms))
        {
            lblhistorysymtoms.Visible = false;
            txtMedician.Focus();
        }
        else
        {
            lblsymptoms.Visible = true;
            lblsymptoms.Text = "Please Enter History symtoms";
            txtHistorySymtoms.Text = "";
            txtHistorySymtoms.Focus();
        }
    }

    protected void txtMedician_TextChanged(object sender, EventArgs e)
    {
        String Medicians = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtMedician.Text, Medicians))
        {
            lblMedician.Visible = false;
            chklistTest.Focus();
        }
        else
        {
            lblMedician.Visible = true;
            lblMedician.Text = "Please Enter History symtoms";
            txtMedician.Text = "";
            txtMedician.Focus();
        }
    }
    protected void chklistTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblTest.Visible = false;
        txtMedicineDay.Focus();
    }
    protected void txtMedicineDay_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9]{1}[0-9]{0,2}$";

        if (Regex.IsMatch(txtMedicineDay.Text, Num))
        {
            lblMedicineDay.Visible = false;
            DateTime endDate = Convert.ToDateTime(this.txtdate.Text);
            Int64 addedDays = Convert.ToInt64(txtMedicineDay.Text);
            endDate = endDate.AddDays(addedDays);
            DateTime end = endDate;
            this.txtAppoinmentDate.Text = end.ToShortDateString();
            txtAppoinmentDate.Focus();
        }
        else
        {
            lblMedicineDay.Visible = true;
            lblMedicineDay.Text = "Allow only 1 to 3 digit and starting without 0";
            txtMedicineDay.Text = "";
            txtMedicineDay.Focus();
        }
    }
    protected void txtConsultingCharges_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9]{1}[0-9]{0,3}$";

        if (Regex.IsMatch(txtConsultingCharges.Text, Num))
        {
            lblConsultingCharges.Visible = false;
            rbtPaymentType.Focus();
        }
        else
        {
            lblConsultingCharges.Visible = true;
            lblConsultingCharges.Text = "Allow Only 1 to 4 digit and starting without 0";
            txtConsultingCharges.Text = "";
            txtConsultingCharges.Focus();
        }
    }

    protected void rbtPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblPaymentType.Visible = false;
        btnChekUp.Focus();
    }
    protected void txtAppoinmentDate_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtAppoinmentDate.Text) > Convert.ToDateTime(txtdate.Text))
        {
            lblAppoinmentDate.Visible = false;
        }
        else
        {
            lblAppoinmentDate.Visible = true;
            lblAppoinmentDate.Text = "Select valid date";
            txtAppoinmentDate.Text = "";
            txtAppoinmentDate.Focus();
        }
    }

    #endregion
    protected void btnChekUp_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            int regid = Convert.ToInt32(Session["RegId"].ToString());

            ds = new DataSet();
            ds = pCheckUp.GetPatientCheckupDetails();

            
            int PatientCheckupId = 0;

            for (int i = 0; ds.Tables[0].Rows.Count > i;i++ )
            {

                PatientCheckupId = Convert.ToInt32(ds.Tables[0].Rows[i]["PatientCheckupId"].ToString());


            }
            PatientCheckupId = PatientCheckupId + 1;

            //if (fuTestReport.HasFile)
            //{
            //    foreach (HttpPostedFile uploadedFile in fuTestReport.PostedFiles)
            //    {

            //        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("TestReportsUpload/"),
            //          uploadedFile.FileName));

            //    }
            //}

            if (rbthistory.SelectedValue == "New History")
            {

                pCheckUp.InsertPatientCheckupDetails(PatientCheckupId, Convert.ToInt32(ddlPatientName.SelectedValue)
                                                     , Convert.ToDateTime(txtdate.Text)
                                                     , txtCaseNo.Text
                                                     , Convert.ToInt32(ddlAppointmentTime.SelectedValue)
                                                     , rbthistory.SelectedValue
                                                     , txtHistorySymtoms.Text
                                                     , txtSymptoms.Text
                                                     , txtMedician.Text
                                                     , txtConsultingCharges.Text
                                                     , txtMedicineDay.Text
                                                     , Convert.ToDateTime(txtAppoinmentDate.Text)
                                                     , rbtPaymentType.SelectedValue
                                                     , regid, regid);

                foreach (ListItem item in chklistdieases.Items)
                {
                    if (item.Selected)
                    {

                        pCheckUp.InsertPatientDieasesDetails(PatientCheckupId, txtCaseNo.Text
                                                   , Convert.ToInt32(ddlPatientName.SelectedValue)
                                                   , Convert.ToInt32(item.Value)
                                                   , regid, regid);

                    }
                }

                foreach (ListItem item in chklistTest.Items)
                {
                    if (item.Selected)
                    {
                        pCheckUp.InsertPatientTestDetails(PatientCheckupId, txtCaseNo.Text
                                                   , Convert.ToInt32(ddlPatientName.SelectedValue)
                                                   , Convert.ToInt32(item.Value)
                                                   , ""
                                                   , regid, regid);
                    }
                }

                ShowMessageBox("Insert Successfully");
                clear();
            }
            else if (rbthistory.SelectedValue == "Previous History")
            {
                pCheckUp.InsertPatientCheckupDetails(PatientCheckupId, Convert.ToInt32(ddlPatientName.SelectedValue)
                                                     , Convert.ToDateTime(txtdate.Text)
                                                     , ddlAllCaseNoByPatientID.SelectedValue
                                                     , Convert.ToInt32(ddlAppointmentTime.SelectedValue)
                                                     , rbthistory.SelectedValue
                                                     , txtHistorySymtoms.Text
                                                     , txtSymptoms.Text
                                                     , txtMedician.Text
                                                     , txtConsultingCharges.Text
                                                     , txtMedicineDay.Text
                                                     , Convert.ToDateTime(txtAppoinmentDate.Text)
                                                     , rbtPaymentType.SelectedValue
                                                     , regid, regid);

                foreach (ListItem item in chklistdieases.Items)
                {
                    if (item.Selected)
                    {

                        pCheckUp.InsertPatientDieasesDetails(PatientCheckupId, ddlAllCaseNoByPatientID.SelectedValue
                                                   , Convert.ToInt32(ddlPatientName.SelectedValue)
                                                   , Convert.ToInt32(item.Value)
                                                   , regid, regid);

                    }
                }

                foreach (ListItem item in chklistTest.Items)
                {
                    if (item.Selected)
                    {
                        pCheckUp.InsertPatientTestDetails(PatientCheckupId, ddlAllCaseNoByPatientID.SelectedValue
                                                   , Convert.ToInt32(ddlPatientName.SelectedValue)
                                                   , Convert.ToInt32(item.Value)
                                                   , ""
                                                   , regid, regid);
                    }
                }

                ShowMessageBox("Insert Successfully");
                clear();
            }
            ds = new DataSet();
            ds = pCheckUp.GetPatientCheckupDetails();

            
            int AppoinmentId = 0;

            for (int i = 0; ds.Tables[0].Rows.Count > i;i++ )
            {

                AppoinmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["AppoinmentId"].ToString());


            }
          //  PatientCheckupId = PatientCheckupId + 1;

            appoint.EditAppointmentstatus(AppoinmentId, "Done", regid);
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

    protected void ImgPlus_Click(object sender, ImageClickEventArgs e)
    {

        if (ImgPlus.ImageUrl == "images/minus.png")
        {
            PanelPatientDetails.Visible = false;
            ImgPlus.ImageUrl = "images/plus.png";
        }
        else if (ImgPlus.ImageUrl == "images/plus.png")
        {
            PanelPatientDetails.Visible = true;
            ImgPlus.ImageUrl = "images/minus.png";
        }
        else
        {
            PanelPatientDetails.Visible = true;
            ImgPlus.ImageUrl = "images/minus.png";
        }
    }

    public void clear()
    {
       
        txtCaseNo.Text = "";
        txtSymptoms.Text = "";
        txtHistorySymtoms.Text = "";
        txtMedician.Text = "";
        txtMedicineDay.Text = "";
        txtAppoinmentDate.Text = "";
        txtConsultingCharges.Text = "";
    }

    protected void chklistdieases_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ShowMessageBox("HI");
    }
}