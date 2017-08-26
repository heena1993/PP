<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AppoinmentApproval.aspx.cs" Inherits="AppoinmentApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="col-md-10 content">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="panel panel-default">
            <div class="panel-heading">
                Appointment Details Here....

            </div>
            <div class="panel-body">
              

                <div class="col-sm-12">

                    <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                        
                        <asp:GridView ID="GridAppoinmentApproval" runat="server"  class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" AllowPaging="true" OnPageIndexChanging="GridAppoinmentApproval_PageIndexChanging" PageSize="10" EmptyDataText="No Record Found" AutoGenerateColumns="false"  >

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTempId" runat="server" Text='<%#Bind("TempId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        <%-- <asp:HiddenField ID="hfPatientId" runat="server" Value='<%#Bind("PatientId") %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%#Bind("Time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Patient Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientName" runat="server" Text='<%#Bind("FullName") %>'></asp:Label>
                                        <asp:HiddenField ID="hfPatientId" runat="server" Value='<%#Bind("PatientId") %>' />

                                    </ItemTemplate>


                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Doctor Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoctorName" runat="server" Text='<%#Bind("DoctorName") %>'></asp:Label>
                                     

                                    </ItemTemplate>

                                </asp:TemplateField>
                                  

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="LinkApproval" CommandArgument='<%# Eval("TempId") + ";"+ Eval("PatientId")+";" + Eval("status") %> '  Text='<%# Bind("status") %>' OnCommand="LinkApproval_Command" runat="server"></asp:LinkButton>
                                    </ItemTemplate>


                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        
                            </ContentTemplate>
                             </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

