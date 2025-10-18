using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_U2_ObjectPool_And_Singleton
{
    public class ControladorCarreraSingleton
    {
        //Propiedad para obtener la instancia del singleton
        private static ControladorCarreraSingleton _Instancia;
        //Objeto para el bloqueo en la creacion de la instancia
        private static readonly object _bloqueo = new object();

        private ControladorCarreraSingleton()
        {
        }
        //Propiedad estatica para obtener la instancia unica del singleton
        public static ControladorCarreraSingleton instancia
        {
            get
            {
                if(_Instancia == null)
                {
                    lock (_bloqueo)
                    {
                        if(_Instancia == null)
                        {
                            _Instancia = new ControladorCarreraSingleton();
                        }
                    }
                }
                return _Instancia;
            }
        }

        public void IniciarCarrera()
        {
            Console.WriteLine($"La carrera ha comenzado");
            Console.WriteLine();
        }
        public void FinalizarCarrera()
        {
            Console.WriteLine();
            Console.WriteLine($"La carrera ha terminado");
           
        }
    }
}
