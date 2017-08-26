<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewPatientCheckUPDetails.aspx.cs" Inherits="ViewPatientCheckUPDetails" %>

<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

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

    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            var count = document.getElementById("<%=hfCount.ClientID %>").value;
            var gv = document.getElementById("<%=GridPatientCheckUp.ClientID%>");
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
            /*background: #616161;*/
            background: #2fc8f1;
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
                View Patient CheckUP Details Here....

            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="col-sm-12">

                

                       
                    <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>

                        <asp:GridView ID="GridPatientCheckUp" runat="server" Visible="true" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="PatientCheckupId" OnSelectedIndexChanged="GridPatientCheckUp_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="GridPatientCheckUp_PageIndexChanging" PageSize="5" OnRowEditing="GridPatientCheckUp_RowEditing" OnRowUpdating="GridPatientCheckUp_RowUpdating" OnRowCancelingEdit="GridPatientCheckUp_RowCancelingEdit" OnRowDeleting="GridPatientCheckUp_RowDeleting" EmptyDataText="No Record Found" AutoGenerateColumns="false" OnRowDataBound="GridPatientCheckUp_RowDataBound">

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

                                <asp:CommandField ShowEditButton="True" />

                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:TemplateField HeaderText="Patient CheckUP Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientId" runat="server" Text='<%#Bind("PatientCheckupId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPatientCheckupId" runat="server" Text='<%#Bind("PatientCheckupId") %>'></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Patient Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientName" runat="server" Text='<%#Bind("FullName") %>'></asp:Label>
                                        <asp:HiddenField ID="hfPatientId" runat="server" Value='<%#Bind("PatientId") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      
                                                <asp:DropDownList ID="ddlPatientName" runat="server" class="form-control1" AutoPostBack="true" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblPatientNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <asp:HiddenField ID="hfPatientIdEdit" runat="server" Value='<%#Bind("PatientId") %>' />
                                            
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Case No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#Bind("CaseId") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCaseNo" runat="server" Value='<%#Bind("CaseId") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hfCaseNoEdit" runat="server" Value='<%#Bind("CaseId") %>' />
                                    </EditItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Appoinment Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppointmentDate" runat="server" Text='<%#Bind("Time") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:HiddenField ID="hfAppoinmentId" runat="server" Value='<%#Bind("AppoinmentId") %>' />
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="History">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHistory" runat="server" Text='<%#Bind("History") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       
                                                <asp:RadioButtonList ID="rbthistory" runat="server" RepeatDirection="Vertical" SelectedValue='<%#Bind("History") %>' class="radio-inline" AutoPostBack="true" OnSelectedIndexChanged="rbthistory_SelectedIndexChanged">
                                                    <asp:ListItem Text="NewHistory" Value="New History"></asp:ListItem>
                                                    <asp:ListItem Text="PreviousHistory" Value="Previous History"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:Label ID="lblhistory" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                           
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="History Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHistoryDescription" runat="server" Text='<%#Bind("HistoryDescriprtion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       
                                                <asp:TextBox ID="txtHistorySymtoms" runat="server" Text='<%#Bind("HistoryDescriprtion") %>' class="form-control1" TextMode="MultiLine" Rows="3" AutoPostBack="true" OnTextChanged="txtHistorySymtoms_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblhistorysymtoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                           
                                    </EditItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Symtoms">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSymtoms" runat="server" Text='<%#Bind("Symtoms") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      
                                                <asp:TextBox ID="txtSymptoms" runat="server" class="form-control1" Text='<%#Bind("Symtoms") %>' TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtSymptoms_TextChanged"> </asp:TextBox>
                                                <asp:Label ID="lblsymptoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                           </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Dieases Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDieasesId" runat="server" Text=""></asp:Label>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      
                                                <asp:Label ID="lblDieasesId" runat="server" Text=""></asp:Label>
                                                <%-- <asp:DropDownCheckBoxes ID="ddlDiseases" DataTextField="DieasesName" DataValueField="DieasesId" AddJQueryReference="true"  runat="server" te  CssClass="form-control1" Height="34px" UseSelectAllNode="false">
                                                    <Style SelectBoxWidth="307px" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="90" />
                                                     <Texts SelectBoxCaption="Select Dieases"/>
                                                
                                                </asp:DropDownCheckBoxes>--%>
                                                <%--<asp:DropDownList ID="ddlDiseases" runat="server" class="form-control1" AutoPostBack="true" OnSelectedIndexChanged="ddlDiseases_SelectedIndexChanged"></asp:DropDownList>--%>
                                                <asp:Label ID="lbldiseases" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <div style="width: 151px; height: 150px; overflow: auto" class="form-control1">
                                                    <asp:CheckBoxList ID="ddlDiseases" runat="server" TextAlign="Right" CellPadding="5" CellSpacing="5" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:CheckBoxList>
                                                </div>
                                         
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Medicine Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMedicineDetails" runat="server" Text='<%#Bind("MedicineDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        
                                                <asp:TextBox ID="txtMedician" runat="server" class="form-control1" Text='<%#Bind("MedicineDetails") %>' TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtMedician_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblMedician" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                           
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Consutancy Charge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblConsutancyCharge" runat="server" Text='<%#Bind("ConsutancyCharge") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        
                                                <asp:TextBox ID="txtConsultingCharges" runat="server" Text='<%#Bind("ConsutancyCharge") %>' CssClass="form-control1" AutoPostBack="true" OnTextChanged="txtConsultingCharges_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblConsultingCharges" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                           
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Medicine For Day">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMedicineForDay" runat="server" Text='<%#Bind("MedicineForDay") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       
                                                <asp:TextBox ID="txtMedicineDay" runat="server" Text='<%#Bind("MedicineForDay") %>' CssClass="form-control1" AutoPostBack="true" OnTextChanged="txtMedicineDay_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblMedicineDay" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                          
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Again Appoinment Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgainAppoinmentDate" runat="server" Text='<%#Bind("AgainAppoinmentDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      
                                                <asp:TextBox ID="txtAppoinmentDate" runat="server" Text='<%# Bind("AgainAppoinmentDate") %>' CssClass="form-control1" TextMode="Date" AutoPostBack="true" OnTextChanged="txtAppoinmentDate_TextChanged"></asp:TextBox>

                                                <asp:Label ID="lblAppoinmentDate" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                           
                                    </EditItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaymentType" runat="server" Text='<%#Bind("PaymentType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      
                                                <asp:RadioButtonList ID="rbtPaymentType" runat="server" SelectedValue='<%#Bind("PaymentType") %>' CssClass="radio-inline" RepeatDirection="Vertical" AutoPostBack="true" OnSelectedIndexChanged="rbtPaymentType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                </asp:RadioButtonList>

                                                <asp:Label ID="lblPaymentType" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Test Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestId" runat="server" Text=""></asp:Label>
                                        <%-- <asp:HiddenField ID="hfTestId" runat="server" Value='<%#Bind("TestId") %>' />--%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       
                                                <%--<asp:DropDownList ID="ddlTest" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged"></asp:DropDownList>--%>

                                                <div style="width: 151px; height: 150px; overflow: auto" class="form-control1">
                                                    <asp:CheckBoxList ID="ChkListTest" runat="server" TextAlign="Right" CellPadding="5" CellSpacing="5" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:CheckBoxList>
                                                </div>
                                                <asp:Label ID="lblTest" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                <%--  <asp:HiddenField ID="hfTestIdEdit" runat="server" Value='<%#Bind("TestId") %>' />--%>
                                            
                                    </EditItemTemplate>

                                </asp:TemplateField>

                              <%--  <asp:TemplateField HeaderText="TestReport">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTestReport" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        
                                        <asp:FileUpload ID="fuTestReport" runat="server" />
                                    </EditItemTemplate>

                                </asp:TemplateField>--%>



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
</asp:Content>

