namespace Interfaz
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalir = new Button();
            btnAceptar = new Button();
            labelContraseña = new Label();
            txtClave = new TextBox();
            txtCorreo = new TextBox();
            labelCorreo = new Label();
            labelTitulo = new Label();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(169, 277);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(151, 52);
            btnSalir.TabIndex = 21;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ActiveCaption;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(435, 277);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(151, 52);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // labelContraseña
            // 
            labelContraseña.AutoSize = true;
            labelContraseña.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelContraseña.Location = new Point(169, 209);
            labelContraseña.Name = "labelContraseña";
            labelContraseña.Size = new Size(66, 15);
            labelContraseña.TabIndex = 19;
            labelContraseña.Text = "Contraseña";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(169, 238);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese contraseña...";
            txtClave.Size = new Size(417, 23);
            txtClave.TabIndex = 18;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(169, 168);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese correo....";
            txtCorreo.Size = new Size(417, 23);
            txtCorreo.TabIndex = 17;
            // 
            // labelCorreo
            // 
            labelCorreo.AutoSize = true;
            labelCorreo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelCorreo.Location = new Point(169, 141);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(42, 15);
            labelCorreo.TabIndex = 16;
            labelCorreo.Text = "Correo";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BackColor = Color.Transparent;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitulo.ForeColor = SystemColors.ControlLightLight;
            labelTitulo.Location = new Point(345, 102);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(87, 32);
            labelTitulo.TabIndex = 15;
            labelTitulo.Text = "LOGIN";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.image_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(btnAceptar);
            Controls.Add(labelContraseña);
            Controls.Add(txtClave);
            Controls.Add(txtCorreo);
            Controls.Add(labelCorreo);
            Controls.Add(labelTitulo);
            DoubleBuffered = true;
            Name = "FrmLogin";
            Text = "Inicio sesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnAceptar;
        private Label labelContraseña;
        private TextBox txtClave;
        private TextBox txtCorreo;
        private Label labelCorreo;
        private Label labelTitulo;
    }
}
