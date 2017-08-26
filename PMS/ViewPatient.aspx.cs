using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class ViewPatient : System.Web.UI.Page
{
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    CityStateCountry.CityStateCountryBind cityCountryState = new CityStateCountry.CityStateCountryBind();
    DataSet ds,ds1,ds2;
    private static int PatientId,StateId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Receptionist"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            loaddata();
        }


       
    }
   
    public void loaddata()
    {

        try
        {
            ds = new DataSet();
            ds = patient.GetPatientDetails();
            GridPatient.DataSource = ds;
            GridPatient.DataBind();
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

    #region All Gridview Event
    protected void GridPatient_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridPatient_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void GridPatient_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridPatient.EditIndex = e.NewEditIndex;
        loaddata();
        
    }
    protected void GridPatient_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int PatientId = Convert.ToInt32(GridPatient.DataKeys[e.RowIndex].Values[0]);
        TextBox txtFullName = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtFullName");
        RadioButtonList rbtGender = (RadioButtonList)GridPatient.Rows[e.RowIndex].FindControl("rbtGender");
        TextBox txtAddress = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtAddress");
      
        DropDownList ddlCountry = (DropDownList)GridPatient.Rows[e.RowIndex].FindControl("ddlCountry") as DropDownList;
        DropDownList ddlState = (DropDownList)GridPatient.Rows[e.RowIndex].FindControl("ddlState") as DropDownList;
        DropDownList ddlCity = (DropDownList)GridPatient.Rows[e.RowIndex].FindControl("ddlCity") as DropDownList;
       
        TextBox txtZipCode = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtZipCode");
        TextBox txtUserName = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtUserName");
        Label txtPassword = (Label)GridPatient.Rows[e.RowIndex].FindControl("txtPassword");
        TextBox txtContactNumber = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtContactNumber");
        TextBox txtEmail = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtEmail");
      
        TextBox txtBDate = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtBDate");
     
        TextBox txtAge = (TextBox)GridPatient.Rows[e.RowIndex].FindControl("txtAge");
        Label lblPhoto = (Label)GridPatient.Rows[e.RowIndex].FindControl("lblPhoto");
        FileUpload fuProfileUpload = (FileUpload)GridPatient.Rows[e.RowIndex].FindControl("fuProfileUpload");

        int regid = Convert.ToInt32(Session["RegId"].ToString());
       

        if (fuProfileUpload.HasFile)
        {
            foreach (HttpPostedFile uploadedFile in fuProfileUpload.PostedFiles)
            {

                uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Profile/Patients/"),
                  uploadedFile.FileName));

                System.IO.File.Delete(Request.PhysicalApplicationPath + "Profile/Patients/" + lblPhoto.Text);
            }


            patient.EditPatientDetails(PatientId, txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, Convert.ToDateTime(txtBDate.Text), txtAge.Text, fuProfileUpload.FileName.ToString(), regid);
            ShowMessageBox("update Successfully");
        }
        else
        {

            patient.EditPatientDetails(PatientId, txtFullName.Text, rbtGender.SelectedValue, txtAddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), txtZipCode.Text, txtUserName.Text, txtPassword.Text, txtContactNumber.Text, txtEmail.Text, Convert.ToDateTime(txtBDate.Text), txtAge.Text, lblPhoto.Text, regid);
            ShowMessageBox("update Successfully");
        }

        GridPatient.EditIndex = -1;
        loaddata();

    }
    protected void GridPatient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridPatient.EditIndex = -1;
       
        loaddata();
      
    }
    protected void GridPatient_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridPatient.Rows[e.RowIndex];
        int PaitentId = Convert.ToInt32(GridPatient.DataKeys[e.RowIndex].Values[0]);
        patient.DeletePatientDetails(PaitentId);
        ShowMessageBox("Delete Successfully");

        GridPatient.EditIndex = -1;
        loaddata();
    }
    protected void GridPatient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowState.HasFlag(DataControlRowState.Edit) && (e.Row.DataItem != null)))
        {
            DropDownList ddlCountry = (DropDownList)e.Row.FindControl("ddlCountry") as DropDownList;
            DropDownList ddlState = (DropDownList)e.Row.FindControl("ddlState") as DropDownList;
            DropDownList ddlCity = (DropDownList)e.Row.FindControl("ddlCity") as DropDownList;
            ds = new DataSet();

            ds = cityCountryState.getContrybind();
            ddlCountry.DataSource = ds;
            // ddlCountry.Items.Clear();
            ddlCountry.DataTextField = "name";
            ddlCountry.DataValueField = "id";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select Country--", ""));
           
                HiddenField HiddenCountry = (HiddenField)e.Row.FindControl("HiddenCountry");
                ddlCountry.Items.FindByValue(HiddenCountry.Value).Selected = true;
           

            ds1 = new DataSet();
            ds1 = cityCountryState.getStatebind();
            ddlState.DataSource = ds1;
            ddlState.Items.Clear();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();


            ddlState.Items.Insert(0, new ListItem("--Select State--", ""));
            HiddenField HiddenState = (HiddenField)e.Row.FindControl("HiddenState");
            ddlState.Items.FindByValue(HiddenState.Value).Selected = true;


            int StateID = Convert.ToInt32(ddlState.SelectedValue);
            ds = new DataSet();
            ds.Clear();
            ds = cityCountryState.getcitybind(StateID);

            ddlCity.DataSource = ds;

            //ddlCity.Items.Clear();
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", ""));
            HiddenField Hiddencity = (HiddenField)e.Row.FindControl("Hiddencity");
            ddlCity.Items.FindByValue(Hiddencity.Value).Selected = true;

        }
    }
     #endregion
    #region All Gridview control  Event
   
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
        // Now convert sender as dropdown which is fired and you can get all the properties   of the dropdown
        DropDownList ddl = (DropDownList)sender;
        // Now fetch the data from the database based on selected drodpwon and bind that data to another dropdown this way
        DropDownList ddlState = gvr.FindControl("ddlState") as DropDownList;
        DropDownList ddlCity = gvr.FindControl("ddlCity") as DropDownList;
      
       // DropDownList ddlState = (DropDownList)FindControl("ddlState");
        int StateID = Convert.ToInt32(ddlState.SelectedValue);
        ds = new DataSet();
        ds.Clear();
        ds = cityCountryState.getcitybind(StateID);

        ddlCity.DataSource = ds;
        
        //ddlCity.Items.Clear();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("--Select City--", ""));
    }
    protected void txtFullName_TextChanged1(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtFullName = gvr.FindControl("txtFullName") as TextBox;
        Label lblFullNameError = gvr.FindControl("lblFullNameError") as Label;
        RadioButtonList rbtGender = gvr.FindControl("rbtGender") as RadioButtonList;
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
    protected void txtZipCode_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtZipCode = gvr.FindControl("txtZipCode") as TextBox;
        Label lblZipCode = gvr.FindControl("lblZipCode") as Label;
        TextBox txtUserName = gvr.FindControl("txtUserName") as TextBox;
      
        String Num = "^[1-9][0-9]*$";

        if (Regex.IsMatch(txtZipCode.Text, Num))
        {
            lblZipCode.Visible = false;
           txtUserName.Focus();
        }
        else
        {
            lblZipCode.Visible = true;
            lblZipCode.Text = "Please Enter Only Numeric";
            txtZipCode.Text = "";
            txtZipCode.Focus();
        }
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtUserName = gvr.FindControl("txtUserName") as TextBox;
        Label lblUserName = gvr.FindControl("lblUserName") as Label;
        TextBox txtContactNumber = gvr.FindControl("txtContactNumber") as TextBox;

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
                txtContactNumber.Focus();
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
    protected void txtContactNumber_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtContactNumber = gvr.FindControl("txtContactNumber") as TextBox;
        Label lblContactNumber = gvr.FindControl("lblContactNumber") as Label;
        TextBox txtEmail = gvr.FindControl("txtEmail") as TextBox;
        String Mobile = "^[7-9][0-9]{9}$";

        if (Regex.IsMatch(txtContactNumber.Text, Mobile))
        {
            lblContactNumber.Visible = false;
           txtEmail.Focus();
        }
        else
        {
            lblContactNumber.Visible = true;
            lblContactNumber.Text = "Please Enter Valid Contact Number(Begin with 7,8,9)";
            txtContactNumber.Text = "";
            txtContactNumber.Focus();
        }
    }
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtEmail = gvr.FindControl("txtEmail") as TextBox;
        Label lblEmail = gvr.FindControl("lblEmail") as Label;
        TextBox txtBDate = gvr.FindControl("txtBDate") as TextBox;
        string pattern = null;
        pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        if (Regex.IsMatch(txtEmail.Text, pattern))
        {
            lblEmail.Visible = false;
          //  txtBDate.Focus();
        }
        else
        {

            lblEmail.Visible = true;
            lblEmail.Text = "Please Enter Valid Email";
            txtEmail.Text = "";
            txtEmail.Focus();

        }
    }
    protected void txtBDate_TextChanged(object sender, EventArgs e)
    {
        
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtBDate = gvr.FindControl("txtBDate") as TextBox;
        Label lblBDate = gvr.FindControl("lblBDate") as Label;
        TextBox txtAge = gvr.FindControl("txtAge") as TextBox;
        string date = "2017-01-01";
        string olddate = "1950-01-01";
        if (Convert.ToDateTime(txtBDate.Text) < Convert.ToDateTime(date) || Convert.ToDateTime(txtBDate.Text) > Convert.ToDateTime(olddate))
        {
            lblBDate.Visible = false;
            txtAge.Focus();
        }
        else
        {

            lblBDate.Text = "Select Valid date";
            lblBDate.Visible = true;
            txtBDate.Focus();
            txtBDate.Text = "";
        }
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtAge = gvr.FindControl("txtAge") as TextBox;
        Label lblAge = gvr.FindControl("lblAge") as Label;
        TextBox txtBDate = gvr.FindControl("txtBDate") as TextBox;
        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtAge.Text, Num))
        {
            lblAge.Visible = false;
           // txtEmail.Focus();
        }
        else
        {
            lblAge.Visible = true;
            lblAge.Text = "Please Enter Only Numeric";
            txtAge.Text = "";
            txtAge.Focus();
        }
    }

    #endregion
  
}