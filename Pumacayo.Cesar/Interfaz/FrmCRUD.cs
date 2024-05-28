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
using Entidades;
using Interfaz.FormsGaseosas;

namespace Interfaz
{
    public partial class FrmCRUD : Form
    {
        private InventarioGaseosas<Gaseosa> fabrica;


        public FrmCRUD()
        {
            InitializeComponent();
            this.fabrica = new InventarioGaseosas<Gaseosa>(5);//cantidad maxima

        }
        public FrmCRUD(Usuario usuario) : this()
        {
            MessageBox.Show($"Bienvenido {usuario.nombre}");
            this.Text = "Bienvenido, " + usuario.nombre + "                    Fecha actual: " + DateTime.Today.ToString("dd/MM/yyyy");
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
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Archivos JSON(*.json)|*.json";

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string path = abrirArchivo.FileName;

                try
                {
                    string jsonString = File.ReadAllText(path);

                    var jsonSerializerOptions = new JsonSerializerOptions
                    {
                        Converters = { new GaseosaConverter() }
                    };

                    var deserializedFabrica = JsonSerializer.Deserialize<InventarioGaseosas<Gaseosa>>(jsonString, jsonSerializerOptions);

                    if (deserializedFabrica != null)
                    {
                        this.fabrica = deserializedFabrica;
                        this.ActualizarVisor();
                        MessageBox.Show("Archivo cargado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El archivo JSON no es válido o está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardarArchivo_Click(object sender, EventArgs e)
        {
            SaveFileDialog archivoGuardado = new SaveFileDialog();
            archivoGuardado.Filter = "Archivos JSON(*.json)|*.json";

            if (archivoGuardado.ShowDialog() == DialogResult.OK)
            {
                string path = archivoGuardado.FileName;

                try
                {
                    var jsonSerializerOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Converters = { new GaseosaConverter() }
                    };

                    string jsonString = JsonSerializer.Serialize(this.fabrica, jsonSerializerOptions);

                    File.WriteAllText(path, jsonString);

                    MessageBox.Show("Archivo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if(fabrica.ListaGaseosas != null)
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
    }
}
