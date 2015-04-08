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
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
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
                int IdCliente = 0;
                IdCliente = Util.ObtenerEntero(Request.QueryString["IdCliente"]);

                if (IdCliente != 0)
                {
                    ClearButton.Visible = true;
                    SaveButton.Visible = true;
                    IdTextBox.Visible = true;
                    IdTextBox.Text = IdCliente.ToString();
                }
                if (cliente.Buscar())
                {
                    llenacampo(cliente);
                }
            }
        }

        #region "Metodos"

        private void llenacampo(Clientes cliente)
        {
            IdTextBox.Text = Convert.ToString(IdTextBox.Text);
            NombreTextBox.Text = cliente.Nombre;
            ApellidoTextBox.Text = cliente.Apellido;
            DireccionTextBox.Text = cliente.Direccion;
            EmailTextBox.Text = cliente.Email;
            TelefonoTextBox.Text = cliente.Telefono;
            CelularTextBox.Text = cliente.Celular;
            FechaIngresoTextBox.Text = cliente.FechaIngreso.ToString("yyyy-MM-dd");

            if (cliente.Nombre != null)
            {
                Session["Modificando"] = true;
            }
            else
            {
                Session["Modificando"] = false;
            }
        }

        private void llenaclase(Clientes cliente)
        {
            DateTime fecha = new DateTime();
            cliente.Nombre = NombreTextBox.Text;
            cliente.Apellido = ApellidoTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Celular = CelularTextBox.Text;            
            cliente.FechaIngreso = DateTime.Now;
            DateTime.TryParse(FechaIngresoTextBox.Text, out fecha);
       
        }

        private void limpiacampos()
        {
            IdTextBox.Enabled = true;
            Session["Modificando"] = false;
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CelularTextBox.Text = "";
            FechaIngresoTextBox.Text = "";
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            limpiacampos();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            llenaclase(cliente);
            if (Convert.ToBoolean(Session["Modificando"]) == false)
            {
                if (cliente.Insertar() )
                {
                    MsjLabel.ForeColor = System.Drawing.Color.Green;
                    MsjLabel.Text = "Registro realizado con exito";
                    limpiacampos();
                }
                else
                {
                    MsjLabel.ForeColor = System.Drawing.Color.Red;
                    MsjLabel.Text = "Error de Registro";
                }
                if (Request.QueryString["IdCliente"] != null)
                {
                    cliente.IdCliente = int.Parse(Request.QueryString["IdCliente"]);
                    if (cliente.Insertar())
                    {
                        limpiacampos();
                        Response.Write("Se ha Guardado Correctamente");
                    }
                    else
                        if (cliente.Modificar())
                        {
                            Response.Redirect("cClientes.aspx");
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
            Clientes cliente = new Clientes();
            if (cliente.Eliminar() == true)
            {
                MsjLabel.ForeColor = System.Drawing.Color.Green;
                MsjLabel.Text = "Cliente Eliminado Correctamente";
                limpiacampos();
            }
            else
            {
                MsjLabel.ForeColor = System.Drawing.Color.Red;
                MsjLabel.Text = "Seleccione el Cliente que desea eliminar";
            }
        }

    }
        #endregion
}