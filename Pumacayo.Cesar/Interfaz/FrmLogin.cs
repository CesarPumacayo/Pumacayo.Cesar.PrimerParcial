using System.Text.Json;

namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private Usuario? usuario;

        public Usuario? UsuarioDelForm
        {
            get { return this.usuario; }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }
        public FrmLogin(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.usuario = this.Verificar();
            if(this.usuario != null)
            {
                this.LogUsuario(this.usuario);
            }
            this.DialogResult = DialogResult.OK;
    
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private Usuario? Verificar()
        {
            Usuario? resultado = null;

            string jsonPath = @"..\..\..\MOCK_DATA.json";

            if (File.Exists(jsonPath))
            {
                try
                {
                    var json_str = File.ReadAllText(jsonPath);
                    var opciones = new JsonSerializerOptions();
                    var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json_str, opciones);

                    if (usuarios != null)
                    {
                        resultado = usuarios.FirstOrDefault(user => user.correo == txtCorreo.Text && user.clave == txtClave.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Archivo de datos no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
        private void LogUsuario(Usuario usuario)
        {
            string logPath = @"..\..\..\usuarios.log";
            string logEntry = $"Fecha accedido: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - Nombre: {usuario.nombre} - Apellido: {usuario.apellido}\n";

            File.AppendAllText(logPath, logEntry);
        }
    }
}
