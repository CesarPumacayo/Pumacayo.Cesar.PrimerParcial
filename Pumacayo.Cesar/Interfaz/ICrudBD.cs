using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface ICrudBD
    {
        public void actualizarCrudBaseDatos();

        Task eliminarElementoBaseDatos(double precio);
    }
}
