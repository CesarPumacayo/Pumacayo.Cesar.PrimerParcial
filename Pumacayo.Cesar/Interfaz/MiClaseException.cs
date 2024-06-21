using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public class CamposNullMyExpection : Exception
    {
        public CamposNullMyExpection() : base("Hay campos vacios.") { }

    }

    public class CamposZeroMyExpection: Exception
    {
        public CamposZeroMyExpection() : base("Error en el campo.") { }

        public CamposZeroMyExpection(string mensaje) : base(mensaje) { }

        public CamposZeroMyExpection(string mensaje, Exception? innerException) : base(mensaje, innerException) { }
    }
}
