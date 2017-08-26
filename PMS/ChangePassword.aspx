<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
               Change Password here.....

            </div>
            <div class="panel-body">

                <div class="col-lg-12">

                    <div class="row">
                        <div class="col-sm-4 form-group" style="text-align: right;">
                            <label>Old Password :</label>


                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="txtOld" runat="server" TextMode="Password" placeholder="Enter Old Password Here.." class="form-control"></asp:TextBox>
                            <asp:Label ID="lblOld" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            <br />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4 form-group" style="text-align: right;">
                            <label>New Password :</label>


                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="txtNew" runat="server" TextMode="Password" placeholder="Enter New Password Here.." class="form-control"></asp:TextBox>
                            <asp:Label ID="lblNew" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            <br />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4 form-group" style="text-align: right;">
                            <label>Confirm Password :</label>


                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" placeholder="Enter Confirm Password Here.." class="form-control"></asp:TextBox>
                            <asp:Label ID="lblConfirm" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            <br />
                        </div>
                    </div>

                    <asp:Button ID="btnChangePwd" runat="server" OnClick="btnChangePwd_Click" Text="Change Password" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

