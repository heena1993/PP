﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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
    <script type="text/javascript">
        function ConfirmDelete() {
            var count = document.getElementById("<%=hfCount.ClientID %>").value;
            var gv = document.getElementById("<%=GridTest.ClientID%>");
            var chk = gv.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked && chk[i].id.indexOf("chkAll") == -1) {
                    count++;
                }
            }
            if (count == 0) {
                alert("No records to delete.");
                return false;
            }
            else {
                return confirm("Do you want to delete " + count + " records.");
            }
        }
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
    /*//font-size: .875em;*/
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

    /*//background: #616161;*/
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                Test Details Add

            </div>
            <div class="panel-body">

                <div class="col-lg-12">
                    <div class="row">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <div class="col-sm-12">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-2 form-group" style="text-align: left;">
                                            <label>Test Name :</label>


                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <asp:TextBox ID="txtTestName" runat="server" placeholder="Enter Test Name Here.." AutoPostBack="true" OnTextChanged="txtTestName_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblFullNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-2 form-group" style="text-align: left;">
                                            <label>Test Description : </label>

                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <asp:TextBox ID="txtTestDesc" runat="server" placeholder="Enter Test Description Here.." TextMode="MultiLine" Rows="3" AutoPostBack="true" OnTextChanged="txtTestDesc_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblDesc" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <%--<button type="button" class="btn btn-lg btn-info" style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;">Submit</button>--%>
                            <div style="align-items: center">
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>


        <div class="panel panel-default">
            <div class="panel-heading">
                Test Details View

            </div>
            <div class="panel-body">

                <div class="col-lg-12">
                    <div class="row">
                        <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>

                        <asp:GridView ID="GridTest" runat="server" Visible="true" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="TestId" OnSelectedIndexChanged="GridTest_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="GridTest_PageIndexChanging" PageSize="3" AutoGenerateColumns="false" OnRowEditing="GridTest_RowEditing" OnRowUpdating="GridTest_RowUpdating" OnRowCancelingEdit="GridTest_RowCancelingEdit" OnRowDeleting="GridTest_RowDeleting">

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server"
                                            onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server"
                                            onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                               
                                  <asp:CommandField ShowEditButton="True"  />
                                 <asp:CommandField ShowDeleteButton="True" />
                                <asp:TemplateField HeaderText="Test Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestId" runat="server" Text='<%#Bind("TestId") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TestName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestName" runat="server" Text='<%#Bind("TestName") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:TextBox ID="txtTestName" runat="server" placeholder="Enter Test Name Here.." Text='<%#Bind("TestName") %>' AutoPostBack="true" class="form-control1" OnTextChanged="txtTestName_TextChanged1"></asp:TextBox>
                                        <asp:Label ID="lblTestNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TestDescription">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestDescription" runat="server" Text='<%#Bind("TestDescription") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:TextBox ID="txtTestDescription" runat="server" placeholder="Enter Test Description Here.." Text='<%#Bind("TestDescription") %>' TextMode="MultiLine" Rows="3" AutoPostBack="true" class="form-control1" OnTextChanged="txtTestDescription_TextChanged" ></asp:TextBox>
                                        <asp:Label ID="lblTestDescriptionError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>
                            </Columns>

                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Checked Records"
                            OnClientClick="return ConfirmDelete();" OnClick="btnDelete_Click" class="btn btn-danger" />
                    </div>
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>

