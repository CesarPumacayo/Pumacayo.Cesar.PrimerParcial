namespace Interfaz.FormsGaseosas
{
    partial class FrmManaos
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
            cboSabor = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            checkCalorias = new CheckBox();
            SuspendLayout();
            // 
            // cboSabor
            // 
            cboSabor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSabor.FormattingEnabled = true;
            cboSabor.Location = new Point(223, 74);
            cboSabor.Name = "cboSabor";
            cboSabor.Size = new Size(121, 23);
            cboSabor.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 56);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 23;
            label4.Text = "Sabor: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(223, 137);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 22;
            label5.Text = "Exceso de calorias:";
            // 
            // checkCalorias
            // 
            checkCalorias.AutoSize = true;
            checkCalorias.Location = new Point(334, 137);
            checkCalorias.Name = "checkCalorias";
            checkCalorias.Size = new Size(15, 14);
            checkCalorias.TabIndex = 21;
            checkCalorias.UseVisualStyleBackColor = true;
            // 
            // FrmManaos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 384);
            Controls.Add(cboSabor);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(checkCalorias);
            Name = "FrmManaos";
            Text = "FrmManaos";
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(checkCalorias, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(cboSabor, 0);
            Controls.SetChildIndex(cboBotella, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSabor;
        private Label label4;
        private Label label5;
        private CheckBox checkCalorias;
    }
}