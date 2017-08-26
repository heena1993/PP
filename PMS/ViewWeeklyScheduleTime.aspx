<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewWeeklyScheduleTime.aspx.cs" Inherits="ViewWeeklyScheduleTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-10 content">

        <div class="panel panel-default">
            <div class="panel-heading">
                View Weekly Schedule

            </div>
            <div class="panel-body">


                <div class="col-sm-12">

                    <div class="box-body table-responsive no-padding">

                        <asp:GridView ID="GridWeeklySchedule" runat="server" Visible="true" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="DoctorId" AllowPaging="true" OnPageIndexChanging="GridWeeklySchedule_PageIndexChanging" PageSize="5" OnRowDataBound="GridWeeklySchedule_RowDataBound" EmptyDataText="No Record Found" AutoGenerateColumns="false" >

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="Doctor ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoctorId" runat="server" Text='<%#Bind("DoctorId") %>'></asp:Label>
                                        <asp:HiddenField ID="hfDoctorId" runat="server" Value='<%#Bind("DoctorId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Doctor Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoctorName" runat="server" Text='<%#Bind("DoctorName") %>'></asp:Label>
                                        <%-- <asp:HiddenField ID="hfPatientId" runat="server" Value='<%#Bind("PatientId") %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Week Start Date and End Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWeekStartDateEndDate" runat="server" Text='<%#Bind("WeekStartDateEndDate") %>'></asp:Label>
                                        <asp:HiddenField ID="hfWeekStartDateEndDate" Value='<%#Bind("WeekStartDateEndDate") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View Schedule">
                                    <ItemTemplate>
                                        <img alt="" style="cursor: pointer" src="images/plus.png" />
                                        <asp:Panel ID="pnlweeklySchedule" runat="server" Style="display: none">
                                             <div class="box-body table-responsive no-padding">
                                            <asp:GridView ID="GridWeeklyScheduleByStartDateAndEndDate" runat="server" AutoGenerateColumns="false" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Day">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDay" runat="server" Text='<%#Bind("Day") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Morning Timing">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMorning" runat="server" Text='<%#Bind("Morning","{0:hh-tt-ss}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Evening Timing">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEvening" runat="server" Text='<%#Bind("Evening","{0:hh-tt-ss}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                                 </div>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

