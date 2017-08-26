<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DoctorWeeklySchedule.aspx.cs" Inherits="DoctorWeeklySchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-10 content">

        <div class="panel panel-default">
            <div class="panel-heading">
                Patient Register Form

            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-2 form-group" style="text-align: left;">
                                    <label runat="server" id="lbldoctor" visible="false">Doctor :</label>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:DropDownList ID="ddlDoctorName" Visible="false" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctorName_SelectedIndexChanged"></asp:DropDownList>

                                       <asp:Label ID="lblDoctorName" runat="server" Visible="true" ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2 form-group" style="text-align: left;">
                                    <label>Date :</label>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date" AutoPostBack="true" OnTextChanged="txtDate_TextChanged" class="form-control"></asp:TextBox>
                                      <asp:Label ID="lblDateError" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                            <%--<div class="row">

                               

                                <div class="col-sm-0 form-group">
                                    <br />
                                    <br />
                                    <label>Mor :</label>
                                    <br />
                                    <br />
                                    <label>Eve :</label>
                                </div>
                                <div class="col-sm-2  form-group">
                                    <asp:Label ID="lblday1" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldaynm1" runat="server" Text=""></asp:Label>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:Label ID="lblday2" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldaynm2" runat="server" Text=""></asp:Label>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:Label ID="lblday3" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldaynm3" runat="server" Text=""></asp:Label>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:Label ID="lblday4" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldaynm4" runat="server" Text=""></asp:Label>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:Label ID="lblday5" runat="server" Text=""></asp:Label>

                                    <br />
                                    <asp:Label ID="lbldaynm5" runat="server" Text=""></asp:Label>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:Label ID="lblday6" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldaynm6" runat="server" Text=""></asp:Label>

                                </div>


                            </div>--%>
                            <%-- <div class="row">
                                <div class="col-sm-2 form-group">
                                    <asp:TextBox ID="txtday1mor" TextMode="Time" runat="server" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday1tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday1eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday1toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 form-group">

                                    <asp:TextBox ID="txtday2mor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday2tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday2eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday2toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:TextBox ID="txtday3mor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday3tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday3eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday3toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>

                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:TextBox ID="txtday4mor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday4tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday4eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday4toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 form-group">
                                    <asp:TextBox ID="txtday5mor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday5tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday5eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday5toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>

                                </div>
                                <div class="col-sm-2 form-group">

                                    <asp:TextBox ID="txtday6mor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday6tomor" runat="server" TextMode="Time" Width="50px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtday6eve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>To :
                                    <asp:TextBox ID="txtday6toeve" runat="server" TextMode="Time" Width="50px"></asp:TextBox>

                                </div>
                            </div>--%>



                            <div class="row">
                                <div class="table-responsive">
                                    <table class="table" style="font-size: 18px; font-style: initial;">
                                        <thead style="border-top: 2px solid #ffffff;background: rgb(245, 71, 133);font-size:20px;">
                                            <tr>
                                                <th style="color: white;">Weekly Date</th>
                                                <th style="color: white;">Morning Timing</th>
                                                <th style="color: white;">Evening Timing</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday1" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbldaynm1" runat="server" Text=""></asp:Label>


                                                </td>

                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday1mor" CssClass="form-control" TextMode="Time" runat="server"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time:<asp:TextBox ID="txtday1tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday1eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%-- <div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday1toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </td>

                                            </tr>


                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday2" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbldaynm2" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday2mor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time<asp:TextBox ID="txtday2tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday2eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday2toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </td>
                                            </tr>


                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday3" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbldaynm3" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday3mor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday3tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday3eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday3toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </td>
                                            </tr>


                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday4" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbldaynm4" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday4mor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday4tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                  
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday4eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%-- <div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday4toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    
                                                </td>
                                            </tr>


                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday5" runat="server" Text=""></asp:Label>

                                                    <br />
                                                    <asp:Label ID="lbldaynm5" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday5mor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%-- <div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday5tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                   
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday5eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday5toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    
                                                </td>
                                            </tr>


                                            <tr style="border-bottom: 1px solid #0c0c0c;">
                                                <td>
                                                    <asp:Label ID="lblday6" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbldaynm6" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday6mor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                        <%--<div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time :<asp:TextBox ID="txtday6tomor" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            From Time :<asp:TextBox ID="txtday6eve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                       <%-- <div class="col-sm-2 form-group">
                                                            To :
                                                        </div>--%>
                                                        <div class="col-sm-6 form-group">
                                                            To Time:<asp:TextBox ID="txtday6toeve" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <div class="row">
                                                       <div class="col-sm-6 form-group">
                                                       <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                                                 </div>
                                                         <div class="col-sm-6 form-group">
                                                             </div>
                                                     </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>

