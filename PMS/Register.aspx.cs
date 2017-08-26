using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    CityStateCountry.CityStateCountryBind cityCountryState = new CityStateCountry.CityStateCountryBind();
    Admin.AdminRegistration admin = new Admin.AdminRegistration();
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Bindcountry();
            BindState();

        }

    }


    #region Bind Country State City code
    protected void Bindcountry()
    {
        DataSet ds = new DataSet();

        ds = cityCountryState.getContrybind();
        ddlCountry.DataSource = ds;
        ddlCountry.Items.Clear();
        ddlCountry.DataTextField = "name";
        ddlCountry.DataValueField = "id";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("--Select Country--", ""));

    }

    protected void BindState()
    {

        DataSet ds = new DataSet();
        ds = cityCountryState.getStatebind();
        ddlState.DataSource = ds;
        ddlState.Items.Clear();
        ddlState.DataTextField = "StateName";
        ddlState.DataValueField = "StateId";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("--Select State--", ""));


    }
    protected void BindCity(int StateId)
    {

        DataSet ds = new DataSet();
        ds = cityCountryState.getcitybind(StateId);
        ddlCity.DataSource = ds;
        ddlCity.Items.Clear();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("--Select City--", ""));


    }

    #endregion

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {


            if (ddlUserType.SelectedValue == "Receptionist")
            {
                if (fuProfileUpload.HasFile)
                {
                    foreach (HttpPostedFile uploadedFile in fuProfileUpload.PostedFiles)
                    {

                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Receptionist/"),
                          uploadedFile.FileName));

                    }
                }
                admin.InsertAdminDetail(txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, txtAge.Text, Convert.ToDateTime(txtBDate.Text), fuProfileUpload.FileName.ToString());
                ShowMessageBox("Insert Successfully");
            }
            else if (ddlUserType.SelectedValue == "Patient")
            {


                if (fuProfileUpload.HasFile)
                {
                    foreach (HttpPostedFile uploadedFile in fuProfileUpload.PostedFiles)
                    {

                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Patients/"),
                          uploadedFile.FileName));

                    }
                }
                patient.InsertPatientByOwn(txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, Convert.ToDateTime(txtBDate.Text), txtAge.Text, "1", fuProfileUpload.FileName.ToString());
                ShowMessageBox("Insert Successfully");
                clear();
            }
            else if (ddlUserType.SelectedValue == "Doctor")
            {
                if (fuProfileUpload.HasFile)
                {
                    foreach (HttpPostedFile uploadedFile in fuProfileUpload.PostedFiles)
                    {

                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Doctors/"),
                          uploadedFile.FileName));

                    }
                }

                doctors.InsertDoctorDetail(txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, txtAge.Text, Convert.ToDateTime(txtBDate.Text), txtHospitalName.Text, txtQualification.Text, txtSpecialize.Text, fuProfileUpload.FileName.ToString());
                ShowMessageBox("Insert Successfully");
                clear();
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


    protected void clear()
    {
        txtFullName.Text = "";
        rbtGender.SelectedIndex = 0;
        txtAddress.Text = "";
        ddlCountry.SelectedValue = "";
        ddlState.SelectedValue = "";
        ddlCity.SelectedValue = "";
        txtZipCode.Text = "";
        txtBDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtContactNumber.Text = "";
        ddlUserType.SelectedValue = "";
        txtHospitalName.Text = "";
        txtQualification.Text = "";
        txtSpecialize.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
    }

    protected bool ValidatePage()
    {
        bool flag = true;
        if (txtFullName.Text.Trim() == "")
        {
            lblFullNameError.Text = "Enter Full Name";
            lblFullNameError.Visible = true;
            flag = false;
            txtFullName.Focus();
            txtFullName.Text = "";
        }
        else
        {
            lblFullNameError.Visible = false;
            //flag = true;
        }

        if (rbtGender.SelectedValue == "")
        {
            lblGender.Text = "Select Gender";
            lblGender.Visible = true;
            flag = false;
            rbtGender.Focus();

        }
        else
        {
            lblGender.Visible = false;
            //flag = true;
        }


        if (txtAddress.Text.Trim() == "")
        {
            lblAddress.Text = "Enter Address";
            lblAddress.Visible = true;
            flag = false;
            txtAddress.Focus();
            txtAddress.Text = "";
        }
        else
        {
            lblAddress.Visible = false;
            //flag = true;
        }

        if (ddlCity.SelectedValue == "")
        {
            lblCity.Text = "Select City";
            lblCity.Visible = true;
            flag = false;
            ddlCity.Focus();

        }
        else
        {
            lblCity.Visible = false;
            //flag = true;
        }

        if (txtZipCode.Text.Trim() == "")
        {
            lblZipCode.Text = "Enter Zip Code";
            lblZipCode.Visible = true;
            flag = false;
            txtZipCode.Focus();
            txtZipCode.Text = "";
        }
        else
        {
            lblZipCode.Visible = false;
            //flag = true;
        }

        if (ddlState.SelectedValue == "")
        {
            lblState.Text = "Select State";
            lblState.Visible = true;
            flag = false;
            ddlState.Focus();

        }
        else
        {
            lblState.Visible = false;
            // flag = true;
        }

        if (ddlCountry.SelectedValue == "")
        {
            lblCountry.Text = "Select Country";
            lblCountry.Visible = true;
            flag = false;
            ddlCountry.Focus();

        }
        else
        {
            lblCountry.Visible = false;
            // flag = true;
        }

        if (txtBDate.Text.Trim() == "")
        {
            lblBDate.Text = "Enter Birth Date";
            lblBDate.Visible = true;
            flag = false;
            txtBDate.Focus();
            txtBDate.Text = "";
        }
        else
        {
            lblBDate.Visible = false;
            //flag = true;
        }


        if (txtAge.Text.Trim() == "")
        {
            lblAge.Text = "Enter Age";
            lblAge.Visible = true;
            flag = false;
            txtAge.Focus();
            txtAge.Text = "";
        }
        else
        {
            lblAge.Visible = false;
            //flag = true;
        }

        if (txtEmail.Text.Trim() == "")
        {
            lblEmail.Text = "Enter Email";
            lblEmail.Visible = true;
            flag = false;
            txtEmail.Focus();
            txtEmail.Text = "";
        }
        else
        {
            lblEmail.Visible = false;
            //flag = true;
        }

        if (txtContactNumber.Text.Trim() == "")
        {
            lblContactNumber.Text = "Enter Contact Number";
            lblContactNumber.Visible = true;
            flag = false;
            txtContactNumber.Focus();
            txtContactNumber.Text = "";
        }
        else
        {
            lblContactNumber.Visible = false;
            //flag = true;
        }


        if (txtUserName.Text.Trim() == "")
        {
            lblUserName.Text = "Enter UserName";
            lblUserName.Visible = true;
            flag = false;
            txtUserName.Focus();
            txtUserName.Text = "";
        }
        else
        {
            lblUserName.Visible = false;
            //flag = true;
        }


        if (txtPassword.Text.Trim() == "")
        {
            lblPassword.Text = "Enter Password";
            lblPassword.Visible = true;
            flag = false;
            txtPassword.Focus();
            txtPassword.Text = "";
        }
        else
        {
            lblPassword.Visible = false;
            //flag = true;
        }

        if (ddlUserType.SelectedValue == "")
        {
            lblUserType.Text = "Select User Type";
            lblUserType.Visible = true;
            flag = false;
            ddlUserType.Focus();

        }
        else
        {
            lblUserType.Visible = false;
            //flag = true;
        }

        if (ddlUserType.SelectedValue == "Doctor")
        {
            if (txtHospitalName.Text.Trim() == "")
            {
                lblHospitalName.Text = "Enter Hospital Name";
                lblHospitalName.Visible = true;
                flag = false;
                txtHospitalName.Focus();
                txtHospitalName.Text = "";
            }
            else
            {
                lblHospitalName.Visible = false;
                //flag = true;
            }

            if (txtQualification.Text.Trim() == "")
            {
                lblQualification.Text = "Enter Qualification";
                lblQualification.Visible = true;
                flag = false;
                txtQualification.Focus();
                txtQualification.Text = "";
            }
            else
            {
                lblQualification.Visible = false;
                //flag = true;
            }

            if (txtSpecialize.Text.Trim() == "")
            {
                lblSpecialize.Text = "Enter Specialize";
                lblSpecialize.Visible = true;
                flag = false;
                txtSpecialize.Focus();
                txtSpecialize.Text = "";
            }
            else
            {
                lblSpecialize.Visible = false;
                //flag = true;
            }
        }

        if (fuProfileUpload.FileName == "")
        {

            lblProfileUpload.Text = "Enter Specialize";
            lblProfileUpload.Visible = true;
            flag = false;
            fuProfileUpload.Focus();

        }
        else
        {
            lblProfileUpload.Visible = false;
        }
        if (flag == false)
        {
            return false;
        }
        return true;

    }

    #region All Text changed Event
    protected void txtFullName_TextChanged(object sender, EventArgs e)
    {
        String alpha = "^[A-Za-z ]+$";

        if (Regex.IsMatch(txtFullName.Text, alpha))
        {
            lblFullNameError.Visible = false;
            rbtGender.Focus();
        }
        else
        {
            lblFullNameError.Visible = true;
            lblFullNameError.Text = "Please Enter only Alpha";
            txtFullName.Text = "";
            txtFullName.Focus();
        }
    }
    protected void rbtGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblGender.Visible = false;
        txtAddress.Focus();
    }
    protected void txtAddress_TextChanged(object sender, EventArgs e)
    {

        String alphaNo = "^[a-zA-Z0-9., ]*$";
        if (Regex.IsMatch(txtAddress.Text, alphaNo))
        {
            lblAddress.Visible = false;
            ddlCity.Focus();
        }
        else
        {
            lblAddress.Visible = true;
            lblAddress.Text = "Please Enter valid Address";
            txtAddress.Text = "";
            txtAddress.Focus();
        }

    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCity.Visible = false;
        txtZipCode.Focus();
    }
    protected void txtZipCode_TextChanged(object sender, EventArgs e)
    {

        String Num = "^[1-9][0-9]*$";

        if (Regex.IsMatch(txtZipCode.Text, Num))
        {
            lblZipCode.Visible = false;
            ddlState.Focus();
        }
        else
        {
            lblZipCode.Visible = true;
            lblZipCode.Text = "Please Enter Only Numeric";
            txtZipCode.Text = "";
            txtZipCode.Focus();
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblState.Visible = false;
        ddlCountry.Focus();
        int StateId = Convert.ToInt32(ddlState.SelectedValue.ToString());
        BindCity(StateId);
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCountry.Visible = false;
        txtBDate.Focus();
    }
    protected void txtBDate_TextChanged(object sender, EventArgs e)
    {
        string date = "2017-01-01";
        string olddate = "1950-01-01";
        if (Convert.ToDateTime(txtBDate.Text) > Convert.ToDateTime(date) || Convert.ToDateTime(txtBDate.Text) < Convert.ToDateTime(olddate))
        {
            lblBDate.Text = "Select Valid date";
            lblBDate.Visible = true;
            txtBDate.Focus();
            txtBDate.Text = "";
        }
        else
        {
            lblBDate.Visible = false;
            txtAge.Focus();
            int nDOBYear = Convert.ToDateTime(txtBDate.Text).Year;
            int nCurrentYear = DateTime.Now.Year;
            txtAge.Text = (nCurrentYear - nDOBYear).ToString();
        }


    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9]{1}[0-9]{0,2}$";

        if (Regex.IsMatch(txtAge.Text, Num))
        {
            lblAge.Visible = false;
            txtEmail.Focus();
        }
        else
        {
            lblAge.Visible = true;
            lblAge.Text = "Please Enter Only Numeric";
            txtAge.Text = "";
            txtAge.Focus();
        }
    }
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        string pattern = null;
        pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        if (Regex.IsMatch(txtEmail.Text, pattern))
        {
            lblEmail.Visible = false;
            txtContactNumber.Focus();
        }
        else
        {

            lblEmail.Visible = true;
            lblEmail.Text = "Please Enter Valid Email";
            txtEmail.Text = "";
            txtEmail.Focus();

        }
    }
    protected void txtContactNumber_TextChanged(object sender, EventArgs e)
    {
        String Mobile = "^[7-9][0-9]{9}$";

        if (Regex.IsMatch(txtContactNumber.Text, Mobile))
        {
            lblContactNumber.Visible = false;
            txtUserName.Focus();
        }
        else
        {
            lblContactNumber.Visible = true;
            lblContactNumber.Text = "Please Enter Valid Contact Number(Begin with 7,8,9)";
            txtContactNumber.Text = "";
            txtContactNumber.Focus();
        }
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        //lblUserName.Visible = false;
        //txtPassword.Focus();
        String Role = ddlUserType.SelectedValue.ToString();
        if (Role == "Receptionist")
        {

            String alphanum = "^[a-zA-Z0-9 ]*$";
            if (Regex.IsMatch(txtUserName.Text, alphanum))
            {
                DataSet ds = new DataSet();
                ds = admin.CheckUSerExist(txtUserName.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Your Username Are Exist";
                }
                else
                {
                    lblUserName.Visible = false;
                    txtPassword.Focus();
                }
            }
            else
            {
                lblUserName.Visible = true;
                lblUserName.Text = "Please Enter Only alpha Numeric";
                txtUserName.Text = "";
                txtUserName.Focus();
            }

        }
        else if (Role == "Doctors")
        {

            String alphanum = "^[a-zA-Z0-9 ]*$";
            if (Regex.IsMatch(txtUserName.Text, alphanum))
            {
                DataSet ds = new DataSet();
                ds = doctors.CheckUSerExist(txtUserName.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Your Username Are Exist";
                }
                else
                {
                    lblUserName.Visible = false;
                    txtPassword.Focus();
                }
            }
            else
            {
                lblUserName.Visible = true;
                lblUserName.Text = "Please Enter Only alpha Numeric";
                txtUserName.Text = "";
                txtUserName.Focus();
            }


        }
        else if (Role == "Patient")
        {

            String alphanum = "^[a-zA-Z0-9 ]*$";
            if (Regex.IsMatch(txtUserName.Text, alphanum))
            {
                DataSet ds = new DataSet();
                ds = patient.CheckUSerExist(txtUserName.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Your Username Are Exist";
                    txtUserName.Text = "";
                    txtUserName.Focus();
                }
                else
                {
                    lblUserName.Visible = false;
                    txtPassword.Focus();
                }
            }
            else
            {
                lblUserName.Visible = true;
                lblUserName.Text = "Please Enter Only alpha Numeric";
                txtUserName.Text = "";
                txtUserName.Focus();
            }

        }
    }
    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        lblPassword.Visible = false;
        ddlUserType.Focus();
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue == "Doctor")
        {
            PanelDoctors.Visible = true;
        }
        else
        {
            PanelDoctors.Visible = false;
        }
        lblUserType.Visible = false;
    }

    protected void txtHospitalName_TextChanged(object sender, EventArgs e)
    {
        String HospitalName = "^[a-zA-Z0-9,.! ]*$";

        if (Regex.IsMatch(txtHospitalName.Text, HospitalName))
        {
            lblHospitalName.Visible = false;
            txtQualification.Focus();
        }
        else
        {
            lblHospitalName.Visible = true;
            lblHospitalName.Text = "Please Enter Hospital Name";
            txtHospitalName.Text = "";
            txtHospitalName.Focus();
        }
    }
    protected void txtQualification_TextChanged(object sender, EventArgs e)
    {
        String Qualification = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtQualification.Text, Qualification))
        {
            lblQualification.Visible = false;
            txtSpecialize.Focus();
        }
        else
        {
            lblQualification.Visible = true;
            lblQualification.Text = "Please Enter Qualification";
            txtQualification.Text = "";
            txtQualification.Focus();
        }
    }
    protected void txtSpecialize_TextChanged(object sender, EventArgs e)
    {
        String Specialize = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtSpecialize.Text, Specialize))
        {
            txtSpecialize.Visible = false;

        }
        else
        {
            lblSpecialize.Visible = true;
            lblSpecialize.Text = "Please Enter Qualification";
            txtSpecialize.Text = "";
            txtSpecialize.Focus();
        }
    }

    #endregion

}