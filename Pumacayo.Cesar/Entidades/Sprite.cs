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
        public bool EsRetornable
        {
            get { return this.esRetornable; }
            set { this.esRetornable = value; }
        }
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
        public Sprite(EtipoBotella tipoBotella, double precio, int cantidad, bool esRetornable) : base(tipoBotella, precio, cantidad)
        {
            this.EsRetornable = esRetornable;
        }
        public Sprite(EtipoBotella tipoBotella, double precio, int cantidad, double codigo, bool esRetornable) : this(tipoBotella, precio, cantidad, esRetornable)
        {
            this.Codigo = codigo;
        }

        #endregion


        #region Metodo Abstracto
        public override string MostrarMarca()
        {
            return "Sprite";
        }
        #endregion


        #region Metodo virtual
        public override void Beber()
        {
            Console.WriteLine($"Estás bebiendo una gaseosa de la marca {MostrarMarca()}");
        }
        #endregion


        #region Metodo Polimorfismo
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
