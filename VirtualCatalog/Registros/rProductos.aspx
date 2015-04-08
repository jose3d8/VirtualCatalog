<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="VirtualCatalog.Registros.rProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .panel-heading {
            height: 79px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success">
        <div class="panel panel-heading" style="background-color: #336699; color: #FFFFFF; font-weight: bold; font-size: 25px; height: 50px; width: 541px;">
            Registro de Productos
        </div>
        <div class=" panel-body">

            <%--Existencia--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdProductoLabel" style="color: Black">
                        IdProducto</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" CssClass="form-control input-sm" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Introdusca un Id valido" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Descripcion--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="DescripcionLabel" style="color: Black">
                        Descripcion</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="100" Width="532px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Introdusca una Descripcion" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Precio--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="PrecioLabel" style="color: Black">
                        Precio</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="PrecioTextBox" runat="server" MaxLength="50" Width="150px" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PrecioTextBox" ErrorMessage="Introdusca el Precio " ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Existencia--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="ExistenciaLabel" style="color: Black">
                        Existencia</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="ExistenciaTextBox" runat="server" Width="134px" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ExistenciaTextBox" ErrorMessage="Introdusca la Cantidad Disponible " ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="panel-group">
                <div class="col-md-12">
                    <asp:Button ID="ClearButton" runat="server" OnClick="ClearButton_Click" Text="Clear" Width="100px" />
                    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save" Width="100px" />
                    <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Delete" Width="100px" />
                </div>
            </div>
            <asp:Label ID="MsjLabel" runat="server" Text="MsjLabel"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" HeaderText="Problema de Resgistro:" />
        </div>
    </div>
</asp:Content>
