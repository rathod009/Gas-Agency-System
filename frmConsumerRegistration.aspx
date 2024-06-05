<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmConsumerRegistration.aspx.cs" Inherits="frmConsumerRegistration" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="UserControls/BrowseImage.ascx" tagname="BrowseImage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
        <center>           
           
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                   
            
                    <table style="border: thin solid #5D7B9D; background-color: Window; width: 500px; ">
                        <tr>
                        <td colspan="6" align="center" style="background-color:#C1312F" >
                            <b style="color:White">Gas Connection Registration Form </b>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >FirstName</td>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" ></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="3" rowspan="4">
                            
                            <uc1:BrowseImage ID="BrowseImage1" runat="server" />
                            
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td >MiddleName</td>
                            <td><asp:TextBox ID="txtMName" runat="server"></asp:TextBox></td>
                        <td>
                        
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >LastName</td>
                        <td><asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td> 
                        <td>Gender</td>                       
                        <td align="left">
                            <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem>--Select One--</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ErrorMessage="*" ControlToValidate="ddlGender" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                        DOB
                        </td>
                        <td><asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                           
                            </cc1:CalendarExtender>
                            
                            <cc1:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDOB">
                            </cc1:CalendarExtender>
                            
                        </td>
                        <td>
                       <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="*" ControlToValidate="txtDOB" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Connection Type</td>
                        <td valign="middle" align="left">
                            <asp:DropDownList ID="ddlConnection" runat="server">
                            </asp:DropDownList>
                            </td>
                        <td>
                        
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left" valign="middle">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td>State Name</td>
                        <td><asp:DropDownList ID="ddlStateName" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlStateName_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblDistrict" runat="server" Text="District" Visible="False"></asp:Label>
                            </td><td align="left"><asp:DropDownList ID="ddlDistrict" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged" 
                                    Visible="False"></asp:DropDownList> </td>
                        <td><asp:RequiredFieldValidator ID="rfv1" ControlToValidate="ddlDistrict"  
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCity" runat="server" Text="City Name" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" 
                                    onselectedindexchanged="ddlCity_SelectedIndexChanged" Visible="False" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvagency" runat="server" 
                                    ControlToValidate="ddlCity" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblAgency" runat="server" Text="Agency Name" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAgencyName" runat="server" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvcity" runat="server" 
                                    ControlToValidate="ddlAgencyName" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td>
                            Email Id</td>
                        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td>PhoneNo</td>
                            <td align="left"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                                    ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    
                                                          <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" runat="server" 
                                    ErrorMessage="*" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
       
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >
                            User Name</td>
                        <td >
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                            
                        </td>
                        <td >
                      <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName" ></asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2" >
                        Address
                        </td>
                        <td rowspan="2" align="left" >
                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td rowspan="2" >
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                ControlToValidate="txtAddress" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            
                            </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="3">
                         <asp:Button ID="btnSubmit" runat="server"  Text="Submit" 
                                ForeColor="White" BorderColor="MediumSeaGreen" BackColor="#797A80" 
                                onclick="btnSubmit_Click" />
                          &nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" ForeColor="White" 
                                BorderColor="red" BackColor="#797A80" onclick="btnCancel_Click" />
                        </td>
                        </tr>
                         
                        <tr>
                        <td colspan="6" style="background-color:#C1312F"></td>
                        </tr>
                        
               
                        </table>
                       <br />
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <br />

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

