using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Fanta))]
    [XmlInclude(typeof(Manaos))]
    [XmlInclude(typeof(Sprite))]

    public abstract class Gaseosa
    {
        private EtipoBotella tipoBotella;
        private double precio;
        private int cantidad;


        #region Propiedades

        public EtipoBotella TipoBotella
        {
            get { return this.tipoBotella; }
            set { this.tipoBotella = value; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        #endregion


        #region Constructores

        public Gaseosa()
        {

        }
        public Gaseosa(EtipoBotella tipoBotella, double precio) : this()
        {
            this.TipoBotella = tipoBotella;
            this.Precio = precio;
        }

        public Gaseosa(EtipoBotella tipoBotella, double precio, int cantidad) : this(tipoBotella, precio)
        {
            this.Cantidad = cantidad;

        }
        #endregion

        public abstract string MostrarMarca();

        #region Metodo virtual
        public virtual void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa refrescante");
        }
        #endregion
        #region Metodos Polimorfismo
        public override string ToString()
        {

            return $"Tipo de Botella : {this.TipoBotella} - Precio : {this.Precio} - Cantidad : {this.Cantidad} ";

        }
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Sobrecarga de operadores
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
        public static bool operator !=(Gaseosa? g1, Gaseosa? g2)
        {
            return !(g1 == g2);
        }

        public static explicit operator string(Gaseosa g)
        {
            return g.ToString();
        }
        #endregion

    }
}
