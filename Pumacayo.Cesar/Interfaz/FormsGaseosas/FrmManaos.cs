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
    public partial class FrmManaos : FrmGaseosa
    {
        private Manaos? miManaos;

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
        }

        /// <summary>
        /// Inicializa una nueva instancia con datos del objeto Gaseosa
        /// </summary>
        /// <param name="g">Datos de la gaseosa que muestra el formulario</param>
        public FrmManaos(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.cboSabor.SelectedItem = ((Manaos)g).TipoSabor;
            this.checkCalorias.Checked = ((Manaos)g).ExcesoCalorias;

        }
        /// <summary>
        /// El metodo maneja los eventos heredadas con el click del boton "Aceptar" y carga los datos ingresados al objeto Sprite.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
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
