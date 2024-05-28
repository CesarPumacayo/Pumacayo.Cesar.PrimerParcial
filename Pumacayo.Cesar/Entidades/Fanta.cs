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

        public bool ExcesoAzucar
        {
            get { return this.excesoAzucar; }
            set { this.excesoAzucar = value; }
        }

        public float Litros
        {
            get { return this.litros; }
            set { this.litros = value; }
        }
        #endregion


        #region Constructores 
        public Fanta()
        {

        }
        public Fanta(EtipoBotella tipoBotella, double precio, int cantidad, bool excesoAzucar) : base(tipoBotella, precio, cantidad)
        {
            this.ExcesoAzucar = excesoAzucar;

        }

        public Fanta(EtipoBotella tipoBotella, double precio, int cantidad, float litros, bool excesoAzucar) : this(tipoBotella, precio, cantidad, excesoAzucar)
        {
            this.Litros = litros;
        }

        #endregion

        #region Metodo abstracto
        public override string MostrarMarca()
        {
            return "Fanta";
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
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("- Exceso en azucar: " + this.ExcesoAzucar);
            sb.Append("- Litros: " + this.Litros.ToString());
            return sb.ToString();
        }
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




        #region
        #endregion

        #region
        #endregion


        #region
        #endregion

    }
}
