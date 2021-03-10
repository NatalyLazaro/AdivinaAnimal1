using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdivinaAnimal1.Clases.dbConexion
{
    class listarAnimales
    {
        //Agregar listas para guardar los datos
        public List<string> animal = new List<string>();
        public List<string> pregunta = new List<string>();
        public List<string> respuesta = new List<string>();

        public List<string> listar(string columas)
        {
            clsConexionDB cm = new clsConexionDB();

            //crear cola para almacenar datos
            //Llama la información de la base de datos 
            Queue<string> cola = new Queue<string>();
            List<string> list = new List<string>();

            DataTable dt = cm.consultarTabla("SELECT *  FROM animalestb");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr[columas].ToString());
            }
            return list;
        }

        
        //Cargar Datos 
        public void guardarDatos()
        {
            vaciarlista(animal);
            vaciarlista(pregunta);
            vaciarlista(respuesta);

            animal = listar("animal");
            pregunta = listar("pregunta");
            respuesta = listar("respuesta");
        }

        //Limpiar lista
        public List<string> vaciarlista(List<string> lista)
        {
            lista.Clear();
            return lista;
        }


    }
}
