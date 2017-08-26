<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddPatientCheckUPDetails.aspx.cs" Inherits="AddPatientCheckUPDetails" %>

<%--<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-10 content">

        <div class="panel panel-default">
            <div class="panel-heading">
                Patient CheckUp Form

            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">

                                <div class="col-sm-4 form-group">
                                    <label>Select Patient Name :</label>

                                    <asp:DropDownList ID="ddlPatientName" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lblPatientNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>Date:</label>

                                    <asp:TextBox ID="txtdate" ReadOnly="true" runat="server" TextMode="Date" class="form-control" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lbldate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>select Appointment:</label>

                                    <asp:DropDownList ID="ddlAppointmentTime" runat="server" ReadOnly="true" CssClass="form-control" Enabled="false" ></asp:DropDownList>
                                    <asp:Label ID="lblAppointError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                            <label style="font-size: 18px;">Click Here.. for View Patient Details</label>
                            <asp:ImageButton ID="ImgPlus" runat="server" Height="40px" Width="51px" OnClick="ImgPlus_Click" AlternateText="Show Patient Details" ImageUrl="~/images/plus.png" /></h5>
                            <asp:Panel ID="PanelPatientDetails" runat="server" Visible="false">

                                <hr />
                                <div class="row">
                                    <div class="col-sm-2 form-group">

                                        <label>Photo:</label>

                                        <asp:Image ID="patientimage" runat="server" Width="150" Height="150" />

                                    </div>
                                    <div class="col-sm-5 form-group">
                                        <label>Patient Name  :  </label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                        <hr />
                                        <label>Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                        <hr />
                                        <label>Birth Details  :  </label>
                                        <asp:Label ID="lblBDate" runat="server" Text=""></asp:Label>
                                        <br />
                                        <label>Age  :</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>

                                    </div>
                                    <div class="col-sm-5 form-group">

                                        <label>Appointment  :  </label>
                                        <asp:Label ID="lblAppointmentDate" runat="server" Text=""></asp:Label>
                                        <hr />
                                        <label>Form Time:</label>
                                        <asp:Label ID="lblFromTime" runat="server" Text=""></asp:Label>
                                        <hr />
                                        <label>To Time :  </label>
                                        <asp:Label ID="lblToTime" runat="server" Text=""></asp:Label>

                                    </div>

                                </div>

                            </asp:Panel>

                            <hr />
                            <h5>Patient CheckUP Details</h5>
                            <hr />
                            <div class="row">
                                <div class="col-sm-4 form-group">

                                    <label>History:</label>
                                    <asp:RadioButtonList ID="rbthistory" runat="server" RepeatDirection="Horizontal" CssClass="form-inline" AutoPostBack="true" OnSelectedIndexChanged="rbthistory_SelectedIndexChanged">
                                        <asp:ListItem Text="New History&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="New History"></asp:ListItem>
                                        <asp:ListItem Text="Previous History" Value="Previous History"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:Label ID="lblhistory" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>Case Paper No :</label>

                                    <asp:TextBox ID="txtCaseNo" ReadOnly="true" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txtCaseNo_TextChanged"></asp:TextBox>
                                    <asp:DropDownList ID="ddlAllCaseNoByPatientID" ReadOnly="true" runat="server" Visible="false" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAllCaseNoByPatientID_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lblCaseNo" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>Diseases :</label>

                                    <%--<asp:DropDownList ID="ddlDiseases" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldiseases_SelectedIndexChanged"></asp:DropDownList>--%>

                                    <div style="width: 220px; height: 67px; overflow: auto" class="form-control">
                                        <asp:CheckBoxList ID="chklistdieases" runat="server" TextAlign="Right" RepeatColumns="1" CellPadding="0" CellSpacing="0" RepeatDirection="Vertical" RepeatLayout="Table" OnSelectedIndexChanged="chklistdieases_SelectedIndexChanged1" AutoPostBack="true"  ></asp:CheckBoxList>
                                    </div>

                                    <%--<asp:DropDownCheckBoxes ID="ddlDiseases" Style="height:34px"  runat="server" CssClass="form-control" Height="34px" UseSelectAllNode="false">
                                        <Style SelectBoxWidth="307px" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="90" />
                                        <Items>
                                           
                                        </Items>
                                    </asp:DropDownCheckBoxes>--%>
                                    <asp:Label ID="lbldiseases" runat="server" Visible="false" ForeColor="Red"></asp:Label>



                                </div>
                                <div class="col-sm-4 form-group">
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group">
                                    <label>Symptoms :</label>

                                    <asp:TextBox ID="txtSymptoms" runat="server" class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtSymptoms_TextChanged"> </asp:TextBox>
                                    <asp:Label ID="lblsymptoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>History:</label>
                                    <asp:TextBox ID="txtHistorySymtoms" runat="server" class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtHistorySymtoms_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblhistorysymtoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="col-sm-4 form-group">
                                    <label>Medicians Details:</label>
                                    <asp:TextBox ID="txtMedician" runat="server" class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtMedician_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblMedician" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                            </div>


                            <hr />

                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>Medicine For No OF Days:</label>
                                    <asp:TextBox ID="txtMedicineDay" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMedicineDay_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblMedicineDay" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="col-sm-6 form-group">
                                    <label>Next Appoinment Date :</label>
                                    <asp:TextBox ID="txtAppoinmentDate" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtAppoinmentDate_TextChanged"></asp:TextBox>

                                    <asp:Label ID="lblAppoinmentDate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6 form-group">

                                    <label>Consulting Charges :</label>

                                    <asp:TextBox ID="txtConsultingCharges" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtConsultingCharges_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblConsultingCharges" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Payment Type :</label>
                                    <asp:RadioButtonList ID="rbtPaymentType" runat="server" CssClass="form-inline" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtPaymentType_SelectedIndexChanged">
                                        <asp:ListItem Text="Cash&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Cash"></asp:ListItem>
                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <asp:Label ID="lblPaymentType" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>



                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>Test To Be Done:</label>

                                    <%--<asp:DropDownList ID="ddlTest" runat="server" CssClass="form-control" AutoPostBack="false" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged"></asp:DropDownList>--%>
                                    <div style="width: 250px; height: 67px; overflow: auto" class="form-control">
                                        <asp:CheckBoxList ID="chklistTest" runat="server" TextAlign="Right" RepeatColumns="1" CellPadding="0" CellSpacing="0" RepeatDirection="Vertical" RepeatLayout="Table"></asp:CheckBoxList>
                                    </div>



                                    <asp:Label ID="lblTest" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <%-- <div class="col-sm-6 form-group">

                            <label>Test Report Upload:</label>
                            <asp:FileUpload ID="fuTestReport" runat="server" />
                        </div>--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <asp:Button ID="btnChekUp" runat="server" OnClick="btnChekUp_Click" Text="Submit" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />

                </div>
            </div>
        </div>
    </div>

</asp:Content>

