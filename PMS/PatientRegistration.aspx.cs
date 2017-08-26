using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientRegistration : System.Web.UI.Page
{
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    CityStateCountry.CityStateCountryBind cityCountryState = new CityStateCountry.CityStateCountryBind();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            //Bindcountry();
            BindState();

        }
    }

    #region Bind Country state City code
    private void BindCitiesXml()
    {
        string filePath = Server.MapPath("~/Cities.xml");
        using (DataSet ds = new DataSet())
        {
            ds.ReadXml(filePath);
            ddlCity.DataSource = ds;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", ""));
        }
    }

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
            int regid = Convert.ToInt32(Session["RegId"].ToString());



            if (fuProfileUpload.HasFile)
            {
                foreach (HttpPostedFile uploadedFile in fuProfileUpload.PostedFiles)
                {

                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Patients/"),
                      uploadedFile.FileName));

                }
            }
            patient.InsertPatientByAdmin(txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, Convert.ToDateTime(txtBDate.Text), txtAge.Text, "Patient001", fuProfileUpload.FileName.ToString(), regid, regid);
            ShowMessageBox("Insert Successfully");
            clear();

        }
    }

    public void clear()
    {
        txtFullName.Text = "";
        rbtGender.SelectedIndex = 0;
        txtAddress.Text = "";
        txtZipCode.Text = "";
        txtBDate.Text = "";
        txtAge.Text = "";
        txtEmail.Text = "";
        txtContactNumber.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
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
            // flag = true;
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
            //flag = true;
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
            //flag = true;
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

        if (fuProfileUpload.FileName == "")
        {
            lblProfileUpload.Text = "Enter Password";
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
            lblAddress.Text = "Please Enter only Alpha Numeric";
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
        //ShowMessageBox(ddlCountry.SelectedValue);
        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "alertscipt", "alert('" + ddlCountry.SelectedValue + "')", true);
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
    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        lblPassword.Visible = false;
        //ddlUserType.Focus();
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {

        // lblUserType.Visible = false;
    }

    #endregion


    public static List<string> CountryList()
    {
        List<string> Culturelist = new List<string>();

        CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        foreach (CultureInfo getCultures in getCultureInfo)
        {
            RegionInfo GetRegionInfo = new RegionInfo(getCultures.LCID);

            if (!(Culturelist.Contains(GetRegionInfo.EnglishName)))
            {
                Culturelist.Add(GetRegionInfo.EnglishName);
            }

        }

        Culturelist.Sort();

        return Culturelist;
    }
}