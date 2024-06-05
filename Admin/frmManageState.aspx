<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmManageState.aspx.cs" Inherits="Admin_frmManageState" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<br />
<br />

    <div>
        <center>
            <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Add State </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Add State Details</td></tr>
                    <tr>
                        <td>
                            StateName:
                        </td>
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
                                onclick="btnSubmit_Click" style="height: 26px"  />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                CausesValidation="False"   />
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
            <fieldset id ="fs1" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >State Details</legend>
            <table>
            <tr><td><asp:GridView ID ="gvStateDetails" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                </asp:GridView></td></tr>
                <tr><td align="center"><asp:Button ID="btnClose" runat="server" Text="close" 
                        CausesValidation="False" onclick="btnClose_Click"  />  </td></tr>
            </table> 
            </fieldset>
            <br />
        </center>
    </div>
</asp:Content>
