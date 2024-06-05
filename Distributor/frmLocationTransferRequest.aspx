<%@ Page Language="C#" MasterPageFile="~/Distributor/DistMasterPage.master" AutoEventWireup="true" CodeFile="frmLocationTransferRequest.aspx.cs" Inherits="Distributor_frmLocationTransferRequest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center> 
<div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<fieldset style="width:700px;border-style:groove;border-color:Blue">
<legend>
Location Transfer Requests
</legend>
<table>
<tr><td><asp:GridView ID="gvTransferRequests" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onrowediting="gvTransferRequests_RowEditing">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
    <asp:BoundField DataField="SNO" HeaderText="RequestNo"   /> 
        <asp:BoundField DataField="ConsumerNo" HeaderText="ConsumerNo" 
            SortExpression="ConsumerNo" />
        <asp:BoundField DataField="ToCity" Visible="false"   HeaderText="ToCity" 
            SortExpression="ToCity" />
        <asp:BoundField DataField="fromCity" Visible="false"  HeaderText="fromCity" 
            SortExpression="fromCity" />
        <asp:BoundField DataField="ToCityName" HeaderText="ToCity" 
            SortExpression="ToCity1" />
        <asp:BoundField DataField="FromAgentId" Visible="false"   HeaderText="FromAgentId" 
            SortExpression="FromAgentId" />
        <asp:BoundField DataField="FromAgencyName" Visible="false"   HeaderText="FromAgencyName" 
            SortExpression="FromAgencyName" />
        <asp:BoundField DataField="ToAgentId" Visible="false"   HeaderText="ToAgentId" 
            SortExpression="ToAgentId" />
        <asp:BoundField DataField="ToAgencyName" HeaderText="ToAgencyName" 
            SortExpression="ToAgencyName" />
        <asp:BoundField DataField="RequestedDate" HeaderText="RequestedDate" 
            ReadOnly="True" SortExpression="RequestedDate" />
        <asp:BoundField DataField="Status" HeaderText="Status" 
            SortExpression="Status" />
            <asp:CommandField EditText="Send To Admin" ShowEditButton="true"    />  
    </Columns>
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView> 
   
    </td></tr>
    <tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label>  </td></tr>
</table> 
<br />
</fieldset> 
<br />
</ContentTemplate> 
</asp:UpdatePanel> 
<br /> 
</div>
</center>
</asp:Content>

