<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="VirtualCatalog.Consultas.cClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 57px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4">
                <asp:Label ID="cCientesLabel" runat="server" Font-Bold="True" ForeColor="Black" Text="Consulta de Cliente"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="BuscarLabel" runat="server" ForeColor="Black" Text="Buscar:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="BuscarDropDownList" runat="server">
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="BuscarTextBox" runat="server" Width="181px"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:Button ID="BuscarButton" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="BuscarGridView" runat="server">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="IdCliente" DataNavigateUrlFormatString="~/Registros/rClientes.aspx?IdCliente={0}" Text="Edit" />
                        <asp:HyperLinkField DataNavigateUrlFields="IdCliente" DataNavigateUrlFormatString="~/Registros/rClientes.aspx" Text="New" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
