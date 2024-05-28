namespace Interfaz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int cantidad_intentos = 0;

            //CREO UNA INSTANCIA DEL FORMULARIO DE INICIO
            FrmLogin frm = new FrmLogin();

            //INDICO LA POSICION EN LA PANTALLA
            frm.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                frm.ShowDialog();

                do
                {
                    if (frm.DialogResult == DialogResult.OK)
                    {

                        if (cantidad_intentos == 2 && frm.UsuarioDelForm == null)
                        {
                            MessageBox.Show("Cantidad de intentos superada!!!", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            break;
                        }
                        else if (frm.UsuarioDelForm == null)
                        {
                            MessageBox.Show("Error en usuario y/o clave!!!", "CREDENCIALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            frm.ShowDialog();
                        }
                    }

                    cantidad_intentos++;


                } while (cantidad_intentos < 3 && frm.DialogResult != DialogResult.Cancel);

                //INDICO LA POSICION EN LA PANTALLA
                if (frm.UsuarioDelForm != null)
                {

                    FrmCRUD frmAplicacion = new FrmCRUD(frm.UsuarioDelForm);
                    frmAplicacion.StartPosition = FormStartPosition.CenterScreen;


                    //INICIO LA APLICACION
                    Application.Run(frmAplicacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("La aplicación terminó.", "FIN DEL EJEMPLO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}