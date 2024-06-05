<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmConnectionType.aspx.cs" Inherits="Admin_frmConnectionType" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        <center>
            <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Add&nbsp; Connection Type </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Add Connection Type Details</td></tr>
                    <tr>
                        <td>
                            Connection Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtConnectionName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtConnectionName"></asp:RequiredFieldValidator>
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
                        <td>
                            Refill Charge</td>
                        <td>
                            <asp:TextBox ID="txtRefill" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtRefill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td style="height: 25px">
                            New Connection Price</td>
                        <td style="height: 25px">
                            <asp:TextBox ID="txtNewPrice" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 25px">
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtNewPrice"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSubmit" Text="Submit"  runat="server" 
                                onclick="btnSubmit_Click" style="height: 26px"  />
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
            <fieldset id ="fs1" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >Connection Type</legend>
            <table>
            <tr><td><asp:GridView ID ="gvConnectionDetails" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    DataKeyNames="ConnectionTypeId">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConnectionTypeId" Visible="false"   HeaderText="ConnectionTypeId" 
                        InsertVisible="False" ReadOnly="True" SortExpression="ConnectionTypeId" />
                    <asp:BoundField DataField="ConnectionName" HeaderText="ConnectionName" 
                        SortExpression="ConnectionName" />
                    <asp:BoundField DataField="Description" HeaderText="Description" 
                        SortExpression="Description" />
                    <asp:BoundField DataField="RefillCharge" HeaderText="RefillCharge" 
                        SortExpression="RefillCharge" />
                    <asp:BoundField DataField="NewConnectionPrice" HeaderText="NewPrice" 
                        SortExpression="NewConnectionPrice" />
                </Columns>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                 </td></tr>
                <tr><td align="center"><asp:Button ID="btnClose" runat="server" Text="close" 
                        CausesValidation="False" onclick="btnClose_Click"  />  </td></tr>
            </table> 
            </fieldset>
            <br />
        </center>
    </div>
</asp:Content>

