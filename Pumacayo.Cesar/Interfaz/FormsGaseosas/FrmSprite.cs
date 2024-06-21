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
    public partial class FrmSprite : FrmGaseosa
    {
        private Sprite? miSprite;

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

        }
        /// <summary>
        /// Inicializa una nueva instancia con datos del objeto Gaseosa
        /// </summary>
        /// <param name="g">Datos de la gaseosa que muestra el formulario</param>
        public FrmSprite(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtCodigo.Text = ((Sprite)g).Codigo.ToString();
            this.checkRetornable.Checked = ((Sprite)g).EsRetornable;


        }
        /// <summary>
        /// Manejador de eventos heredada con el click del boton "Aceptar" y carga los datos ingresados al objeto Sprite.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtPrecio.Text) || string.IsNullOrEmpty(this.txtCantidad.Text) || string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    throw new CamposNullMyExpection();
                }
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);
                double codigo = double.Parse(this.txtCodigo.Text);
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
        }
    }
}
