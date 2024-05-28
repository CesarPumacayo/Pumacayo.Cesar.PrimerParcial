using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Fanta))]
    [XmlInclude(typeof(Manaos))]
    [XmlInclude(typeof(Sprite))]
    /// <summary>
    /// Clase abstracta que representa una gaseosa. 
    /// Esta clase no puede ser instanciada directamente y sirve como base para diferentes tipos de gaseosas.
    /// </summary>
    public abstract class Gaseosa
    {
        private EtipoBotella tipoBotella;
        private double precio;
        private int cantidad;

        #region Propiedades
        /// <summary>
        /// Obtiene o establece el tipo de botella de la gaseosa
        /// </summary>
        public EtipoBotella TipoBotella
        {
            get { return this.tipoBotella; }
            set { this.tipoBotella = value; }
        }
        /// <summary>
        /// Obtiene o establece el precio de la gaseosa
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        /// <summary>
        /// Obtiene o establece la cantidad de la gaseosa
        /// </summary>
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia por defecto
        /// </summary>
        public Gaseosa()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Gaseosa con el tipo de botella y precio especificados.
        /// </summary>
        /// <param name="tipoBotella">El tipo de botella de la gaseosa.</param>
        /// <param name="precio">El precio de la gaseosa.</param>
        public Gaseosa(EtipoBotella tipoBotella, double precio) : this()
        {
            this.TipoBotella = tipoBotella;
            this.Precio = precio;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Gaseosa con el tipo de botella, precio y cantidad especificados.
        /// </summary>
        /// <param name="tipoBotella">tipo de botella de la gaseosa</param>
        /// <param name="precio">precio de la gaseosa</param>
        /// <param name="cantidad">precio de la cantidad</param>
        public Gaseosa(EtipoBotella tipoBotella, double precio, int cantidad) : this(tipoBotella, precio)
        {
            this.Cantidad = cantidad;

        }
        #endregion

        /// <summary>
        /// El metodo muestra la marca
        /// </summary>
        /// <returns>Cadena: la marca del tipo de gaseosa en sus derivadas </returns>
        public abstract string MostrarMarca();

        #region Metodo virtual
        public virtual void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa refrescante");
        }
        #endregion
        #region Metodos Polimorfismo

        /// <summary>
        /// Devuelve una cadena de texto de la instancia
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Gaseosa.</returns>
        public override string ToString()
        {

            return $"Tipo de Botella : {this.TipoBotella} - Precio : {this.Precio} - Cantidad : {this.Cantidad} ";

        }
        /// <summary>
        /// Determina si el objeto especificado es igual a la instancia actual de la clase Gaseosa.
        /// </summary>
        /// <param name="obj">El objeto a comparar con la instancia actual.</param>
        /// <returns>true si el objeto especificado es igual a la instancia actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Gaseosa otra)
            {
                return this == otra;
            }
            return false;
        }
        /// <summary>
        /// Devuelve un código hash para la instancia actual de la clase Gaseosa.
        /// </summary>
        /// <returns>Un código hash entero que representa la instancia actual de la clase Gaseosa.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara dos instancias de la clase Gaseosa para determinar si son iguales.
        /// </summary>
        /// <param name="g1">La primera instancia de la clase Gaseosa a comparar.</param>
        /// <param name="g2">La segunda instancia de la clase Gaseosa a comparar.</param>
        /// <returns>true si las instancias son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Gaseosa? g1, Gaseosa? g2)
        {
            if (ReferenceEquals(g1, g2))
            {
                return true;
            }

            if (g1 is null || g2 is null)
            {
                return false;
            }

            return g1.Cantidad == g2.Cantidad && g1.Precio == g2.Precio;
        }
        /// <summary>
        /// Compara dos instancias de la clase Gaseosa para determinar si son diferentes.
        /// </summary>
        /// <param name="g1">La primera instancia de la clase Gaseosa a comparar.</param>
        /// <param name="g2">La segunda instancia de la clase Gaseosa a comparar.</param>
        /// <returns>true si las instancias son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(Gaseosa? g1, Gaseosa? g2)
        {
            return !(g1 == g2);
        }

        /// <summary>
        /// Convierte una instancia de la clase Gaseosa en una cadena de texto.
        /// </summary>
        /// <param name="g">La instancia de la clase Gaseosa a convertir en cadena de texto.</param>
        public static explicit operator string(Gaseosa g)
        {
            return g.ToString();
        }
        #endregion

    }
}
