using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace AdivinaAnimal1.Clases.dbConexion
{
    class clsConexionDB
    {
        //Establecer la conexion con la Base de Datos 
        public static SqlConnection Conectar()
        {
            SqlConnection cm = new SqlConnection("Data Source=ALE0081234\\SQLEXPRESS;Initial Catalog=animalesdb;Integrated Security=True");
            return cm;
        }

        //Para guardar los datos a la base de Datos
        public void aggDatos(string animal, string pregunta, string respuesta)
        {

            string query = "insert into animalestb(animal,pregunta,respuesta)VALUES('"+animal+"','"+pregunta+"','"+respuesta+"')";
            SqlConnection cm = Conectar();
            cm.Open();
            try
            {
                SqlCommand agg = new SqlCommand(query, cm);
                agg.ExecuteNonQuery();
                //Console.WriteLine("El Registro Ha Sido Guardado De Forma Correcta");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Al Guardar El Registro" + ex.Message);

            }
            finally
            {
                cm.Close();
            }
        }

        public DataTable consultarTabla(String sqll)
        {
            SqlConnection cm= Conectar();
            cm.Open();
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, cm);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cm.Close();
            return dataTable;
        }

    }
}
