using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_U2_ObjectPool_And_Singleton
{
    public class AutosF1
    {
        //Propiedad para obtener la instancia del singleton
        public ControladorCarreraSingleton Patrocinador { get; private set; }
        public const string EstadoDisponible = "Disponible";
        public const string EstadoOcupado = "En Carrera";
        public const string EstadoReparado = "En Mantenimiento Pendiente";
        public readonly int Numero;
        public string EstadoAuto {  get; private set; }
        private int vecesUsadas = 0;
        //Constructor de la clase AutosF1
        public AutosF1 (int numero)
        {
            Numero = numero;
            EstadoAuto = EstadoDisponible;
            Patrocinador = ControladorCarreraSingleton.instancia;
        }
        //Metodo para asignar el auto
        public void Asignar()
        {
            EstadoAuto = EstadoOcupado;
            vecesUsadas++;
        }
        //Metodo para liberar el auto
        public void RepararAuto()
        {
           EstadoAuto = EstadoDisponible;

        }
        //Metodo para reparar el auto
        public void LiberarAuto()
        {
            EstadoAuto = EstadoReparado;
        }
        public void MostrarEstado()
        {
            Console.WriteLine($"Autos {Numero}: {EstadoAuto} | Usada {vecesUsadas} veces");
        }
    }
}
