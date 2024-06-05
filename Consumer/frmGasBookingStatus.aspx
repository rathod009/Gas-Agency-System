<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmGasBookingStatus.aspx.cs" Inherits="Consumer_frmGasBookingStatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<fieldset style="width:500px">
<legend>
Gas Booking Status
</legend> 
<table><tr><td><asp:GridView ID="gvShowBookingStatus" runat="server"></asp:GridView> </td></tr></table> 
</fieldset> 
</center> 
</div>
</asp:Content>

