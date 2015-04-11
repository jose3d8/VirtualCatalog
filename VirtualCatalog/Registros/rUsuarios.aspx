<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVC.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="VirtualCatalog.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .panel-heading {
            height: 79px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success">
        <div class="panel panel-heading" style="background-color: #336699; color: #FFFFFF; font-weight: bold; font-size: 25px; height: 50px; width: 541px;">Registro de Usuario</div>
        <div class=" panel-body">

            <%--IdUsuario--%>
            <div class=" form-horizontal col-md-12" role="form">
                <div class="form-group">
                    <label for="IdUsuarioLabel" class="col-md-2 control-label input-sm" style="color: Black">IdUsuario</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="IdTextBox" runat="server" CssClass="form-control input-sm" Width="64px"></asp:TextBox>
                    </div>
                </div>

                <%--Nombre--%>
                <div class="form-group">
                    <label for="NombreLabel" class="col-md-2 control-label input-sm" style="color: Black">Nombre</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="NombreTextBox" runat="server" Width="232px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="NombreTextBox"
                            ErrorMessage="Introdusca un Nombre valido"
                            ForeColor="Red"
                            SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Clave--%>
                <div class="form-group">
                    <label for="ClaveLabel" class="col-md-2 control-label input-sm" style="color: Black">Clave</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="ClaveTextBox" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="ClaveTextBox"
                            ErrorMessage="Introdusca una Clave Valida"
                            ForeColor="Red"
                            SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Confirmar Clave--%>
                <div class="form-group">
                    <label for="ConfirmarClaveLabel" class="col-md-2 control-label input-sm" style="color: Black">Confirmar Clave</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="ConfirmarTextBox" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="ConfirmarTextBox"
                            ErrorMessage="Introdusca de nuevo la Clave "
                            ForeColor="Red"
                            SetFocusOnError="true">*
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToCompare="ClaveTextBox" ControlToValidate="ConfirmarTextBox"
                            ErrorMessage="La clave es incorrecta introduscala de nuevo"
                            ForeColor="Red"
                            SetFocusOnError="true">* 
                        </asp:CompareValidator>
                    </div>
                </div>

                <%--Email--%>
                <div class="form-group">
                    <label for="EmailLabel" class="col-md-2 control-label input-sm" style="color: Black">Email</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="EmailTextBox" runat="server" Width="231px" MaxLength="50" TextMode="Email"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                            ControlToValidate="EmailTextBox"
                            ErrorMessage="Introdusca un Email valido"
                            ForeColor="Red"
                            ValidateEmptyText="True">*
                        </asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="EmailTextBox"
                            ErrorMessage="Escriba un Email valido"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <%--Activo--%>
                <div class="form-group">
                    <label for="ActivoLabel" class="col-md-2 control-label input-sm" style="color: black">Activo</label>
                    <div class="col-lg-9">
                        <asp:CheckBox ID="esActivoCheckBox" runat="server"></asp:CheckBox>
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
