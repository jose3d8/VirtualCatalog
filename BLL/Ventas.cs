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
    public class Ventas
    {
        public int IdVenta { set; get; }
        public DateTime Fecha { set; get; }
        public int IdCliente { set; get; }
        public float Monto { set; get; }

        public List<VentasDetalle> Detalle { set; get; }

        public Ventas()
        {
            this.IdVenta = 0;
            //this.Detalle = new List<VentasDetalle>;
        }

        public void AgregarDetalle(int IdProducto, int Cantidad, float Precio, int IdOferta)
        {
            VentasDetalle det = new VentasDetalle();
            det.IdProducto = IdProducto;
            det.Cantidad = Cantidad;
            det.Precio = Precio;
            det.IdOferta = IdOferta;

            this.Detalle.Add(det);
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;

            this.IdVenta = (int)conexion.ObtenerValorDb("Insert into Ventas(Fecha,IdCliente,Monto) values ('" + Fecha.ToString("MM/dd/yyyy") + "','" + IdCliente + "','" + Monto + "') Select @@Identity");

            if (this.IdVenta > 0)
            {
                foreach (VentasDetalle item in this.Detalle)
                {
                    conexion.EjecutarDB("Insert into VentasDetalle(IdVenta,IdProducto,Cantidad,Precio,IdOferta) values('"
                        + this.IdVenta + "','" + item.IdProducto + "','" + item.Cantidad + "','" + item.Precio + "','" + item.IdOferta + "')");

                }
            }
            return accion;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool paso = false;
            paso = conexion.EjecutarDB("Update Ventas set Fecha = '" + Fecha.ToString("dd/MM//yyyy") + "', IdCliente = '" + IdCliente + "', Monto = '" + Monto + "' Where IdVenta = " + IdVenta.ToString());
            return paso;
        }

        public bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.EjecutarDB("Delete From Ventas Where IdVenta = " + IdVenta);
        }

        public bool Buscar()
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.BuscarDb("Select * From Ventas Where IdVenta = " + IdVenta);
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                this.IdVenta = (int)dt.Rows[0]["IdVenta"];
                this.Fecha = (DateTime)dt.Rows[0]["Fecha"];
                this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                this.Monto = (float)dt.Rows[0]["Monto"];
                this.Detalle = (List<VentasDetalle>)dt.Rows[0]["Detalle"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select " + Campos + " From Ventas Where" + Filtro);
            return dt;
        }
    }
}
