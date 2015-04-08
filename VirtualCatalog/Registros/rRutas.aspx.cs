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
    public partial class rRutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Rutas ruta = new Rutas();
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
                int IdRuta = 0;
                IdRuta = Util.ObtenerEntero(Request.QueryString["IdRuta"]);

                if (IdRuta != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Text = IdRuta.ToString();
                }
                if (ruta.Buscar())
                {
                    llenacampo(ruta);
                }
            }
        }

        #region "Metodos"

        private void llenacampo(Rutas ruta)
        {
            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            DescripcionTextBox.Text = ruta.Descripcion;
            IdClienteDropDownList.Text = Convert.ToString(IdClienteDropDownList.Text);

            if (ruta.IdRuta != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }
        }

        private void llenaclase(Rutas ruta)
        {
            ruta.Descripcion = DescripcionTextBox.Text;
            IdClienteDropDownList.Text = Convert.ToString(IdClienteDropDownList.Text);
        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            IdClienteDropDownList.Text = "";
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Rutas ruta = new Rutas();
            llenaclase(ruta);
            if (Convert.ToBoolean(Session["Modificando"]) == false)
            {
                if (ruta.Insertar())
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
                if (Request.QueryString["IdRuta"] != null)
                {
                    ruta.IdRuta = int.Parse(Request.QueryString["IdRuta"]);
                    if (ruta.Insertar())
                    {
                        limpiacampos();
                        Response.Write("Se ha Guardado Correctamente");
                    }
                    else
                        if (ruta.Modificar())
                        {
                            Response.Redirect("cRutas.aspx");
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
            Rutas ruta = new Rutas();
            if (ruta.Eliminar() == true)
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "Ruta Eliminado Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione la Ruta que desea eliminar";
            }
        }
    }
        #endregion
}