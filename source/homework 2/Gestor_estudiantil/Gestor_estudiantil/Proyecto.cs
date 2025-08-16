using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data.SqlClient;

namespace GestorEstudiantil
{
    internal class Proyecto
    {
        public int Id { get; set; } // Id autoincremental para cada proyecto
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }

        private static string connectionString = "Server=localhost;Database=Gestor_estudiantil;Trusted_Connection=True;";

        // Método para guardar un proyecto en la base de datos
        public void Guardar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Proyecto (Titulo, Descripcion, FechaEntrega) VALUES (@Titulo, @Descripcion, @FechaEntrega)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titulo", Titulo);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para listar todos los proyectos
        public static void Listar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Titulo, Descripcion, FechaEntrega FROM Proyecto";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Título: {reader["Titulo"]}, Descripción: {reader["Descripcion"]}, Fecha de Entrega: {Convert.ToDateTime(reader["FechaEntrega"]).ToShortDateString()}");
                    }
                }
            }
        }
    }
}
