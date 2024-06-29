using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interfaz.FormsGaseosas
{
    public partial class FrmGaseosa : Form
    {
        public FrmGaseosa()
        {
            InitializeComponent();
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
        protected bool ExisteGaseosaEnBaseDeDatosManaos(string tipoBotella, double precio, int cantidad, string tipoSabor, bool excesoCalorias)
        {
            bool existe = false;

            try
            {
                using (var connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Tabla_Gaseosa WHERE tipo_botella = @tipo_botella AND precio = @precio AND cantidad = @cantidad AND tipo_sabor = @tipo_sabor AND exceso_calorias = @exceso_calorias";
                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tipo_botella", tipoBotella);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@tipo_sabor", tipoSabor);
                        command.Parameters.AddWithValue("@exceso_calorias", excesoCalorias);

                        int count = (int)command.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia de la gaseosa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return existe;
        }

        protected bool ExisteGaseosaEnBaseDeDatosFanta(string tipoBotella, double precio, int cantidad, float litros, bool excesoAzucar)
        {
            bool existe = false;

            try
            {
                using (var connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Tabla_Gaseosa WHERE tipo_botella = @tipo_botella AND precio = @precio AND cantidad = @cantidad AND litros = @litros AND exceso_azucar = @exceso_azucar";
                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tipo_botella", tipoBotella);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@litros", litros);
                        command.Parameters.AddWithValue("@exceso_azucar", excesoAzucar);

                        int count = (int)command.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia de la gaseosa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return existe;
        }
        protected bool ExisteGaseosaEnBaseDeDatoSprite(string tipoBotella, double precio, int cantidad, double codigo, bool retornable)
        {
            bool existe = false;

            try
            {
                using (var connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Tabla_Gaseosa WHERE tipo_botella = @tipo_botella AND precio = @precio AND cantidad = @cantidad AND codigo = @codigo AND retornable = @retornable";
                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tipo_botella", tipoBotella);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.Parameters.AddWithValue("@retornable", retornable);

                        int count = (int)command.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia de la gaseosa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return existe;
        }


        protected int ObtenerCantidadGaseosasRegistradas()
        {
            int cantidad = 0;
            try
            {
                using (var connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Tabla_Gaseosa";
                    var cmd = new SqlCommand(consulta, connection);
                    cantidad = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la cantidad de gaseosas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cantidad;
        }
    }
}
