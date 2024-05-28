namespace Interfaz
{
    partial class FrmCRUD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listVisor = new ListBox();
            menuStrip1 = new MenuStrip();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            fantaToolStripMenuItem = new ToolStripMenuItem();
            manaosToolStripMenuItem = new ToolStripMenuItem();
            spriteToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            ordenarToolStripMenuItem = new ToolStripMenuItem();
            precioToolStripMenuItem = new ToolStripMenuItem();
            ascendenteToolStripMenuItem1 = new ToolStripMenuItem();
            descendenteToolStripMenuItem1 = new ToolStripMenuItem();
            cantidadToolStripMenuItem = new ToolStripMenuItem();
            ascendenteToolStripMenuItem = new ToolStripMenuItem();
            descendenteToolStripMenuItem = new ToolStripMenuItem();
            historialToolStripMenuItem = new ToolStripMenuItem();
            btnAbrirArchivo = new Button();
            button1 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listVisor
            // 
            listVisor.FormattingEnabled = true;
            listVisor.ItemHeight = 15;
            listVisor.Location = new Point(31, 64);
            listVisor.Name = "listVisor";
            listVisor.Size = new Size(544, 514);
            listVisor.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, modificarToolStripMenuItem, eliminarToolStripMenuItem, ordenarToolStripMenuItem, historialToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1166, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fantaToolStripMenuItem, manaosToolStripMenuItem, spriteToolStripMenuItem });
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(61, 20);
            agregarToolStripMenuItem.Text = "Agregar";
            // 
            // fantaToolStripMenuItem
            // 
            fantaToolStripMenuItem.Name = "fantaToolStripMenuItem";
            fantaToolStripMenuItem.Size = new Size(116, 22);
            fantaToolStripMenuItem.Text = "Fanta";
            fantaToolStripMenuItem.Click += fantaToolStripMenuItem_Click;
            // 
            // manaosToolStripMenuItem
            // 
            manaosToolStripMenuItem.Name = "manaosToolStripMenuItem";
            manaosToolStripMenuItem.Size = new Size(116, 22);
            manaosToolStripMenuItem.Text = "Manaos";
            manaosToolStripMenuItem.Click += manaosToolStripMenuItem_Click;
            // 
            // spriteToolStripMenuItem
            // 
            spriteToolStripMenuItem.Name = "spriteToolStripMenuItem";
            spriteToolStripMenuItem.Size = new Size(116, 22);
            spriteToolStripMenuItem.Text = "Sprite";
            spriteToolStripMenuItem.Click += spriteToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(70, 20);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(62, 20);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { precioToolStripMenuItem, cantidadToolStripMenuItem });
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(62, 20);
            ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // precioToolStripMenuItem
            // 
            precioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendenteToolStripMenuItem1, descendenteToolStripMenuItem1 });
            precioToolStripMenuItem.Name = "precioToolStripMenuItem";
            precioToolStripMenuItem.Size = new Size(122, 22);
            precioToolStripMenuItem.Text = "Precio";
            // 
            // ascendenteToolStripMenuItem1
            // 
            ascendenteToolStripMenuItem1.Name = "ascendenteToolStripMenuItem1";
            ascendenteToolStripMenuItem1.Size = new Size(142, 22);
            ascendenteToolStripMenuItem1.Text = "Ascendente";
            ascendenteToolStripMenuItem1.Click += ascendentePrecio_Click;
            // 
            // descendenteToolStripMenuItem1
            // 
            descendenteToolStripMenuItem1.Name = "descendenteToolStripMenuItem1";
            descendenteToolStripMenuItem1.Size = new Size(142, 22);
            descendenteToolStripMenuItem1.Text = "Descendente";
            descendenteToolStripMenuItem1.Click += descendentePrecio_Click;
            // 
            // cantidadToolStripMenuItem
            // 
            cantidadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendenteToolStripMenuItem, descendenteToolStripMenuItem });
            cantidadToolStripMenuItem.Name = "cantidadToolStripMenuItem";
            cantidadToolStripMenuItem.Size = new Size(122, 22);
            cantidadToolStripMenuItem.Text = "Cantidad";
            // 
            // ascendenteToolStripMenuItem
            // 
            ascendenteToolStripMenuItem.Name = "ascendenteToolStripMenuItem";
            ascendenteToolStripMenuItem.Size = new Size(142, 22);
            ascendenteToolStripMenuItem.Text = "Ascendente";
            ascendenteToolStripMenuItem.Click += ascendenteCantidad_Click;
            // 
            // descendenteToolStripMenuItem
            // 
            descendenteToolStripMenuItem.Name = "descendenteToolStripMenuItem";
            descendenteToolStripMenuItem.Size = new Size(142, 22);
            descendenteToolStripMenuItem.Text = "Descendente";
            descendenteToolStripMenuItem.Click += descendenteCantidad_Click;
            // 
            // historialToolStripMenuItem
            // 
            historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            historialToolStripMenuItem.Size = new Size(113, 20);
            historialToolStripMenuItem.Text = " Historial sesiones";
            historialToolStripMenuItem.Click += historialToolStripMenuItem_Click;
            // 
            // btnAbrirArchivo
            // 
            btnAbrirArchivo.Location = new Point(1064, 529);
            btnAbrirArchivo.Name = "btnAbrirArchivo";
            btnAbrirArchivo.Size = new Size(75, 49);
            btnAbrirArchivo.TabIndex = 8;
            btnAbrirArchivo.Text = "Abrir";
            btnAbrirArchivo.UseVisualStyleBackColor = true;
            btnAbrirArchivo.Click += btnAbrirArchivo_Click;
            // 
            // button1
            // 
            button1.Location = new Point(624, 527);
            button1.Name = "button1";
            button1.Size = new Size(75, 51);
            button1.TabIndex = 7;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnGuardarArchivo_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 35);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 9;
            label1.Text = "Cant. max : 5";
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1166, 592);
            Controls.Add(label1);
            Controls.Add(btnAbrirArchivo);
            Controls.Add(button1);
            Controls.Add(listVisor);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmCRUD";
            Text = "FrmCRUD";
            FormClosing += FrmCRUD_Cerrar;
            Load += FrmCRUD_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listVisor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem fantaToolStripMenuItem;
        private ToolStripMenuItem manaosToolStripMenuItem;
        private ToolStripMenuItem spriteToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem ordenarToolStripMenuItem;
        private ToolStripMenuItem historialToolStripMenuItem;
        private Button btnAbrirArchivo;
        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem precioToolStripMenuItem;
        private ToolStripMenuItem ascendenteToolStripMenuItem1;
        private ToolStripMenuItem descendenteToolStripMenuItem1;
        private ToolStripMenuItem cantidadToolStripMenuItem;
        private ToolStripMenuItem ascendenteToolStripMenuItem;
        private ToolStripMenuItem descendenteToolStripMenuItem;
        private Label label1;
    }
}