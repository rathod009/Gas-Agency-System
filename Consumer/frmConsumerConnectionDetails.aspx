<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmConsumerConnectionDetails.aspx.cs" Inherits="Consumer_frmConsumerConnectionDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center> 
<fieldset style="width:500px;border-style:groove;border-color:Blue" >
<legend>Gas Connection Details</legend> 
<table width="400px" border="1" 
        style="background-color: #FFFFCC; font-weight: bold; color: #0000FF;">
<tr><td colspan="2" style="color: #FF0000; font-weight: bold;">Consumer Gas Card Details</td></tr>
<tr><td>Consumer No:</td><td align="left"><asp:Label ID="lblConsumerNo" runat="server" ></asp:Label> </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td style="height: 26px">Consumer Name:</td><td style="height: 26px" 
        align="left"><asp:Label ID="lblConsumerName" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Connection Type:</td><td align="left"><asp:Label ID="lblConnectionName" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Applied Date:</td><td align="left"><asp:Label ID="lblDate" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Issued Date:</td><td align="left"><asp:Label ID="lblIssuedDate" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Agency Name:</td><td align="left"><asp:Label ID="lblAgencyName" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Agency Address:</td><td align="left"><asp:Label ID="lblAddress" runat="server"></asp:Label>  </td></tr>


<tr><td colspan="2"><asp:Button ID="btnBook" Text="Book Gas"  runat="server" 
        onclick="btnBook_Click" />
 </td><td>&nbsp;</td></tr>


<tr><td colspan="2">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
 </td><td>&nbsp;</td></tr>
</table>
</fieldset> 
<fieldset id="fs1" style="width:500px"  runat="server">
<table><tr><td>&nbsp;</td><td>&nbsp;</td></tr></table> 
</fieldset> 
</center>
</div>
</asp:Content>

