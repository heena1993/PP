<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="PatientAppoinment.aspx.cs" Inherits="PatientAppoinment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
     <script type="text/javascript">
<!--
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    inputList[i].checked = true;
                }
                else {
                    if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
    //-->
    </script>
   

    <style type="text/css">

        .GridPager a,
.GridPager span {
    display: inline-block;
    padding: 0px 9px;
    margin-right: 4px;
    border-radius: 3px;
    border: solid 1px #c0c0c0;
    background: #e9e9e9;
    box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
    //font-size: .875em;
    font-size: -0.125em;
    font-weight: bold;
    text-decoration: none;
    color: #717171;
    text-shadow: 0px 1px 0px rgba(255,255,255, 1);
}

.GridPager a {
    background-color: #f5f5f5;
    color: #969696;
    border: 1px solid #969696;
}

.GridPager span {

    //background: #616161;
    background:#2fc8f1;
    box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
    color: #f0f0f0;
    text-shadow: 0px 0px 3px rgba(0,0,0, .5);
    border: 1px solid #3AC0F2;
}

    </style> 

     <style>
        .form-control1 {
            display: block;
            width: 113px;
            height: 31px;
            padding: 6px 12px;
            font-size: 13px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                Appointment Book

            </div>
            <div class="panel-body">

                <div class="col-lg-12">
                    <div class="col-lg-12">
                        <div class="row">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <div class="col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-2 form-group" style="text-align: left;">
                                                <label>Date :</label>


                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"  AutoPostBack="true" OnTextChanged="txtDate_TextChanged" class="form-control"></asp:TextBox>

                                                <asp:Label ID="lblDateError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <br />
                                            </div>
                                        </div>
                                       
                                        
                                        <div class="row">
                                            <div class="col-sm-2 form-group" style="text-align: left;">
                                                <label>Patient Name : </label>

                                            </div>
                                            <div class="col-sm-4 form-group">
                                              
                                                <asp:TextBox ID="txtPatient" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPatient_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblPatient" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <br />
                                            </div>
                                            <div class="col-sm-2 form-group" style="text-align: right;">
                                                <label>Doctors :</label>


                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <asp:DropDownList ID="ddlDoctors" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctors_SelectedIndexChanged">

                                                </asp:DropDownList>

                                                <asp:Label ID="lblDoctors" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <br />
                                            </div>
                                        </div>
                                         <div class="row">
                                            <div class="col-sm-2 form-group" style="text-align: left;">
                                                <label> Time:</label>


                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <asp:DropDownList ID="ddlFromTime" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFromTime_SelectedIndexChanged">
                                                   <asp:ListItem Value="">---------Select FromTime-----------</asp:ListItem>
                                                </asp:DropDownList>
                                               
                                                <asp:Label ID="lblFromtime" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <br />
                                            </div>

                                             
                                        </div>
                                      

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <%--<button type="button" class="btn btn-lg btn-info" style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;">Submit</button>--%>
                                <div style="align-items: center">
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                                </div>
                            </div>
                        </div>

                    </div>
                    
                </div>
            </div>
        </div>



    </div>
</asp:Content>

