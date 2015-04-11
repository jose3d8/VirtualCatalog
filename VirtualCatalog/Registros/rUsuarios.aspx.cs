using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using BLL;
using BLL.Utilitarios;

namespace VirtualCatalog.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            MsjLabel.Text = "";
            if (!IsPostBack)
            {
                Session["Modificando"] = false;
                int IdUsuario = 0;
                IdUsuario = Util.ObtenerEntero(Request.QueryString["IdUsuario"]);

                if (IdUsuario != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Visible = true;
                    IdTextBox.Text = IdUsuario.ToString();
                }
                if (usuario.Buscar())
                {
                    llenacampo(usuario);

                }
            }

        }

        #region "Metodos"


        private void llenacampo(Usuarios usuario)
        {

            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            NombreTextBox.Text = usuario.Nombre;
            ClaveTextBox.Text = usuario.Clave;
            ConfirmarTextBox.Text = usuario.Clave;
            EmailTextBox.Text = usuario.Email;
            esActivoCheckBox.Checked = usuario.esActivo;

            if (usuario.Nombre != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }
        }


        private void llenaclase(Usuarios usuario)
        {

            usuario.Nombre = NombreTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.esActivo = esActivoCheckBox.Checked;
        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ClaveTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            EmailTextBox.Text = "";
            esActivoCheckBox.Checked = false;

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            llenaclase(usuario);
            if (Convert.ToBoolean(Session["Modificando"]) == false)
            {
                if (usuario.Insertar())
                {

                    MsjLabel.ForeColor = System.Drawing.Color.Green;
                    MsjLabel.Text = "Registro realizado con exito";
                    limpiacampos();
                }
                else
                {
                    MsjLabel.ForeColor = System.Drawing.Color.Red;
                    MsjLabel.Text = "Error de registro";
                }
                if (Request.QueryString["IdUsuario"] != null)
                {
                    usuario.IdUsuario = int.Parse(Request.QueryString["IdUsuario"]);
                    if (usuario.Insertar())
                    {
                        limpiacampos();
                        Response.Write("Se ha Guardado Correctamente");
                    }
                    else
                        if (usuario.Modificar())
                        {
                            Response.Redirect("cUsuarios.aspx");
                        }
                        else
                        {
                            Response.Write("No se pudo Modificar");
                        }

                }

            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Usuarios.Eliminar(int.Parse(Request.QueryString["IdUsuario"])))
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "Usuario Eliminado Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione el Usuario que desea eliminar";
            }
        }

    }
        #endregion "Metodos"
}