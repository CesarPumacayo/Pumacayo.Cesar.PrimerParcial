using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Entidades;
using Interfaz.FormsGaseosas;
using Microsoft.VisualBasic.Logging;

namespace Interfaz
{
    public partial class FrmCRUD : Form
    {
        private InventarioGaseosas<Gaseosa> fabrica;


        public FrmCRUD()
        {
            InitializeComponent();
            this.fabrica = new InventarioGaseosas<Gaseosa>(5);


        }
        /// <summary>
        /// Constructor del formulario FrmCRUD que inicializa la interfaz de usuario
        /// y configura las opciones del menú según el perfil del usuario.
        /// </summary>
        /// <param name="usuario">Instancia de la clase Usuario segun la condicion de los distintos perfiles de cada usuario.</param>
        public FrmCRUD(Usuario usuario) : this()
        {
            MessageBox.Show($"¡Bienvenido {usuario.nombre}!", "Login exitoso.");
            this.Text = $"Bienvenido, { usuario.nombre} {usuario.apellido}                                 Fecha actual: " + DateTime.Today.ToString("dd/MM/yyyy");
        
            if(usuario.perfil == "administrador")
            {
  
            }
            else if(usuario.perfil == "supervisor")
            {
                eliminarToolStripMenuItem.Enabled = false;
            }
            else if(usuario.perfil == "vendedor")
            {
                eliminarToolStripMenuItem.Enabled = false;
                modificarToolStripMenuItem.Enabled = false; 
                agregarToolStripMenuItem.Enabled = false;
            }
        
        }

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void FrmCRUD_Cerrar(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Quieres cerrar la sesion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void ActualizarVisor()
        {
            this.listVisor.Items.Clear();
            if (fabrica.ListaGaseosas != null)
            {
                foreach (Gaseosa gaseosa in fabrica.ListaGaseosas)
                {
                    this.listVisor.Items.Add(gaseosa);
                }
            }
            else
            {
                MessageBox.Show("La lista de gaseosas es null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fantaToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            FrmFanta frmFanta = new FrmFanta();
            frmFanta.ShowDialog();
            if (frmFanta.DialogResult == DialogResult.OK)
            {
                Gaseosa? nuevaGaseosa = frmFanta.MiFanta;

                if (nuevaGaseosa != null)
                {
                    if (nuevaGaseosa == this.fabrica)
                    {
                        MessageBox.Show("La gaseosa ya existe en la lista.");
                    }
                    else
                    {
                        this.fabrica += nuevaGaseosa;
                        this.ActualizarVisor();
                    }
                }
                else
                {
                    MessageBox.Show("Error: La gaseosa no fue creada correctamente.");
                }
            }
        }

        private void manaosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManaos frmManaos = new FrmManaos();
            frmManaos.ShowDialog();
            if (frmManaos.DialogResult == DialogResult.OK)
            {
                Gaseosa? nuevaGaseosa = frmManaos.MiManaos;

                if (nuevaGaseosa == this.fabrica)
                {
                    MessageBox.Show("La gaseosa ya existe en la lista.");
                }
                else
                {
                    this.fabrica += nuevaGaseosa;
                    this.ActualizarVisor();


                }
            }
        }

        private void spriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSprite frmSprite = new FrmSprite();
            frmSprite.ShowDialog();
            if (frmSprite.DialogResult == DialogResult.OK)
            {
                Gaseosa? nuevaGaseosa = frmSprite.MiSprite;

                if (nuevaGaseosa != null)
                {
                    if (nuevaGaseosa == this.fabrica)
                    {
                        MessageBox.Show("La gaseosa ya existe en la lista.");
                    }
                    else
                    {
                        this.fabrica += nuevaGaseosa;
                        this.ActualizarVisor();
                    }
                }
                else
                {
                    MessageBox.Show("Error: La gaseosa no fue creada correctamente.");
                }
            }

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.listVisor.SelectedIndex;
            if (i == -1 || this.fabrica.ListaGaseosas == null)
            {
                return;
            }
            Gaseosa gaseosaSeleccionada = this.fabrica.ListaGaseosas[i];

            if (gaseosaSeleccionada is Sprite)
            {
                FrmSprite frmSprite = new FrmSprite((Sprite)gaseosaSeleccionada);
                frmSprite.ShowDialog();

                if (frmSprite.DialogResult == DialogResult.OK)
                {
                    if (frmSprite.MiSprite != null)
                    {
                        this.fabrica.ListaGaseosas[i] = frmSprite.MiSprite;
                    }
                    this.ActualizarVisor();
                }
            }
            else if (gaseosaSeleccionada is Manaos)
            {
                FrmManaos frmManaos = new FrmManaos((Manaos)gaseosaSeleccionada);
                frmManaos.ShowDialog();

                if (frmManaos.DialogResult == DialogResult.OK)
                {
                    if (frmManaos.MiManaos != null)
                    {
                        this.fabrica.ListaGaseosas[i] = frmManaos.MiManaos;
                    }
                    this.ActualizarVisor();
                }
            }
            else if (gaseosaSeleccionada is Fanta)
            {
                FrmFanta frmFanta = new FrmFanta((Fanta)gaseosaSeleccionada);
                frmFanta.ShowDialog();

                if (frmFanta.DialogResult == DialogResult.OK)
                {
                    if (frmFanta.MiFanta != null)
                    {
                        this.fabrica.ListaGaseosas[i] = frmFanta.MiFanta;
                    }
                    this.ActualizarVisor();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.listVisor.SelectedIndex;
            if (index == -1 || this.fabrica.ListaGaseosas == null)
            {
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar esta gaseosa?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (index < fabrica.ListaGaseosas.Count)
                {
                    Gaseosa g = this.fabrica.ListaGaseosas[index];
                    this.fabrica -= g;
                    this.ActualizarVisor();
                }
            }

        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo XML (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DeserializeCollection(openFileDialog.FileName);
                this.ActualizarVisor();
            }
        }

        private void btnGuardarArchivo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo XML (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeCollection(saveFileDialog.FileName);
            }

        }

        private void ascendentePrecio_Click(object sender, EventArgs e)
        {
            if (fabrica.ListaGaseosas != null)
            {
                this.fabrica.ListaGaseosas.Sort(InventarioGaseosas<Gaseosa>.OrdenarPorPrecioAscendente);
                this.ActualizarVisor();
            }
        }

        private void descendentePrecio_Click(object sender, EventArgs e)
        {
            if (fabrica.ListaGaseosas != null)
            {
                this.fabrica.ListaGaseosas.Sort(InventarioGaseosas<Gaseosa>.OrdenarPorPrecioDescendente);
                this.ActualizarVisor();
            }
        }

        private void ascendenteCantidad_Click(object sender, EventArgs e)
        {
            if (fabrica.ListaGaseosas != null)
            {
                this.fabrica.ListaGaseosas.Sort(InventarioGaseosas<Gaseosa>.OrdenarPorCantidadAscendente);
                this.ActualizarVisor();
            }
        }

        private void descendenteCantidad_Click(object sender, EventArgs e)
        {
            if (fabrica.ListaGaseosas != null)
            {
                this.fabrica.ListaGaseosas.Sort(InventarioGaseosas<Gaseosa>.OrdenarPorCantidadDescendente);
                this.ActualizarVisor();
            }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSesiones frmSesiones = new FrmSesiones();
            frmSesiones.MdiParent = this;
            frmSesiones.Show();
        }



        private void SerializeCollection(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InventarioGaseosas<Gaseosa>));
                using (FileStream stream = File.Create(filePath))
                {
                    serializer.Serialize(stream, fabrica);
                }
                MessageBox.Show("La colección se ha serializado correctamente.", "Serialización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al serializar la colección: " + ex.Message, "Error de Serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeserializeCollection(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InventarioGaseosas<Gaseosa>));
                using (FileStream stream = File.OpenRead(filePath))
                {
                    var deserializedObject = serializer.Deserialize(stream) as InventarioGaseosas<Gaseosa>;

                    if (deserializedObject != null)
                    {
                        fabrica = deserializedObject;
                    }
                }
                MessageBox.Show("La colección se ha deserializado correctamente.", "Deserialización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deserializar la colección: " + ex.Message, "Error de Deserialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



















    }
}
