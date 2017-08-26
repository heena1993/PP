using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    LoginWeb.Login login = new LoginWeb.Login();
    Doctors.DoctorRegistration doctors = new Doctors.DoctorRegistration();
    Admin.AdminRegistration admin = new Admin.AdminRegistration();
    Patient.PatientRegistration patient = new Patient.PatientRegistration();

    bool flag = true;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        if (txtOld.Text.Trim() == "" && txtNew.Text == "" && txtConfirm.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alertscipt", "alert('Please Enter Details')", true);
        }
        else if (txtConfirm.Text != txtNew.Text)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alertscipt", "alert('The Confirm Password not match with new Password')", true);
        }
        else
        {
            if (Session["Doctor"] != null)
            {

                flag = doctors.DoctorsChangePassword(Convert.ToInt32(Session["DoctorId"].ToString()), txtOld.Text, txtNew.Text);

            }
            else if (Session["Receptionist"] != null)
            {
                flag = admin.AdminChangePassword(Convert.ToInt32(Session["RegId"].ToString()), txtOld.Text, txtNew.Text);

            }
            else if (Session["Patient"] != null)
            {
                flag = patient.PatientChangePassword(Convert.ToInt32(Session["PatientId"].ToString()), txtOld.Text, txtNew.Text);

            }
          
            if (flag == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "alertscipt", "alert('Your Passowrd Are Changed')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "alertscipt", "alert('Password Not Match with Old Password')", true);


            }
        }

    }
}