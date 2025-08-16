using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace GestorEstudiantil
{
    internal class Estudiante
    {
        
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        private static string connectionString = "Server=localhost;Database=Gestor_estudiantil;Trusted_Connection=True;";

        public void Guardar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Estudiante (Matricula, Nombre, Edad) VALUES (@Matricula, @Nombre, @Edad)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Edad", Edad);
                    cmd.Parameters.AddWithValue("@Matricula", Matricula);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Listar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Matricula, Nombre, Edad FROM Estudiante";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Matricula: {reader["Matricula"]}, Nombre: {reader["Nombre"]}, Edad: {reader["Edad"] }");
                    }
                }
            }
        }
    }
}
