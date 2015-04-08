<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rRutas.aspx.cs" Inherits="VirtualCatalog.Registros.rRutas" %>

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
            Registro de Rutas
        </div>
        <div class=" panel-body">

            <%--Lista de Rutas--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdOfertaLabel" style="color: Black">
                        IdRuta</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" CssClass="form-control input-sm" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Introdusca un Id valido" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <%--Descripcion--%>
            <div class="form-group">
                <label class="col-md-2 control-label input-sm" for="DescripcionLabel" style="color: Black">
                    Descripcion</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="100" Width="532px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Introdusca una Descripcion" ForeColor="Red" SetFocusOnError="true">*
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

            <%--Lista de Rutas--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="ListaLabel" style="color: Black">
                        Lista de Rutas</label>
                    <asp:GridView ID="ListaRutasGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCliente" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" InsertVisible="False" ReadOnly="True" SortExpression="IdCliente" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso" SortExpression="FechaIngreso" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdCliente], [Nombre], [Apellido], [Direccion], [FechaIngreso] FROM [Clientes]"></asp:SqlDataSource>
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
            <asp:ValidationSummary ID="ValidationSummary0" runat="server" ForeColor="Red" HeaderText="Problema de Resgistro:" />
        </div>
    </div>
</asp:Content>
