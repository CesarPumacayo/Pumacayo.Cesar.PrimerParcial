using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fanta : Gaseosa
    {
        private bool excesoAzucar;
        private float litros;
        #region Propiedades
        /// <summary>
        /// Obtiene o establece el exceso de azucar de Fanta
        /// </summary>
        public bool ExcesoAzucar
        {
            get { return this.excesoAzucar; }
            set { this.excesoAzucar = value; }
        }
        /// <summary>
        /// Obtiene o establece los litros de Fanta
        /// </summary>
        public float Litros
        {
            get { return this.litros; }
            set { this.litros = value; }
        }
        #endregion


        #region Constructores 
        /// <summary>
        /// Inicializa una nueva instancia por defecto de la clase Fanta.
        /// </summary>
        public Fanta()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Fanta con el tipo de botella, precio, cantidad, litros y exceso de azúcar especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Fanta.</param>
        /// <param name="precio">El precio de la Fanta.</param>
        /// <param name="cantidad">La cantidad de Fanta.</param>
        /// <param name="litros">La cantidad de litros de Fanta.</param>
        /// <param name="excesoAzucar">Indica si la Fanta tiene exceso de azúcar.</param>
        public Fanta(EtipoBotella tipoBotella, double precio, int cantidad, bool excesoAzucar) : base(tipoBotella, precio, cantidad)
        {
            this.ExcesoAzucar = excesoAzucar;

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Fanta con el tipo de botella, precio, cantidad, litros y exceso de azúcar especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Fanta.</param>
        /// <param name="precio">El precio de la Fanta.</param>
        /// <param name="cantidad">La cantidad de Fanta.</param>
        /// <param name="litros">La cantidad de litros de Fanta.</param>
        /// <param name="excesoAzucar">Indica si la Fanta tiene exceso de azúcar.</param>
        public Fanta(EtipoBotella tipoBotella, double precio, int cantidad, float litros, bool excesoAzucar) : this(tipoBotella, precio, cantidad, excesoAzucar)
        {
            this.Litros = litros;
        }

        #endregion

        #region Metodo abstracto
        /// <summary>
        /// Devuelve una cadena que representa la marca de la Fanta.
        /// </summary>
        /// <returns>Una cadena que contiene la marca "Fanta".</returns>
        public override string MostrarMarca()
        {
            return "Fanta";
        }
        #endregion


        #region Metodo 
        /// <summary>
        /// Método que muestra un mensaje indicando que se está bebiendo una Fanta.
        /// </summary>
        public override void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa de la marca {MostrarMarca()}");
        }
        #endregion

        #region Metodo Polimorfismo
        /// <summary>
        /// Devuelve una cadena que representa la instancia actual de la clase Fanta.
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Fanta.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("- Exceso en azucar: " + this.ExcesoAzucar);
            sb.Append("- Litros: " + this.Litros.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Determina si el objeto especificado es igual a la instancia actual de la clase Fanta.
        /// </summary>
        /// <param name="obj">El objeto a comparar con la instancia actual.</param>
        /// <returns>true si el objeto especificado es igual a la instancia actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Fanta fanta = (Fanta)obj;
            return base.Equals(obj) && ExcesoAzucar == fanta.ExcesoAzucar && Litros == fanta.Litros;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
