using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace BaseDeDatos.Clases.BaseDatos
{
    class ClsMySQL
    {
        public MySqlConnection conectar;
        private string ConexionMySql { get; }


        public ClsMySQL()
        {
            this.ConexionMySql = "Database=alumnos; Data Source=localhost; User Id=root; Password=12345678;";

        }

        public void AbrirBD()
        {
            try
            {
                this.conectar = new MySqlConnection(this.ConexionMySql);
                conectar.Open();
                Console.WriteLine("\nConexion establecida");
            }
            catch (MySqlException er)
            {
                Console.WriteLine($"Error: {er.Message}");
            }
        }
        public void CerrarBD()
        {
            conectar.Close();
            Console.WriteLine("\nConexion cerrada");
        }
        //se guardan datos en la tabla
        public void CrudTable(string datos)
        {
            AbrirBD();
            try
            {
                MySqlCommand comando = new MySqlCommand(datos, conectar);
                comando.ExecuteNonQuery();
                Console.WriteLine("Registro guardado");
            }
            catch (MySqlException er)
            {
                Console.WriteLine($"Error al guardar: {er.Message}");
            }
            finally
            {
                CerrarBD();
            }
        }
        //Se insertan datos 1X1
        public string insertarBD()
        {
            int correlativo;
            string nombre;
            int parcial1, parcial2, parcial3;
            string CadenaDatos;
            string nombreTabla = "tb_alumnos";
            
            Console.Write("Ingrese el correlativo: ");
            correlativo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nombres y apellidos: ");
            nombre = Console.ReadLine();
            Console.Write("Ingrese nota de parcial 1: ");
            parcial1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nota de parcial 2: ");
            parcial2 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nota de parcial 3: ");
            parcial3 = int.Parse(Console.ReadLine());
            CadenaDatos =($"INSERT INTO {nombreTabla} (correlativo, nombres, parcial1, parcial2, parcial3) VALUES ({ correlativo },'{nombre}',{ parcial1 },{ parcial2 },{ parcial3 });");
            return CadenaDatos;
        }
        //Se inserta un registro directo con datos 
        public string Insert_Registro_txt()
        {
            string lec;
            
            TextReader leer = new StreamReader(@"C:\Users\USUARIOTC\Downloads\BaseDeDatos\BaseDeDatos\BaseDeDatos\Archivotxt\alumnos.txt");
            lec = leer.ReadToEnd();
            return lec;
        }

        public void consulta_bd(string consulta)
        {
            string datos = "";
            AbrirBD();
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                MySqlDataReader reader = null;
                reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    datos += reader.GetString(1) + "  " + reader.GetString(2) + "\n";
                }
                Console.WriteLine("\nConsulta realizada con exito ");

            }
            catch (MySqlException er)
            {
                Console.WriteLine($"Error al hace consulta: {er.Message}");
            }
            finally
            {
                CerrarBD();
            }
            Console.WriteLine($"\n{consulta}");
            Console.WriteLine($"\n{datos}");

        }

    }

    
    
}
