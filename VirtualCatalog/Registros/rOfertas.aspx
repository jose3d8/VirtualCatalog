<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rOfertas.aspx.cs" Inherits="VirtualCatalog.Registros.rOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

         <style type="text/css">
        .panel-heading {
            height: 79px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success">
        <div class="panel panel-heading" style="background-color: #336699; color: #FFFFFF; font-weight: bold; font-size: 25px; height: 50px; width: 541px; margin-left: 2px;">
            Registro de Ofertas
        </div>
        <div class=" panel-body">

            <%--IdOferta--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdOfertaLabel" style="color: Black">
                        IdOferta</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" CssClass="form-control input-sm" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Introdusca un Id valido" ForeColor="Red" SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <%--IdProducto--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdProductoLabel" style="color: Black">
                        IdProducto</label>
                    <div class="col-lg-9">
                        <asp:DropDownList ID="IdProductoDropDownList" runat="server" CssClass="form-control input-sm" Height="18px" Width="128px" DataSourceID="SqlDataSource1" DataTextField="IdProducto" DataValueField="IdProducto"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdProducto] FROM [Productos]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>

            <%--PrecioOferta--%>
            <div class="form-group">
                <label class="col-md-2 control-label input-sm" for="PrecioOfertaLabel" style="color: Black">
                    PrecioOferta</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="PrecioOfertaTextBox" runat="server" MaxLength="50" Width="150px" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PrecioOfertaTextBox" ErrorMessage="Introdusca el Precio de la oferta " ForeColor="Red" SetFocusOnError="true">*
                    </asp:RequiredFieldValidator>
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
            <asp:ValidationSummary ID="ValidationSummary0" runat="server" ForeColor="Red" HeaderText="Problema de Resgistro:" Height="79px" style="margin-left: 1px" Width="705px" />
        </div>
    </div>
</asp:Content>
