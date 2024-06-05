<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmHome.aspx.cs" Inherits="frmHome" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <legend>Know Gas Cylinder Available Status </legend>
                        <table>
                            <tr>
                                <td>
                                    State Name:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStateName" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlStateName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblDistrict" Visible="false"   Text="District" runat="server">
                                    </asp:Label>
                                </td>
                                <td><asp:DropDownList ID="ddlDistrict" Visible="false"   runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCity" Text="City" Visible="false"    runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCity" Visible="false"   runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlCity_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblAgency" Visible="false"   Text="AgencyName"  runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAgency" Visible="false"   runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="4" align="center"><asp:Button ID="btnSubmit" Enabled="false"   Text="Click For Status"  
                                    runat="server" onclick="btnSubmit_Click"  /> </td></tr>
                            <tr><td colspan="4" align="center"><asp:GridView ID="gvCylinders" Visible="false"   runat="server" ></asp:GridView> </td></tr>
                        </table>
                    </fieldset>
              </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>
