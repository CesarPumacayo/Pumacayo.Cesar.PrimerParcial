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


namespace Interfaz.FormsGaseosas
{
    /// <summary>
    /// Clase derivada de FrmGaseosa
    /// </summary>
    public partial class FrmFanta : FrmGaseosa
    {
        private Fanta? miFanta;

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
        }

        /// <summary>
        /// Inicializa una nueva instancia con datos del objeto Gaseosa
        /// </summary>
        /// <param name="g">Datos de la gaseosa que muestra el formulario</param>
        public FrmFanta(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtLitros.Text = ((Fanta)g).Litros.ToString();
            this.checkAzucar.Checked = ((Fanta)g).ExcesoAzucar;

        }
        /// <summary>
        /// Manejador de eventos heredada con el click del boton "Aceptar" y carga los datos ingresados al objeto Fanta.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {

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
        }

    }
}
