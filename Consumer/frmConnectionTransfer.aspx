<%@ Page Language="C#" MasterPageFile="~/Consumer/ConsumerMasterPage.master" AutoEventWireup="true" CodeFile="frmConnectionTransfer.aspx.cs" Inherits="Consumer_frmConnectionTransfer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<fieldset style="width:600px;border-style:groove;border-color:Blue">
<legend>
Location Transfer 
</legend> 
<br />
<table width="550px" bgcolor="#99CCFF"><tr><td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        State:</td>
    <td align="left"><asp:DropDownList ID="ddlState" runat="server" 
                                                                                    onselectedindexchanged="ddlState_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>  </td></tr>
<tr><td>Consumer No</td>
    <td>
        <asp:TextBox ID="txtConsumerNo" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        District:</td>
    <td align="left"><asp:DropDownList ID="ddlDistrict" 
        runat="server" onselectedindexchanged="ddlDistrict_SelectedIndexChanged" 
        Enabled="False" AutoPostBack="True"></asp:DropDownList>  </td></tr>
<tr><td>From City</td>
    <td>
        <asp:TextBox ID="txtFromCity" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        To City:</td>
    <td align="left"><asp:DropDownList ID="ddlCity" runat="server" 
        onselectedindexchanged="ddlCity_SelectedIndexChanged" Enabled="False" AutoPostBack="True"></asp:DropDownList> </td></tr>
<tr><td>From AgencyName</td>
    <td>
        <asp:TextBox ID="txtFromAgency" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        Agency Name:</td>
    <td align="left"><asp:DropDownList ID="ddlAgencyName" 
        runat="server" Enabled="False"></asp:DropDownList>  </td></tr>
        <tr><td colspan="4">
            <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                Text="Send Request" />
            </td>
    </tr>
        <tr><td colspan="4">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
    </tr>
</table> 
<br />
</fieldset> 
        <br />
</ContentTemplate> 
    </asp:UpdatePanel>
</center> 
</div>
</asp:Content>

