using AdivinaAnimal1.Clases.AdivinaAnimal;
using AdivinaAnimal1.Clases.dbConexion;
using System;

namespace AdivinaAnimal1
{
    class Program
    {
        private static object juego;

        static void juegoAnimal()
        {
            Console.WriteLine("Hola amigo!\n");
            Console.WriteLine("Juegos a adivinar Animales");
            Boolean otroJuego = true;
            AdivinaAnimal juego = new AdivinaAnimal();

            do
            {
                juego.jugar();
                Console.WriteLine("Jugamos otra vez");
                otroJuego = juego.respuesta();
            } while (otroJuego);
        }

        static void Main(string[] args)
        {
            AdivinaAnimal jugemos = new AdivinaAnimal();
            int a = 0;
            bool salir = false;
            Console.WriteLine("\t\tBienvenidos a arboles binarios\n");
            Console.WriteLine("Elige ver opción 1 para ver árbol, 2 para jugar y 3 cerrar");
            a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                jugemos.mostrarArbol();
                Console.ReadKey();
            }
            else
            {
                if (a == 2)
                {
                    juegoAnimal();
                }
                else
                {
                    if(a == 3)
                    {
                        Console.WriteLine("Esta Seguro Que Desea Salir?");
                        salir = jugemos.respuesta();
                    }
                    else
                    {
                        Console.WriteLine("Esa no es una opción intenta otra vez");
                    }
                }

            }
        }
    }
}
