using BaseDeDatos.Clases.BaseDatos;
using System;
using System.Data;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsMySQL cnMySql = new ClsMySQL();
            ClsConexion cnSql = new ClsConexion();
            ClsOracle cnOracle = new ClsOracle();
            int opcion;

            Console.WriteLine("Ingrese una opcion:\n1.Conectar con SQL server\n2.Conectar con MySql\n3.Conectar con Oracle");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    int selecion;
                    Console.WriteLine("Ingrese opcion:\n1. Conectar a SQL Server\n2.Insertar datos\n3. Insertar doc.txt");
                    selecion = int.Parse(Console.ReadLine());
                    
                    switch (selecion)
                    {

                        case 1:
                            cnSql.abrirConexion();
                            cnSql.cerrarConexionBD();
                            break;
                        case 2:
                            string datos=cnSql.insertar_datos();
                            cnSql.EjecutaSQLDirecto(datos);

                            break;
                        case 3:
                            string ob_txt = cnSql.Insert_Registro_txt();
                            cnSql.EjecutaSQLDirecto(ob_txt);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }

                    break;
                case 2:
                    int selecion2;
                    Console.WriteLine("Ingrese opcion:\n1. Conectar y comprobar conexion a MySQL\n2.Insertar datos\n3. Insertar doc.txt\n4.Hacer consulta");
                    selecion2 = int.Parse(Console.ReadLine());
                    switch (selecion2)
                    {
                        case 1:
                            cnMySql.AbrirBD();
                            cnMySql.CerrarBD();
                            break;
                        case 2:
                            string dat = cnMySql.insertarBD();
                            cnMySql.CrudTable(dat);
                            break;
                        case 3:
                            string dt_txt = cnMySql.Insert_Registro_txt();
                            cnMySql.CrudTable(dt_txt);
                            break;
                        case 4:
                            string consult = "SELECT * FROM tb_alumnos where parcial1>6";
                            cnMySql.consulta_bd(consult);

                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    int selecion3;
                    Console.WriteLine("Ingrese opcion:\n1. Conectar a Oracle\n2.Insertar datos\n3. Insertar doc.txt");
                    selecion3 = int.Parse(Console.ReadLine());
                    switch (selecion3)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;

            }
        }
    }
}
