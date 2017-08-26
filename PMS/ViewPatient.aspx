<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewPatient.aspx.cs" Inherits="ViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }

    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            var count = document.getElementById("<%=hfCount.ClientID %>").value;
            var gv = document.getElementById("<%=GridPatient.ClientID%>");
            var chk = gv.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked && chk[i].id.indexOf("chkAll") == -1) {
                    count++;
                }
            }
            if (count == 0) {
                alert("No records to delete.");
                return false;
            }
            else {
                return confirm("Do you want to delete " + count + " records.");
            }
        }
    </script>

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

    <style>
        .form-control1 {
            display: block;
            width: 113px;
            height: 31px;
            padding: 6px 12px;
            font-size: 13px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                Dieases Add

            </div>
            <div class="panel-body">

                <div class="col-lg-12">

                    <div class="box-body table-responsive no-padding">
                        <%--<asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="javascript:return Confirmationbox();" />--%>

                        <asp:GridView ID="GridPatient" runat="server" Visible="true" class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" DataKeyNames="PatientId" OnSelectedIndexChanged="GridPatient_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="GridPatient_PageIndexChanging" PageSize="5" OnRowEditing="GridPatient_RowEditing" OnRowUpdating="GridPatient_RowUpdating" OnRowCancelingEdit="GridPatient_RowCancelingEdit" OnRowDeleting="GridPatient_RowDeleting" EmptyDataText="No Record Found" AutoGenerateColumns="false" OnRowDataBound="GridPatient_RowDataBound">

                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server"
                                            onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server"
                                            onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowEditButton="True" />

                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:TemplateField HeaderText="Patient Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientId" runat="server" Text='<%#Bind("PatientId") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="FullName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FullName") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:TextBox ID="txtFullName" runat="server" placeholder="Enter Full Name Here.." Text='<%#Bind("FullName") %>' AutoPostBack="true" class="form-control1" OnTextChanged="txtFullName_TextChanged1"></asp:TextBox>
                                        <asp:Label ID="lblFullNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%#Bind("Gender") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="rbtGender" class="radio-inline" runat="server" AutoPostBack="true" RepeatDirection="Vertical" ForeColor="Black" SelectedValue='<%#Bind("Gender") %>'>
                                            <asp:ListItem Text="Female&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Female"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:Label ID="lblGender" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Bind("Address") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address Here.." AutoPostBack="true" class="form-control1" Text='<%#Bind("Address") %>' TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        <asp:Label ID="lblAddress" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountryId" runat="server" Text='<%#Bind("name") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" class="form-control1">
                                           
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenCountry" runat="server" Value='<%#Bind("CountryId") %>'/>
                                        <asp:Label ID="lblCountry" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="State Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStateId" runat="server" Text='<%#Bind("StateName") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" class="form-control1" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" >
                                           
                                        </asp:DropDownList>
                                         <asp:HiddenField ID="HiddenState" runat="server" Value='<%#Bind("StateId") %>' />
                                        <asp:Label ID="lblState" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCityId" runat="server" Text='<%#Bind("CityName") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" class="form-control1" >
                                         
                                        </asp:DropDownList>
                                        <asp:Label ID="lblCity" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                          <asp:HiddenField ID="HiddenCity" runat="server" Value='<%#Bind("CityId") %>' />
                                    </EditItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Pincode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPincode" runat="server" Text='<%#Bind("Pincode") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="true" placeholder="Enter Zip Code Here.." Text='<%#Bind("Pincode") %>' class="form-control1" OnTextChanged="txtZipCode_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblZipCode" runat="server" Visible="false" ForeColor="Red"></asp:Label>

                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="true" placeholder="Enter UserName Here.." Text='<%#Bind("UserName") %>' class="form-control1" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblUserName" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Password">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassword" runat="server" Text='<%#Bind("Password") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtPassword" runat="server" Text='<%#Bind("Password") %>'></asp:Label>
                                   <%--     <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password Here.." Text='<%#Bind("Password") %>' class="form-control1" TextMode="Password"></asp:TextBox>--%>
                                        <asp:Label ID="lblPassword" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ContactNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Bind("ContactNo") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtContactNumber" MaxLength="10" TextMode="Number" AutoPostBack="true" Text='<%#Bind("ContactNo") %>' runat="server" placeholder="Enter Contact Number Here.." class="form-control1" OnTextChanged="txtContactNumber_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblContactNumber" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EmailId">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("EmailId") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="true" placeholder="Enter Email ID Here.." Text='<%#Bind("EmailId") %>' class="form-control1" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblEmail" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BirthDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBirthDate" runat="server" Text='<%#Bind("BirthDate","{0:dd-MMM-yyyy}") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBDate" runat="server" TextMode="Date" AutoPostBack="true" Text='<%# Bind("BirthDate","{0:yyyy-MM-dd}") %>' class="form-control1" OnTextChanged="txtBDate_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblBDate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Age">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAge" runat="server" Text='<%#Bind("Age") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAge" runat="server" AutoPostBack="true" placeholder="Enter Age Here.." Text='<%#Bind("Age") %>' class="form-control1" OnTextChanged="txtAge_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblAge" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPhoto" runat="server" Text='<%#Bind("Photo") %>' Width="10px"></asp:Label>--%>
                                        <%--<img src="Profile/Patients/<%#DataBinder.Eval(Container, "Photo")%>"
                                            width="60" height="60" style="border: solid" />--%>
                                       
                                      <%--  <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Photo","~/Profile/Patients/{0}.jpg") %>'  />--%>

                                       <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Profile/Patients/" + Convert.ToString(Eval("Photo")) %>'  Height="50px" Width="50px"/>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPhoto" runat="server" Text='<%#Bind("Photo") %>' ></asp:Label>
                                        <asp:FileUpload ID="fuProfileUpload" runat="server" ForeColor="Black" CssClass="form-control1" />

                                    </EditItemTemplate>

                                </asp:TemplateField>
                            </Columns>



                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Checked Records"
                            OnClientClick="return ConfirmDelete();" OnClick="btnDelete_Click" class="btn btn-danger" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

