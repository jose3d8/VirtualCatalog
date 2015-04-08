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
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Productos producto = new Productos();
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
                int IdProducto = Util.ObtenerEntero(Request.QueryString["IdProducto"]);

                if (IdProducto != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Text = IdProducto.ToString();
                }
                if (producto.Buscar())
                {
                    llenacampo(producto);
                }
            }
        }

        #region "Metodos"

        private void llenacampo(Productos producto)
        {
            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            DescripcionTextBox.Text = producto.Descripcion;
            PrecioTextBox.Text = Convert.ToString(PrecioTextBox.Text);
            ExistenciaTextBox.Text = Convert.ToString(ExistenciaTextBox.Text);

            if (producto.IdProducto != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }
        }

        private void llenaclase(Productos producto)
        {
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Precio = Convert.ToSingle(PrecioTextBox.Text);
            producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            PrecioTextBox.Text = "";
            ExistenciaTextBox.Text = "";
        }
        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            llenaclase(producto);
            if (producto.Insertar())
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
            if (Request.QueryString["IdProducto"] != null)
            {
                producto.IdProducto = int.Parse(Request.QueryString["IdProducto"]);
                if (producto.Insertar())
                {
                    limpiacampos();
                    Response.Write("Se ha Guardado Correctamente");
                }
                else
                    if (producto.Modificar())
                    {
                        Response.Redirect("cProductos.aspx");
                    }
                    else
                    {
                        Response.Write("No se pudo Modificar");
                    }

            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            if (producto.Eliminar() == true)
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "Producto Eliminado Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione el Producto que desea eliminar";
            }
        }
    }

        #endregion
}