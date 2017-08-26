using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    LoginWeb.Login login = new LoginWeb.Login();
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    Admin.AdminRegistration admin = new Admin.AdminRegistration();
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    DataSet ds, ds1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String Role = ddlUserType.SelectedValue.ToString();
        if (Role == "Receptionist")
        {
            DataSet ds = new DataSet();
            ds = login.GetLoginAdminDetails(txtUserName.Text, txtPassword.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Receptionist"] = txtUserName.Text;
                Session["Profile"] = ds.Tables[0].Rows[0]["Photo"].ToString();
                Session["RegId"] = ds.Tables[0].Rows[0]["RegId"].ToString();
                Response.Redirect("~/Dashboard.aspx");
            }
            else
            {
                ShowMessageBox("Your Username And Password Invalid");
                clear();
            }
        }
        else if (Role == "Doctors")
        {
           
            ds = new DataSet();
            ds = login.GetLoginDoctorDetails(txtUserName.Text, txtPassword.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Doctor"] = txtUserName.Text;
                Session["DoctorId"] = ds.Tables[0].Rows[0]["DoctorId"].ToString(); 
                Session["Profile"] = ds.Tables[0].Rows[0]["Photo"].ToString();
                //Session["RegId"] = ds.Tables[0].Rows[0]["RegId"].ToString();
                Response.Redirect("DoctorDashboard.aspx");
            }
            else
            {
                ShowMessageBox("Your Username And Password Invalid");
                clear();
            }
        }
        else if (Role == "Patient")
        {
            DataSet ds = new DataSet();
            ds = login.GetLoginPatientDetails(txtUserName.Text, txtPassword.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Patient"] = txtUserName.Text;
                Session["PatientId"] = ds.Tables[0].Rows[0]["PatientId"].ToString();
                Session["FullName"] = ds.Tables[0].Rows[0]["FullName"].ToString(); 
               Session["Profile"] = ds.Tables[0].Rows[0]["Photo"].ToString();
               Response.Redirect("PatientDashboard.aspx");
            }
            else
            {
                ShowMessageBox("Your Username And Password Invalid");
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
    public void clear()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        ddlUserType.SelectedIndex = 0;
    }


    protected void btnForgotPwd_Click(object sender, EventArgs e)
    {
        //if (txtFrgEmail.Text == "" && ddlUserTypeFgP.SelectedValue == "")
        //{
            String Role = ddlUserTypeFgP.SelectedValue.ToString();
            if (Role == "Receptionist")
            {

                ds1 = new DataSet();
                ds1 = admin.AdminForgotPasswordDetails(txtFrgEmail.Text);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ShowMessageBox("Your Password is " + ds1.Tables[0].Rows[0]["Password"].ToString());
                }
                else
                {
                    ShowMessageBox("Email ID Wrong");
                }

            }
            else if (Role == "Doctors")
            {
                ds1 = new DataSet();
                ds1 = doctors.DoctorsForgotPasswordDetails(txtFrgEmail.Text);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ShowMessageBox("Your Password is " + ds1.Tables[0].Rows[0]["Password"].ToString());
                }
                else
                {
                    ShowMessageBox("Email ID Wrong");
                }
            }
            else if (Role == "Patient")
            {
                ds1 = new DataSet();
                ds1 = patient.PatientForgotPasswordDetails(txtFrgEmail.Text);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ShowMessageBox("Your Password is " + ds1.Tables[0].Rows[0]["Password"].ToString());
                }
                else
                {
                    ShowMessageBox("Email ID Wrong");
                }
            }
        //}
        //else
        //{
        //    ShowMessageBox("Fill The Form");
        //}

    }
}
