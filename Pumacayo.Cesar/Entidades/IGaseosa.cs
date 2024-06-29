using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IGaseosa<T> where T : Gaseosa
    {
        event Action<T>? GaseosaAgregadaEvent;
        event Action<T>? GaseosaModificadaEvent;


        void AgregarGaseosa(T gaseosa);
        void ModificarGaseosa(int indice, T gaseosa);
    }        
}
