<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmShowYearWiseConneciton.aspx.cs" Inherits="Admin_frmShowYearWiseConneciton" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Report for Year Wise Connecions</h3>
<center>
<table>
<tr><td align="left" >Select Year</td><td align="left" >
    <asp:DropDownList ID="ddlYear" runat ="server" AutoPostBack="True" >

    <asp:ListItem>2005</asp:ListItem>
    <asp:ListItem>2006</asp:ListItem>
    <asp:ListItem>2007</asp:ListItem>
    <asp:ListItem>2008</asp:ListItem>
    <asp:ListItem>2009</asp:ListItem>
    <asp:ListItem>2010</asp:ListItem>
    </asp:DropDownList></td></tr>
</table>
<fieldset style="width:750px;border-style:groove;border-color:Blue">
<table>
<tr>
<td align="left" ><asp:GridView ID="grvYear" runat ="server" 
        AutoGenerateColumns="False" DataKeyNames="SNO" DataSourceID="SqlDataSource1" >
    <Columns>
        <asp:BoundField DataField="SNO" HeaderText="SNO" InsertVisible="False" 
            ReadOnly="True" SortExpression="SNO" />
        <asp:BoundField DataField="ConsumerNo" HeaderText="ConsumerNo" 
            SortExpression="ConsumerNo" />
        <asp:BoundField DataField="ConsumerName" HeaderText="ConsumerName" 
            SortExpression="ConsumerName" />
        
        <asp:BoundField DataField="ConnectionName" HeaderText="ConnectionName" 
            SortExpression="ConnectionName" />
        
        <asp:BoundField DataField="AllotedDate" HeaderText="AllotedDate" 
            SortExpression="AllotedDate" />
       
        <asp:BoundField DataField="ConnectionCharge" HeaderText="ConnectionCharge" 
            SortExpression="ConnectionCharge" />
        <asp:BoundField DataField="CylinderNo" HeaderText="CylinderNo" 
            SortExpression="CylinderNo" />
       
        <asp:BoundField DataField="AgencyName" HeaderText="AgencyName" 
            SortExpression="AgencyName" />
    </Columns>
    <EmptyDataTemplate>
    <asp:Label ID="lbl1" runat ="server" Text="No Connection Made"></asp:Label>
    </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConStr %>" 
        SelectCommand="sp_GetYearWiseConnections" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlYear" Name="Year" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </td>
</tr>
</table>
</fieldset> 
</center>
</asp:Content>

