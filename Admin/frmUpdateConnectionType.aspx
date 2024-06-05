<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmUpdateConnectionType.aspx.cs" Inherits="Admin_frmUpdateConnectionType" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    
    </Triggers>
    <ContentTemplate> 
    
<fieldset id ="fs1" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >Connection Type</legend>
            <table>
            <tr><td><asp:GridView ID ="gvConnectionDetails" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    DataKeyNames="ConnectionTypeId" 
                    onrowediting="gvConnectionDetails_RowEditing">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                <asp:CommandField EditText="Edit" ShowEditButton="true" />  
                    <asp:BoundField DataField="ConnectionTypeId"   HeaderText="TypeId" 
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
                <tr><td align="center">&nbsp;</td></tr>
            </table> 
            </fieldset>
 <fieldset id ="fs2" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >Update Connection</legend>
            <table>
         <tr><td>Connection Name:</td><td><asp:TextBox ID="txtConnectionName" runat="server" ></asp:TextBox> </td></tr>
        <tr><td>Description:</td><td><asp:TextBox ID="txtDescription" runat="server" 
                TextMode="MultiLine"></asp:TextBox>  </td></tr>
         <tr><td>RefillCharge:</td><td><asp:TextBox ID="txtRefill" runat="server"></asp:TextBox>  </td></tr>
           <tr><td>New Connection Price:</td><td><asp:TextBox ID="txtNewPrice" runat="server"></asp:TextBox>  </td></tr>
           <tr><td colspan="2" align="center">
               <asp:Button ID="btnSubmit" Text="Update"  
                   runat="server" onclick="btnSubmit_Click"  /> 
               <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" 
                   Text="Cancel" />
               </td></tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table> 
            </fieldset>
            <br />
            <br />
            </ContentTemplate>
             </asp:UpdatePanel>
            </center>
            </div>
           
</asp:Content>

