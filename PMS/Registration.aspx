<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        body {
            /*padding-top: 90px;*/
        }

        .panel-login {
            border-color: #ccc;
            -webkit-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            -moz-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
        }

            .panel-login > .panel-heading {
                color: #00415d;
                background-color: #fff;
                border-color: #fff;
                text-align: center;
            }

                .panel-login > .panel-heading a {
                    text-decoration: none;
                    color: #666;
                    font-weight: bold;
                    font-size: 15px;
                    -webkit-transition: all 0.1s linear;
                    -moz-transition: all 0.1s linear;
                    transition: all 0.1s linear;
                }

                    .panel-login > .panel-heading a.active {
                        color: #029f5b;
                        font-size: 18px;
                    }

                .panel-login > .panel-heading hr {
                    margin-top: 10px;
                    margin-bottom: 0px;
                    clear: both;
                    border: 0;
                    height: 1px;
                    background-image: -webkit-linear-gradient(left,rgba(0, 0, 0, 0),rgba(0, 0, 0, 0.15),rgba(0, 0, 0, 0));
                    background-image: -moz-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                    background-image: -ms-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                    background-image: -o-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                }

            .panel-login input[type="text"], .panel-login input[type="email"], .panel-login input[type="password"] {
                height: 45px;
                border: 1px solid #ddd;
                font-size: 16px;
                -webkit-transition: all 0.1s linear;
                -moz-transition: all 0.1s linear;
                transition: all 0.1s linear;
            }

            .panel-login input:hover,
            .panel-login input:focus {
                outline: none;
                -webkit-box-shadow: none;
                -moz-box-shadow: none;
                box-shadow: none;
                /*border-color: #ccc;*/
            }

        .btn-login {
            background-color: #59B2E0;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            /*border-color: #59B2E6;*/
        }

            .btn-login:hover,
            .btn-login:focus {
                color: #fff;
                background-color: #53A3CD;
                border-color: #53A3CD;
            }

        .forgot-password {
            text-decoration: underline;
            color: #888;
        }

            .forgot-password:hover,
            .forgot-password:focus {
                text-decoration: underline;
                color: #666;
            }

        .btn-register {
            background-color: #1CB94E;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            border-color: #1CB94A;
        }

            .btn-register:hover,
            .btn-register:focus {
                color: #fff;
                background-color: #1CA347;
                border-color: #1CA347;
            }
    </style>

    <script type="text/javascript" >

        $(function () {

            $('#login-form-link').click(function (e) {
                $("#login-form").delay(100).fadeIn(100);
                $("#register-form").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
            $('#register-form-link').click(function (e) {
                $("#register-form").delay(100).fadeIn(100);
                $("#login-form").fadeOut(100);
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="banner_w3ls page_head">
        <h1 style="margin-left: 113px; padding-top: 7px; font-size: 40px; font-weight: bold; color: white;">Registration</h1>
    </div>

    <div class="container">
        <h3 class="title" style="margin-top: 30px">Register Here..</h3>

        <div class="row" style="margin-top: -44px;">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login" style="background-color: rgb(0, 210, 212);">
                   
                    <div class="panel-body" style="margin-top: 20px;">
                        <div class="row">
                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Full Name :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtFullName" runat="server" class="form-control" placeholder="Full Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                     Address :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Birth Date:
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtBDate" TextMode="Date" runat="server" class="form-control" placeholder="Birth Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Age :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtAge" runat="server" class="form-control" placeholder="Age"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Gender :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        

                                        <asp:RadioButtonList ID="rbtGender" CssClass="radio-inline" runat="server" ForeColor="White" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Female&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Female"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>

                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    City :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                       <%-- <asp:TextBox ID="txtCity" runat="server" placeholder="City"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlCity" runat="server"  class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Contact  :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtContactNo" runat="server" class="form-control" placeholder="Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Email ID :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                           

                            <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Select User Type:
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlUserType" runat="server" class="form-control">
                                            <asp:ListItem Text="---Select User Type" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                            <asp:ListItem Text="Doctors" Value="Doctors"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>




                            <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    User Name :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Password :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <%--<input type="password" name="password" id="password" tabindex="2" class="form-control" placeholder="Password">--%>

                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Profile :
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        
                                        <asp:FileUpload ID="fuProfile" runat="server" ForeColor="White" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group text-center">
                                <input type="checkbox" tabindex="3" class="" name="remember" id="remember" />
                                <label for="remember" style="color: white; font-weight: bold; font-size: 16px;">I Agree Term and Condition</label>
                            </div>
                            <div class="form-group" style="background-color: #f54785;">
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-3">
                                        

                                        <asp:Button ID="btnRegister" runat="server" Text="Register" class="form-control btn btn-login" value="Log In" Style="background-color: #f54785; color: white; font-weight: bold; font-size: 16px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                           
                                        </div>

                                        <div class="col-lg-6">
                                            <div class="text-right">
                                                <a href="Login.aspx" tabindex="5" class="forgot-password" style="color: white; font-weight: bold; font-size: 16px;">Back</a>
                                            </div>
                                        </div>

                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

