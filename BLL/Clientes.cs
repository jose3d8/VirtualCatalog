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
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Clientes()
        {
            this.IdCliente = 0;
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;
            accion = conexion.EjecutarDB("Insert into Clientes(Nombre,Apellido,Direccion,Email,Telefono,Celular,FechaIngreso) values('"
            + Nombre + "','" + Apellido + "','" + Direccion + "','" + Email + "','" + Telefono + "','" + Celular + "','" + FechaIngreso.ToString("MM/dd/yyyy") + "')");
            return accion;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;
            accion = conexion.EjecutarDB("Update Clientes set Nombre = '" + Nombre + "', Apellido = '" + Apellido + "', Direccion = '" + Direccion +
            "', Email = '" + Email + "', Telefono = '" + Telefono + "', Celular = '" + Celular + "', FechaIngreso = '" + FechaIngreso.ToString("dd/MM//yyyy") + "' Where IdCliente = " + IdCliente.ToString());
            return accion;
        }

        public static bool Eliminar(int IdCliente)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.EjecutarDB("Delete From Clientes Where IdCliente = " + IdCliente);
        }
        public bool Buscar()
        {
            bool Retorno = false;
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();
            dt = conexion.BuscarDb("Select * From Clientes Where IdCliente = " + IdCliente);
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
                this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                this.Nombre = (string)dt.Rows[0]["Nombre"];
                this.Apellido = (string)dt.Rows[0]["Apellido"];
                this.Direccion = (string)dt.Rows[0]["Direccion"];
                this.Email = (string)dt.Rows[0]["Email"];
                this.Telefono = (string)dt.Rows[0]["Telefono"];
                this.Celular = (string)dt.Rows[0]["Celular"];
                this.FechaIngreso = (DateTime)dt.Rows[0]["FechaIngreso"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.BuscarDb("Select " + Campos + " From Clientes Where " + Filtro);
            return dt;
        }
    }
}
