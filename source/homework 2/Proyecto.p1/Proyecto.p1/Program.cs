using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    // ========= CONFIG DE CONEXIÓN =========
    internal static class Db
    {
        private const string ConnectionString =
            @"Server=DESKTOP-5T9MG4F;Database=Gestor_estudiantil;Trusted_Connection=True;";
        public static SqlConnection GetConnection() => new SqlConnection(ConnectionString);
    }

    // ========= MODELOS =========
    internal class Estudiantes
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }
    }

    internal class Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Materia { get; set; }
        public string Fechaentrega { get; set; } // en BD columna es FechaEntrega
    }

    internal class Proyecto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Materia { get; set; }
        public string Fechaentrega { get; set; } // en BD columna es FechaEntrega
    }

    // ========= REPOSITORIOS =========
    internal class EstudiantesRepository
    {
        private const string Table = "dbo.Estudian";

        public void Insert(Estudiantes e)
        {
            string sql = $@"INSERT INTO {Table} (Nombre, Apellido, Matricula)
                            VALUES (@Nombre, @Apellido, @Matricula);";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 120).Value = e.Nombre ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar, 120).Value = e.Apellido ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Matricula", SqlDbType.Int).Value = e.Matricula;
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Estudiantes> GetAll()
        {
            var list = new List<Estudiantes>();
            string sql = $@"SELECT Nombre, Apellido, Matricula FROM {Table};";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Estudiantes
                {
                    Nombre = rd["Nombre"] as string,
                    Apellido = rd["Apellido"] as string,
                    Matricula = Convert.ToInt32(rd["Matricula"])
                });
            }
            return list;
        }
    }

    internal class TareaRepository
    {
        public void Insert(Tarea t)
        {
            const string sql = @"INSERT INTO dbo.Tarea (Titulo, Descripcion, Materia, FechaEntrega)
                                 VALUES (@Titulo, @Descripcion, @Materia, @FechaEntrega);";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar, 200).Value = t.Titulo ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = (object?)t.Descripcion ?? DBNull.Value;
            cmd.Parameters.Add("@Materia", SqlDbType.NVarChar, 100).Value = t.Materia ?? (object)DBNull.Value;
            if (DateTime.TryParse(t.Fechaentrega, out var fecha))
                cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = fecha;
            else
                cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = DBNull.Value;
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Tarea> GetAll()
        {
            var list = new List<Tarea>();
            const string sql = @"SELECT Titulo, Descripcion, Materia, FechaEntrega FROM dbo.Tarea;";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Tarea
                {
                    Titulo = rd["Titulo"] as string,
                    Descripcion = rd["Descripcion"] as string,
                    Materia = rd["Materia"] as string,
                    Fechaentrega = rd["FechaEntrega"] == DBNull.Value ? null :
                                   Convert.ToDateTime(rd["FechaEntrega"]).ToString("yyyy-MM-dd")
                });
            }
            return list;
        }
    }

    internal class ProyectoRepository
    {
        public void Insert(Proyecto p)
        {
            const string sql = @"INSERT INTO dbo.Proyecto (Titulo, Descripcion, Materia, FechaEntrega)
                                 VALUES (@Titulo, @Descripcion, @Materia, @FechaEntrega);";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar, 200).Value = p.Titulo ?? (object)DBNull.Value;
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = (object?)p.Descripcion ?? DBNull.Value;
            cmd.Parameters.Add("@Materia", SqlDbType.NVarChar, 100).Value = p.Materia ?? (object)DBNull.Value;
            if (DateTime.TryParse(p.Fechaentrega, out var fecha))
                cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = fecha;
            else
                cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = DBNull.Value;
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Proyecto> GetAll()
        {
            var list = new List<Proyecto>();
            const string sql = @"SELECT Titulo, Descripcion, Materia, FechaEntrega FROM dbo.Proyecto;";
            using var cn = Db.GetConnection();
            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Proyecto
                {
                    Titulo = rd["Titulo"] as string,
                    Descripcion = rd["Descripcion"] as string,
                    Materia = rd["Materia"] as string,
                    Fechaentrega = rd["FechaEntrega"] == DBNull.Value ? null :
                                   Convert.ToDateTime(rd["FechaEntrega"]).ToString("yyyy-MM-dd")
                });
            }
            return list;
        }
    }

    // ========= PROGRAMA =========
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENIDO AL GESTOR DE TAREAS ADRIEL");
            Console.WriteLine("-------------------------------");

            Console.Write("Ingrese tu nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.Write("Ingresa tu apellido: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.Write("Ingresa tu matricula : ");
            if (!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Matrícula inválida. Saliendo...");
                return;
            }

            var estRepo = new EstudiantesRepository();
            var estudiante = new Estudiantes { Nombre = nombre, Apellido = apellido, Matricula = matricula };

            try
            {
                estRepo.Insert(estudiante);
                Console.WriteLine("✅ Estudiante guardado en la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error guardando estudiante: " + ex.Message);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Agregar proyecto");
            Console.Write("Elija una de las opciones con un numero del 1 al 2 : ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("DIga el titulo de la tarea: ");
                string titulo = Console.ReadLine();

                Console.Write("Diga la descripcion de la tarea: ");
                string descripcion = Console.ReadLine();

                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. calculo integral");
                Console.WriteLine("2. programacion 1");
                Console.WriteLine("3. analisis");
                Console.WriteLine("4. base de datos");
                Console.Write("Elige un numero del 1 al 4 para elegir la materia de tu tarea: ");
                string materia = Console.ReadLine();

                switch (materia)
                {
                    case "1": materia = "calculo integral"; break;
                    case "2": materia = "programacion 1"; break;
                    case "3": materia = "Analisis"; break;
                    case "4": materia = "Base de datos"; break;
                    default:
                        Console.WriteLine("Materia no valida.");
                        return;
                }

                Console.Write("Diga la fecha de entrega de la tarea (yyyy-MM-dd): ");
                string fechaentrega = Console.ReadLine();

                var tarea = new Tarea
                {
                    Materia = materia,
                    Titulo = titulo,
                    Descripcion = descripcion,
                    Fechaentrega = fechaentrega
                };

                try
                {
                    new TareaRepository().Insert(tarea);
                    Console.WriteLine($"✅ Tarea '{titulo}' (Materia: {materia}) con fecha {fechaentrega} agregada.");
                    // Listar para confirmar
                    Console.WriteLine("\nTareas registradas:");
                    foreach (var t in new TareaRepository().GetAll())
                        Console.WriteLine($"- {t.Titulo} | {t.Materia} | {t.Fechaentrega}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error guardando tarea: " + ex.Message);
                }
            }
            else if (opcion == "2")
            {
                Console.Write("DIga el titulo de su proyecto: ");
                string titulo = Console.ReadLine();

                Console.Write("Diga la descripcion de su proyecto: ");
                string descripcion = Console.ReadLine();

                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. calculo integral");
                Console.WriteLine("2. programacion 1");
                Console.WriteLine("3. analisis");
                Console.WriteLine("4. base de datos");
                Console.Write("Elige un numero del 1 al 4 para elegir la materia de su proyecto: ");
                string materia = Console.ReadLine();

                switch (materia)
                {
                    case "1": materia = "calculo integral"; break;
                    case "2": materia = "programacion 1"; break;
                    case "3": materia = "Analisis"; break;
                    case "4": materia = "Base de datos"; break;
                    default:
                        Console.WriteLine("Materia no valida.");
                        return;
                }

                Console.Write("Diga la fecha de entrega de su proyecto (yyyy-MM-dd): ");
                string fechaentrega = Console.ReadLine();

                var proyecto = new Proyecto
                {
                    Materia = materia,
                    Titulo = titulo,
                    Descripcion = descripcion,
                    Fechaentrega = fechaentrega
                };

                try
                {
                    new ProyectoRepository().Insert(proyecto);
                    Console.WriteLine($"✅ Proyecto '{titulo}' (Materia: {materia}) con fecha {fechaentrega} agregado.");
                    // Listar para confirmar
                    Console.WriteLine("\nProyectos registrados:");
                    foreach (var p in new ProyectoRepository().GetAll())
                        Console.WriteLine($"- {p.Titulo} | {p.Materia} | {p.Fechaentrega}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error guardando proyecto: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.WriteLine("\nEstudiantes registrados (muestra rápida):");
            foreach (var e in estRepo.GetAll())
                Console.WriteLine($"- {e.Nombre} {e.Apellido} | {e.Matricula}");

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}