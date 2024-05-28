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
        public FrmSprite(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.txtCodigo.Text = ((Sprite)g).Codigo.ToString();
            this.checkRetornable.Checked = ((Sprite)g).EsRetornable;


        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);
                double codigo = double.Parse(this.txtCodigo.Text);
                bool esRetornable = this.checkRetornable.Checked;

                this.miSprite = new Sprite(tipoBotella, precio, cantidad, codigo, esRetornable);

                base.btnAceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos numéricos tengan un formato válido.\n" + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
