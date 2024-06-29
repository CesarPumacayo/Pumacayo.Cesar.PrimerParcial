using System;
using System.Data.SqlClient;

namespace Entidades
{
    public class BaseDatosActualizador
    {
        public Gaseosa? gaseosa;

        public void ActualizarCrudBaseDatos(InventarioGaseosas<Gaseosa> fabrica)
        {
            AccesoBaseDatos ado = new AccesoBaseDatos();

            if (ado.ProbarConexion())
            {
                try
                {
                    // Definir la consulta SQL
                    string query = "SELECT id, tipo_botella, precio, cantidad, exceso_azucar, litros, tipo_sabor, exceso_calorias, codigo, retornable FROM Tabla_Gaseosa";

                    // Crear un objeto SqlCommand
                    using (SqlCommand command = new SqlCommand(query, AccesoBaseDatos.Conectar()))
                    {
                        // Crear un lector de datos
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Iterar a través de los resultados
                            while (reader.Read())
                            {
                                if(fabrica.ListaGaseosas != null)
                                {

                                    if (fabrica.ListaGaseosas.Count >= 5)
                                    {
                                        // Si ya hay 5 elementos en la lista, salimos del bucle
                                        break;
                                    }
                                }

                                //???▼

                                // Obtener datos comunes
                                Enum.TryParse(reader["tipo_botella"].ToString(), out EtipoBotella tipoBotella);
                                double precio = Convert.ToDouble(reader["precio"]);
                                int cantidad = Convert.ToInt32(reader["cantidad"]);

                                // Lógica para inferir el tipo de gaseosa
                                if (!reader.IsDBNull(reader.GetOrdinal("litros")) && !reader.IsDBNull(reader.GetOrdinal("exceso_azucar")))
                                {
                                    // Asumimos que es una Fanta
                                    float litros = Convert.ToSingle(reader["litros"]);
                                    bool excesoAzucar = Convert.ToBoolean(reader["exceso_azucar"]);
                                    gaseosa = new Fanta(tipoBotella, precio, cantidad, litros, excesoAzucar);
                                }
                                else if (!reader.IsDBNull(reader.GetOrdinal("tipo_sabor")) && !reader.IsDBNull(reader.GetOrdinal("exceso_calorias")))
                                {
                                    // Asumimos que es una Manaos
                                    Enum.TryParse(reader["tipo_sabor"].ToString(), out EtipoSabor tipoSabor);
                                    bool excesoCalorias = Convert.ToBoolean(reader["exceso_calorias"]);
                                    gaseosa = new Manaos(tipoBotella, precio, cantidad, tipoSabor, excesoCalorias);
                                }
                                else if (!reader.IsDBNull(reader.GetOrdinal("codigo")) && !reader.IsDBNull(reader.GetOrdinal("retornable")))
                                {
                                    // Asumimos que es una Sprite
                                    double codigo = Convert.ToDouble(reader["codigo"]);
                                    bool esRetornable = Convert.ToBoolean(reader["retornable"]);
                                    gaseosa = new Sprite(tipoBotella, precio, cantidad, codigo, esRetornable);
                                }

                                if (gaseosa != null)
                                {
                                    if(fabrica.ListaGaseosas != null)
                                    {
                                        fabrica.ListaGaseosas.Add(gaseosa);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No se conectó");
            }
        }
    }
}
