<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmShowTransferStatus.aspx.cs" Inherits="Consumer_frmShowTransferStatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center>
<fieldset style="width:500px">
<legend>
Gas Transfer Status
</legend> 
<table><tr><td><asp:GridView ID="gvShowTransferStatus" runat="server"></asp:GridView> 
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <br />
    </td></tr></table> 
</fieldset> 
</center> 
</div>
</asp:Content>

