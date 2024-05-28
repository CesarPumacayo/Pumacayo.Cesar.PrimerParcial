using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sprite : Gaseosa
    {
        private bool esRetornable;
        private double codigo;

        #region Propiedades
        /// <summary>
        /// Obtiene o establece si es retornable el sprite
        /// </summary>
        public bool EsRetornable
        {
            get { return this.esRetornable; }
            set { this.esRetornable = value; }
        }
        /// <summary>
        /// Obtiene o establece el codigo de barra de Sprite
        /// </summary>
        public double Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        #endregion

        #region Constructores

        public Sprite()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Sprite con el tipo de botella, precio, cantidad y si es retornable especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Sprite.</param>
        /// <param name="precio">El precio de la Sprite.</param>
        /// <param name="cantidad">La cantidad de Sprite.</param>
        /// <param name="esRetornable">Indica si la Sprite es retornable.</param>
        public Sprite(EtipoBotella tipoBotella, double precio, int cantidad, bool esRetornable) : base(tipoBotella, precio, cantidad)
        {
            this.EsRetornable = esRetornable;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Sprite con el tipo de botella, precio, cantidad, código y si es retornable especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la Sprite.</param>
        /// <param name="precio">El precio de la Sprite.</param>
        /// <param name="cantidad">La cantidad de Sprite.</param>
        /// <param name="codigo">El código de la Sprite.</param>
        /// <param name="esRetornable">Indica si la Sprite es retornable.</param>
        public Sprite(EtipoBotella tipoBotella, double precio, int cantidad, double codigo, bool esRetornable) : this(tipoBotella, precio, cantidad, esRetornable)
        {
            this.Codigo = codigo;
        }

        #endregion


        #region Metodo Abstracto
        /// <summary>
        /// Devuelve una cadena que representa la marca de la Sprite.
        /// </summary>
        /// <returns>Una cadena que contiene la marca "Sprite".</returns>
        public override string MostrarMarca()
        {
            return "Sprite";
        }
        #endregion


        #region Metodo virtual
        /// <summary>
        /// Muestra un mensaje indicando que se está bebiendo una gaseosa de la marca Sprite.
        /// </summary>
        public override void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa de la marca {MostrarMarca()}");
        }
        #endregion


        #region Metodo Polimorfismo
        /// <summary>
        /// Devuelve una cadena que representa la instancia actual de la clase Sprite.
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Sprite.</returns>
        public override string ToString()
        {
            return $"{base.ToString()} - Codigo : {this.Codigo} - Retornable: {this.EsRetornable}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Sprite sprite = (Sprite)obj;
            return base.Equals(obj) && Codigo == sprite.Codigo && EsRetornable == sprite.EsRetornable;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion







    }
}
