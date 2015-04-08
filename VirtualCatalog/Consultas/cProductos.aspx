<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="cProductos.aspx.cs" Inherits="VirtualCatalog.Consultas.cProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4">
                <asp:Label ID="cProductosLabel" runat="server" Font-Bold="True" ForeColor="Black" Text="Consulta de Productos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="BuscarLabel" runat="server" ForeColor="Black" Text="Buscar:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="BuscarDropDownList" runat="server">
                    <asp:ListItem>Id</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="BuscarTextBox" runat="server" Width="181px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BuscarButton" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="BuscarGridView" runat="server">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="IdProducto" DataNavigateUrlFormatString="~/Registros/rProductos.aspx" Text="Edit" />
                        <asp:HyperLinkField DataNavigateUrlFields="IdProducto" DataNavigateUrlFormatString="~/Registros/rProductos.aspx" Text="New" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
