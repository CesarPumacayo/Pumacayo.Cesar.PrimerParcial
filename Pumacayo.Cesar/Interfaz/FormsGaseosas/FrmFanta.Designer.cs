namespace Interfaz.FormsGaseosas
{
    partial class FrmFanta
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
            label5 = new Label();
            checkAzucar = new CheckBox();
            txtLitros = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 158);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 20;
            label5.Text = "Exceso de azúcar:";
            // 
            // checkAzucar
            // 
            checkAzucar.AutoSize = true;
            checkAzucar.Location = new Point(538, 158);
            checkAzucar.Name = "checkAzucar";
            checkAzucar.Size = new Size(15, 14);
            checkAzucar.TabIndex = 19;
            checkAzucar.UseVisualStyleBackColor = true;
            // 
            // txtLitros
            // 
            txtLitros.Location = new Point(432, 92);
            txtLitros.Name = "txtLitros";
            txtLitros.Size = new Size(121, 23);
            txtLitros.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(432, 74);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 17;
            label4.Text = "Litros";
            // 
            // FrmFanta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(checkAzucar);
            Controls.Add(txtLitros);
            Controls.Add(label4);
            Name = "FrmFanta";
            Text = "FrmFanta";
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(txtLitros, 0);
            Controls.SetChildIndex(checkAzucar, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cboBotella, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private CheckBox checkAzucar;
        private TextBox txtLitros;
        private Label label4;
    }
}