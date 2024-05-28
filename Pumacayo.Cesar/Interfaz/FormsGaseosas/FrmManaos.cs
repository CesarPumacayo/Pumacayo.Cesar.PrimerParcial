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
        #region 
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
        public FrmManaos(Gaseosa g) : this()
        {
            this.txtPrecio.Text = g.Precio.ToString();
            this.txtCantidad.Text = g.Cantidad.ToString();
            this.cboBotella.SelectedItem = g.TipoBotella;
            this.cboSabor.SelectedItem = ((Manaos)g).TipoSabor;
            this.checkCalorias.Checked = ((Manaos)g).ExcesoCalorias;

        }
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EtipoBotella tipoBotella = (EtipoBotella)base.cboBotella.SelectedItem;
                int cantidad = int.Parse(base.txtCantidad.Text);
                double precio = double.Parse(base.txtPrecio.Text);

                EtipoSabor tipoSabor = (EtipoSabor)this.cboSabor.SelectedItem;
                bool excesoCalorias = this.checkCalorias.Checked;

                this.miManaos = new Manaos(tipoBotella, precio, cantidad, tipoSabor, excesoCalorias);

                base.btnAceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos numéricos tengan un formato válido.\n" + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
