<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminProfile.aspx.cs" Inherits="AdminProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                Profile

            </div>
            <div class="panel-body">

                <div class="col-lg-12">
                    <div id="user-profile-2" class="user-profile">
                        <div class="tabbable">
                            <ul class="nav nav-tabs padding-18">
                                <li class="active">
                                    <a data-toggle="tab" href="#home" aria-expanded="true">
                                        <i class="green ace-icon fa fa-user bigger-120"></i>
                                        Profile
                                    </a>
                                </li>

                                <li class="">
                                    <a data-toggle="tab" href="#Edit" aria-expanded="false">
                                        <i class="orange ace-icon fa fa-rss bigger-120"></i>
                                        Edit Profile
                                    </a>
                                </li>




                            </ul>

                            <div class="tab-content no-border padding-24">
                                <div id="home" class="tab-pane in active">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3 center">
                                            <span class="profile-picture">
                                                <asp:Image ID="ViewImage" runat="server" class="editable img-responsive" Height="250px" />

                                            </span>

                                            <div class="space space-4"></div>




                                        </div>
                                        <!-- /.col -->

                                        <div class="col-xs-12 col-sm-9">

                                            <h4 class="blue">
                                                <span class="middle">
                                                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                                                </span>

                                                <span class="label label-purple arrowed-in-right">
                                                    <i class="ace-icon fa fa-circle smaller-80 align-middle"></i>
                                                    online
                                                </span>
                                            </h4>



                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Full Name :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblFullName" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Gender :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblGender" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Address :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblAddress" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>City :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblCity" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Pincode :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblPincode" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>State :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblState" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Country :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblCountry" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Birth Date :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblBDate" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Age :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblAge" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Email :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblEmail" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>Contact Number :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblContactNumber" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4 form-group" style="text-align: right;">
                                                    <label>UserName :</label>
                                                </div>
                                                <div class="col-sm-6 form-group" style="text-align: left;">
                                                    <asp:Label ID="lblUserName2" runat="server" Text="" ForeColor="#293faf"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>



                                            <div class="hr hr-8 dotted"></div>


                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->

                                    <div class="space-20"></div>

                                    <div class="row">


                                        <div class="col-xs-12 col-sm-6">
                                            <div class="widget-box transparent">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="space-20"></div>
                                </div>
                                <!-- /#home -->


                                <!-- /#Edit -->
                                <div id="Edit" class="tab-pane">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3 center">
                                            <span class="profile-picture">
                                                <asp:Image ID="EditImage" runat="server" class="editable img-responsive" Height="250px" />

                                            </span>

                                            <br />
                                            <br />
                                            <br />
                                            <asp:FileUpload ID="fuProfile" runat="server"  Width="200px"  />

                                            <asp:Label ID="lblExtension" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </div>
                                        <!-- /.col -->

                                        <div class="col-xs-12 col-sm-9">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>FullName :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtFullName" runat="server" AutoPostBack="true" OnTextChanged="txtFullName_TextChanged" placeholder="Enter FullName Here...." class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblFullNameError" runat="server" Text="" ForeColor="Red"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Gender :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:RadioButtonList ID="rbtGender" CssClass="radio-inline" AutoPostBack="true" OnSelectedIndexChanged="rbtGender_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" ForeColor="Black">
                                                                <asp:ListItem Text="Female&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Female"></asp:ListItem>
                                                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:Label ID="lblGenderError" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Address :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" Rows="3" runat="server" AutoPostBack="true" OnTextChanged="txtAddress_TextChanged" placeholder="Enter Address Here...." class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblAddressError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Country :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                                            <asp:Label ID="lblCountryError" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>State :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                                            <asp:Label ID="lblStateError" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>City :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                                            <asp:Label ID="lblCityError" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Pincode :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="true" OnTextChanged="txtZipCode_TextChanged" placeholder="Enter Pincode Here...." class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblZipCode" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Birth Date :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtBDate" runat="server" TextMode="Date" AutoPostBack="true" OnTextChanged="txtBDate_TextChanged" class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblBDateError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>



                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Age :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtAge" runat="server" placeholder="Enter Age Here...." AutoPostBack="true" OnTextChanged="txtAge_TextChanged" class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblAgeError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Email :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email Here...." AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblEmailError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>Contact Number :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtContactNumber" runat="server" AutoPostBack="true" OnTextChanged="txtContactNumber_TextChanged" placeholder="Enter Contact Number Here...." class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblContactNumberError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-sm-2 form-group" style="text-align: right;">
                                                            <label>UserName :</label>
                                                        </div>
                                                        <div class="col-sm-6 form-group" style="text-align: left;">
                                                            <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" placeholder="Enter UserName Here...." class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblUserNameError" runat="server" Text="" ForeColor="Red"></asp:Label>


                                                        </div>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;"  />



                                        </div>
                                        <div class="hr hr-8 dotted"></div>


                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <div class="space-20"></div>


                            </div>

                            <!-- /#feed -->


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

