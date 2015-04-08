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
    public class Rutas
    {
        public int IdRuta { set; get; }
        public string Descripcion { set; get; }

        public List<RutasDetalle> Detalle { set; get; }

        public Rutas()
        {
            this.IdRuta = 0;
        }

        public void AgregarDetalle(int IdCliente, int OrdenVisita)
        {
            RutasDetalle det = new RutasDetalle();
            det.IdCliente = IdCliente;
            det.OrdenVisita = OrdenVisita;

            this.Detalle.Add(det);
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;

            this.IdRuta = (int)conexion.ObtenerValorDb("Insert into Rutas(Descripcion) values ('" + Descripcion + "') Select @@Identity");

            if (this.IdRuta > 0)
            {
                foreach (RutasDetalle item in this.Detalle)
                {
                    conexion.EjecutarDB("Insert into RutasDetalle(IdRuta,IdCliente,OrdenVisita) values ('"
                       + this.IdRuta + "','" + item.IdCliente + "','" + item.OrdenVisita + "')");
                }
            }
            return paso;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;

            paso = conexion.EjecutarDB("Update Rutas set Descripcion = '" + Descripcion + "' Where IdRuta = " + IdRuta.ToString());
            foreach (RutasDetalle item in this.Detalle)
            {
                conexion.EjecutarDB("Update RutasDetalle set IdCliente = '" + item.IdCliente + "', OrdenVisita ='"
                  + item.OrdenVisita + "')");
            }
            return paso;
        }

        public bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.EjecutarDB("Delete From Rutas Where IdRuta = " + IdRuta);
        }

        public bool Buscar()
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.BuscarDb("Select * From Rutas Where IdRuta = " + IdRuta);
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                this.IdRuta = (int)dt.Rows[0]["IdRuta"];
                this.Descripcion = (string)dt.Rows[0]["Descripcion"];
                this.Detalle = (List<RutasDetalle>) dt.Rows[0]["Detalle"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select" + Campos + "From Rutas Where" + Filtro);
            return dt;
        }
    }
}
