using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CamposNullMyExpection : Exception
    {
        public CamposNullMyExpection() : base("Hay campos vacios.") { }

    }
    public class RegistroNoGuardadoException : Exception
    {
        public RegistroNoGuardadoException() : base() { }
        public RegistroNoGuardadoException(string message) : base(message) { }
        public RegistroNoGuardadoException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class CamposZeroMyExpection: Exception
    {
        public CamposZeroMyExpection() : base("Error en el campo.") { }

        public CamposZeroMyExpection(string mensaje) : base(mensaje) { }

        public CamposZeroMyExpection(string mensaje, Exception? innerException) : base(mensaje, innerException) { }
    }
}
