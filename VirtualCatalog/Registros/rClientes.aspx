<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="VirtualCatalog.Registros.rClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel-heading {
            height: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success" style="right: 20px">
        <div class="panel panel-heading" style="background-color: #336699; color: white; font-weight: bold; height: 50px; font-size: 25px; width: 541px;">
          Registro de Clientes
        </div>
        <div class=" panel-body">

            <%--Celular--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="IdClienteLabel" style="color: Black">IdCliente</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="IdTextBox" 
                            ErrorMessage="Introdusca un Id valido" 
                            ForeColor="Red" 
                            SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Fecha Ingreso--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="NombreLabel" style="color: Black">Nombre</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" Width="232px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="NombreTextBox" 
                            ErrorMessage="Introdusca un Nombre valido" 
                            ForeColor="Red" 
                            SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Telefono--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="ApellidoLabel" style="color: Black">Apellido</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="ApellidoTextBox" runat="server" MaxLength="50" Width="232px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ApellidoTextBox" 
                            ErrorMessage="Introdusca un Apellido valido" 
                            ForeColor="Red" 
                            SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Celular--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="DireccionLabel" style="color: Black">Direccion</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="DireccionTextBox" runat="server" MaxLength="100" Width="534px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="DireccionTextBox" 
                            ErrorMessage="Introdusca una Direccion valida" 
                            ForeColor="Red" SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Email--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="EmailLabel" style="color: Black">
                        Email</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="50" Width="231px" TextMode="Email"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Introdusca un Email valido" ForeColor="Red" ValidateEmptyText="True" SetFocusOnError="True">* </asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="EmailTextBox" 
                            ErrorMessage="Escriba un Email valido" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ForeColor="Red" 
                            SetFocusOnError="True">*
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <%--Telefono--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="TelefonoLabel" style="color: Black">Telefono </label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="12" Width="232px" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TelefonoTextBox" 
                            ErrorMessage="Introdusca un # de Telefono valido" 
                            ForeColor="Red" 
                            SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Celular--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="CelularLabel" style="color: Black">Celular </label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="CelularTextBox" runat="server" MaxLength="12" Width="232px" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="CelularTextBox" 
                            ErrorMessage="Introdusca un # de Celular valido" 
                            ForeColor="Red" 
                            SetFocusOnError="true">* 
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Fecha Ingreso--%>
                <div class="form-group">
                    <label class="col-md-2 control-label input-sm" for="Fecha IngresoLabel" style="color: Black">Fecha Ingreso </label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="FechaIngresoTextBox" runat="server" TextMode="Date" Width="232px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="FechaIngresoTextBox" 
                            ErrorMessage="fecha invalida"
                            ForeColor="Red"  
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)[0-9]{2}$"
                            SetFocusOnError="True" Display="Dynamic">*
                        </asp:RegularExpressionValidator>
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
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" HeaderText="Problema de Resgistro:" Height="16px" />
        </div>
    </div>
</asp:Content>
