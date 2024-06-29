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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Interfaz.FormsGaseosas
{
    /// <summary>
    /// Clase derivada de FrmGaseosa
    /// </summary>
    public partial class FrmFanta : FrmGaseosa
    {
        private Fanta? miFanta;
        public Gaseosa? gaseosas;
        int id;
        private bool esActualizacion = false;
        private int cantidadGaseosasRegistradas;
        #region Propiedades
        /// <summary>
        /// Obtiene la instancia de la clase Fanta asociada al formulario.
        /// </summary>
        public Fanta? MiFanta
        {
            get { return this.miFanta; }
        }
        #endregion


        /// <summary>
        /// FrmFanta inicializa una nueva instancia , agrega lista de tipo de botella al combobox y deja un valor predeterminado 
        /// </summary>
        public FrmFanta()
        {

            InitializeComponent();
            foreach (EtipoBotella tipoBotella in Enum.GetValues(typeof(EtipoBotella)))
            {
                this.cboBotella.Items.Add(tipoBotella);
            }
            this.cboBotella.SelectedItem = EtipoBotella.Plastico;
            cantidadGaseosasRegistradas = ObtenerCantidadGaseosasRegistradas();
        }

        /// <summary>
        /// Inicializa una nueva instancia con datos del objeto Gaseosa
        /// </summary>
        /// <param name="g">Datos de la gaseosa que muestra el formulario</param>
        public FrmFanta(Gaseosa g) : this()
        {
            esActualizacion = true;
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtLitros.Text = ((Fanta)g).Litros.ToString();
            this.checkAzucar.Checked = ((Fanta)g).ExcesoAzucar;


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
        /// Manejador de eventos heredada con el click del boton "Aceptar" y carga los datos ingresados al objeto Fanta.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cantidadGaseosasRegistradas >= 5)
            {
                MessageBox.Show("No se pueden agregar más gaseosas, se ha alcanzado el límite máximo." +
                                "\n\nActualice la base de datos.",
                                "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            agregarFanta();

            try
            {
                if (string.IsNullOrEmpty(this.txtPrecio.Text) || string.IsNullOrEmpty(this.txtCantidad.Text) || string.IsNullOrEmpty(this.txtLitros.Text))
                {
                    throw new CamposNullMyExpection();
                }


                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);

                float litros = float.Parse(this.txtLitros.Text);
                bool excesoAzucar = this.checkAzucar.Checked;

                if (precio == 0 || cantidad == 0 || litros == 0)
                {


                    throw new CamposZeroMyExpection("Ingrese un número distinto de cero.\n¡Tenga cuidado!");

                }
                this.miFanta = new Fanta(tipoBotella, precio, cantidad, litros, excesoAzucar);

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

        /// <summary>
        /// Método para agregar una gaseosa tipo Fanta a la base de datos o actualizarla si ya existe.
        /// </summary>
        public void agregarFanta()
        {
            EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
            int cantidad = int.Parse(base.txtCantidad.Text);
            double precio = double.Parse(base.txtPrecio.Text);

            float litros = float.Parse(this.txtLitros.Text);
            bool excesoAzucar = this.checkAzucar.Checked;

            this.gaseosas = new Fanta(tipoBotella, precio, cantidad, litros, excesoAzucar);

            string tipoBotellaStr = tipoBotella.ToString();

            if (ExisteGaseosaEnBaseDeDatosFanta(tipoBotellaStr, precio, cantidad, litros, excesoAzucar))
            {
                MessageBox.Show("La gaseosa ya existe en la base de datos.", "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (esActualizacion == false)
            {
                try
                {
                    string insertar = $"INSERT INTO Tabla_Gaseosa " +
                                 "(tipo_botella, precio, cantidad, exceso_azucar, litros) " +
                                 "VALUES (@tipo_botella, @precio, @cantidad, @exceso_azucar, @litros)";
                    using (SqlCommand command = new SqlCommand(insertar, AccesoBaseDatos.Conectar()))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@exceso_azucar", excesoAzucar);
                        command.Parameters.AddWithValue("@litros", litros);

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
                    using (var connection = AccesoBaseDatos.Conectar())
                    {
                        string actualizar = "UPDATE Tabla_Gaseosa SET tipo_botella = @tipo_botella, precio = @precio, cantidad = @cantidad, exceso_azucar = @exceso_azucar, litros = @litros WHERE ID = @id";
                        var cmd = new SqlCommand(actualizar, connection);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@exceso_azucar", excesoAzucar);
                        cmd.Parameters.AddWithValue("@litros", litros);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Actualización del dato exitoso!");
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


    }
}
