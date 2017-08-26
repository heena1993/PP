<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Medician.aspx.cs" Inherits="Medician" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-10 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                Medician Add

            </div>
            <div class="panel-body">

                <div class="col-lg-12">

                    <div class="row">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <div class="col-sm-6">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Name :</label>


                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <asp:TextBox ID="txtName" runat="server" placeholder="Enter Medician Name Here.." AutoPostBack="true" OnTextChanged="txtName_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtStart" runat="server" TextMode="Time"></asp:TextBox>

                                            <br />
                                             <asp:TextBox ID="txtEnd" runat="server" TextMode="Time" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                            <br />

                                            <asp:DropDownList ID="dropdownList" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Description : </label>

                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="2" placeholder="Enter Description Here.." AutoPostBack="true" OnTextChanged="txtDesc_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblDesc" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Type : </label>

                                        </div>
                                        <div class="col-sm-8 form-group">
                                            
                                            <asp:DropDownList ID="ddlMedicianType" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicianType_SelectedIndexChanged">
                                                <asp:ListItem Text="----Select Medician Type-------" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Liquid" Value="Liquid"></asp:ListItem> 
                                            <asp:ListItem Text="Tablet" Value="Tablet"></asp:ListItem>
                                             <asp:ListItem Text="Oinment" Value="Oinment"></asp:ListItem>
                                             <asp:ListItem Text="Insuline" Value="Insuline"></asp:ListItem>
                                             <asp:ListItem Text="Injection" Value="Injection"></asp:ListItem>
                                             <asp:ListItem Text="Powder" Value="Powder"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblMedicianType" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>
                                    
                                   
                                    
                                    <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Potency : </label>

                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <asp:TextBox ID="txtMedicianPotency" runat="server" placeholder="Enter Medician Potency Here.." AutoPostBack="true" OnTextChanged="txtMedicianPotency_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblPotency" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>

                                     <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Does : </label>

                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <asp:TextBox ID="txtDoes" runat="server" placeholder="Enter Medician Does Here.." AutoPostBack="true" OnTextChanged="txtDoes_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblDoes" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>

                                     <div class="row">
                                        <div class="col-sm-4 form-group" style="text-align: left;">
                                            <label>Medician Unit : </label>

                                        </div>
                                        <div class="col-sm-8 form-group">
                                            
                                            <asp:DropDownList ID="ddlMedicianUnit" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicianUnit_SelectedIndexChanged">
                                                <asp:ListItem Text="----Select Medician Unit-------" Value=""></asp:ListItem>
                                               
                                             <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                             <asp:ListItem Text="ML" Value="ML"></asp:ListItem>
                                             <asp:ListItem Text="GM" Value="GM"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblMedicianUnit" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                            <br />
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <%--<button type="button" class="btn btn-lg btn-info" style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;">Submit</button>--%>
                           <div style="align-items:center">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Submit"  class="btn btn-lg btn-info" Style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                                </div>
                            </div>

                          
                        </div>

                    
                    </div>
                </div>
            </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                Medician Add

            </div>
            <div class="panel-body">

                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-sm-12">
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                         
                        
                <div class="table-responsive">
              <asp:GridView ID="GridMedicine" runat="server" Visible="true"   class="table table-hover" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="lightslategray" Font-Size="17px" OnSelectedIndexChanged="GridMedicine_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="GridMedicine_PageIndexChanging" PageSize="3" OnRowDataBound="GridMedicine_RowDataBound1" OnRowEditing="GridMedicine_RowEditing" OnRowCancelingEdit="GridMedicine_RowCancelingEdit" OnRowUpdating="GridMedicine_RowUpdating" OnRowDeleting="GridMedicine_RowDeleting" EmptyDataText="No Record Found" AutoGenerateColumns="false">
                     <PagerStyle HorizontalAlign = "Center" />   
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

                      

                       <asp:TemplateField HeaderText="Medicine Id">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineId" runat="server"  Text='<%#Bind("MedicineId") %>' Width="10px"></asp:Label>
                          </ItemTemplate>

                      </asp:TemplateField>

                       <asp:TemplateField HeaderText="Deciease Name">
                          <ItemTemplate>
                            

                             <asp:GridView ID="gvarray" runat="server" CssClass="Gridview" AutoGenerateColumns="false" HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="White" Caption="Single-Dimensional Array">
                            <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name"/>
                            </Columns>
                            </asp:GridView>
                              </ItemTemplate>
                           </asp:TemplateField>

                      <asp:TemplateField HeaderText="Medicine Name">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineName" runat="server" Text='<%#Bind("MedicineName") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtMedicineName" runat="server" CssClass="form-control1" Text ='<%#Bind("MedicineName") %>' AutoPostBack="true" OnTextChanged="txtMedicineName_TextChanged" ></asp:TextBox>
                               <asp:Label ID="lblNameError1" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                             
                          </EditItemTemplate>
                         
                      
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Medicine Description">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineDescription" runat="server" Text='<%#Bind("MedicineDescription") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtMedicineDescription" runat="server" CssClass="form-control1" Text ='<%#Bind("MedicineDescription") %>' AutoPostBack="true" OnTextChanged="txtMedicineDescription_TextChanged"></asp:TextBox>
                               <asp:Label ID="lblDesc" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                          </EditItemTemplate>
                          
                      
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Medicine Type">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineTypehd" runat="server" Text='<%#Bind("MedicineType") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>

                                 <asp:DropDownList ID="ddlMedicianType" CssClass="form-control1" runat="server" AppendDataBoundItems="True"  selectedvalue='<%#Bind("MedicineType") %>' AutoPostBack="true" OnSelectedIndexChanged="ddlMedicianType_SelectedIndexChanged1" >
                                                <asp:ListItem Text="----Select Medician Type-------" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Liquid" Value="Liquid"></asp:ListItem> 
                                            <asp:ListItem Text="Tablet" Value="Tablet"></asp:ListItem>
                                             <asp:ListItem Text="Oinment" Value="Oinment"></asp:ListItem>
                                             <asp:ListItem Text="Insuline" Value="Insuline"></asp:ListItem>
                                             <asp:ListItem Text="Injection" Value="Injection"></asp:ListItem>
                                             <asp:ListItem Text="Powder" Value="Powder"></asp:ListItem>
                                            </asp:DropDownList>

                               <asp:Label ID="lblMedicianType" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                          </EditItemTemplate>
                          
                      
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Medicine Potency">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicinePotency" runat="server" Text='<%#Bind("MedicinePotency") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtMedicinePotency" runat="server" CssClass="form-control1" Text ='<%#Bind("MedicinePotency") %>' AutoPostBack="true" OnTextChanged="txtMedicinePotency_TextChanged"></asp:TextBox>

                                   <asp:Label ID="lblPotency" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                          </EditItemTemplate>
                          
                      
                      </asp:TemplateField>

                       <asp:TemplateField HeaderText="Medicine Does">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineDoes" runat="server" Text='<%#Bind("MedicineDoes") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtMedicineDoes" runat="server" CssClass="form-control1" Text ='<%#Bind("MedicineDoes") %>' AutoPostBack="true" OnTextChanged="txtMedicineDoes_TextChanged"></asp:TextBox>
                                <asp:Label ID="lblDoes" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                          </EditItemTemplate>
                          
                      
                      </asp:TemplateField>

                       <asp:TemplateField HeaderText="Medicine Unit">
                          <ItemTemplate>
                              <asp:Label ID="lblMedicineUnithd" runat="server" Text='<%#Bind("MedicineUnit") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                           <asp:DropDownList ID="ddlMedicianUnit" runat="server"  CssClass="form-control1" AppendDataBoundItems="True" selectedvalue='<%#Bind("MedicineUnit") %>' AutoPostBack="true" OnSelectedIndexChanged="ddlMedicianUnit_SelectedIndexChanged1" >
                                                <asp:ListItem Text="----Select Medician Unit-------" Value=""></asp:ListItem>
                                               
                                             <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                             <asp:ListItem Text="ML" Value="ML"></asp:ListItem>
                                             <asp:ListItem Text="GM" Value="GM"></asp:ListItem>
                                            </asp:DropDownList>
                               <asp:Label ID="lblMedicianUnit" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                          </EditItemTemplate>
                          
                      
                      </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    
                    <%--    <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Checked Records"
                            OnClientClick="return ConfirmDelete();" OnClick="btnDelete_Click" class="btn btn-danger" />
                           --%>
                    
                    </div>
                     </ContentTemplate>
                     </asp:UpdatePanel>
                              </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

     
</asp:Content>

