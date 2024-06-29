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
        public SqlDataReader lector;
        public SqlCommand command;


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

        private bool ProbarConexionRegistro(SqlCommand command)
        {
            bool respuesta = false;

            command.Connection = this.conexion;

            this.conexion.Open();

            int filasAfectadas = command.ExecuteNonQuery();

            if (filasAfectadas == 1)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
        //public bool AgregarGaseosaTabla<T>(T gaseosa , string tabla) where T : Gaseosa
        //{
        //    bool retorno = false;

        //    try
        //    {
        //        this.command = new SqlCommand();//OJO
        //        this.command.Parameters.Clear();
        //        this.command.Parameters.AddWithValue("@tipo_botella", (int)gaseosa.TipoBotella);
        //        this.command.Parameters.AddWithValue("@precio", (double)gaseosa.Precio);
        //        this.command.Parameters.AddWithValue("@cantidad", (int)gaseosa.Cantidad);


        //        if (gaseosa is Fanta fanta)
        //        {
        //            command.Parameters.AddWithValue("@exceso_azucar", (bool)fanta.ExcesoAzucar);
        //            command.Parameters.AddWithValue("@litros", (double)fanta.Litros);

        //            command.CommandText = $"INSERT INTO {tabla} " +
        //                "(tipo_botella, precio, cantidad, exceso_azucar) " +
        //                "VALUES (@tipo_botella, @precio, @cantidad, @exceso_azucar, @litros)";
        //        }
        //        else if (gaseosa is Manaos manaos)
        //        {
        //            command.Parameters.AddWithValue("@tipo_sabor", (int)manaos.TipoSabor);
        //            command.Parameters.AddWithValue("@exceso_calorias", (bool)manaos.ExcesoCalorias);
        //            command.CommandText = $"INSERT INTO {tabla} " +
        //                "(tipo_botella, precio, cantidad, tipo_sabor, exceso_calorias) " +
        //               "VALUES (@tipo_botella, @precio, @cantidad, @tipo_sabor, @exceso_calorias)";
        //        }
        //        else if (gaseosa is Sprite sprite)
        //        {
        //            command.Parameters.AddWithValue("@codigo", (double)sprite.Codigo);
        //            command.Parameters.AddWithValue("@retornable", (bool)sprite.EsRetornable);
        //            command.CommandText = $"INSERT INTO {tabla} " +
        //                "(tipo_botella, precio, cantidad, codigo, retornable) " +
        //               "VALUES (@tipo_botella, @precio, @cantidad, @codigo, @retornable)";
        //        }

        //        ProbarConexionRegistro(command);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        if (this.conexion.State == ConnectionState.Open)
        //        {
        //            this.conexion.Close();

        //        }
        //    }

        //    return retorno;

        //}

        //public bool EliminarGaseosaTabla<T>(T gaseosa) where T : Gaseosa
        //{
        //    bool retorno = false;

        //    try
        //    {
        //        this.command = new SqlCommand();
        //        this.command.Parameters.Clear();
        //        this.command.Parameters.AddWithValue("@id", gaseosa.GetType().GetProperty("Id").GetValue(entidad));

        //        this.command.CommandType = System.Data.CommandType.Text;
        //        this.command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE id = @id";
        //        this.command.Connection = this.conexion;
        //    }

        //    return retorno;
        //}









    }
}
