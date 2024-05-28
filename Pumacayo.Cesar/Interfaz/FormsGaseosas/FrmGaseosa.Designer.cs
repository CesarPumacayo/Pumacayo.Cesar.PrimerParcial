namespace Interfaz.FormsGaseosas
{
    partial class FrmGaseosa
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            cboBotella = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(49, 283);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 50);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(251, 283);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(100, 50);
            btnAceptar.TabIndex = 15;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(49, 74);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(121, 23);
            txtPrecio.TabIndex = 14;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(49, 137);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(121, 23);
            txtCantidad.TabIndex = 13;
            // 
            // cboBotella
            // 
            cboBotella.FormattingEnabled = true;
            cboBotella.Location = new Point(49, 209);
            cboBotella.Name = "cboBotella";
            cboBotella.Size = new Size(121, 23);
            cboBotella.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 119);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 11;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 10;
            label2.Text = "Precio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 175);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 9;
            label1.Text = "Botella:";
            // 
            // FrmGaseosa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtPrecio);
            Controls.Add(txtCantidad);
            Controls.Add(cboBotella);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmGaseosa";
            Text = "FrmGaseosa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button btnCancelar;
        protected Button btnAceptar;
        protected TextBox txtPrecio;
        protected TextBox txtCantidad;
        protected ComboBox cboBotella;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}