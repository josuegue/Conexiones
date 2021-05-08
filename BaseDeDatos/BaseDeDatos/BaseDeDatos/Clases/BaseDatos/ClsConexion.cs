using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace BaseDeDatos.Clases.BaseDatos
{
    /// <summary>
    /// Clase de conexion para uso docente
    /// hecho por Ruldin Ayala
    /// </summary>
    class ClsConexion
    {
        public SqlConnection conexion;
        private String _conexion { get; }

        public ClsConexion()
        {

            _conexion = "Data Source=LT-RULDIN\\SQLEXPRESS2014;Initial Catalog=programacion1;Integrated Security=True";

        }



        /// <summary>
        /// Cierra la conexion.
        /// </summary>
        public void cerrarConexionBD()
        {
            conexion.Close();
            Console.WriteLine("Conexion cerrada");
        }



        /// <summary>
        /// abre la conexion
        /// </summary>
        public void abrirConexion()
        {
            conexion = new SqlConnection(_conexion);
            conexion.Open();
            Console.WriteLine("Conexion abierta");
        }




        /// <summary>
        /// metodo que ejecuta una consulta, esta clase maneja la apertura y clausura a la base de datos
        /// </summary>
        /// <param name="sqll"></param>
        /// <returns></returns>
        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }



        /// <summary>
        /// ejecuta una instrucción de insersion, eliminación y actualización,
        /// esta clase se encarga de manejar las aperturas y clausuras de la conexion.
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                SqlCommand comm = new SqlCommand(sqll, conexion);
                comm.ExecuteReader();
                Console.WriteLine("Registro realizado");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }



        }




        /// <summary>
        /// ejecuta instrucciones SQL, pero el progromador debe manejar la apertura y clausura
        /// de las conexiones.
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaSQLManual(String sqll)
        {
            // se abre y cierra la conexino manualmente
            SqlCommand comm = new SqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }


        public string Insert_Registro_txt()
        {
            string lec;

            TextReader leer = new StreamReader(@"C:\Users\USUARIOTC\Downloads\BaseDeDatos\BaseDeDatos\BaseDeDatos\Archivotxt\alumnos.txt");
            lec = leer.ReadToEnd();
            return lec;
        }

        public string insertar_datos()
        {
            int correlativo;
            string nombre;
            int parcial1, parcial2, parcial3;
            string CadenaDatos;
            string nombreTabla;
            Console.Write("Ingrese el nombre de la tabla");
            nombreTabla = Console.ReadLine();
            Console.Write("Ingrese el correlativo:");
            correlativo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nombres y apellidos");
            nombre = Console.ReadLine();
            Console.Write("Ingrese nota de parcial 1: ");
            parcial1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nota de parcial 2: ");
            parcial2 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nota de parcial 3: ");
            parcial3 = int.Parse(Console.ReadLine());
            CadenaDatos = $"INSERT INTO {nombreTabla} (correlativo, nombre, parcial1, parcial2, parcial3) VALUES ({ correlativo } ,'{nombre} ',{ parcial1 },{ parcial2 },{ parcial3 }";
            return CadenaDatos;
        }

    }// fin de la clase
}
