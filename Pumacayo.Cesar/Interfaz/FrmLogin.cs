using System.Text.Json;

namespace Interfaz
{
    /// <summary>
    /// Clase FrmLogin que es una ventana de inicio de sesion
    /// </summary>
    public partial class FrmLogin : Form
    {

        private Usuario? usuario;

        /// <summary>
        /// Propiedad que devuelve el usuario que ha iniciado sesión en el formulario.
        /// </summary>
        public Usuario? UsuarioDelForm
        {
            get { return this.usuario; }
        }
        /// <summary>
        /// FrmLogin inicializa una nueva instancia
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }


        /// <summary>
        /// El metodo maneja el evento de hacer click en el botón "Aceptar". Llama a un método que verifica el usuario y registra su información si la verificación es exitosa.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento</param>
        /// <param name="e">los datos del evento de click</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.usuario = this.Verificar();
            if(this.usuario != null)
            {
                this.LogUsuario(this.usuario);
            }
            this.DialogResult = DialogResult.OK;
    
        }
        /// <summary>
        /// El metodo maneja el evento de hacer click en el botón "Cancelar" del inicio de sesion.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento</param>
        /// <param name="e">los datos del evento de click</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        /// <summary>
        /// El método "Verificar" comprueba si las credenciales del usuario ingresadas (clave y correo) coinciden con algún usuario en el archivo especificado por jsonPath (ruta de MOCK_DATA.json).
        /// El archivo JSON se deserializa en una lista de objetos Usuario.
        /// </summary>
        /// <returns>resultado: El objeto Usuario si se encuentra una coincidencia; de lo contrario, null.</returns>
        public Usuario? Verificar()
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

        /// <summary>
        /// Registra la información del usuario en el archivo "usuarios.log", incluyendo la fecha (año - mes - dia - hora - segundos), el nombre y apellido del usuario que inicio sesion.
        /// </summary>
        /// <param name="usuario">El objeto Usuario cuya información se va a registrar.</param>
        private void LogUsuario(Usuario usuario)
        {
            string logPath = @"..\..\..\usuarios.log";
            string logEntry = $"Fecha accedido: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - Nombre: {usuario.nombre} - Apellido: {usuario.apellido}\n";

            File.AppendAllText(logPath, logEntry);
        }
    }
}
