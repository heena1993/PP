using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Receptionist"] != null)
        {

            lblUserName.Text = Session["Receptionist"].ToString();
            imgProfile.ImageUrl = ("~/Profile/Receptionist/" + Session["Profile"].ToString());

            lblSideUserName.Text = Session["Receptionist"].ToString();
            imgSideProfile.ImageUrl = ("~/Profile/Receptionist/" + Session["Profile"].ToString());

            hrefprofile.HRef = "../AdminProfile.aspx";
            liBookAppointment.Visible = true;
            liAppoinmentApproval.Visible = true;
            liDieasesDetails.Visible = true;
            liPatientCheckUP.Visible = true;
            liPatientDetails.Visible = true;
            liTestDetails.Visible = true;
            liViewAllData.Visible = true;
            liAppoinmentDetail.Visible = true;
            liDdoctorsWeeklyschedule.Visible = true;
        }
        else if (Session["Doctor"] != null)
        {

            lblUserName.Text = Session["Doctor"].ToString();
            imgProfile.ImageUrl = ("~/Profile/Doctors/" + Session["Profile"].ToString());

            lblSideUserName.Text = Session["Doctor"].ToString();
            imgSideProfile.ImageUrl = ("~/Profile/Doctors/" + Session["Profile"].ToString());

            hrefprofile.HRef = "../DoctorsProfile.aspx";
            liAppoinmentDetail.Visible = true;
            liReport.Visible = true;
            liPatientReport.Visible = true;
            liPatientCheckupDetails.Visible = true;
            liDdoctorsWeeklyschedule.Visible = true;
        }
        else if (Session["Patient"] != null)
        {

            lblUserName.Text = Session["Patient"].ToString();
            imgProfile.ImageUrl = ("~/Profile/Patients/" + Session["Profile"].ToString());

            lblSideUserName.Text = Session["Patient"].ToString();
            imgSideProfile.ImageUrl = ("~/Profile/Patients/" + Session["Profile"].ToString());

            hrefprofile.HRef = "../AdminProfile.aspx";
            liPatientAppoinment.Visible = true;
        }
        else if (Session["Receptionist"] == null || Session["Doctor"] == null || Session["Patient"] == null)
        {
            Response.Redirect("Login.aspx");
        }
       
    }
}
