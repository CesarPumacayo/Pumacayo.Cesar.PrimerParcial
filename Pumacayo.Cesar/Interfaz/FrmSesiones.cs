using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class FrmSesiones : Form
    {
        public FrmSesiones()
        {
            InitializeComponent();
            CargarLog();
        }
        private void CargarLog()
        {
            string logPath = @"..\..\..\usuarios.log";

            if(File.Exists(logPath)) 
            {
                string[] lineaSesiones = File.ReadAllLines(logPath);
                foreach (string lineas in  lineaSesiones) 
                {
                    listBox1.Items.Add(lineas); 
                }
            }
            else
            {
                MessageBox.Show("El archivo de log no existe");
            }
        }
    }
}
