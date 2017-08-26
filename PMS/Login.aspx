<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

    

    <script type="text/javascript">

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="banner_w3ls page_head">
        <h1 style="margin-left: 113px; padding-top: 7px; font-size: 40px; font-weight: bold; color: white;">Login</h1>
    </div>


    <div class="container">
        <h3 class="title" style="margin-top: 30px">Login Here..</h3>

        <div class="row" style="margin-top: -44px;">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login" style="background-color: rgb(0, 210, 212);">
                    <%--<div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Login</a>
                            </div>
                            <div class="col-xs-6">
                                <a href="#" id="register-form-link">Register</a>
                            </div>
                        </div>
                    </div>--%>
                    <div class="panel-body" style="margin-top: 20px;">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 16px;">
                                    Select User Type:
                                </div>
                                <div class="col-lg-9" style="text-align: left;">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlUserType" runat="server" class="form-control">
                                            <asp:ListItem Text="---Select User Type" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Receptionist" Value="Receptionist"></asp:ListItem> 
                                            <asp:ListItem Text="Doctors" Value="Doctors"></asp:ListItem>
                                             <asp:ListItem Text="Patient" Value="Patient"></asp:ListItem>
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

                            <div class="form-group text-center">
                                <input type="checkbox" tabindex="3" class="" name="remember" id="remember">
                                <label for="remember" style="color: white; font-weight: bold; font-size: 16px;">Remember Me</label>
                            </div>
                            <div class="form-group" style="background-color: #f54785;">
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-3">
                                        <%--<input type="submit" name="login-submit" id="login-submit" tabindex="4" class="form-control btn btn-login" value="Log In">--%>

                                        <asp:Button ID="btnLogin" runat="server" Text="Log In" class="form-control btn btn-login" value="Log In" Style="background-color: #f54785; color: white; font-weight: bold; font-size: 16px;" OnClick="btnLogin_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <div class="text-left">
                                              <%--   <button type="button">Open Large Modal</button>--%>
                                                <a data-toggle="modal" data-target="#myModal" class="forgot-password" style="color: white; font-weight: bold; font-size: 16px;">Forgot Password?</a>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <div class="text-right">
                                                <a href="Register.aspx" tabindex="5" class="forgot-password" style="color: white; font-weight: bold; font-size: 16px;">Registration</a>
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

    <div class="container">
 
  <!-- Trigger the modal with a button -->
 

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-lg" style="width:500px">
      <div class="modal-content panel-login" style="background-color: rgb(0, 210, 212);">
        <div class="modal-header" style="background-color:#FFFFFF">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Forgot Password</h4>
        </div>
        <div class="modal-body">
          
            <div class="" style="background-color: rgb(0, 210, 212);">
                    <%--<div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Login</a>
                            </div>
                            <div class="col-xs-6">
                                <a href="#" id="register-form-link">Register</a>
                            </div>
                        </div>
                    </div>--%>
                    <div class="panel-body" style="margin-top: 20px;">
                        <div class="row">
                            
                            <div class="col-lg-12" style="vertical-align:middle">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 14px;margin-top:10px">
                                    User Type :
                                </div>
                                <div class="col-lg-9" style="text-align: left;vertical-align:middle">
                                    <div class="form-group">
                                        
                                        <asp:DropDownList ID="ddlUserTypeFgP" runat="server" class="form-control">
                                            <asp:ListItem Text="---Select User Type" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Receptionist" Value="Receptionist"></asp:ListItem> 
                                            <asp:ListItem Text="Doctors" Value="Doctors"></asp:ListItem>
                                             <asp:ListItem Text="Patient" Value="Patient"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-12" style="vertical-align:middle">
                                <div class="col-lg-3" style="color: white; font-weight: bold; font-size: 14px;margin-top:10px">
                                    Email :
                                </div>
                                <div class="col-lg-9" style="text-align: left;vertical-align:middle">
                                    <div class="form-group">
                                        <%--<input type="text" name="username" id="username" tabindex="1" class="form-control" placeholder="Username" value="">--%>
                                        <asp:TextBox ID="txtFrgEmail" TextMode="Email" runat="server" class="form-control" placeholder="Email ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="false" ></asp:CheckBoxList>
                                
                                <label for="remember" style="color: white; font-weight: bold; font-size: 16px;" ></label>
                            </div>
                            <div class="form-group" style="background-color: #f54785;">
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-3">
                                        <%--<input type="submit" name="login-submit" id="login-submit" tabindex="4" class="form-control btn btn-login" value="Log In">--%>

                                        <asp:Button ID="btnForgotPwd" runat="server" Text="Get Passoword" class="form-control btn btn-login" value="Get Passoword" Style="background-color: #f54785; color: white; font-weight: bold; font-size: 16px;" OnClick="btnForgotPwd_Click" />
                                    </div>
                                </div>
                            </div>
                     
                        </div>
                    </div>
                </div>
        </div>
        <div class="modal-footer" style="background-color:#FFFFFF">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</div>


    


</asp:Content>

