using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Concurrent;
using System.Data;
using AdivinaAnimal1.Clases.dbConexion;

namespace AdivinaAnimal1.Clases.AdivinaAnimal
{
    class AdivinaAnimal
    {
        private static Nodo raiz;
        
        public AdivinaAnimal()
        {
            raiz = new Nodo("Elefa8nte");
        }

        public void jugar()
        {
            ordenarArbol(); // Cargar datos 

            Nodo nodo = raiz;
            
            while (nodo != null)//Interacion con arbol
            {
                if (nodo.izquierda != null) //reciste una pregunta
                {
                    Console.WriteLine(nodo.valorNodo());
                    nodo = (respuesta()) ? nodo.izquierda : nodo.derecha;
                }
                else
                {
                    Console.WriteLine($"Ya se, es un {nodo.valorNodo()}");
                    if (respuesta())
                    {
                        Console.WriteLine("Gane!!! :)");
                    }
                    else
                    {
                            animalNuevo();
                    }
                    nodo = null;
                    return;
                } //Fin del If
            }//Fin del While
        }//Fin del método

        public void mostrarArbol()
        {
            listarAnimales colum = new listarAnimales ();
            colum.guardarDatos();
            string tipraiz = "     ";
            string space = "";

            for (int i = colum.animal.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(space + tipraiz + "_izquierda-Raiz_");
                Console.ReadKey();
                Console.WriteLine(space + "\t" + colum.animal[i] + "|" + colum.pregunta[i] + "");
                tipraiz = "sig->";
                space += "\t";
            }
        }

        public bool respuesta()
        {
            while (true)
            {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser si o no");
            }
        }

        //FIN DE LA RESPUESTA

        public void animalNuevo()
        {
            clsConexionDB conexionDB = new clsConexionDB();

            Console.WriteLine("Chale :( ¿Cuál Es Tu Animal Pues?");
            string nuevoA = Console.ReadLine();
            Console.WriteLine($"Qué pregunta con respuesta si/no puedo hacer que es un {nuevoA}");
            string pregunta = Console.ReadLine();
            Console.WriteLine($"Para un(a) {nuevoA} la respuesta es si/no?");
            string resp = Console.ReadLine().ToLower();
            conexionDB.aggDatos(nuevoA,pregunta,resp); // Almacenar datos
        } //Fin


        //CODIGO PROVANDO
        public void ordenarArbol()
        {
            listarAnimales columnas = new listarAnimales();//cargo la clase lstcolumns a columns
            columnas.guardarDatos();//cargo las listas a columns

            for (int i = 0; i < columnas.animal.Count; i++)
            {
                // crear un nodo para almacer la nueva raiz
                Nodo nodo = new Nodo(columnas.pregunta[i]);//nuevo nodo
                nodo.izquierda = new Nodo(columnas.animal[i]); // dirección del Nodo
                nodo.derecha = raiz; // dirección del nodo 
                raiz = nodo; 
            }
        }
    }
}
