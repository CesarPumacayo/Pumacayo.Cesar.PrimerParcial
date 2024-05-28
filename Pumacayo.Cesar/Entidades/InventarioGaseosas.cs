using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InventarioGaseosas<T> where T : Gaseosa
    {
        private List<T>? listaGaseosas;

        private int? cantMaxGaseosas;

        #region Propiedades
        public List<T>? ListaGaseosas
        {
            get { return this.listaGaseosas; }
            set { this.listaGaseosas = value; }
        }
        public int? CantMaxGaseosas
        {
            get { return cantMaxGaseosas; }
            set { this.cantMaxGaseosas = value; }
        }

        #endregion


        public InventarioGaseosas()
        {
            this.ListaGaseosas = new List<T>();
            this.CantMaxGaseosas = cantMaxGaseosas;
        }


        public InventarioGaseosas(int cantMaxGaseosas) : this()
        {
            this.CantMaxGaseosas = cantMaxGaseosas;
        }

        public static bool operator ==(Gaseosa? g, InventarioGaseosas<T>? c)
        {
            if (g is null || c is null || c.ListaGaseosas is null)
                return false;

            foreach (Gaseosa item in c.ListaGaseosas)
            {
                if (item == g)
                {
                    return true;
                }
            }
            return false;
        }



        public static bool operator !=(Gaseosa g, InventarioGaseosas<T> c)
        {
            return !(g == c);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is InventarioGaseosas<T>)
            {
                retorno = this == ((InventarioGaseosas<T>)obj);
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static InventarioGaseosas<T> operator +(InventarioGaseosas<T> c, Gaseosa? g)
        {
            if (c.ListaGaseosas != null && g != null)
            {
                if (c.ListaGaseosas.Count < c.cantMaxGaseosas)
                {
                    if (g != c && !(c.ListaGaseosas.Contains((T)g)))
                    {
                        c.ListaGaseosas.Add((T)g);
                    }
                    else
                    {
                        Console.WriteLine("La gaseosa ya esta en la lista");
                    }
                }
                else
                {
                    Console.WriteLine("La lista ya esta COMPLETA!!");
                }
            }
            else
            {
                Console.WriteLine("La lista es null");
            }
            return c;
        }
        public static InventarioGaseosas<T> operator -(InventarioGaseosas<T> c, Gaseosa? g)
        {
            if (c.ListaGaseosas != null && g != null)
            {
                if (c.ListaGaseosas.Contains((T)g))
                {
                    c.ListaGaseosas.Remove((T)g);
                }
                else
                {
                    Console.WriteLine("La gaseosa que buscabamos - no se encuentra en la lista");
                }
            }
            else
            {
                Console.WriteLine("No se encuentra la lista");
            }
            return c;

        }

        public static int OrdenarPorPrecioAscendente(Gaseosa a, Gaseosa b)
        {
            if (a.Precio < b.Precio)
                return -1;

            else if (a.Precio > b.Precio)
                return 1;
            else
                return 0;
        }

        public static int OrdenarPorPrecioDescendente(Gaseosa a, Gaseosa b)
        {
            if (a.Precio < b.Precio)
                return 1;

            else if (a.Precio > b.Precio)
                return -1;
            else
                return 0;
        }

        public static int OrdenarPorCantidadAscendente(Gaseosa a, Gaseosa b)
        {
            if (a.Cantidad < b.Cantidad)
                return -1;

            else if (a.Cantidad > b.Cantidad)
                return 1;
            else
                return 0;
        }

        public static int OrdenarPorCantidadDescendente(Gaseosa a, Gaseosa b)
        {
            if (a.Cantidad < b.Cantidad)
                return 1;

            else if (a.Cantidad > b.Cantidad)
                return -1;
            else
                return 0;
        }
    }
}
