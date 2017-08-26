using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public partial class Medician : System.Web.UI.Page
{
    LoginWeb.Login login = new LoginWeb.Login();
    DM.MedicalDiagnosis dm = new DM.MedicalDiagnosis();
    DataSet ds;
    public static GridViewRow currentRow;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MedicineLoaddata();
            //BindGridview();
        }

        DateTime dateValue = new DateTime(2014, 6, 12);
        Response.Write(dateValue.ToString("ddd"));

    }


   
    public void MedicineLoaddata()
    {
        try
        { 
            GridMedicine.DataKeyNames = new string[] { "MedicineId" };
            ds = new DataSet();
            ds = dm.GetMedicineDetails();
           
           
            GridMedicine.DataSource = ds;
            GridMedicine.DataBind();
        }
        catch (SqlException ex)
        {

        }

    }

    private void BindGridview()
    {
       
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
       
        String alphaNo = "^[a-zA-Z0-9]*$";

        if (Regex.IsMatch(txtName.Text, alphaNo))
        {
            lblNameError.Visible = false;
            txtDesc.Focus();
        }
        else
        {
            lblNameError.Visible = true;
            lblNameError.Text = "Please Enter only Alpha Numeric";
            txtName.Text = "";
            txtName.Focus();
        }
    }
    protected void txtDesc_TextChanged(object sender, EventArgs e)
    {
      

        String alphaNo = "^[a-zA-Z0-9, ]*$";
        if (Regex.IsMatch(txtDesc.Text, alphaNo))
        {
            lblDesc.Visible = false;
            txtMedicianPotency.Focus();
        }
        else
        {
            lblDesc.Visible = true;
            lblDesc.Text = "Please Enter only Alpha Numeric";
            txtDesc.Text = "";
            txtDesc.Focus();
        }
    }
    protected void ddlMedicianType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMedicianType.Visible = false;
        txtName.Focus();
    }
    protected void txtDoes_TextChanged(object sender, EventArgs e)
    {
        lblDoes.Visible = false;
       ddlMedicianUnit.Focus();
    }
    protected void ddlMedicianUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMedicianUnit.Visible = false;
        ddlMedicianUnit.Focus();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            dm.InsertMedicineDetails(txtName.Text,txtDesc.Text, ddlMedicianType.SelectedValue.ToString(), txtMedicianPotency.Text, txtDoes.Text, ddlMedicianUnit.SelectedValue.ToString(),1,1);
            ShowMessageBox("insert Successfully");
            MedicineLoaddata();
        }
    }
    protected void txtMedicianPotency_TextChanged(object sender, EventArgs e)
    {
        lblPotency.Visible = false;
        btnAdd.Focus();
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
        if (ddlMedicianType.SelectedValue == "")
        {
            lblMedicianType.Text = "Select MedicianType";
            lblMedicianType.Visible = true;
            flag = false;
            ddlMedicianType.Focus();

        }
        else
        {
            lblMedicianType.Visible = false;
            flag = true;
        }
        if (txtName.Text.Trim() == "")
        {
            lblNameError.Text = "Enter Medician Name";
            lblNameError.Visible = true;
            flag = false;
            txtName.Focus();
            txtName.Text = "";
        }
        else
        {
            lblNameError.Visible = false;
            flag = true;
        }

        if (txtDesc.Text.Trim() == "")
        {
            lblDesc.Text = "Enter Medician Description";
            lblDesc.Visible = true;
            flag = false;
            txtDesc.Focus();
            txtDesc.Text = "";
        }
        else
        {
            lblDesc.Visible = false;
            flag = true;
        }

        if (txtMedicianPotency.Text.Trim() == "")
        {
            lblPotency.Text = "Enter Medician Potency";
            lblPotency.Visible = true;
            flag = false;
            txtMedicianPotency.Focus();
            txtMedicianPotency.Text = "";
        }
        else
        {
            lblPotency.Visible = false;
            flag = true;
        }

        if (txtDoes.Text.Trim() == "")
        {
            lblDoes.Text = "Enter Does";
            lblDoes.Visible = true;
            flag = false;
            txtDoes.Focus();
            txtDoes.Text = "";
        }
        else
        {
            lblDoes.Visible = false;
            flag = true;
        }


        if (ddlMedicianUnit.SelectedValue == "")
        {
            lblMedicianUnit.Text = "Select Medician Unit";
            lblMedicianUnit.Visible = true;
            flag = false;
            ddlMedicianUnit.Focus();

        }
        else
        {
            lblMedicianUnit.Visible = false;
            flag = true;
        }


        if (flag == false)
        {
            return false;
        }
        return true;

    }
   
   
    protected void GridMedicine_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridMedicine.EditIndex = e.NewEditIndex;
        MedicineLoaddata();
    }
    protected void GridMedicine_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridMedicine.EditIndex = -1;
        MedicineLoaddata();
    }
    protected void GridMedicine_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //GridViewRow currentRow = GridMedicine.SelectedRow;
       // GridViewRow currentRow = GridMedicine.Rows[e.RowIndex];
         currentRow = (GridViewRow)GridMedicine.Rows[e.RowIndex];

        if (ValidatePage1(currentRow))
        {
        
            //GridViewRow row = GridMedicine.Rows[e.RowIndex];

            int MedicineId = Convert.ToInt32(GridMedicine.DataKeys[e.RowIndex].Values[0]);
            TextBox txtName = (TextBox)GridMedicine.Rows[e.RowIndex].FindControl("txtMedicineName");
            TextBox txtDesc = (TextBox)GridMedicine.Rows[e.RowIndex].FindControl("txtMedicineDescription");
            DropDownList ddlMedicianType1 = (DropDownList)GridMedicine.Rows[e.RowIndex].FindControl("ddlMedicianType") as DropDownList;

            string medicinetype = (GridMedicine.Rows[e.RowIndex].FindControl("ddlMedicianType") as DropDownList).SelectedItem.Value;
            TextBox txtMedicianPotency = (TextBox)GridMedicine.Rows[e.RowIndex].FindControl("txtMedicinePotency");
            TextBox txtDoes = (TextBox)GridMedicine.Rows[e.RowIndex].FindControl("txtMedicineDoes");
            DropDownList Units = (DropDownList)GridMedicine.Rows[e.RowIndex].FindControl("ddlMedicianUnit") as DropDownList;
            string unit = (GridMedicine.Rows[e.RowIndex].FindControl("ddlMedicianUnit") as DropDownList).SelectedItem.Value;

           
            dm.EditMedicineDetails(MedicineId, txtName.Text, txtDesc.Text, medicinetype, txtMedicianPotency.Text, txtDoes.Text, unit, 1);
            ShowMessageBox("update Successfully");

            GridMedicine.EditIndex = -1;
            MedicineLoaddata();
        }
    }




    protected bool ValidatePage1(GridViewRow currentRow)
    {
        bool flag = true;

        DropDownList ddlMedicianType = (DropDownList)currentRow.FindControl("ddlMedicianType");
        Label lblMedicianType = (Label)currentRow.FindControl("lblMedicianType");
        TextBox txtName = (TextBox)currentRow.FindControl("txtMedicineName");
        Label lblNameError = (Label)currentRow.FindControl("lblNameError1");
        TextBox txtDesc = (TextBox)currentRow.FindControl("txtMedicineDescription");
        Label lblDesc = (Label)currentRow.FindControl("lblDesc");
        TextBox txtMedicianPotency = (TextBox)currentRow.FindControl("txtMedicinePotency");
        Label lblPotency = (Label)currentRow.FindControl("lblPotency");
        TextBox txtDoes = (TextBox)currentRow.FindControl("txtMedicineDoes");
        Label lblDoes = (Label)currentRow.FindControl("lblDoes");
        DropDownList ddlMedicianUnit = (DropDownList)currentRow.FindControl("ddlMedicianUnit");
        Label lblMedicianUnit = (Label)currentRow.FindControl("lblMedicianUnit");

        if (ddlMedicianType.SelectedValue == "")
        {
            lblMedicianType.Text = "Select MedicianType";
            lblMedicianType.Visible = true;
            flag = false;
            txtDesc.Focus();

        }
        else
        {
            lblMedicianType.Visible = false;
            flag = true;
        }
       
        if (txtName.Text.Trim() == "")
        {
            lblNameError.Text = "Enter Medician Name";
            lblNameError.Visible = true;
            flag = false;
            ddlMedicianType.Focus();
            txtName.Text = "";
        }
        else
        {
            lblNameError.Visible = false;
            flag = true;
        }
     
        if (txtDesc.Text.Trim() == "")
        {
            lblDesc.Text = "Enter Medician Description";
            lblDesc.Visible = true;
            flag = false;
            txtDesc.Focus();
            txtDesc.Text = "";
        }
        else
        {
            lblDesc.Visible = false;
            flag = true;
        }
     
        if (txtMedicianPotency.Text.Trim() == "")
        {
            lblPotency.Text = "Enter Medician Potency";
            lblPotency.Visible = true;
            flag = false;
            txtMedicianPotency.Focus();
            txtMedicianPotency.Text = "";
        }
        else
        {
            lblPotency.Visible = false;
            flag = true;
        }
       
        if (txtDoes.Text.Trim() == "")
        {
            lblDoes.Text = "Enter Does";
            lblDoes.Visible = true;
            flag = false;
            txtDoes.Focus();
            txtDoes.Text = "";
        }
        else
        {
            lblDoes.Visible = false;
            flag = true;
        }
     
        if (ddlMedicianUnit.SelectedValue == "")
        {
            lblMedicianUnit.Text = "Select Medician Unit";
            lblMedicianUnit.Visible = true;
            flag = false;
            ddlMedicianUnit.Focus();

        }
        else
        {
            lblMedicianUnit.Visible = false;
            flag = true;
        }


        if (flag == false)
        {
            return false;
        }
        return true;

    }
    protected void GridMedicine_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridMedicine.Rows[e.RowIndex];
        int MedicineId = Convert.ToInt32(GridMedicine.DataKeys[e.RowIndex].Values[0]);
        dm.DeleteMedicineDetails(MedicineId);
        ShowMessageBox("Delete Successfully");

        GridMedicine.EditIndex = -1;
        MedicineLoaddata();
    }
    protected void GridMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridMedicine_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridMedicine_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowType == DataControlRowType.DataRow)  && (e.Row.DataItem != null))
        {
            GridView gvarray = (GridView)e.Row.FindControl("gvarray") as GridView;
           
            string[] arrlist = { "aspdotnet", "Suresh", "Dasari", "India", "AndhraPradesh", "Guntur" };
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            for (int i = 0; i < arrlist.Count(); i++)
            {
                dt.Rows.Add();
                dt.Rows[i]["Name"] = arrlist[i].ToString();
            }
            gvarray.DataSource = dt;
            gvarray.DataBind();
           
        }
       
    }
    protected void txtMedicineName_TextChanged(object sender, EventArgs e)
    {
      
        String alphaNo = "^[a-zA-Z0-9]*$";
        GridViewRow currentRow =(GridViewRow)((TextBox)sender).Parent.Parent;

        TextBox txtName = (TextBox)currentRow.FindControl("txtMedicineName");
       Label lblNameError1 = (Label)currentRow.FindControl("lblNameError1");
        if (Regex.IsMatch(txtName.Text, alphaNo))
        {
            lblNameError1.Visible = false;
            txtDesc.Focus();
        }
        else
        {
            lblNameError1.Visible = true;
            lblNameError1.Text = "Please Enter only Alpha Numeric";
            txtName.Text = "";
            txtName.Focus();
        }
    }
    protected void txtMedicineDescription_TextChanged(object sender, EventArgs e)
    {
      //  TextBox txtName = (TextBox)currentRow.FindControl("txtMedicineName");
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblDesc = (Label)currentRow.FindControl("lblDesc");
        TextBox txtMedicineDescription = (TextBox)currentRow.FindControl("txtMedicineDescription");
        DropDownList ddlMedicianType = (DropDownList)currentRow.FindControl("ddlMedicianType");
        String alphaNo = "^[a-zA-Z0-9., ]*$";
        if (Regex.IsMatch(txtMedicineDescription.Text, alphaNo))
        {
            lblDesc.Visible = false;
            ddlMedicianType.Focus();
        }
        else
        {
            lblDesc.Visible = true;
            lblDesc.Text = "Please Enter only Alpha Numeric";
            txtMedicineDescription.Text = "";
            txtMedicineDescription.Focus();
        }

      //  lblDesc.Visible = false;
       
    }
    protected void ddlMedicianType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblMedicianType = (Label)currentRow.FindControl("lblMedicianType");
        lblMedicianType.Visible = false;
        //txtName.Focus();
    }
    protected void txtMedicinePotency_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblPotency = (Label)currentRow.FindControl("lblPotency");
        lblPotency.Visible = false;
    }
    protected void txtMedicineDoes_TextChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblDoes = (Label)currentRow.FindControl("lblDoes");
        lblDoes.Visible = false;
    }
    protected void ddlMedicianUnit_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

        Label lblMedicianUnit = (Label)currentRow.FindControl("lblMedicianUnit");
        lblMedicianUnit.Visible = false;
    }
    protected void txtEnd_TextChanged(object sender, EventArgs e)
    {
        DateTime start = DateTime.ParseExact(txtStart.Text, "HH:mm tt", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(txtEnd.Text, "HH:mm tt", CultureInfo.InvariantCulture);

        int interval = 30;
        List<string> lstTimeIntervals = new List<string>();
        for (DateTime i = start; i < end; i = i.AddMinutes(interval))
            lstTimeIntervals.Add(i.ToString("HH:mm tt"));

        dropdownList.DataSource = lstTimeIntervals;
        dropdownList.DataBind();
    }
}