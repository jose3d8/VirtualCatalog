using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Productos
    {
        public int IdProducto { set; get; }
        public string Descripcion { set; get; }
        public double Precio { set; get; }
        public double Existencia { set; get; }

        public Productos()
        {
            this.IdProducto = 0;
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;
            paso = conexion.EjecutarDB("Insert into Productos (Descripcion,Precio,Existencia) values('" + Descripcion + "','" + Precio + "','" + Existencia + "')");
            return paso;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;
            paso = conexion.EjecutarDB("Update Productos Set Descripcion = '" + Descripcion + "', Precio = '" + Precio + "', Existencia = '" + Existencia + "' Where IdProducto = " + IdProducto.ToString());
            return paso;
        }

        public static bool Eliminar(int IdProducto)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.EjecutarDB("Delete From Productos Where IdProducto = " + IdProducto);
        }

        public bool Buscar()
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.BuscarDb("Select * From Productos Where IdProducto = " + IdProducto);
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                this.IdProducto = (int)dt.Rows[0]["IdProducto"];
                this.Descripcion = (string)dt.Rows[0]["Descripcion"];
                this.Precio = (double)dt.Rows[0]["Precio"];
                this.Existencia = (double)dt.Rows[0]["Existencia"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select " + Campos + " From Productos Where" + Filtro);
            return dt;
        }
    }
}
