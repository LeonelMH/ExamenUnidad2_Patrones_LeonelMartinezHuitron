using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_U2_ObjectPool_And_Singleton
{
    public class AutosPool
    {

        private readonly Stack<AutosF1> _autosDisponibles = new Stack<AutosF1>();
        private readonly List<AutosF1> _autostodos = new List<AutosF1>();

        //Constructor del pool de autos
        public AutosPool(int cantidadInicial)
        {
            for(int i = 1; i <= cantidadInicial; i++)
            {
                var auto = new AutosF1(i);
                _autosDisponibles.Push(auto);
                _autostodos.Add(auto);
                Console.WriteLine($"Total de Autos en el pool: {_autosDisponibles.Count}");
            }
        }
        //Metodo para asignar un auto del pool
        public AutosF1 AsignarAuto()
        {
            if (_autosDisponibles.Count > 0)
            {
                var auto = _autosDisponibles.Pop();
                auto.Asignar();
                Console.WriteLine($"Auto: {auto.Numero} asignado.");
                return auto;
            }
            Console.WriteLine("No hay autos disponibles en el pool.");
            return null;
        }
        //Metodo para liberar un auto del pool
        public void LiberarAutoF1(AutosF1 auto)
        {
            if (auto.EstadoAuto == AutosF1.EstadoOcupado)
            {
                auto.LiberarAuto();
                Console.WriteLine($"Auto: {auto.Numero} liberado y en mantenimiento.");
            }
            else
            {
                Console.WriteLine($"Auto {auto.Numero} no puede ser liberado porque no está en carrera.");
            }
        }
        //Metodo para reparar un auto del pool
        public void RepararAutoF1(AutosF1 auto)
        {
            if (auto.EstadoAuto == AutosF1.EstadoReparado)
            {
                auto.RepararAuto();
                _autosDisponibles.Push(auto);
                Console.WriteLine($"Auto: {auto.Numero} reparado y disponible en el pool.");
            }
            else
            {
                Console.WriteLine($"Auto {auto.Numero} no está en mantenimiento, no se puede reparar.");
            }
        }
        public void MostrarEstado()
        {
            Console.WriteLine($"-----Estado del Pool-----");
            foreach(var carros in _autostodos)
            {
                carros.MostrarEstado();
            }
            Console.WriteLine();
        }
    }
}
