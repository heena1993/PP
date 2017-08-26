<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="viewFutureAppointmentToDoctors.aspx.cs" Inherits="viewFutureAppointmentToDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-10 content">

        <div class="panel panel-default">
            <div class="panel-heading">
                View Today's Appointment Details Here....

            </div>
            <div class="panel-body">
              

                <div class="col-sm-12">

                    <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>

                        <asp:GridView ID="GridFutureAppointmntTODoctors" runat="server" Visible="false" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="AppoinmentId" AllowPaging="true" OnPageIndexChanging="GridPatientCheckUp_PageIndexChanging" PageSize="5" EmptyDataText="No Record Found" AutoGenerateColumns="false">

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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

                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        
                        <asp:GridView ID="GridFutureAppointmntTOAdmin" runat="server" Visible="false" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="AppoinmentId" AllowPaging="true" OnPageIndexChanging="GridPatientCheckUp_PageIndexChanging" PageSize="5" EmptyDataText="No Record Found" AutoGenerateColumns="false">

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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

                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

