using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dieases : System.Web.UI.Page
{
    DM.MedicalDiagnosis dm = new DM.MedicalDiagnosis();
    DataSet ds;
    private static int Dieasesid;
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
            ds = dm.GetDieasesDetails();
            GridDieases.DataSource = ds;
            GridDieases.DataBind();
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
            if (btnAdd.Text == "Submit")
            {
                int regid = Convert.ToInt32(Session["RegId"].ToString());

                dm.InsertDieasesDetails(txtName.Text, txtDesc.Text, regid, regid);
                ShowMessageBox("Insert Successfully");
                loaddata();
                clear();
            }
            else if (btnAdd.Text == "Update")
            {
                int regid = Convert.ToInt32(Session["RegId"].ToString());

                dm.EditDieasesDetails(Dieasesid,txtName.Text, txtDesc.Text, regid);
                ShowMessageBox("Update Successfully");
                loaddata();
                clear();
            }
        }
        else
        {
            ShowMessageBox("Fill the Form");
        }

    }

    protected bool ValidatePage()
    {
        bool flag = true;
        if (txtName.Text.Trim() == "")
        {
            lblFullNameError.Text = "Enter Name";
            lblFullNameError.Visible = true;
            flag = false;
            txtName.Focus();
            txtName.Text = "";
        }
        else
        {
            lblFullNameError.Visible = false;
            flag = true;
        }

        if (txtDesc.Text.Trim() == "")
        {
            lblDesc.Text = "Enter Description";
            lblDesc.Visible = true;
            flag = false;
            txtDesc.Focus();
            txtDesc.Text = "";
        }
        else
        {
            lblFullNameError.Visible = false;
            flag = true;
        }

        if (flag == false)
        {
            return false;
        }
        return true;

    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        String alpha = "^[A-Za-z0-9 ]+$";

        if (Regex.IsMatch(txtName.Text, alpha))
        {
            lblFullNameError.Visible = false;
            txtDesc.Focus();
        }
        else
        {
            lblFullNameError.Visible = true;
            lblFullNameError.Text = "Please Enter valid Name";
            txtName.Text = "";
            txtName.Focus();
        }
    }
    protected void txtDesc_TextChanged(object sender, EventArgs e)
    {
      
        String alphaNo = "^[a-zA-Z0-9,. ]*$";
        if (Regex.IsMatch(txtDesc.Text, alphaNo))
        {
            lblDesc.Visible = false;
            btnAdd.Focus();
        }
        else
        {
            lblDesc.Visible = true;
            lblDesc.Text = "Please Enter only Alpha Numeric";
            txtDesc.Text = "";
            txtDesc.Focus();
        }
    }

    protected void clear()
    {
        txtName.Text = "";
        txtDesc.Text = "";
        btnAdd.Text = "Submit";
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList arr;
        if (ViewState["SelectedRecords"] != null)
            arr = (ArrayList)ViewState["SelectedRecords"];
        else
            arr = new ArrayList();
        CheckBox chkAll = (CheckBox)GridDieases.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < GridDieases.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                if (!arr.Contains(GridDieases.DataKeys[i].Value))
                {
                    arr.Add(GridDieases.DataKeys[i].Value);
                    dm.DeleteDieasesDetails(Convert.ToInt32(GridDieases.DataKeys[i].Value.ToString()));
                    clear();
                }
            }
            else
            {
                CheckBox chk = (CheckBox)GridDieases.Rows[i]
                                   .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    if (!arr.Contains(GridDieases.DataKeys[i].Value))
                    {
                        arr.Add(GridDieases.DataKeys[i].Value);

                        dm.DeleteDieasesDetails(Convert.ToInt32(GridDieases.DataKeys[i].Value.ToString()));
                        clear();
                    }
                }
                else
                {
                    if (arr.Contains(GridDieases.DataKeys[i].Value))
                    {
                        arr.Remove(GridDieases.DataKeys[i].Value);
                    }
                }
            }
        }
        ViewState["SelectedRecords"] = arr;
        loaddata();
    }
    protected void GridDieases_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dieasesid = Convert.ToInt32(GridDieases.SelectedRow.Cells[2].Text);
        txtName.Text = GridDieases.SelectedRow.Cells[3].Text;
        txtDesc.Text = GridDieases.SelectedRow.Cells[4].Text;
        btnAdd.Text = "Update";
    }
    protected void GridDieases_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridDieases.PageIndex = e.NewPageIndex;
        loaddata();
        GridDieases.DataBind();
    }
    protected void GridDieases_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridDieases.EditIndex = e.NewEditIndex;
        loaddata();
    }
    protected void GridDieases_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }
    protected void GridDieases_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridDieases.EditIndex = -1;

        loaddata();
    }
    protected void GridDieases_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridDieases.Rows[e.RowIndex];
        int DieasesId = Convert.ToInt32(GridDieases.DataKeys[e.RowIndex].Values[0]);
        dm.DeleteDieasesDetails(DieasesId);
        ShowMessageBox("Delete Successfully");

        GridDieases.EditIndex = -1;
        loaddata();
    }
    protected void GridDieases_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int DieasesId = Convert.ToInt32(GridDieases.DataKeys[e.RowIndex].Values[0]);
        TextBox txtDieasesName = (TextBox)GridDieases.Rows[e.RowIndex].FindControl("txtDieasesName");

        TextBox txtDieasesDescription = (TextBox)GridDieases.Rows[e.RowIndex].FindControl("txtDieasesDescription");

        int regid = Convert.ToInt32(Session["RegId"].ToString());
        dm.EditDieasesDetails(DieasesId, txtDieasesName.Text, txtDieasesDescription.Text, regid);
        ShowMessageBox("update Successfully");
        GridDieases.EditIndex = -1;
        loaddata();
    }
    protected void txtDieasesName_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtDieasesName = gvr.FindControl("txtDieasesName") as TextBox;
        Label lblDieasesNameError = gvr.FindControl("lblDieasesNameError") as Label;
        TextBox txtDieasesDescription = gvr.FindControl("txtDieasesDescription") as TextBox;
        String alpha = "^[A-Za-z ]+$";

        if (Regex.IsMatch(txtDieasesName.Text, alpha))
        {
            lblDieasesNameError.Visible = false;
            txtDieasesDescription.Focus();
        }
        else
        {
            lblDieasesNameError.Visible = true;
            lblDieasesNameError.Text = "Please Enter valid Name";
            txtDieasesName.Text = "";
            txtDieasesName.Focus();
        }
    }
    protected void txtDieasesDescription_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtDieasesDescription = gvr.FindControl("txtDieasesDescription") as TextBox;
        Label lblDieasesDescriptionError = gvr.FindControl("lblDieasesDescriptionError") as Label;
        String alphaNo = "^[a-zA-Z0-9., ]*$";
        if (Regex.IsMatch(txtDieasesDescription.Text, alphaNo))
        {
            lblDieasesDescriptionError.Visible = false;
           // btnAdd.Focus();
        }
        else
        {
            lblDieasesDescriptionError.Visible = true;
            lblDieasesDescriptionError.Text = "Please Enter only Alpha Numeric";
            txtDieasesDescription.Text = "";
            txtDieasesDescription.Focus();
        }
    }
}