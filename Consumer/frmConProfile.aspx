<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmConProfile.aspx.cs" Inherits="Consumer_frmConProfile" Title="Untitled Page" %>

<%@ Register src="../UserControls/BrowseImage.ascx" tagname="BrowseImage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
              <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                
              <asp:AsyncPostBackTrigger ControlID="btnUpdatePass" EventName="Click" />
         
               <asp:AsyncPostBackTrigger ControlID="btnPassCancel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="lbChangePassword" EventName="Click" />  
               </Triggers>
                <ContentTemplate>
                   
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 670px;">
                        <tr>
                        <td colspan="6" align="center" style=" background-color:#5D7B9D" >
                            <b>Update My Profile </b>
                        </td>
                        </tr>
                       
                        
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                            Image</td>
                        <td> 
                            <uc1:BrowseImage ID="BrowseImage1" runat="server" />
                            </td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                       </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >
                            Email</td>
                        <td align="left" >
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td >
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="*" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
                        </td>
                        <td rowspan="2" >
                        Address
                        </td>
                        <td rowspan="2" >
                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td rowspan="2" >
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td>PhoneNo</td>
                        <td align="left">
                            <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" runat="server" 
                                    ErrorMessage="*" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>

                            </td>
                        <td>
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="3">
                         <asp:Button ID="btnUpdate" runat="server"  Text="Update" 
                                ForeColor="White" BorderColor="MediumSeaGreen" BackColor="#797A80" 
                                onclick="btnUpdate_Click" />
                          &nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" ForeColor="White" 
                                BorderColor="red" BackColor="#797A80" onclick="btnCancel_Click" />
                        </td>
                        </tr>
                         <tr>
                <td colspan="3">
                    </td>
                    <td colspan="3" align="right">Click Here for!<asp:LinkButton ID="lbChangePassword" 
                            runat="server" onclick="lbChangePassword_Click" CausesValidation="False">Change Password</asp:LinkButton> </td>
                </tr>
                        <tr>
                        <td colspan="6" style="background-color:#5D7B9D"></td>
                        </tr>
                        
               
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

            
        </center>
   
    
<div id="divChangePss" visible="false"   runat="server">
               
                   
            
                    <table style="border: thin solid #5D7B9D; background-color:window;  width: 400px;">
                        <tr>
                        <td colspan="3" align="center" style=" background-color:#5D7B9D" >
                            <b style="text-decoration: underline">Change Password </b>
                        </td>
                        </tr>                    
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >
                            Old Password</td>
                        <td >
                        <asp:TextBox ID="txtOld" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvOld" runat="server" ErrorMessage="*" ControlToValidate="txtOld"></asp:RequiredFieldValidator> 
                        </td>                        
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>                        
                        <td >
                            New Password</td>
                        <td >
                        <asp:TextBox ID="txtNew" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvNew" runat="server" ErrorMessage="*" ControlToValidate="txtNew"></asp:RequiredFieldValidator> 
                        </td>    
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>                        
                        <td >
                            Confirm Password</td>
                        <td >
                        <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ErrorMessage="*" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator> 
                        </td>    
                        </tr>
                        
                        <tr>
                        <td colspan="3" >
                            </td>
                        </tr>
                        <tr>
                        <td >
                            </td>
                        <td colspan="2">
                         <asp:Button ID="btnUpdatePass" runat="server"  Text="Update" ForeColor="White"
                                 BorderColor="MediumSeaGreen" BackColor="#797A80" onclick="btnUpdatePass_Click" 
                                 />
                          &nbsp;
                        <asp:Button ID="btnPassCancel" runat="server" ForeColor="White" 
                                CausesValidation="false" Text="Cancel"  
                                BorderColor="red" BackColor="#797A80" onclick="btnPassCancel_Click" />
                        </td>
                        </tr>
                         <tr>
                <td colspan="3">
                    </td>
                </tr>
                        <tr>
                        <td colspan="3" style="background-color:#5D7B9D"></td>
                        </tr>                       
                        </table>
                        <br />
                       <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>

              
           
        
        
    </div>
    </ContentTemplate>
      </asp:UpdatePanel>
      </center>
       </div>
</asp:Content>
