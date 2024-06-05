<%@ Page Language="C#" MasterPageFile="~/Distributor/DistMasterPage.master" AutoEventWireup="true" CodeFile="frmUseGasBookingRequest.aspx.cs" Inherits="Distributor_frmUseGasBookingRequest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<fieldset style="width:500px;border-style:groove;border-color:Blue">
<legend>Gas Booking Requests</legend> 
<table>
<tr><td>
    <asp:GridView ID="gvBookingRequest" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
        onrowediting="gvBookingRequest_RowEditing" >
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            
            <asp:TemplateField HeaderText="User Id" Visible="true">
              <ItemTemplate>
                <asp:Label  ID="lblUserId" runat="server" Text='<%# Eval("SNo")%>' ></asp:Label>
              </ItemTemplate>          
            </asp:TemplateField>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
            <asp:BoundField DataField="ConsumerNo" HeaderText="ConsumerNo" />     
            <asp:BoundField DataField="BookedDate" HeaderText="Booked Date" />     
            <asp:BoundField DataField="Status" HeaderText="Status" />                
            <asp:CommandField ShowEditButton="true" EditText="Accept" CausesValidation="false" />
            </Columns>
            <EmptyDataTemplate>
                No Data In The Table
            </EmptyDataTemplate>
    </asp:GridView> </td></tr></table>
    <br />
   
</fieldset>  
</center> 
</div>
</asp:Content>

