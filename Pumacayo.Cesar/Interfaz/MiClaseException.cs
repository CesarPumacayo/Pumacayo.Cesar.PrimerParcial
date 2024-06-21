using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public class MiClaseException : Exception
    {
        public MiClaseException()
            :base("Mensaje de error")
        {
        }

        public MiClaseException(string mensaje)
            :base(mensaje) 
        {
            
        }
    }
}
