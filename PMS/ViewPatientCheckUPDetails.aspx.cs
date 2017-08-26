using Saplin.Controls;
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

public partial class ViewPatientCheckUPDetails : System.Web.UI.Page
{
    PatientCheckUp.PatientChecup pCheckUP = new PatientCheckUp.PatientChecup();
    Patient.PatientRegistration patient = new Patient.PatientRegistration();
    Appointment.AppointmentBook appoint = new Appointment.AppointmentBook();
    DM.MedicalDiagnosis dm = new DM.MedicalDiagnosis();
    DataSet ds, ds1, ds2, ds3, ds4;
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
            ds = pCheckUP.GetPatientCheckupDetails();
            GridPatientCheckUp.DataSource = ds;
            GridPatientCheckUp.DataBind();
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList arr;
        if (ViewState["SelectedRecords"] != null)
            arr = (ArrayList)ViewState["SelectedRecords"];
        else
            arr = new ArrayList();
        CheckBox chkAll = (CheckBox)GridPatientCheckUp.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < GridPatientCheckUp.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                if (!arr.Contains(GridPatientCheckUp.DataKeys[i].Value))
                {
                    arr.Add(GridPatientCheckUp.DataKeys[i].Value);

                    // clear();
                    ds = new DataSet();
                    ds = pCheckUP.GetPatientCheckupDetailsBYPatientCheckupId(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()));
                    ds1 = new DataSet();
                    ds2 = new DataSet();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds1 = pCheckUP.GetPatientDieasesDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds.Tables[0].Rows[0]["CaseId"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["PatientId"].ToString()));
                        ds2 = pCheckUP.GetPatientTestDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds.Tables[0].Rows[0]["CaseId"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["PatientId"].ToString()));
                    }

                    for (int j = 0; ds1.Tables[0].Rows.Count > j; j++)
                    {
                        pCheckUP.DeletePatientDieasesDetails(Convert.ToInt32(ds1.Tables[0].Rows[j]["PatientDieasesID"].ToString()), Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds1.Tables[0].Rows[j]["CaseId"].ToString(), Convert.ToInt32(ds1.Tables[0].Rows[j]["PatientId"].ToString()));
                    }

                    for (int j = 0; ds2.Tables[0].Rows.Count > j; j++)
                    {
                        pCheckUP.DeletePatientTestDetails(Convert.ToInt32(ds2.Tables[0].Rows[j]["PatientTestID"].ToString()), Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds2.Tables[0].Rows[j]["CaseId"].ToString(), Convert.ToInt32(ds2.Tables[0].Rows[j]["PatientId"].ToString()));
                    }

                    pCheckUP.DeletePatientCheckupDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()));


                }
            }
            else
            {
                CheckBox chk = (CheckBox)GridPatientCheckUp.Rows[i]
                                   .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    if (!arr.Contains(GridPatientCheckUp.DataKeys[i].Value))
                    {
                        arr.Add(GridPatientCheckUp.DataKeys[i].Value);

                        // clear();
                        ds = new DataSet();
                        ds = pCheckUP.GetPatientCheckupDetailsBYPatientCheckupId(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()));
                        ds1 = new DataSet();
                        ds2 = new DataSet();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ds1 = pCheckUP.GetPatientDieasesDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds.Tables[0].Rows[0]["CaseId"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["PatientId"].ToString()));
                            ds2 = pCheckUP.GetPatientTestDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds.Tables[0].Rows[0]["CaseId"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["PatientId"].ToString()));
                        }

                        for (int j = 0; ds1.Tables[0].Rows.Count > j; j++)
                        {
                            pCheckUP.DeletePatientDieasesDetails(Convert.ToInt32(ds1.Tables[0].Rows[j]["PatientDieasesID"].ToString()), Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds1.Tables[0].Rows[j]["CaseId"].ToString(), Convert.ToInt32(ds1.Tables[0].Rows[j]["PatientId"].ToString()));
                        }

                        for (int j = 0; ds2.Tables[0].Rows.Count > j; j++)
                        {
                            pCheckUP.DeletePatientTestDetails(Convert.ToInt32(ds2.Tables[0].Rows[j]["PatientTestID"].ToString()), Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()), ds2.Tables[0].Rows[j]["CaseId"].ToString(), Convert.ToInt32(ds2.Tables[0].Rows[j]["PatientId"].ToString()));
                        }

                        pCheckUP.DeletePatientCheckupDetails(Convert.ToInt32(GridPatientCheckUp.DataKeys[i].Value.ToString()));

                    }
                }
                else
                {
                    if (arr.Contains(GridPatientCheckUp.DataKeys[i].Value))
                    {
                        arr.Remove(GridPatientCheckUp.DataKeys[i].Value);
                    }
                }
            }
        }
        ViewState["SelectedRecords"] = arr;
        loaddata();
    }

    #region All Gridview Events
    protected void GridPatientCheckUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridPatientCheckUp.Rows[e.RowIndex];
        int PatientCheckupId = Convert.ToInt32(GridPatientCheckUp.DataKeys[e.RowIndex].Values[0]);
        pCheckUP.DeletePatientCheckupDetails(PatientCheckupId);
        ShowMessageBox("Delete Successfully");

        GridPatientCheckUp.EditIndex = -1;
        loaddata();
    }
    protected void GridPatientCheckUp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridPatientCheckUp.EditIndex = -1;

        loaddata();
    }
    protected void GridPatientCheckUp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int PatientCheckupId = Convert.ToInt32(GridPatientCheckUp.DataKeys[e.RowIndex].Values[0]);

        DropDownList ddlPatientName = (DropDownList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("ddlPatientName") as DropDownList;
        RadioButtonList rbthistory = (RadioButtonList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("rbthistory");
        TextBox txtHistorySymtoms = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtHistorySymtoms");
        TextBox txtSymptoms = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtSymptoms");
        // DropDownList ddlDiseases = (DropDownList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("ddlDiseases") as DropDownList;
        TextBox txtMedician = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtMedician");
        TextBox txtConsultingCharges = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtConsultingCharges");
        TextBox txtMedicineDay = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtMedicineDay");
        TextBox txtAppoinmentDate = (TextBox)GridPatientCheckUp.Rows[e.RowIndex].FindControl("txtAppoinmentDate");
        // DropDownList ddlTest = (DropDownList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("ddlTest") as DropDownList;

        //Label lblTestReport = (Label)GridPatientCheckUp.Rows[e.RowIndex].FindControl("lblTestReport");
        CheckBoxList ddlDiseases = (CheckBoxList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("ddlDiseases") as CheckBoxList;
        CheckBoxList ChkListTest = (CheckBoxList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("ChkListTest") as CheckBoxList;


        //FileUpload fuTestReport = (FileUpload)GridPatientCheckUp.Rows[e.RowIndex].FindControl("fuTestReport");
        RadioButtonList rbtPaymentType = (RadioButtonList)GridPatientCheckUp.Rows[e.RowIndex].FindControl("rbtPaymentType");


        HiddenField hfPatientIdEdit = (HiddenField)GridPatientCheckUp.Rows[e.RowIndex].FindControl("hfPatientIdEdit");

        HiddenField hfCaseNoEdit = (HiddenField)GridPatientCheckUp.Rows[e.RowIndex].FindControl("hfCaseNoEdit");

        int regid = Convert.ToInt32(Session["RegId"].ToString());

        pCheckUP.EditPatientCheckupDetails(PatientCheckupId
                                              , Convert.ToInt32(ddlPatientName.SelectedValue)
                                              , rbthistory.SelectedValue
                                              , txtHistorySymtoms.Text
                                              , txtSymptoms.Text
                                              , txtMedician.Text
                                              , txtConsultingCharges.Text
                                              , txtMedicineDay.Text
                                              , Convert.ToDateTime(txtAppoinmentDate.Text)
                                              , rbtPaymentType.SelectedValue
                                              , regid);

        ShowMessageBox("update Successfully");

        ds = new DataSet();

        ds = pCheckUP.GetPatientDieasesDetails(PatientCheckupId, Convert.ToString(hfCaseNoEdit.Value), Convert.ToInt32(hfPatientIdEdit.Value));

        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            pCheckUP.DeletePatientDieasesDetails(Convert.ToInt32(ds.Tables[0].Rows[i]["PatientDieasesID"].ToString()), PatientCheckupId, ds.Tables[0].Rows[i]["CaseId"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["PatientId"].ToString()));
        }

        for (int i = 0; i < ddlDiseases.Items.Count; i++)
        {
            if (ddlDiseases.Items[i].Selected)
            {
                pCheckUP.InsertPatientDieasesDetails(PatientCheckupId, Convert.ToString(hfCaseNoEdit.Value)
                                               , Convert.ToInt32(ddlPatientName.SelectedValue)
                                               , Convert.ToInt32(ddlDiseases.Items[i].Value)
                                               , regid, regid);

            }
        }

        ds1 = new DataSet();

        ds1 = pCheckUP.GetPatientTestDetails(PatientCheckupId, Convert.ToString(hfCaseNoEdit.Value), Convert.ToInt32(hfPatientIdEdit.Value));

        for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
        {
            pCheckUP.DeletePatientTestDetails(Convert.ToInt32(ds1.Tables[0].Rows[i]["PatientTestID"].ToString()), PatientCheckupId, ds1.Tables[0].Rows[i]["CaseId"].ToString(), Convert.ToInt32(ds1.Tables[0].Rows[i]["PatientId"].ToString()));
        }



        //if (fuTestReport.HasFile)
        //{
        //    foreach (HttpPostedFile uploadedFile in fuTestReport.PostedFiles)
        //    {

        //        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("TestReportsUpload/"),
        //          uploadedFile.FileName));

        //        //System.IO.File.Delete(Request.PhysicalApplicationPath + "TestReportsUpload/" + );
        //    }

        for (int i = 0; i < ChkListTest.Items.Count; i++)
        {
            if (ChkListTest.Items[i].Selected)
            {
                pCheckUP.InsertPatientTestDetails(PatientCheckupId, Convert.ToString(hfCaseNoEdit.Value)
                                               , Convert.ToInt32(ddlPatientName.SelectedValue)
                                               , Convert.ToInt32(ChkListTest.Items[i].Value)
                                               , ""
                                               , regid, regid);

            }
        }

        //  }

        GridPatientCheckUp.EditIndex = -1;
        loaddata();



    }
    protected void GridPatientCheckUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridPatientCheckUp.PageIndex = e.NewPageIndex;
        loaddata();
        GridPatientCheckUp.DataBind();
    }
    protected void GridPatientCheckUp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridPatientCheckUp.EditIndex = e.NewEditIndex;
        loaddata();
    }
    protected void GridPatientCheckUp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridPatientCheckUp_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowState.HasFlag(DataControlRowState.Edit) && (e.Row.DataItem != null)))
        {
            //int PatientCheckupId = Convert.ToInt32(GridPatientCheckUp.DataKeys[e.DataRow].Values[0]);

            DropDownList ddlPatientName = (DropDownList)e.Row.FindControl("ddlPatientName") as DropDownList;
            // Saplin.Controls.DropDownCheckBoxes ddlDiseases = (DropDownCheckBoxes)e.Row.FindControl("ddlDiseases");

            CheckBoxList ddlDiseases = (CheckBoxList)e.Row.FindControl("ddlDiseases") as CheckBoxList;
            CheckBoxList ChkListTest = (CheckBoxList)e.Row.FindControl("ChkListTest") as CheckBoxList;

            Label lblDieasesId = (Label)e.Row.FindControl("lblDieasesId") as Label;
            Label lblPatientCheckupId = (Label)e.Row.FindControl("lblPatientCheckupId") as Label;


            lblDieasesId.Text = "";
            ds = new DataSet();

            ds = patient.GetPatientDetails();
            ddlPatientName.DataSource = ds;

            ddlPatientName.DataTextField = "FullName";
            ddlPatientName.DataValueField = "PatientId";
            ddlPatientName.DataBind();
            ddlPatientName.Items.Insert(0, new ListItem("--Select Patient Name--", ""));

            HiddenField hfPatientIdEdit = (HiddenField)e.Row.FindControl("hfPatientIdEdit");
            ddlPatientName.Items.FindByValue(hfPatientIdEdit.Value).Selected = true;

            HiddenField hfCaseNoEdit = (HiddenField)e.Row.FindControl("hfCaseNoEdit");
            //ds1.Clear();
            ds1 = new DataSet();


            ds1 = dm.GetDieasesDetails();

            ddlDiseases.DataSource = ds1.Tables[0];

            ddlDiseases.DataTextField = "DieasesName";
            ddlDiseases.DataValueField = "DieasesId";
            ddlDiseases.DataBind();

            ds2 = new DataSet();

            ds2 = pCheckUP.GetPatientDieasesDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNoEdit.Value), Convert.ToInt32(hfPatientIdEdit.Value));

            for (int i = 0; i < ddlDiseases.Items.Count; i++)
            {
                for (int j = 0; ds2.Tables[0].Rows.Count > j; j++)
                {
                    if (ds2.Tables[0].Rows[j]["DieasesId"].ToString() == ddlDiseases.Items[i].Value)
                    {
                        ddlDiseases.Items[i].Selected = true;
                    }
                }
            }


            ds3 = new DataSet();


            ds3 = dm.GetTestDetails();

            ChkListTest.DataSource = ds3.Tables[0];

            ChkListTest.DataTextField = "TestName";
            ChkListTest.DataValueField = "TestId";
            ChkListTest.DataBind();


            ds4 = new DataSet();

            ds4 = pCheckUP.GetPatientTestDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNoEdit.Value), Convert.ToInt32(hfPatientIdEdit.Value));

            for (int i = 0; i < ChkListTest.Items.Count; i++)
            {
                for (int j = 0; ds4.Tables[0].Rows.Count > j; j++)
                {
                    if (ds4.Tables[0].Rows[j]["TestId"].ToString() == ChkListTest.Items[i].Value)
                    {
                        ChkListTest.Items[i].Selected = true;
                    }
                }
            }


        }
        else if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.DataItem != null))
        {
            Label lblDieasesId = (Label)e.Row.FindControl("lblDieasesId") as Label;
            Label lblTestId = (Label)e.Row.FindControl("lblTestId") as Label;
            Label lblPatientCheckupId = (Label)e.Row.FindControl("lblPatientId") as Label;
            // Label lblTestReport = (Label)e.Row.FindControl("lblTestReport") as Label;
            HiddenField hfPatientId = (HiddenField)e.Row.FindControl("hfPatientId");

            lblDieasesId.Text = "";
            HiddenField hfCaseNo = (HiddenField)e.Row.FindControl("hfCaseNo");

            ds1 = new DataSet();

            ds1 = pCheckUP.GetPatientDieasesDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNo.Value), Convert.ToInt32(hfPatientId.Value));

            for (int i = 0; ds1.Tables[0].Rows.Count > i; i++)
            {
                lblDieasesId.Text = lblDieasesId.Text + ds1.Tables[0].Rows[i]["DieasesName"].ToString();
                lblDieasesId.Text = lblDieasesId.Text + ",";
            }

            ds2 = new DataSet();
            ds2 = pCheckUP.GetPatientTestDetails(Convert.ToInt32(lblPatientCheckupId.Text), Convert.ToString(hfCaseNo.Value), Convert.ToInt32(hfPatientId.Value));

            for (int i = 0; ds2.Tables[0].Rows.Count > i; i++)
            {
                lblTestId.Text = lblTestId.Text + ds2.Tables[0].Rows[i]["TestName"].ToString();
                lblTestId.Text = lblTestId.Text + ",";

                //lblTestReport.Text = lblTestReport.Text + ds2.Tables[0].Rows[i]["TestReport"].ToString();
                //lblTestReport.Text = lblTestReport.Text + ",";
            }


        }


    }

    #endregion

    #region All Textbox Event
    protected void ddlPatientName_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlPatientName = gvr.FindControl("ddlPatientName") as DropDownList;
        Label lblPatientNameError = gvr.FindControl("lblPatientNameError") as Label;
       // RadioButton rbthistory = gvr.FindControl("rbthistory") as RadioButton;
        TextBox txtHistorySymtoms = gvr.FindControl("txtHistorySymtoms") as TextBox;


        lblPatientNameError.Visible = false;
        txtHistorySymtoms.Focus();


    }
    protected void rbthistory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow gvr = (GridViewRow)((RadioButtonList)sender).Parent.Parent;
        //RadioButton rbthistory = gvr.FindControl("rbthistory") as RadioButton;
        //TextBox txtHistorySymtoms = gvr.FindControl("txtHistorySymtoms") as TextBox;
        //Label lblhistory = gvr.FindControl("lblhistory") as Label;

        //lblhistory.Visible = false;
        //txtHistorySymtoms.Focus();


    }

    
    protected void txtSymptoms_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        Label lblsymptoms = gvr.FindControl("lblsymptoms") as Label;
        TextBox txtsymptoms = gvr.FindControl("txtsymptoms") as TextBox;
        CheckBoxList ddldiseases = gvr.FindControl("ddldiseases") as CheckBoxList;
       

        string symptoms = "^[a-za-z0-9,. ]*$";

        if (Regex.IsMatch(txtsymptoms.Text, symptoms))
        {
            lblsymptoms.Visible = false;
            ddldiseases.Focus();
        }
        else
        {
            lblsymptoms.Visible = true;
            lblsymptoms.Text = "please enter symtoms";
            txtsymptoms.Text = "";
            txtsymptoms.Focus();
        }

    }

    protected void ddlDiseases_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
       
        Label lbldiseases = gvr.FindControl("lbldiseases") as Label;
        TextBox txtMedician = gvr.FindControl("txtMedician") as TextBox;

        lbldiseases.Visible = false;
        txtMedician.Focus();

    }
    protected void txtMedician_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtConsultingCharges = gvr.FindControl("txtConsultingCharges") as TextBox;
        Label lblMedician = gvr.FindControl("lblMedician") as Label;
        TextBox txtMedician = gvr.FindControl("txtMedician") as TextBox;

        String Medicians = "^[a-zA-Z0-9,.]*$";

        if (Regex.IsMatch(txtMedician.Text, Medicians))
        {
            lblMedician.Visible = false;
            txtConsultingCharges.Focus();
        }
        else
        {
            lblMedician.Visible = true;
            lblMedician.Text = "Please Enter Medician";
            txtMedician.Text = "";
            txtMedician.Focus();
        }


    }
    protected void txtConsultingCharges_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtConsultingCharges = gvr.FindControl("txtConsultingCharges") as TextBox;
        Label lblConsultingCharges = gvr.FindControl("lblConsultingCharges") as Label;
        TextBox txtMedicineDay = gvr.FindControl("txtMedicineDay") as TextBox;

        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtConsultingCharges.Text, Num))
        {
            lblConsultingCharges.Visible = false;
            txtMedicineDay.Focus();
        }
        else
        {
            lblConsultingCharges.Visible = true;
            lblConsultingCharges.Text = "Please Enter Only Numeric";
            txtConsultingCharges.Text = "";
            txtConsultingCharges.Focus();
        }

    }
    protected void txtMedicineDay_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtMedicineDay = gvr.FindControl("txtMedicineDay") as TextBox;
        Label lblMedicineDay = gvr.FindControl("lblMedicineDay") as Label;
        TextBox txtAppoinmentDate = gvr.FindControl("txtAppoinmentDate") as TextBox;

        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtMedicineDay.Text, Num))
        {
            lblMedicineDay.Visible = false;
            txtAppoinmentDate.Focus();
        }
        else
        {
            lblMedicineDay.Visible = true;
            lblMedicineDay.Text = "Please Enter Only Numeric";
            txtMedicineDay.Text = "";
            txtMedicineDay.Focus();
        }

    }
    protected void txtAppoinmentDate_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        RadioButtonList rbtPaymentType = gvr.FindControl("rbtPaymentType") as RadioButtonList;
        Label lblAppoinmentDate = gvr.FindControl("lblAppoinmentDate") as Label;
        TextBox txtAppoinmentDate = gvr.FindControl("txtAppoinmentDate") as TextBox;

        if (Convert.ToDateTime(txtAppoinmentDate.Text) > Convert.ToDateTime(DateTime.Now.ToString()))
        {
            lblAppoinmentDate.Visible = false;
            rbtPaymentType.Focus();
        }
        else
        {
            lblAppoinmentDate.Visible = true;
            lblAppoinmentDate.Text = "Select valid date";
            txtAppoinmentDate.Text = "";
            txtAppoinmentDate.Focus();
        }


    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlTest = gvr.FindControl("ddlTest") as DropDownList;
        Label lblTest = gvr.FindControl("lblTest") as Label;
        FileUpload fuTestReport = gvr.FindControl("fuTestReport") as FileUpload;

        lblTest.Visible = false;
        fuTestReport.Focus();


    }
    protected void rbtPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((RadioButtonList)sender).Parent.Parent;
        RadioButtonList rbtPaymentType = gvr.FindControl("rbtPaymentType") as RadioButtonList;
        Label lblPaymentType = gvr.FindControl("lblPaymentType") as Label;
        //FileUpload fuTestReport = gvr.FindControl("fuTestReport") as FileUpload;
        CheckBoxList ChkListTest = gvr.FindControl("ChkListTest") as CheckBoxList;
        ChkListTest.Focus();

        lblPaymentType.Visible = false;

    }
    protected void txtHistorySymtoms_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtHistorySymtoms = gvr.FindControl("txtHistorySymtoms") as TextBox;
        Label lblhistorysymtoms = gvr.FindControl("lblhistorysymtoms") as Label;
        TextBox txtSymptoms = gvr.FindControl("txtSymptoms") as TextBox;

        String historysymtoms = "^[a-zA-Z0-9,. ]*$";

        if (Regex.IsMatch(txtHistorySymtoms.Text, historysymtoms))
        {
            lblhistorysymtoms.Visible = false;
            txtSymptoms.Focus();
        }
        else
        {
            lblhistorysymtoms.Visible = true;
            lblhistorysymtoms.Text = "Please Enter History symtoms";
            txtHistorySymtoms.Text = "";
            txtHistorySymtoms.Focus();
        }
    }
    #endregion
   
}