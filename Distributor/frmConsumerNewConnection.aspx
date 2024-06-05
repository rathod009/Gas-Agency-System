<%@ Page Language="C#" MasterPageFile="~/Distributor/DistMasterPage.master" AutoEventWireup="true" CodeFile="frmConsumerNewConnection.aspx.cs" Inherits="Distributor_frmConsumerNewConnection" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate> 
<fieldset style="width:500px;border-style: groove; border-color: #0066FF;"> 
<legend style="color: #0000FF; font-weight: bold;">Consumer Connection Requests</legend> 
<table><tr><td>
    <asp:GridView ID="gvConsumerRequests" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ConsumerNo" 
        ForeColor="#333333" GridLines="None" 
        onrowediting="gvConsumerRequests_RowEditing">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField EditText="Edit" ShowEditButton="true" />
            <asp:BoundField DataField="ConsumerNo" HeaderText="ConsumerNo" 
                InsertVisible="False" ReadOnly="True" SortExpression="ConsumerNo" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" />
            <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" 
                ReadOnly="True" SortExpression="RequestDate" />
            <asp:TemplateField HeaderText="ConsumerPhoto">
                <ItemTemplate>
                    <asp:Image ID="image1" runat="server" Width="100px" Height="75px"  
                        ImageUrl='<%# "Handler.ashx?CID="+ Eval("ConsumerNo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    
    </td></tr></table> 
</fieldset>
    <br />
 <br />

    <fieldset id="fs1" visible="false"   runat="server" style=" width:600px; border-bottom-style:groove;border-color:Blue" >
    <legend style="color: #0000FF; font-weight: bold">Accept Consumer Connection</legend> 
    <br />
    
    <table border="1" align="center" 
            style="border-color: #66CCFF; background-color: #99CCFF;">
    <tr><td>ConsumerNo:</td><td align="left"><asp:TextBox ID="txtConsumerNO" 
            runat="server" ReadOnly="True"></asp:TextBox> </td>
    <td>Consumer Name:</td><td align="left">
        <asp:TextBox ID="txtConsumerName" 
            runat="server" ReadOnly="True"></asp:TextBox>  </td></tr>
    <tr><td>Consumer Address:</td><td><asp:TextBox ID="txtAddress" 
            TextMode="MultiLine"  runat="server" ReadOnly="True"></asp:TextBox>  </td>
        
            <td>
                Connection Type</td>
            <td align="left">
                <asp:TextBox ID="txtConnection" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    
        <tr>
            <td>
                Requested Date:</td>
            <td align="left">
                <asp:TextBox ID="txtReDate" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
      <td>Alloted Date:</td><td align="left"><asp:TextBox ID="txtAllotedDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtAllotedDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtAllotedDate">
            </cc1:CalendarExtender>
            </td><td>
    <asp:RequiredFieldValidator ID="rfv1" ControlToValidate="txtAllotedDate"  
            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  </td>  </tr>
    <tr><td>Cylinder No</td><td align="left"><asp:TextBox id="txtCylinder" runat="server"></asp:TextBox></td>
        
            <td>
                Deposit Amount</td>
            <td align="left">
                <asp:TextBox ID="txtDepositAmount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Connection Charge</td>
            <td align="left">
                <asp:TextBox ID="txtConnectionCharge" runat="server" 
                    AutoCompleteType="Disabled"></asp:TextBox>
            </td>
       
            <td>
                Regulator</td>
            <td align="left">
                <asp:TextBox ID="txtRegulator" MaxLength="1"  runat="server" Width="30px"></asp:TextBox>
            </td>
            <td><asp:CompareValidator ID="cv1" ControlToValidate="txtRegulator"  runat="server" 
                    ErrorMessage="*" Type="Integer" ValueToCompare="1"></asp:CompareValidator>  </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Button ID="btnSubmit" runat="server" Text="Accept" 
                    onclick="btnSubmit_Click" style="height: 26px" />
                <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" 
                    Text="Close" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table> 
    <br />
    </fieldset>
    <br />
    <br />
</ContentTemplate>
    </asp:UpdatePanel>
</center> 
</div>
</asp:Content>


