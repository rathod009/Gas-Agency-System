<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmFeedBack.aspx.cs" Inherits="Consumer_frmFeedBack" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<div>
<br />
<br />
<fieldset style="width:400px;border-style:groove;border-color:Blue">
<legend style="color: #0066FF; font-weight: bold;">Feed Back Form</legend>
<table style="background-color: #66CCFF"><tr><td>Subject</td><td align="left"><asp:TextBox ID="txtSubject" runat="server"></asp:TextBox> </td><td align="left">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"  ErrorMessage="*"></asp:RequiredFieldValidator></td></tr>
<tr><td>Description:</td><td><asp:TextBox ID="txtDescription" 
        TextMode="MultiLine"   runat="server" Height="165px" Width="247px"></asp:TextBox>  </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"  ErrorMessage="*"></asp:RequiredFieldValidator>
        </td></tr>
<tr><td colspan="3"><asp:Button ID="btnSubmit" Text="Submit"  runat="server" 
        onclick="btnSubmit_Click" />  </td><td>&nbsp;</td></tr>
<tr><td colspan="3">
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    </td><td>
        &nbsp;</td></tr>
</table> 
<br />

</fieldset> 
    <br />
    <br />
    <br />
    
</div>
</center> 
</asp:Content>

