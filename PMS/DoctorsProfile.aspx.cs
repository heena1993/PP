﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoctorsProfile : System.Web.UI.Page
{
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    CityStateCountry.CityStateCountryBind cityCountryState = new CityStateCountry.CityStateCountryBind();

    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Doctor"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {

            BindProfile();
            Bindcountry();
            BindState();
        }


    }


    protected void BindProfile()
    {
        int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());

        try
        {
            ds = new DataSet();
            ds = doctors.GetDoctorDetailByDoctorId(doctorId);

            #region Fill Lable For View
            //Fill Lable For Viwe
            lblFullName.Text = ds.Tables[0].Rows[0]["DoctorName"].ToString();
            lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblCity.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
            lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            lblState.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
            lblCountry.Text = ds.Tables[0].Rows[0]["name"].ToString();

            DateTime BDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BirthDate"].ToString());

            lblBDate.Text = String.Format("{0:yyyy-MM-dd}", BDate);
            lblAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
            lblContactNumber.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            lblUserName2.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            //lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

            lblHospitalName.Text = ds.Tables[0].Rows[0]["HospitalName"].ToString();
            lblQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
            lblSpecialist.Text = ds.Tables[0].Rows[0]["Specialist"].ToString();


            ViewImage.ImageUrl = ("Profile/Doctors/" + ds.Tables[0].Rows[0]["Photo"].ToString());
            #endregion

            #region Fill TextBox For Edir Value

            txtFullName.Text = ds.Tables[0].Rows[0]["DoctorName"].ToString();
            rbtGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();



            txtZipCode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            ddlState.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();
            ddlCountry.Text = ds.Tables[0].Rows[0]["CountryId"].ToString();

            BindCity(Convert.ToInt32(ds.Tables[0].Rows[0]["StateId"].ToString()));
            ddlCity.SelectedValue = ds.Tables[0].Rows[0]["CityId"].ToString();

            //DateTime BDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BirthDate"].ToString());

            txtBDate.Text = String.Format("{0:yyyy-MM-dd}", BDate);
            txtAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
            txtContactNumber.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

            txtHospitalName.Text = ds.Tables[0].Rows[0]["HospitalName"].ToString();
            txtQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
            txtSpecialist.Text = ds.Tables[0].Rows[0]["Specialist"].ToString();

            EditImage.ImageUrl = ("Profile/Doctors/" + ds.Tables[0].Rows[0]["Photo"].ToString());

            #endregion

        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }

    #region Bind Country State City Code
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
            lblGenderError.Text = "Select Gender";
            lblGenderError.Visible = true;
            flag = false;
            rbtGender.Focus();

        }
        else
        {
            lblGenderError.Visible = false;
            //flag = true;
        }


        if (txtAddress.Text.Trim() == "")
        {
            lblAddressError.Text = "Enter Address";
            lblAddressError.Visible = true;
            flag = false;
            txtAddress.Focus();
            txtAddress.Text = "";
        }
        else
        {
            lblAddressError.Visible = false;
            //flag = true;
        }

        if (ddlCity.SelectedValue == "")
        {
            lblCityError.Text = "Select City";
            lblCityError.Visible = true;
            flag = false;
            ddlCity.Focus();

        }
        else
        {
            lblCityError.Visible = false;
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
            lblStateError.Text = "Select State";
            lblStateError.Visible = true;
            flag = false;
            ddlState.Focus();

        }
        else
        {
            lblStateError.Visible = false;
            // flag = true;
        }

        if (ddlCountry.SelectedValue == "")
        {
            lblCountryError.Text = "Select Country";
            lblCountryError.Visible = true;
            flag = false;
            ddlCountry.Focus();

        }
        else
        {
            lblCountryError.Visible = false;
            // flag = true;
        }

        if (txtBDate.Text.Trim() == "")
        {
            lblBDateError.Text = "Enter Birth Date";
            lblBDateError.Visible = true;
            flag = false;
            txtBDate.Focus();
            txtBDate.Text = "";
        }
        else
        {
            lblBDateError.Visible = false;
            //flag = true;
        }


        if (txtAge.Text.Trim() == "")
        {
            lblAgeError.Text = "Enter Age";
            lblAgeError.Visible = true;
            flag = false;
            txtAge.Focus();
            txtAge.Text = "";
        }
        else
        {
            lblAgeError.Visible = false;
            //flag = true;
        }

        if (txtEmail.Text.Trim() == "")
        {
            lblEmailError.Text = "Enter Email";
            lblEmailError.Visible = true;
            flag = false;
            txtEmail.Focus();
            txtEmail.Text = "";
        }
        else
        {
            lblEmailError.Visible = false;
            //flag = true;
        }

        if (txtContactNumber.Text.Trim() == "")
        {
            lblContactNumberError.Text = "Enter Contact Number";
            lblContactNumberError.Visible = true;
            flag = false;
            txtContactNumber.Focus();
            txtContactNumber.Text = "";
        }
        else
        {
            lblContactNumberError.Visible = false;
            //flag = true;
        }


        if (txtUserName.Text.Trim() == "")
        {
            lblUserNameError.Text = "Enter UserName";
            lblUserNameError.Visible = true;
            flag = false;
            txtUserName.Focus();
            txtUserName.Text = "";
        }
        else
        {
            lblUserNameError.Visible = false;
            //flag = true;
        }


        if (txtHospitalName.Text.Trim() == "")
        {
            lblHospitalNameError.Text = "Enter Hospital Name";
            lblHospitalNameError.Visible = true;
            flag = false;
            txtHospitalName.Focus();
            txtHospitalName.Text = "";
        }
        else
        {
            lblHospitalNameError.Visible = false;
            //flag = true;
        }

        if (txtQualification.Text.Trim() == "")
        {
            lblQualificationError.Text = "Enter Qualification";
            lblQualificationError.Visible = true;
            flag = false;
            txtQualification.Focus();
            txtQualification.Text = "";
        }
        else
        {
            lblQualificationError.Visible = false;
            //flag = true;
        }

        if (txtSpecialist.Text.Trim() == "")
        {
            lblSpecialistError.Text = "Enter Specialist";
            lblSpecialistError.Visible = true;
            flag = false;
            txtSpecialist.Focus();
            txtSpecialist.Text = "";
        }
        else
        {
            lblSpecialistError.Visible = false;
            //flag = true;
        }


        if (flag == false)
        {
            return false;
        }
        return true;

    }

    #region All Text change Event

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
        lblGenderError.Visible = false;
        //txtAddress.Focus();
    }
    protected void txtAddress_TextChanged(object sender, EventArgs e)
    {
        lblAddressError.Visible = false;
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCountryError.Visible = false;
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        int StateId = Convert.ToInt32(ddlState.SelectedValue.ToString());
        BindCity(StateId);

        lblStateError.Visible = false;
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCityError.Visible = false;
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
    protected void txtBDate_TextChanged(object sender, EventArgs e)
    {
        string date = "2017-01-01";
        string olddate = "1950-01-01";
        if (Convert.ToDateTime(txtBDate.Text) > Convert.ToDateTime(date) || Convert.ToDateTime(txtBDate.Text) < Convert.ToDateTime(olddate))
        {

            lblBDateError.Text = "Select Valid date";
            lblBDateError.Visible = true;
            txtBDate.Focus();
            txtBDate.Text = "";

        }
        else
        {
            lblBDateError.Visible = false;

        }
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9]{1}[0-9]{0,2}$";

        if (Regex.IsMatch(txtAge.Text, Num))
        {
            lblAgeError.Visible = false;
            //txtEmail.Focus();
        }
        else
        {
            lblAgeError.Visible = true;
            lblAgeError.Text = "Please Enter Only Numeric";
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
            lblEmailError.Visible = false;
            txtContactNumber.Focus();
        }
        else
        {

            lblEmailError.Visible = true;
            lblEmailError.Text = "Please Enter Valid Email";
            txtEmail.Text = "";
            txtEmail.Focus();

        }
    }
    protected void txtContactNumber_TextChanged(object sender, EventArgs e)
    {
        String Mobile = "^[7-9][0-9]{9}$";

        if (Regex.IsMatch(txtContactNumber.Text, Mobile))
        {
            lblContactNumberError.Visible = false;
            txtUserName.Focus();
        }
        else
        {
            lblContactNumberError.Visible = true;
            lblContactNumberError.Text = "Please Enter Valid Contact Number(Begin with 7,8,9)";
            txtContactNumber.Text = "";
            txtContactNumber.Focus();
        }
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        lblUserName.Visible = false;
    }

    protected void txtHospitalName_TextChanged(object sender, EventArgs e)
    {
        String HospitalName = "^[a-zA-Z0-9,.! ]*$";

        if (Regex.IsMatch(txtHospitalName.Text, HospitalName))
        {
            lblHospitalNameError.Visible = false;
            txtQualification.Focus();
        }
        else
        {
            lblHospitalNameError.Visible = true;
            lblHospitalNameError.Text = "Please Enter Hospital Name";
            txtHospitalName.Text = "";
            txtHospitalName.Focus();
        }
    }
    protected void txtQualification_TextChanged(object sender, EventArgs e)
    {
        String Qualification = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtQualification.Text, Qualification))
        {
            lblQualificationError.Visible = false;
            txtSpecialist.Focus();
        }
        else
        {
            lblQualificationError.Visible = true;
            lblQualificationError.Text = "Please Enter Qualification";
            txtQualification.Text = "";
            txtQualification.Focus();
        }
    }
    protected void txtSpecialist_TextChanged(object sender, EventArgs e)
    {
        String Specialize = "^[a-zA-Z0-9,.]*$";

        if (Regex.IsMatch(txtSpecialist.Text, Specialize))
        {
            lblSpecialistError.Visible = false;

        }
        else
        {
            lblSpecialistError.Visible = true;
            lblSpecialistError.Text = "Please Enter Qualification";
            txtSpecialist.Text = "";
            txtSpecialist.Focus();
        }
    }

    #endregion
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            int doctorId = Convert.ToInt32(Session["DoctorId"].ToString());

            if (fuProfile.HasFile)
            {
                string strpath = System.IO.Path.GetExtension(fuProfile.FileName);
                if (strpath != ".jpg" && strpath != ".jpeg" && strpath != ".gif" && strpath != ".png")
                {
                    ShowMessageBox("Only image formats (jpg,jpeg,png, gif) are accepted ");
                }
                else
                {
                    foreach (HttpPostedFile uploadedFile in fuProfile.PostedFiles)
                    {

                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Doctors/"),
                          uploadedFile.FileName));

                        System.IO.File.Delete(Request.PhysicalApplicationPath + "Profile/Doctors/" + Session["Profile"].ToString());
                    }

                    //doctors.EditDoctorDetail(doctorId, txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtContactNumber.Text, txtEmail.Text, txtAge.Text, Convert.ToDateTime(txtBDate.Text), fuProfile.FileName, regid);

                    doctors.EditDoctorDetail(doctorId
                                            , txtFullName.Text
                                            , rbtGender.SelectedValue
                                            , txtAddress.Text
                                            , Convert.ToInt32(ddlCity.SelectedValue)
                                            , Convert.ToInt32(ddlState.SelectedValue)
                                            , Convert.ToInt32(ddlCountry.SelectedValue)
                                            , txtZipCode.Text
                                            , txtUserName.Text
                                            , txtContactNumber.Text
                                            , txtEmail.Text
                                            , txtAge.Text
                                            , Convert.ToDateTime(txtBDate.Text)
                                            , txtHospitalName.Text
                                            , txtQualification.Text
                                            , txtSpecialist.Text
                                            , fuProfile.FileName.ToString()
                                            , doctorId
                                            );
                    Session["Doctor"] = txtUserName.Text;
                    Session["Profile"] = fuProfile.FileName;
                    Response.Redirect("DoctorsProfile.aspx");
                    ShowMessageBox("Update Successfully");
                }
            }
            else
            {
                //doctors.EditDoctorDetail(regid, txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtContactNumber.Text, txtEmail.Text, txtAge.Text, Convert.ToDateTime(txtBDate.Text), Session["Profile"].ToString(), regid);

                doctors.EditDoctorDetail(doctorId
                                      , txtFullName.Text
                                      , rbtGender.SelectedValue
                                      , txtAddress.Text
                                      , Convert.ToInt32(ddlCity.SelectedValue)
                                      , Convert.ToInt32(ddlState.SelectedValue)
                                      , Convert.ToInt32(ddlCountry.SelectedValue)
                                      , txtZipCode.Text
                                      , txtUserName.Text
                                      , txtContactNumber.Text
                                      , txtEmail.Text
                                      , txtAge.Text
                                      , Convert.ToDateTime(txtBDate.Text)
                                      , txtHospitalName.Text
                                      , txtQualification.Text
                                      , txtSpecialist.Text
                                      , Session["Profile"].ToString()
                                      , doctorId
                                      );

                Session["Doctor"] = txtUserName.Text;
                //Session["Profile"] = fuProfile.FileName;
                Session["Profile"] = Session["Profile"].ToString();
                Response.Redirect("DoctorsProfile.aspx");
                ShowMessageBox("Update Successfully");
            }
        }
    }
    
}