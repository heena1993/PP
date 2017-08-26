<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMasterPage.master" AutoEventWireup="true" CodeFile="PatientCheckup.aspx.cs" Inherits="PatientCheckup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="col-md-10 content">
        
     <div class="panel panel-default">
            <div class="panel-heading">
                Patient Register Form

            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                
                                <div class="col-sm-4 form-group">
                                     <label> Name :</label>

                                    <asp:DropDownList ID="ddlName" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lblNameError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                            <div class="row">
                                
                                <div class="col-sm-4 form-group">
                                   
                                    <br />

                                     <label> Address :</label>

                                    <asp:TextBox ID="txtaddress" runat="server"  class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtaddress_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lbladdress" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                 <div class="col-sm-1 form-group">
                                     <label></label>
                                    <asp:TextBox ID="txtAppoinmnentno" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAppoinmnentno_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblAppoinmnentno" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    
                            <br />
                                    <label>Age:</label>
                                    <asp:TextBox ID="txtage" runat="server"  class="form-control" AutoPostBack="true" OnTextChanged="txtage_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                     </div>
                             <div class="col-sm-3 form-group">
                                    <label>Date:</label>

                                    <asp:TextBox ID="txtdate" runat="server" TextMode="Date"  class="form-control" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                                   <asp:Label ID="lbldate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                </div>
                                  <div class="col-sm-3 form-group">
                                       <label>Photo:</label>
                                      <br />
                                      <asp:Image ID="patientimage" runat="server" Width="150" Height="150"  />
                                        <asp:Label ID="lblimage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                      </div>
                              </div>
                          <div class="row">
                              <div class="col-sm-4 form-group">
                                   
                                    
                                </div>

                              <div class="col-sm-1 form-group">
                                    
                                    
                                </div>
                              </div>

                            <hr />
                             <div class="row">
                                 <div class="col-sm-4 form-group">
                                    <label> Case Paper No :</label>

                                    <asp:TextBox ID="txtcaseno" runat="server"  class="form-control" AutoPostBack="true" OnTextChanged="txtcaseno_TextChanged" ></asp:TextBox>
                                    <asp:Label ID="lblcaseno" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                      </div>
                                   <div class="col-sm-4 form-group"> 
                                      <label>History:</label>
                                     <asp:RadioButtonList ID="rbthistory" runat="server" RepeatDirection="Horizontal" CssClass="form-inline" AutoPostBack="true" OnSelectedIndexChanged="rbthistory_SelectedIndexChanged">
                                         <asp:ListItem>New History</asp:ListItem>
                                          <asp:ListItem>Previous History</asp:ListItem>
                                     </asp:RadioButtonList>
                                        <asp:Label ID="lblhistory" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                              <div class="col-sm-4 form-group">
                                    <label> Diseases :</label>

                                    <asp:DropDownList ID="ddldiseases" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldiseases_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lbldiseases" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    
                                </div>
                                  <div class="col-sm-4 form-group">

                                       </div>

                             </div>
                            <div class="row">
                                 <div class="col-sm-4 form-group">
                                    <label> Symptoms :</label>

                                    <asp:TextBox ID="txtsymptoms" runat="server"  class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txtsymptoms_TextChanged"> </asp:TextBox>
                                    <asp:Label ID="lblsymptoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                     </div>
                                 <div class="col-sm-4 form-group"> 
                                      <label>History:</label>
                                      <asp:TextBox ID="txthistorysymtoms" runat="server"  class="form-control" TextMode="MultiLine" Rows="4" AutoPostBack="true" OnTextChanged="txthistorysymtoms_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblhistorysymtoms" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                                 
                                 </div>

                             <hr />
                            <div class="row">
                                <div class="col-sm-4 form-group">
                                        <label> Test To Be Done:</label>

                                        <asp:DropDownList ID="ddltest" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltest_SelectedIndexChanged"></asp:DropDownList>
                                       
                                    <asp:Label ID="lbltest" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:Image ID="imagetest" runat="server" Width="100px" Height="100px" />
                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                     </div>
                           
                                 
                                 <div class="col-sm-4 form-group">
                                        <label> Medicine For:</label>
                                        <asp:TextBox ID="txtmedicineday" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtmedicineday_TextChanged"></asp:TextBox> 
                                    <asp:Label ID="lblmedicineday" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                     <br />
                                      <label> Consulting Charges :</label>

                                      <asp:TextBox ID="txtConsultingCharges" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtConsultingCharges_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblConsultingCharges" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <br />
                                         <label>Payment Type :</label>
                                  <asp:RadioButtonList ID="rbtpaymenttype" runat="server" CssClass="form-inline" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtpaymenttype_SelectedIndexChanged">
                                      <asp:ListItem>Cash</asp:ListItem>
                                       <asp:ListItem>Credit</asp:ListItem>
                                  </asp:RadioButtonList>
                                  
                                    <asp:Label ID="lblpaymenttype" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                     </div>
                              
                              <div class="col-sm-4 form-group">
                                  <label>Next Appoinment Date :</label>
                                    <asp:TextBox ID="txtappoinmentdate" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtappoinmentdate_TextChanged"></asp:TextBox>

                                    <asp:Label ID="lblappoinmentdate" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                  <br />
                                   <label> Total :</label>

                                      <asp:TextBox ID="txttotal" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lbltotal" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    
                                  </div>
                                
                                   
                             </div>

                            <div class="row">
                               <div class="col-sm-4 form-group">
                                   
                                    
                                
                                </div>
                              <div class="col-sm-4 form-group">
                                    <asp:Button ID="btnChekUp" runat="server" OnClick="btnChekUp_Click" Text="ADD" class="btn btn-lg btn-info" style="background-color: #f54785; width: 218px; color: white; font-weight: bold; font-size: 16px;" />
                                  </div>
                                 </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  
                  
                </div>

                <div class="col-sm-8">

                    </div>
                <br />
                <br />
                <br />
                <br />
                <br />

            </div>
        </div>
        
         
         </div>
</asp:Content>

