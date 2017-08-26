<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="col-md-10 content">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="panel panel-default">
            <div class="panel-heading">
           Today's  Appointment View

            </div>
            <div class="panel-body">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                <div class="col-lg-12">

                    <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>

                        <asp:GridView ID="GridAppointment" runat="server" Visible="true" class="table table-hover"   HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="AppoinmentId" AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="GridAppointment_RowDataBound" >

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager"  />
                           <Columns>

                                <asp:TemplateField HeaderText="Appointment ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppoinmentId" runat="server" Text='<%#Bind("AppoinmentId") %>'></asp:Label>
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
                                        <asp:HiddenField ID="hfDoctorId" runat="server" Value='<%#Bind("DoctorId") %>' />

                                    </ItemTemplate>


                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Check Up Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCheckUpStatus" runat="server" Text='<%#Bind("AppoinmentStatus") %>'></asp:Label>
                                       
                                    </ItemTemplate>

                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="CheckUp">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Linkcheckup" runat="server" CommandArgument='<%# Eval("PatientId")+";"+ Eval("AppoinmentId")+";"+ Eval("Date","{0:dd-MMM-yyyy}")+";"+Eval("Time") %>' OnCommand="Linkcheckup_Command1">Check Up</asp:LinkButton>
                                       
                                    </ItemTemplate>


                                </asp:TemplateField>

                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                      
                    </div>
                </div>
                                        </ContentTemplate>
                     </asp:UpdatePanel>
            </div>
        </div>





    </div>
</asp:Content>

