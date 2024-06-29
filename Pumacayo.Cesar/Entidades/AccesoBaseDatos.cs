using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class AccesoBaseDatos
    {
        public SqlConnection conexion;
        public static string cadena_conexion;
        public SqlDataReader? lector;
        public SqlCommand? command;


        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(cadena_conexion);
            conexion.Open();
            return conexion;

        }

        static AccesoBaseDatos()
        {
            AccesoBaseDatos.cadena_conexion = Properties.Resources.miConexion;
            //AccesoBaseDatos.cadena_conexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=gaseosas_bd;Integrated Security=True;Encrypt=False";
        }

        public AccesoBaseDatos()
        {
            this.conexion = new SqlConnection(AccesoBaseDatos.cadena_conexion);
        }

        public bool ProbarConexion()
        {
           bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch
            {

            }
            finally
            {
                if(this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
                
            }
            return retorno;
        }
    }
}
