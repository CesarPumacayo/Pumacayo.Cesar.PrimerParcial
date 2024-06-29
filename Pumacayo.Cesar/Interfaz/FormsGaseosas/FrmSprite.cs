using Entidades;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Interfaz.FormsGaseosas
{
    public partial class FrmSprite : FrmGaseosa
    {
        private Sprite? miSprite;
        private int id;
        private bool esActualizacion = false;
        private int cantidadGaseosasRegistradas;

        #region Propiedades
        /// <summary>
        /// Obtiene (Lectura) la instancia de la clase Sprite asociada al formulario.
        /// </summary>
        public Sprite? MiSprite
        {
            get { return this.miSprite; }
        }
        #endregion

        public FrmSprite()
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
        public FrmSprite(Gaseosa g) : this()
        {
            esActualizacion = true;
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtCodigo.Text = ((Sprite)g).Codigo.ToString();
            this.checkRetornable.Checked = ((Sprite)g).EsRetornable;
            try
            {
                using (SqlConnection connection = AccesoBaseDatos.Conectar())
                {
                    string consulta = "SELECT ID FROM Tabla_Gaseosa WHERE precio = @precio AND cantidad = @cantidad AND tipo_botella = @tipo_botella";
                    SqlCommand cmd2 = new SqlCommand(consulta, connection);
                    cmd2.Parameters.AddWithValue("@precio", g.Precio);
                    cmd2.Parameters.AddWithValue("@cantidad", g.Cantidad);
                    cmd2.Parameters.AddWithValue("@tipo_botella", g.TipoBotella.ToString());

                    id = (int)cmd2.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Manejador de eventos heredada con el click del boton "Aceptar" y carga los datos ingresados al objeto Sprite.
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
            agregarSprite();
            try
            {
                if (string.IsNullOrEmpty(this.txtPrecio.Text) || string.IsNullOrEmpty(this.txtCantidad.Text) || string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    throw new CamposNullMyExpection();
                }
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);
                float codigo = float.Parse(this.txtCodigo.Text); // Convertir a float
                bool esRetornable = this.checkRetornable.Checked;

                if (precio == 0 || cantidad == 0 || codigo == 0)
                {
                    throw new CamposZeroMyExpection("Ingrese un número distinto de cero.\n¡Tenga cuidado!");
                }
                this.miSprite = new Sprite(tipoBotella, precio, cantidad, codigo, esRetornable);

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

        public void agregarSprite()
        {
            EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
            int cantidad = int.Parse(base.txtCantidad.Text);
            double precio = double.Parse(base.txtPrecio.Text);
            float codigo = float.Parse(this.txtCodigo.Text); // Convertir a float
            bool esRetornable = this.checkRetornable.Checked;

            this.miSprite = new Sprite(tipoBotella, precio, cantidad, codigo, esRetornable);

            string tipoBotellaStr = tipoBotella.ToString();

            if (ExisteGaseosaEnBaseDeDatoSprite(tipoBotellaStr, precio, cantidad, codigo, esRetornable))
            {
                MessageBox.Show("La gaseosa ya existe en la base de datos.", "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (esActualizacion == false)
            {
                try
                {
                    using (SqlConnection connection = AccesoBaseDatos.Conectar())
                    {
                        string insertar = "INSERT INTO Tabla_Gaseosa (tipo_botella, precio, cantidad, retornable, codigo) VALUES (@tipo_botella, @precio, @cantidad, @retornable, @codigo)";
                        using (SqlCommand command = new SqlCommand(insertar, connection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                            command.Parameters.AddWithValue("@precio", precio);
                            command.Parameters.AddWithValue("@cantidad", cantidad);
                            command.Parameters.AddWithValue("@retornable", esRetornable);
                            command.Parameters.AddWithValue("@codigo", codigo);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Ingreso del dato exitoso!");
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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
                    using (SqlConnection connection = AccesoBaseDatos.Conectar())
                    {
                        string actualizar = "UPDATE Tabla_Gaseosa SET tipo_botella = @tipo_botella, precio = @precio, cantidad = @cantidad, retornable = @retornable, codigo = @codigo WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(actualizar, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@tipo_botella", tipoBotellaStr);
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@retornable", esRetornable);
                            cmd.Parameters.AddWithValue("@codigo", codigo);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Datos actualizados!");
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la base datos: " + ex.Message);
                }
            }
        }
    }
}
