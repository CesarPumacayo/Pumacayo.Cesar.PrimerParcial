using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Manaos (derivada) de Gaseosa (Clase base)
    /// </summary>
    public class Manaos : Gaseosa
    {
        private EtipoSabor tipoSabor;
        private bool excesoCalorias;

        #region Propiedades
        /// <summary>
        /// Obtiene o establece el tipo de sabor de la Manaos.
        /// </summary>
        public EtipoSabor TipoSabor
        {
            get { return this.tipoSabor; }
            set { this.tipoSabor = value; }

        }
        /// <summary>
        /// Obtiene o establece si la Manaos tiene exceso de calorías.
        /// </summary>
        public bool ExcesoCalorias
        {
            get { return this.excesoCalorias; }
            set { this.excesoCalorias = value; }
        }
        #endregion


        #region Constructores Sobrecargados
        public Manaos()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Manaos con el tipo de botella, precio, cantidad y exceso de calorías especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Manaos.</param>
        /// <param name="precio">El precio de la Manaos.</param>
        /// <param name="cantidad">La cantidad de Manaos.</param>
        /// <param name="excesoCalorias">Indica si la Manaos tiene exceso de calorías.</param>
        public Manaos(EtipoBotella tipoBotella, double precio, int cantidad, bool excesoCalorias) : base(tipoBotella, precio, cantidad)
        {
            this.ExcesoCalorias = excesoCalorias;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Manaos con el tipo de botella, precio, cantidad, tipo de sabor y exceso de calorías especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Manaos.</param>
        /// <param name="precio">El precio de la Manaos.</param>
        /// <param name="cantidad">La cantidad de Manaos.</param>
        /// <param name="tipoSabor">El tipo de sabor de la Manaos.</param>
        /// <param name="excesoCalorias">Indica si la Manaos tiene exceso de calorías.</param>
        public Manaos(EtipoBotella tipoBotella, double precio, int cantidad, EtipoSabor tipoSabor, bool excesoCalorias) : this(tipoBotella, precio, cantidad, excesoCalorias)
        {
            this.TipoSabor = tipoSabor;
        }
        #endregion




        #region Metodo Abstracto override
        /// <summary>
        /// Devuelve una cadena que representa la marca de la Manaos.
        /// </summary>
        /// <returns>Una cadena que contiene la marca "Manaos".</returns>
        public override string MostrarMarca()
        {
            return "Manaos";
        }
        #endregion

        #region Metodo del Virtual Base
        /// <summary>
        /// Muestra un mensaje indicando que se está bebiendo una gaseosa de la marca Manaos.
        /// </summary>
        public override void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa de la marca {MostrarMarca()}");
        }
        #endregion

        #region Metodo Polimorfismo
        /// <summary>
        /// Devuelve una cadena que representa la instancia actual de la clase Manaos.
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Manaos.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("- Exceso en calorias: " + this.ExcesoCalorias);
            sb.Append("- Sabor: " + this.TipoSabor.ToString());
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Manaos manaos = (Manaos)obj;
            return base.Equals(obj) && ExcesoCalorias == manaos.ExcesoCalorias && TipoSabor == manaos.TipoSabor;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
