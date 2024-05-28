namespace Interfaz.FormsGaseosas
{
    partial class FrmSprite
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
            checkRetornable = new CheckBox();
            txtCodigo = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(234, 140);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 16;
            label5.Text = "Retornable:";
            // 
            // checkRetornable
            // 
            checkRetornable.AutoSize = true;
            checkRetornable.Location = new Point(317, 141);
            checkRetornable.Name = "checkRetornable";
            checkRetornable.Size = new Size(15, 14);
            checkRetornable.TabIndex = 15;
            checkRetornable.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(234, 74);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(121, 23);
            txtCodigo.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 56);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 13;
            label4.Text = "Código de barra :";
            // 
            // FrmSprite
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 383);
            Controls.Add(label5);
            Controls.Add(checkRetornable);
            Controls.Add(txtCodigo);
            Controls.Add(label4);
            Name = "FrmSprite";
            Text = "FrmSprite";
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(txtCodigo, 0);
            Controls.SetChildIndex(checkRetornable, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cboBotella, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private CheckBox checkRetornable;
        private TextBox txtCodigo;
        private Label label4;
    }
}