using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Interfaz
{
    public class Usuario
    {
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? clave { get; set; }
        public string? correo { get; set; }
        public string? perfil { get; set; }

        [XmlElement(ElementName = "Tipo")]
        public string Tipo { get; set; }
        [XmlElement(ElementName = "Datos")]
        public Gaseosa Datos { get; set; }

    }
}
