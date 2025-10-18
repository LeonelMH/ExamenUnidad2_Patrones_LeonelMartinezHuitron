using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_U2_ObjectPool_And_Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tienes un carro de F1, donde tu patron Singleton es el controlador de carrera,
            //en este caso estos controladores de carrera serian los patrocionadores de dichos competidores de cada carro/auto de formula 1.
            //Mientras que el object pool lo que hace es si tenemos un vehiculo o auto de formula 1 que choca/accidenta,
            //dicho vehiculo vuelve a la pscina de objetos, y vuelve a estar disponible otro vehiculo/auto, donde se puede reutilizar.

            Console.WriteLine("=== COMPETENCIA DE AUTOS ===\n");
            //Creacion del Object Pool con 3 autos disponibles
            AutosPool pool = new AutosPool(3);
            Console.WriteLine("Autos creados: (3 disponibles)\n");
            //Asignar autos del pool
            var auto1 = pool.AsignarAuto();
            var auto2 = pool.AsignarAuto();
            var auto3 = pool.AsignarAuto();

            //Mostrar los patrocinadores de cada auto 
            Console.WriteLine($"Auto {auto1.Numero} patrocinado por Controlador de Carrera: {auto1.Patrocinador.GetHashCode()}");
            Console.WriteLine($"Auto {auto2.Numero} patrocinado por Controlador de Carrera: {auto2.Patrocinador.GetHashCode()}");
            Console.WriteLine($"Auto {auto3.Numero} patrocinado por Controlador de Carrera: {auto3.Patrocinador.GetHashCode()}");

            //Validar que todos los autos comparten el mismo patrocinador (Singleton)
            bool mismaInstancia = ReferenceEquals(auto1.Patrocinador, auto2.Patrocinador) &&
                                  ReferenceEquals(auto2.Patrocinador, auto3.Patrocinador) &&
                                  ReferenceEquals(auto1.Patrocinador, ControladorCarreraSingleton.instancia);

            Console.WriteLine($"\n¿Todos los autos comparten la misma instancia de patrocinador? {mismaInstancia}");

            auto1.Patrocinador.IniciarCarrera();
            pool.MostrarEstado();

            pool.LiberarAutoF1(auto3);
            pool.MostrarEstado();

            pool.RepararAutoF1(auto3);
            pool.MostrarEstado();

            auto3 = pool.AsignarAuto();
            pool.MostrarEstado();

            auto1.Patrocinador.FinalizarCarrera();

            Console.WriteLine("\n=== COMPETENCIA DE AUTOS ===\n");
            Console.ReadKey();
        }
    }
}
