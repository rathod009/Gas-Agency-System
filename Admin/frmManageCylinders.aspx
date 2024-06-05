<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmManageCylinders.aspx.cs" Inherits="Admin_frmManageCylinders" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <fieldset style="width: 500px; border-style: groove; border-color: Blue">
                <legend>Gas Cylinder Details</legend>
                <br />
                <table style="background-color: #66CCFF">
                    <tr>
                        <td>
                            State Name
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            District Name
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City Name:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Agency Name:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAgencyName" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total Cylinders:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalCylinders" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Available Cylinders:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAvailableCylinders" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" /><asp:Button
                                ID="btnShow" Text="Show All" runat="server" OnClick="btnShow_Click" />
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 650px" id="fs1" visible="false" runat="server">
                <legend>Agency wise Cylinder Details</legend>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvCylinders" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" AutoGenerateColumns="False" 
                                onrowediting="gvCylinders_RowEditing">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:BoundField DataField="SNO" HeaderText="SNO" InsertVisible="False" ReadOnly="True"
                                        SortExpression="SNO" />
                                    <asp:BoundField DataField="CityId" Visible="false" HeaderText="CityId" SortExpression="CityId" />
                                    <asp:BoundField DataField="AgentId" Visible="false" HeaderText="AgentId" SortExpression="AgentId" />
                                    <asp:BoundField DataField="AgencyName" HeaderText="AgencyName" SortExpression="AgencyName" />
                                    <asp:BoundField DataField="TotalCylinders" HeaderText="TotalCylinders" SortExpression="TotalCylinders" />
                                    <asp:BoundField DataField="AvailableCylinders" HeaderText="AvailableCylinders" SortExpression="AvailableCylinders" />
                                    <asp:BoundField DataField="Status" Visible="false" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="CityName" HeaderText="CityName" SortExpression="CityName" />
                                    <asp:BoundField DataField="StateName" HeaderText="StateName" SortExpression="StateName" />
                                    <asp:CommandField EditText="Edit" ShowEditButton="true" />
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <div id="div1" visible="false"   runat="server"  style="width: 500px">
                <fieldset> 
                <legend>Update Info</legend>
                    <table>
                        <tr>
                            <td>
                                AgencyName:
                            </td>
                           <td><asp:TextBox ID="txtAgencyName" runat="server"></asp:TextBox>  </td>
                        </tr>
                        <tr>
                            <td>
                                Total Cylinders:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalCylinders1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Available Cylinders:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAvailableCylinders1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnUpdate" Text="Update" runat="server" 
                                    onclick="btnUpdate_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblMsg1" runat="server" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                </div>
            </fieldset>
            <br />
            <br />
            </ContentTemplate> 
            </asp:UpdatePanel>  
            
        </div>
    </center>
</asp:Content>
