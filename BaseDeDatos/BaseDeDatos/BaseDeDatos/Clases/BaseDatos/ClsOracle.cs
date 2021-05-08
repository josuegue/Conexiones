
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;



namespace BaseDeDatos.Clases.BaseDatos
{
    class ClsOracle
    {
        public OracleConnection ConexionOracle;
        private string Conexion { get; }
        public ClsOracle()
        {
            Conexion = "Data Source = localhost:1521/XE; User Id = system; Password = 12345678;";
        }
        

        public void Abrir_Cnt_Oracle()
        {
            try
            {
                ConexionOracle = new OracleConnection(Conexion);
                ConexionOracle.Open();
                Console.WriteLine("Conectado a base de datos");
            }
            catch (OracleException er)
            {
                Console.WriteLine($"Error de concexion: {er.Message}");
            }
        }
        
        public void Cerrar_Cnt_Oracle()
        {
            this.ConexionOracle.Close();
            Console.WriteLine("Conexion cerrada");
        }

        public void Insert_Dt_Oracle(string cad_insert)
        {
            Abrir_Cnt_Oracle();
            try
            {
                OracleCommand oracle = new OracleCommand(cad_insert, ConexionOracle);
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de guardado: {ex.Message}");
            }
            finally
            {

            }
        }

    }
}
