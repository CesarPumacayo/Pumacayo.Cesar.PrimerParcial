using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Entidades
{
    public class CambiosBaseDatos
    {
        public Gaseosa? gaseosa;

        private InventarioGaseosas<Gaseosa> cajaInventario;

        public void MostrarCambiosCrud(InventarioGaseosas<Gaseosa> cajaInventario)
        {
            AccesoBaseDatos ado = new AccesoBaseDatos();
            //using(SqlDataReader reader = SqlCommand.ExecuteReader())
            //while(reader.Read()) 
            //{
            //    if(reader["GASEOSA"].ToString() == "")       
                
                
                
            //}

        }
    }
}
