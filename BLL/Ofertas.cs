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
    public class Ofertas
    {
        public int IdOferta { set; get; }
        public int IdProducto { set; get; }
        public float PrecioOferta { set; get; }

        public Ofertas()
        {
            this.IdOferta = 0;
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;
            paso = conexion.EjecutarDB("Insert into Ofertas(IdProducto,PrecioOferta) values('"
            + IdProducto + "','" + PrecioOferta + "')");
            return paso;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;
            paso = conexion.EjecutarDB("Update Ofertas set IdProducto = '" + IdProducto + "', PrecioOferta = '" + PrecioOferta + "' Where IdOferta = " + IdOferta.ToString());
            return paso;
        }

        public bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.EjecutarDB("Delete From Ofertas Where IdOferta = " + IdOferta);
        }

        public bool Buscar()
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.BuscarDb("Select * From Ofertas Where IdOferta = " + IdOferta);
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                this.IdOferta = (int)dt.Rows[0]["IdOferta"];
                this.IdProducto = (int)dt.Rows[0]["IdProducto"];
                this.PrecioOferta = (float)dt.Rows[0]["PrecioOferta"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select " + Campos + " From Clientes Where" + Filtro);
            return dt;
        }
    }
}
