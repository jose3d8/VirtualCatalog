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
    public class Usuarios
    {
        public int IdUsuario { set; get; }
        public string Nombre { set; get; }
        public string Clave { set; get; }
        public string Confirmar { set; get; }
        public string Email { set; get; }
        public bool esActivo { set; get; }
        DataTable Datos = new DataTable();

        public Usuarios()
        {
            this.IdUsuario = 0;
        }

        public bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;

            //this.IdUsuario = (int)conexion.ObtenerValorDb("Insert into Usuarios(Nombre,Clave,Email,esActivo) values('" + Nombre + "','" + Clave + "','" + Email + "','" + esActivo + "') Select @@Identity");
            accion = conexion.EjecutarDB("Insert into Usuarios(Nombre,Clave,Email,esActivo) values('" + Nombre + "','" + Clave + "','" + Email + "','" + esActivo + "')");
            return accion;
        }

        public bool Modificar()
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;
            accion = conexion.EjecutarDB("Update Usuarios set Nombre = '" + Nombre + "', Clave = '" + Clave + "', Email = '" + Email + "', esActivo = '" + esActivo + "' Where IdUsuario = " + IdUsuario.ToString());
            return accion;

        }

        public bool Eliminar(int prmIdUsuario)
        {
            ConexionDb conexion = new ConexionDb();
            bool accion = false;
            accion = conexion.EjecutarDB("Delete from Usuarios where IdUsuario = " + prmIdUsuario);
            return accion;
        }

        public bool Buscar(int prmUsuario)
        {
            bool Retorno = false;
            DataTable Datos = new DataTable();
            ConexionDb conexion = new ConexionDb();

            Datos = conexion.BuscarDb("Select * from Usuarios where IdUsuario = " + prmUsuario);
            if (Datos.Rows.Count > 0)
            {
                Retorno = true;
                this.IdUsuario = (int)Datos.Rows[0]["IdUsuario"];
                this.Nombre = (string)Datos.Rows[0]["Nombre"];
                this.Clave = (string)Datos.Rows[0]["Clave"];
                this.Email = (string)Datos.Rows[0]["Email"];
                this.esActivo = (bool)Datos.Rows[0]["esActivo"];
            }

            return Retorno;
        }

        public DataTable Listar(string Campos, string Filtro)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable datos = new DataTable();
            datos = conexion.BuscarDb("Select " + Campos + " from Usuarios Where " + Filtro);
            return datos;
        }

        public bool BuscarId(string Nombre)
        {
            ConexionDb conexion = new ConexionDb();
            Boolean paso = false;
            DataTable Datos = new DataTable();
            Datos = conexion.BuscarDb("Select * from Usuarios where Nombre = '" + Nombre + "'");

            if (Datos.Rows.Count > 0)
            {
                this.IdUsuario = (int)Datos.Rows[0]["IdUsuario"];
                paso = true;
            }

            return paso;
        }

        public Boolean Autenticar(string pUserName, string pPassword)
        {
            ConexionDb conexion = new ConexionDb();
            Boolean retorno = false;
            object idUsuario = conexion.ObtenerValorDb("SELECT IdUsuario from Usuarios Where Usuarios = '" + pUserName + "' And Clave = '" + pPassword + "'");

            if (idUsuario != null)
            {
                retorno = this.Buscar((int)IdUsuario);
            }

            return retorno;
        }

    }
}
