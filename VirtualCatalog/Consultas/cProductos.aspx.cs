using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VirtualCatalog.Consultas
{
    public partial class cProductos : System.Web.UI.Page
    {
        Productos producto = new Productos();
        string Campos = "IdProducto, Descripcion, Precio, Existencia";
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
                Filtro += "and IdProducto like '%" + BuscarTextBox.Text + "%'";
            }

            Buscargrip();
        }

        private void Buscargrip()
        {
            BuscarGridView.DataSource = producto.Listar(Campos, Filtro);
            BuscarGridView.DataBind();
        }
    }
}