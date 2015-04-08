<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="VirtualCatalog.Registros.rVentas" %>

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
            Registro de Ventas
        </div>
        <div class=" panel-body">

            <%--IdVenta--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdOfertaLabel" style="color: Black">
                        IdVenta</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" Width="128px" CssClass="form-control input-sm" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Introdusca un Id valido" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <%--Fecha--%>
            <div class="form-group">
                <label class="col-md-2 control-label input-sm" for="FechaLabel" style="color: Black">Fecha </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="FechaTextBox" runat="server" Width="128px" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FechaTextBox" ErrorMessage="Introdusca una Fecha valida" ForeColor="Red" SetFocusOnError="true">*
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <%--IdCliente--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdProductoLabel" style="color: Black">
                        IdCliente</label>
                    <div class="col-lg-9">
                        <asp:DropDownList ID="IdClienteDropDownList" runat="server" CssClass="form-control input-sm" Height="18px" Width="128px">
                            <asp:ListItem>IdCliente</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <%--IdProducto--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdProductoLabel" style="color: Black">
                        IdProducto</label>
                    <div class="col-lg-9">
                        <asp:DropDownList ID="IdProductoDropDownList" runat="server" CssClass="form-control input-sm" Height="18px" Width="128px">
                            <asp:ListItem>IdProducto</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <%--Monto--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdOfertaLabel" style="color: Black">
                        Cantidad</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="CantidadTextBox" runat="server" Width="128px" CssClass="form-control input-sm" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CantidadTextBox" ErrorMessage="Introdusca una Cantidad" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <%--Precio--%>
            <div class="form-group">
                <label class="col-md-2 control-label input-sm" for="PrecioLabel" style="color: Black">
                    Precio</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="PrecioTextBox" runat="server" MaxLength="50" Width="128px" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <%--IdOferta--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdProductoLabel" style="color: Black">
                        IdOferta</label>
                    <div class="col-lg-9">
                        <asp:DropDownList ID="IdOfertaDropDownList" runat="server" CssClass="form-control input-sm" Height="18px" Width="128px">
                            <asp:ListItem>IdOferta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <%--Monto--%>
            <div class="form-group">
                <label class="col-md-2 control-label input-sm" for="PrecioLabel" style="color: Black">
                    Monto</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="MontoTextBox" runat="server" MaxLength="50" Width="150px" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="MontoTextBox" ErrorMessage=" Monto incorrecto " ForeColor="Red" SetFocusOnError="true">*
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <%--Lista de Ventas--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="ListaLabel" style="color: Black">
                        Lista de Ventas</label>
                    <asp:GridView ID="ListaVentasGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="IdVenta" HeaderText="IdVenta" SortExpression="IdVenta" />
                            <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" SortExpression="IdProducto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                            <asp:BoundField DataField="IdOferta" HeaderText="IdOferta" SortExpression="IdOferta" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdVenta], [IdProducto], [Cantidad], [Precio], [IdOferta] FROM [VentasDetalle]"></asp:SqlDataSource>
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
