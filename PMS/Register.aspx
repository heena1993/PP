<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        @import "font-awesome.min.css";
        @import "font-awesome-ie7.min.css";
        /* Space out content a bit */
        body {
            /*padding-top: 20px;
            padding-bottom: 20px;*/
        }

        /* Everything but the jumbotron gets side spacing for mobile first views */
        .header,
        .marketing,
        .footer {
            /*padding-right: 15px;
            padding-left: 15px;*/
        }

        /* Custom page header */
        .header {
            border-bottom: 1px solid #e5e5e5;
        }
            /* Make the masthead heading the same height as the navigation */
            .header h3 {
                padding-bottom: 19px;
                margin-top: 0;
                margin-bottom: 0;
                line-height: 40px;
            }

        /* Custom page footer */
        .footer {
            padding-top: 19px;
            color: #777;
            border-top: 1px solid #e5e5e5;
        }

        /* Customize container */
        @media (min-width: 768px) {
            .container1 {
                /*max-width: 730px;*/
                max-width: 1030px;
                margin-left: 150px;
                margin-right: 150px;
            }
        }

        .container-narrow > hr {
            margin: 30px 0;
        }

        /* Main marketing message and sign up button */
        .jumbotron {
            text-align: center;
            border-bottom: 1px solid #e5e5e5;
        }

            .jumbotron .btn {
                padding: 14px 24px;
                font-size: 21px;
            }

        /* Supporting marketing content */
        .marketing {
            margin: 40px 0;
        }

            .marketing p + h4 {
                margin-top: 28px;
            }

        /* Responsive: Portrait tablets and up */
        @media screen and (min-width: 768px) {
            /* Remove the padding we set earlier */
            .header,
            .marketing,
            .footer {
                padding-right: 0;
                padding-left: 0;
            }
            /* Space out the masthead */
            .header {
                margin-bottom: 30px;
            }
            /* Remove the bottom border on the jumbotron for visual effect */
            .jumbotron {
                border-bottom: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="banner_w3ls page_head">
        <h1 style="margin-left: 113px; padding-top: 7px; font-size: 40px; font-weight: bold; color: white;">Registration</h1>
    </div>

    <div class="container1" style="margin-top: 12px;">
        <h3 class="title" style="margin-top: 30px">Register Here..</h3>
        <div class="col-lg-12 well" style="margin-top: -34px; background-color: rgb(0, 210, 212); color: white; font-size: 16px;">

            <div class="row">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>Full Name :</label>

                                    <asp:TextBox ID="txtFullName" runat="server" placeholder="Enter Full Name Here.." AutoPostBack="true" OnTextChanged="txtFullName_TextChanged" class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblFullNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                    <label>Gender : </label>
                                    <br />

                                    <asp:RadioButtonList ID="rbtGender" CssClass="radio-inline" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtGender_SelectedIndexChanged" RepeatDirection="Horizontal" ForeColor="White">
                                        <asp:ListItem Text="Female&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Female"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:Label ID="lblGender" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>


                                <div class="col-sm-6 form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address Here.." AutoPostBack="true" OnTextChanged="txtAddress_TextChanged" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    <asp:Label ID="lblAddress" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-sm-3 form-group">

                                    <label>Country</label>

                                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                    <asp:Label ID="lblCountry" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label>State</label>

                                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                    <asp:Label ID="lblState" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label>City</label>
                                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" class="form-control">
                                        <asp:ListItem Text="Valsad" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblCity" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label>Zip</label>
                                    <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="true" OnTextChanged="txtZipCode_TextChanged" placeholder="Enter Zip Code Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblZipCode" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                            </div>
                            <div class="row">

                                <div class="col-sm-6 form-group">
                                    <label>Birth Date</label>
                                    <asp:TextBox ID="txtBDate" runat="server" TextMode="Date" AutoPostBack="true" OnTextChanged="txtBDate_TextChanged" placeholder="Enter Birth Date Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblBDate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" placeholder="Enter Email ID Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblEmail" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Age :</label>
                                    <asp:TextBox ID="txtAge" runat="server" AutoPostBack="true" OnTextChanged="txtAge_TextChanged" placeholder="Enter Age Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblAge" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                    <label>Contact Number :</label>
                                    <asp:TextBox ID="txtContactNumber" MaxLength="10" TextMode="Number" AutoPostBack="true" OnTextChanged="txtContactNumber_TextChanged" runat="server" placeholder="Enter Contact Number Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblContactNumber" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group">
                                    <label>Select User Type</label>
                                    <%--<input type="text" placeholder="Enter Phone Number Here.." class="form-control">--%>
                                    <asp:DropDownList ID="ddlUserType" runat="server" class="form-control" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select User Type Here.." Value=""></asp:ListItem>
                                        <asp:ListItem Text="Receptionist" Value="Receptionist"></asp:ListItem>
                                        <asp:ListItem Text="Patient" Value="Patient"></asp:ListItem>
                                        <asp:ListItem Text="Doctor" Value="Doctor"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblUserType" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <asp:Panel ID="PanelDoctors" runat="server" Visible="false">

                                    <div class="col-sm-4 form-group">
                                        <label>Hospital Name :</label>
                                        <asp:TextBox ID="txtHospitalName" runat="server" placeholder="Enter Hospital Name Here.." class="form-control" OnTextChanged="txtHospitalName_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblHospitalName" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label>Qualification</label>
                                        <asp:TextBox ID="txtQualification" runat="server" placeholder="Enter Qualification Here.." class="form-control" OnTextChanged="txtQualification_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblQualification" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label>Specialist</label>
                                        <asp:TextBox ID="txtSpecialize" runat="server" placeholder="Enter Specialist Here.." class="form-control" OnTextChanged="txtSpecialize_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblSpecialize" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </div>

                                </asp:Panel>
                                <div class="col-sm-4 form-group">
                                    <label>UserName</label>
                                    <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" placeholder="Enter UserName Here.." class="form-control"></asp:TextBox>
                                    <asp:Label ID="lblUserName" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password Here.." class="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="lblPassword" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>

                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <label>Choose Photo :</label>
                        <asp:FileUpload ID="fuProfileUpload" runat="server" ForeColor="White" />
                        <asp:Label ID="lblProfileUpload" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    </div>

                    <%--<button type="button" class="btn btn-lg btn-info" style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;">Submit</button>--%>

                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>

