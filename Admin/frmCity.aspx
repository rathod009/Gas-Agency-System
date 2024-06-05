<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmCity.aspx.cs" Inherits="Admin_frmCity" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center> 
<div>
<br />
<br />

   <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Add City </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Add City</td></tr>
                    <tr>
                        <td>
                            District&nbsp; Name</td>
                        <td>
                            <asp:DropDownList ID="ddDistrict" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            City Name:                         </td>
                        <td>
                            <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*"  ControlToValidate="txtStateName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           Description:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine"   runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv2" ErrorMessage="*"  runat="server" 
                                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSubmit" Text="Submit"  runat="server" 
                                onclick="btnSubmit_Click"  />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                CausesValidation="False" onclick="btnCancel_Click"   />
                            <asp:Button ID="btnShow"  runat="server" Text="Show" CausesValidation="False" 
                                onclick="btnShow_Click" />  
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" style="background-color: #99CCFF;" align="center">
                            &nbsp;</td>
                    </tr>
                   
                    
                   
                    <tr>
                        <td colspan="3" align="center">
                        <asp:Label ID="lblMsg" ForeColor="Red"   runat="server"></asp:Label>  
                            </td>
                    </tr>
                   
                </table>
            </fieldset>
    <br />
    <fieldset id="fs1" visible="false"   runat="server"    style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Show City Details </legend>
                <table><tr><td><asp:GridView ID="gvShowCity" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" >
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    </asp:GridView> </td></tr>
                    <tr><td align="Center">
                        <asp:Button ID="btnClose" Text="Close"  runat="server" 
                            onclick="btnClose_Click" CausesValidation="False" /> </td></tr>
                    </table> 
            </fieldset>
</div>
</center>
</asp:Content>

