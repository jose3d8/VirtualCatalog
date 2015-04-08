using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexionDb
    {

        //public string ConexionString
        //{
        //    get { return WebConfigurationManager.AppSettings["ConexionString"]; }
        //}

        //public static SqlConnection con = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=TeacherControlDb;Integrated Security=True");
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Users\Alex\documents\visual studio 2013\Projects\VirtualCatalog\VirtualCatalog\App_Data\VirtualCatalog.mdf;Integrated Security=True");

        public string ultimoError;

        public string UltimoError
        {
            get { return ultimoError; }
        }

        public bool EjecutarDB(string Codigo)
        {
            bool mensaje = false;
            SqlCommand cmd = new SqlCommand();


            try
            {
                con.Open(); // abrimos la conexion
                //MessageBox.Show("Conexion abierta");

                cmd.Connection = con; //asignamos la conexion
                cmd.CommandText = Codigo;     //asignamos el comando
                cmd.ExecuteNonQuery(); // ejecutamos el comando

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mensaje = true;
                con.Close(); //cerramos la conexion
                // MessageBox.Show("Conexion cerrada");

            }
            return mensaje;
        }
        /// <summary>
        /// para buscar datos en la base de datos
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public DataTable BuscarDb(string comando)
        {
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            try
            {
                con.Open(); // abrimos la conexion
                adp = new SqlDataAdapter(comando, con);

                adp.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close(); //cerramos la conexion

            }
            return dt;
        }

        public Object ObtenerValorDb(string escalar)
        {
            SqlCommand com = new SqlCommand(escalar, con);
            Object objeto;

            try
            {
                con.Open();
                objeto = com.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

            return objeto;
        }
    }
}
