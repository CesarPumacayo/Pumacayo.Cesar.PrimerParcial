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
            historialToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listVisor
            // 
            listVisor.FormattingEnabled = true;
            listVisor.ItemHeight = 15;
            listVisor.Location = new Point(49, 35);
            listVisor.Name = "listVisor";
            listVisor.Size = new Size(682, 409);
            listVisor.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, modificarToolStripMenuItem, eliminarToolStripMenuItem, ordenarToolStripMenuItem, historialToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
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
            // 
            // manaosToolStripMenuItem
            // 
            manaosToolStripMenuItem.Name = "manaosToolStripMenuItem";
            manaosToolStripMenuItem.Size = new Size(116, 22);
            manaosToolStripMenuItem.Text = "Manaos";
            // 
            // spriteToolStripMenuItem
            // 
            spriteToolStripMenuItem.Name = "spriteToolStripMenuItem";
            spriteToolStripMenuItem.Size = new Size(116, 22);
            spriteToolStripMenuItem.Text = "Sprite";
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(70, 20);
            modificarToolStripMenuItem.Text = "Modificar";
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(62, 20);
            eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(62, 20);
            ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // historialToolStripMenuItem
            // 
            historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            historialToolStripMenuItem.Size = new Size(113, 20);
            historialToolStripMenuItem.Text = " Historial sesiones";
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wallpaperflare_com_wallpaper__5_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(listVisor);
            Controls.Add(menuStrip1);
            Name = "FrmCRUD";
            Text = "FrmCRUD";
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
    }
}