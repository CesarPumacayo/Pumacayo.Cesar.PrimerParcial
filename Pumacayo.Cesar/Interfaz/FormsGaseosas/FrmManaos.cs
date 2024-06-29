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
    public partial class FrmManaos : FrmGaseosa
    {
        private Manaos? miManaos;
        public Gaseosa? gaseosas;
        private int id;
        private bool esActualizacion = false;
        private int cantidadGaseosasRegistradas;


        #region Propiedades
        /// <summary>
        /// Obtiene (Lectura) la instancia de la clase Manaos asociada al formulario.
        /// </summary>
        public Manaos? MiManaos
        {
            get { return this.miManaos; }
        }
        #endregion
        public FrmManaos()
        {
            InitializeComponent();
            foreach (EtipoSabor tipoSabor in Enum.GetValues(typeof(EtipoSabor)))
            {
                this.cboSabor.Items.Add(tipoSabor);
            }
            foreach (EtipoBotella tipoBotella in Enum.GetValues(typeof(EtipoBotella)))
            {
                this.cboBotella.Items.Add(tipoBotella);
            }
            this.cboSabor.SelectedItem = EtipoSabor.Cola;
            this.cboBotella.SelectedItem = EtipoBotella.Plastico;
            cantidadGaseosasRegistradas = ObtenerCantidadGaseosasRegistradas();

        }

        /// <summary>
        /// Inicializa una nueva instancia con datos del objeto Gaseosa
        /// </summary>
        /// <param name="g">Datos de la gaseosa que muestra el formulario</param>
        public FrmManaos(Gaseosa g) : this()
        {
            esActualizacion = true;
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.cboSabor.SelectedItem = ((Manaos)g).TipoSabor;
            this.checkCalorias.Checked = ((Manaos)g).ExcesoCalorias;
            try
            {
                using (var connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = $"SELECT ID FROM Tabla_Gaseosa WHERE precio = '{g.Precio}' AND cantidad = '{g.Cantidad}' AND tipo_botella = '{g.TipoBotella}'";
                    var cmd2 = new SqlCommand(consulta, connection);
                    id = (int)cmd2.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// El metodo maneja los eventos heredadas con el click del boton "Aceptar" y carga los datos ingresados al objeto Sprite.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cantidadGaseosasRegistradas >= 5)
            {
                MessageBox.Show("No se pueden agregar más gaseosas, se ha alcanzado el límite máximo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método sin realizar la inserción
            }
            agregarManaos();
            try
            {
                if (string.IsNullOrEmpty(this.txtPrecio.Text) || string.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    throw new CamposNullMyExpection();
                }
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);

                EtipoSabor tipoSabor = (EtipoSabor)this.cboSabor.SelectedItem;
                bool excesoCalorias = this.checkCalorias.Checked;

                if (precio == 0 || cantidad == 0)
                {
                    throw new CamposZeroMyExpection("Ingrese un número distinto de cero.\n¡Tenga cuidado!");

                }

                this.miManaos = new Manaos(tipoBotella, precio, cantidad, tipoSabor, excesoCalorias);

                this.DialogResult = DialogResult.OK; // Asegúrate de establecer el resultado del diálogo aquí

                base.btnAceptar_Click(sender, e);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos numéricos tengan un formato válido.\n" + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CamposNullMyExpection ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CamposZeroMyExpection ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cantidadGaseosasRegistradas++;

        }
        private int ObtenerCantidadGaseosasRegistradas()
        {
            int cantidad = 0;
            try
            {
                // Lógica para obtener la cantidad de gaseosas en la base de datos
                // Aquí deberías realizar una consulta SQL para contar las gaseosas registradas
                // Ejemplo:
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
        public void agregarManaos()
        {
            EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
            int cantidad = int.Parse(base.txtCantidad.Text);
            double precio = double.Parse(base.txtPrecio.Text);
            EtipoSabor tipoSabor = (EtipoSabor)this.cboSabor.SelectedItem;
            bool excesoCalorias = this.checkCalorias.Checked;

            this.gaseosas = new Manaos(tipoBotella, precio, cantidad, tipoSabor, excesoCalorias);

            string tipoSaborStr = tipoSabor.ToString();
            string tipoBotellaStr = tipoBotella.ToString();


            if (esActualizacion == false)
            {
                try
                {
                    string insertar = $"INSERT INTO Tabla_Gaseosa " +
                                      "(tipo_botella, precio, cantidad, exceso_calorias, tipo_sabor) " +
                                      "VALUES (@tipo_botella, @precio, @cantidad, @exceso_calorias, @tipo_sabor)";
                    using (SqlCommand command = new SqlCommand(insertar, AccesoBaseDatos.Conectar()))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@exceso_calorias", excesoCalorias);
                        command.Parameters.AddWithValue("@tipo_sabor", tipoSaborStr);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Ingreso del dato exitoso!");
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error SQL: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    string actualizar = "UPDATE Tabla_Gaseosa SET tipo_botella = @tipo_botella, precio = @precio, cantidad = @cantidad, exceso_calorias = @exceso_calorias, tipo_sabor = @tipo_sabor WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(actualizar, AccesoBaseDatos.Conectar()))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@exceso_calorias", excesoCalorias);
                        cmd.Parameters.AddWithValue("@tipo_sabor", tipoSaborStr);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos actualizados!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la base datos: " + ex.Message);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
