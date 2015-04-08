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
    public partial class rOfertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ofertas oferta = new Ofertas();
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
                int IdOferta = 0;
                IdOferta = Util.ObtenerEntero(Request.QueryString["IdOferta"]);

                if (IdOferta != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Text = IdOferta.ToString();
                }
                if (oferta.Buscar())
                {
                    llenacampo(oferta);
                }
            }
        }

        #region "Metodos"

        private void llenacampo(Ofertas oferta)
        {
            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            IdProductoDropDownList.Text = Convert.ToString(IdProductoDropDownList.Text);
            PrecioOfertaTextBox.Text = Convert.ToString(PrecioOfertaTextBox.Text);

            if (oferta.IdProducto != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }
        }

        private void llenaclase(Ofertas oferta)
        {
            oferta.IdProducto = Convert.ToInt32(IdProductoDropDownList.Text);
            oferta.PrecioOferta = Convert.ToSingle(PrecioOfertaTextBox.Text);
        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            IdProductoDropDownList.Text = "";
            PrecioOfertaTextBox.Text = "";
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Ofertas oferta = new Ofertas();
            llenaclase(oferta);
            if (Convert.ToBoolean(Session["Modificando"]) == false)
            {
                if (oferta.Insertar())
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
                if (Request.QueryString["IdOferta"] != null)
                {
                    oferta.IdOferta = int.Parse(Request.QueryString["IdOferta"]);
                    if (oferta.Insertar())
                    {
                        limpiacampos();
                        Response.Write("Se ha Guardado Correctamente");
                    }
                    else
                        if (oferta.Modificar())
                        {
                            Response.Redirect("cOfertas.aspx");
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
            Ofertas oferta = new Ofertas();
            if (oferta.Eliminar() == true)
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "Oferta Eliminada Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione la Oferta que desea eliminar";
            }
        }
    }
        #endregion
}