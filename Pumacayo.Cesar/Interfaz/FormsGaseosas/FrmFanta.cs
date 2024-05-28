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
    public partial class FrmFanta : FrmGaseosa
    {
        private Fanta? miFanta;

        #region Propiedades
        public Fanta? MiFanta
        {
            get { return this.miFanta; }
        }
        #endregion
        public FrmFanta()
        {
            InitializeComponent();
            foreach (EtipoBotella tipoBotella in Enum.GetValues(typeof(EtipoBotella)))
            {
                this.cboBotella.Items.Add(tipoBotella);
            }
            this.cboBotella.SelectedItem = EtipoBotella.Plastico;
        }
        public FrmFanta(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtLitros.Text = ((Fanta)g).Litros.ToString();
            this.checkAzucar.Checked = ((Fanta)g).ExcesoAzucar;

        }
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);

                float litros = float.Parse(this.txtLitros.Text);
                bool excesoAzucar = this.checkAzucar.Checked;

                this.miFanta = new Fanta(tipoBotella, precio, cantidad, litros, excesoAzucar);

                base.btnAceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos numéricos tengan un formato válido.\n" + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
