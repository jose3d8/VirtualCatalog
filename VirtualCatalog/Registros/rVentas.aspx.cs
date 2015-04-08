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
    public partial class rVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
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
                int IdVenta = 0;
                IdVenta = Util.ObtenerEntero(Request.QueryString["IdVenta"]);

                if (IdVenta != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Text = IdVenta.ToString();
                }
                if (venta.Buscar())
                {
                    llenacampo(venta);
                }
            }
        }

        #region "Metodos"

        private void llenacampo(Ventas venta)
        {
            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            FechaTextBox.Text = venta.Fecha.ToString("yyyy-MM-dd");
            IdClienteDropDownList.Text = Convert.ToString(IdClienteDropDownList.Text);
            IdProductoDropDownList.Text = Convert.ToString(IdProductoDropDownList.Text);
            CantidadTextBox.Text = Convert.ToString(CantidadTextBox.Text);
            PrecioTextBox.Text = Convert.ToString(PrecioTextBox.Text);
            IdOfertaDropDownList.Text = Convert.ToString(IdOfertaDropDownList.Text);
            MontoTextBox.Text = Convert.ToString(MontoTextBox.Text);

            if (venta.IdVenta != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }

        }

        private void llenaclase(Ventas venta)
        {

            venta.Fecha = DateTime.Parse(FechaTextBox.Text);
            IdClienteDropDownList.Text = Convert.ToString(IdClienteDropDownList.Text);
            IdProductoDropDownList.Text = Convert.ToString(IdProductoDropDownList.Text);
            CantidadTextBox.Text = CantidadTextBox.Text;
            PrecioTextBox.Text = PrecioTextBox.Text;
            IdOfertaDropDownList.Text = IdOfertaDropDownList.Text;
            MontoTextBox.Text = MontoTextBox.Text;

        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            FechaTextBox.Text = "";
            IdClienteDropDownList.Text = "";
            IdProductoDropDownList.Text = "";
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
            IdOfertaDropDownList.Text = "";
            MontoTextBox.Text = "";
        }
        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            llenaclase(venta);
            if (Convert.ToBoolean(Session["Modificando"]) == false)
            {
                if (venta.Insertar())
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
                if (Request.QueryString["IdVenta"] != null)
                {
                    venta.IdVenta = int.Parse(Request.QueryString["IdVenta"]);
                    if (venta.Insertar())
                    {
                        limpiacampos();
                        Response.Write("Se ha Guardado Correctamente");
                    }
                    else
                        if (venta.Modificar())
                        {
                            Response.Redirect("cVentas.aspx");
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
            Ventas venta = new Ventas();
            if (venta.Eliminar() == true)
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "venta Eliminada Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione la venta que desea eliminar";
            }
        }
    }
        #endregion
}