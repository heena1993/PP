using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    DM.MedicalDiagnosis dm = new DM.MedicalDiagnosis();
    DataSet ds;
    private static int Testid;
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
            ds = dm.GetTestDetails();
            GridTest.DataSource = ds;
            GridTest.DataBind();
        }
        catch (SqlException ex)
        {
            ShowMessageBox("Remote Acess Not Available");
        }

    }
   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            if (btnAdd.Text == "Add")
            {
                int regid = Convert.ToInt32(Session["RegId"].ToString());

                dm.InsertTestDetails(txtTestName.Text, txtTestDesc.Text, regid, regid);
                ShowMessageBox("Insert Successfully");
                loaddata();
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

    protected bool ValidatePage()
    {
        bool flag = true;
        if (txtTestName.Text.Trim() == "")
        {
            lblFullNameError.Text = "Enter Name";
            lblFullNameError.Visible = true;
            flag = false;
            txtTestName.Focus();
            txtTestName.Text = "";
        }
        else
        {
            lblFullNameError.Visible = false;
            
        }

        if (txtTestDesc.Text.Trim() == "")
        {
            lblDesc.Text = "Enter Description";
            lblDesc.Visible = true;
            flag = false;
            txtTestDesc.Focus();
            txtTestDesc.Text = "";
        }
        else
        {
            lblFullNameError.Visible = false;
            
        }

        if (flag == false)
        {
            return false;
        }
        return true;

    }

    protected void clear()
    {
        txtTestName.Text = "";
        txtTestDesc.Text = "";
        btnAdd.Text = "Add";
    }

    protected void txtTestName_TextChanged(object sender, EventArgs e)
    {
        String alpha = "^[A-Za-z0-9 ]+$";

        if (Regex.IsMatch(txtTestName.Text, alpha))
        {
            lblFullNameError.Visible = false;
            txtTestDesc.Focus();
        }
        else
        {
            lblFullNameError.Visible = true;
            lblFullNameError.Text = "Please Enter valid Name";
            txtTestName.Text = "";
            txtTestName.Focus();
        }
    }
    protected void txtTestDesc_TextChanged(object sender, EventArgs e)
    {
        String alphaNo = "^[a-zA-Z0-9., ]*$";
        if (Regex.IsMatch(txtTestDesc.Text, alphaNo))
        {
            lblDesc.Visible = false;
            btnAdd.Focus();
        }
        else
        {
            lblDesc.Visible = true;
            lblDesc.Text = "Please Enter only Alpha Numeric";
            txtTestDesc.Text = "";
            txtTestDesc.Focus();
        }

       
    }
    protected void GridTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        Testid = Convert.ToInt32(GridTest.SelectedRow.Cells[2].Text);
        txtTestName.Text = GridTest.SelectedRow.Cells[3].Text;
        txtTestDesc.Text = GridTest.SelectedRow.Cells[4].Text;
        btnAdd.Text = "Update";
    }
    protected void GridTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridTest.PageIndex = e.NewPageIndex;
        loaddata();
        GridTest.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void GridTest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridTest.EditIndex = e.NewEditIndex;
        loaddata();
        
    }
    protected void GridTest_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int TestId = Convert.ToInt32(GridTest.DataKeys[e.RowIndex].Values[0]);
        TextBox txtTestName = (TextBox)GridTest.Rows[e.RowIndex].FindControl("txtTestName");

        TextBox txtTestDescription = (TextBox)GridTest.Rows[e.RowIndex].FindControl("txtTestDescription");
      
        int regid = Convert.ToInt32(Session["RegId"].ToString());
        dm.EditTestDetails(TestId,txtTestName.Text,txtTestDescription.Text,regid);
        ShowMessageBox("update Successfully");
        GridTest.EditIndex = -1;
        loaddata();
    }
    protected void GridTest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridTest.EditIndex = -1;

        loaddata();
    }
    protected void GridTest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridTest.Rows[e.RowIndex];
        int TestId = Convert.ToInt32(GridTest.DataKeys[e.RowIndex].Values[0]);
         dm.DeleteTestDetails(TestId);
        ShowMessageBox("Delete Successfully");

        GridTest.EditIndex = -1;
        loaddata();
    }
    protected void txtTestName_TextChanged1(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtTestName = gvr.FindControl("txtTestName") as TextBox;
        Label lblTestNameError = gvr.FindControl("lblTestNameError") as Label;

        String alpha = "^[A-Za-z ]+$";

        if (Regex.IsMatch(txtTestName.Text, alpha))
        {
            lblTestNameError.Visible = false;
            txtTestDesc.Focus();
        }
        else
        {
            lblTestNameError.Visible = true;
            lblTestNameError.Text = "Please Enter valid Name";
            txtTestName.Text = "";
            txtTestName.Focus();
        }
    }

    protected void txtTestDescription_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblTestDescriptionError = (Label)currentRow.FindControl("lblTestDescriptionError");
        TextBox txtTestDescription = (TextBox)currentRow.FindControl("txtTestDescription");
        DropDownList ddlMedicianType = (DropDownList)currentRow.FindControl("ddlMedicianType");
        String alphaNo = "^[a-zA-Z0-9., ]*$";
        if (Regex.IsMatch(txtTestDescription.Text, alphaNo))
        {
            lblTestDescriptionError.Visible = false;
           // ddlMedicianType.Focus();
        }
        else
        {
            lblTestDescriptionError.Visible = true;
            lblTestDescriptionError.Text = "Please Enter only Alpha Numeric";
            txtTestDescription.Text = "";
            txtTestDescription.Focus();
        }
    }
}