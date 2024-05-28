using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manaos : Gaseosa
    {
        private EtipoSabor tipoSabor;
        private bool excesoCalorias;

        #region Propiedades
        public EtipoSabor TipoSabor
        {
            get { return this.tipoSabor; }
            set { this.tipoSabor = value; }

        }
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
        public Manaos(EtipoBotella tipoBotella, double precio, int cantidad, bool excesoCalorias) : base(tipoBotella, precio, cantidad)
        {
            this.ExcesoCalorias = excesoCalorias;
        }
        public Manaos(EtipoBotella tipoBotella, double precio, int cantidad, EtipoSabor tipoSabor, bool excesoCalorias) : this(tipoBotella, precio, cantidad, excesoCalorias)
        {
            this.TipoSabor = tipoSabor;
        }
        #endregion




        #region Metodo Abstracto override
        public override string MostrarMarca()
        {
            return "Manaos";
        }
        #endregion

        #region Metodo del Virtual Base
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
