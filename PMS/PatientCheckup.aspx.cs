using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class PatientCheckup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void txtFullName_TextChanged(object sender, EventArgs e)
    {

    }

    protected bool ValidatePage()
    {
        bool flag = true;

        if (ddlName.SelectedValue == "")
        {
            lblNameError.Text = "Select Patient";
            lblNameError.Visible = true;
            flag = false;
            ddlName.Focus();

        }
        else
        {
            lblNameError.Visible = false;
            //flag = true;
        }
        if (txtAppoinmnentno.Text.Trim() == "")
        {
            lblAppoinmnentno.Text = "Enter Appoinmnent no";
            lblAppoinmnentno.Visible = true;
            flag = false;
            txtAppoinmnentno.Focus();
            txtAppoinmnentno.Text = "";
        }
        else
        {
            lblAppoinmnentno.Visible = false;
            //flag = true;
        }

        if (txtaddress.Text.Trim() == "")
        {
            lbladdress.Text = "Enter Address";
            lbladdress.Visible = true;
            flag = false;
            txtaddress.Focus();
            txtaddress.Text = "";
        }
        else
        {
            lbladdress.Visible = false;
            //flag = true;
        }


        if (txtage.Text.Trim() == "")
        {
            lblage.Text = "Enter Age";
            lblage.Visible = true;
            flag = false;
            txtage.Focus();
            txtage.Text = "";
        }
        else
        {
            lblage.Visible = false;
            //flag = true;
        }

        if (txtdate.Text.Trim() == "")
        {
            lbldate.Text = "Select Date";
            lbldate.Visible = true;
            flag = false;
            txtdate.Focus();
            txtdate.Text = "";
        }
        else
        {
            lbldate.Visible = false;
            //flag = true;
        }

        if (txtcaseno.Text.Trim() == "")
        {
            lblcaseno.Text = "Enter Case No";
            lblcaseno.Visible = true;
            flag = false;
            txtcaseno.Focus();
            txtcaseno.Text = "";
        }
        else
        {
            lblcaseno.Visible = false;
            //flag = true;
        }
        if (rbthistory.SelectedValue == "")
        {
            lblhistory.Text = "Select History";
            lblhistory.Visible = true;
            flag = false;
            rbthistory.Focus();

        }
        else
        {
            lblhistory.Visible = false;
            //flag = true;
        }

        if (ddldiseases.SelectedValue == "")
        {
            lbldiseases.Text = "Select Diseases";
            lbldiseases.Visible = true;
            flag = false;
            ddldiseases.Focus();

        }
        else
        {
            lbldiseases.Visible = false;
            //flag = true;
        }
        if (txtsymptoms.Text.Trim() == "")
        {
            lblsymptoms.Text = "Enter symptoms";
            lblsymptoms.Visible = true;
            flag = false;
            txtsymptoms.Focus();
            txtsymptoms.Text = "";
        }
        else
        {
            lblsymptoms.Visible = false;
            //flag = true;
        }

        if (txthistorysymtoms.Text.Trim() == "")
        {
            lblhistorysymtoms.Text = "Enter symptoms Discription";
            lblhistorysymtoms.Visible = true;
            flag = false;
            txthistorysymtoms.Focus();
            txthistorysymtoms.Text = "";
        }
        else
        {
            lblhistorysymtoms.Visible = false;
            //flag = true;
        }

        if (ddltest.SelectedValue == "")
        {
            lbltest.Text = "Select Test";
            lbltest.Visible = true;
            flag = false;
            ddltest.Focus();

        }
        else
        {
            lbltest.Visible = false;
            //flag = true;
        }

        if (txtmedicineday.Text.Trim() == "")
        {
            lblmedicineday.Text = "Enter Day of Medicine";
            lblmedicineday.Visible = true;
            flag = false;
            txtmedicineday.Focus();
            txtmedicineday.Text = "";
        }
        else
        {
            lblhistorysymtoms.Visible = false;
            //flag = true;
        }


        if (txtappoinmentdate.Text.Trim() == "")
        {
            lblappoinmentdate.Text = "Enter Appoinment Date";
            lblappoinmentdate.Visible = true;
            flag = false;
            txtappoinmentdate.Focus();
            txtappoinmentdate.Text = "";
        }
        else
        {
            lblappoinmentdate.Visible = false;
            //flag = true;
        }

        if (txtConsultingCharges.Text.Trim() == "")
        {
            lblConsultingCharges.Text = "Enter Consulting Charges";
            lblConsultingCharges.Visible = true;
            flag = false;
            txtConsultingCharges.Focus();
            txtConsultingCharges.Text = "";
        }
        else
        {
            lblConsultingCharges.Visible = false;
            //flag = true;
        }

        if (rbtpaymenttype.SelectedValue == "")
        {
            lblpaymenttype.Text = "Select Payment Type";
            lblpaymenttype.Visible = true;
            flag = false;
            rbtpaymenttype.Focus();

        }
        else
        {
            lblpaymenttype.Visible = false;
            //flag = true;
        }
        if (flag == false)
        {
            return false;
        }
        return true;
    }
    protected void btnChekUp_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
        }
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblNameError.Visible = false;
        txtAppoinmnentno.Focus();
    }
    protected void txtaddress_TextChanged(object sender, EventArgs e)
    {
        lbladdress.Visible = false;
        txtage.Focus();
    }
    protected void txtAppoinmnentno_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtAppoinmnentno.Text, Num))
        {
            lblAppoinmnentno.Visible = false;
            txtdate.Focus();
        }
        else
        {
            lblAppoinmnentno.Visible = true;
            lblAppoinmnentno.Text = "Please Enter Only Numeric";
            txtAppoinmnentno.Text = "";
            txtAppoinmnentno.Focus();
        }
      
    }
    protected void txtage_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtage.Text, Num))
        {
            lblage.Visible = false;
            txtcaseno.Focus();
        }
        else
        {
            lblage.Visible = true;
            lblage.Text = "Please Enter Only Numeric";
            txtage.Text = "";
            txtage.Focus();
        }
        
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        lbldate.Visible = false;
        txtaddress.Focus();
    }
    protected void txtcaseno_TextChanged(object sender, EventArgs e)
    {
       
        String caseno = "^[a-zA-Z0-9]*$";

        if (Regex.IsMatch(txtcaseno.Text, caseno))
        {
            lblcaseno.Visible = false;
            rbthistory.Focus();
        }
        else
        {
            lblcaseno.Visible = true;
            lblcaseno.Text = "Please Enter Valid Case no";
            txtcaseno.Text = "";
            txtcaseno.Focus();
        }


    }
    protected void rbthistory_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblhistory.Visible = false;
        ddldiseases.Focus();
    }
    protected void ddldiseases_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbldiseases.Visible = false;
        txtsymptoms.Focus();
    }
    protected void txtsymptoms_TextChanged(object sender, EventArgs e)
    {
        String symptoms = "^[a-zA-Z0-9,.]*$";

        if (Regex.IsMatch(txtsymptoms.Text, symptoms))
        {
            lblsymptoms.Visible = false;
            txthistorysymtoms.Focus();
        }
        else
        {
            lblsymptoms.Visible = true;
            lblsymptoms.Text = "Please Enter symtoms";
            txtsymptoms.Text = "";
            txtsymptoms.Focus();
        }

      
    }
    protected void txthistorysymtoms_TextChanged(object sender, EventArgs e)
    {


        String historysymtoms = "^[a-zA-Z0-9,.]*$";

        if (Regex.IsMatch(txthistorysymtoms.Text, historysymtoms))
        {
            lblhistorysymtoms.Visible = false;
            ddltest.Focus();
        }
        else
        {
            lblsymptoms.Visible = true;
            lblsymptoms.Text = "Please Enter History symtoms";
            txthistorysymtoms.Text = "";
            txthistorysymtoms.Focus();
        }
    }
    protected void ddltest_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbltest.Visible = false;
        txtmedicineday.Focus();
    }
    protected void txtmedicineday_TextChanged(object sender, EventArgs e)
    {
        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtmedicineday.Text, Num))
        {
            lblmedicineday.Visible = false;
            txtappoinmentdate.Focus();
        }
        else
        {
            lblmedicineday.Visible = true;
            lblmedicineday.Text = "Please Enter Only Numeric";
            txtmedicineday.Text = "";
            txtmedicineday.Focus();
        }
    }
    protected void txtappoinmentdate_TextChanged(object sender, EventArgs e)
    {
        lblappoinmentdate.Visible = false;
        txtConsultingCharges.Focus();
    }
    protected void txtConsultingCharges_TextChanged(object sender, EventArgs e)
    {
       
        String Num = "^[1-9][0-9]{1,2}$";

        if (Regex.IsMatch(txtConsultingCharges.Text, Num))
        {
            lblConsultingCharges.Visible = false;
            rbtpaymenttype.Focus();
        }
        else
        {
            lblConsultingCharges.Visible = true;
            lblConsultingCharges.Text = "Please Enter Only Numeric";
            txtConsultingCharges.Text = "";
            txtConsultingCharges.Focus();
        }
    }
    protected void rbtpaymenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblpaymenttype.Visible = false;
        btnChekUp.Focus();
    }
}