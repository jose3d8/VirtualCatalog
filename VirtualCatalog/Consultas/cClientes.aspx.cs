using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VirtualCatalog.Consultas
{
    public partial class cClientes : System.Web.UI.Page
    {
        Clientes cliente = new Clientes();
        string Campos = "IdCliente, Nombre, Apellido, Direccion, Email, Telefono, Celular, FechaIngreso";
        string Filtro = "1=1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscargrip();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (BuscarDropDownList.SelectedIndex == 0)
            {
                Filtro += "and IdCliente like '%" + BuscarTextBox.Text + "%'";
            }

            if (BuscarDropDownList.SelectedIndex == 1)
            {
                Filtro += "and Nombre like '%" + BuscarTextBox.Text + "%'";
            }

            Buscargrip();
        }

        private void Buscargrip()
        {
            BuscarGridView.DataSource = cliente.Listar(Campos, Filtro);
            BuscarGridView.DataBind();

        }
    }
}