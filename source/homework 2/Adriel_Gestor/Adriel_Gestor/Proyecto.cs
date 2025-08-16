using System;
using System.Data.SqlClient;

namespace Adriel_Gestor
{
    public class Proyecto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; }

        public Proyecto(string titulo, string descripcion, DateTime fechaEntrega, string estado)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaEntrega = fechaEntrega;
            Estado = estado;
        }

        private static string connectionString = @"Server=TU_SERVIDOR;Database=Gestor_estudiantil;Trusted_Connection=True;";

        public bool Guardar()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Proyecto (Titulo, Descripcion, FechaEntrega, Estado) VALUES (@Titulo, @Descripcion, @FechaEntrega, @Estado)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", Titulo);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
                    cmd.Parameters.AddWithValue("@Estado", Estado);

                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    con.Close();

                    return filas > 0;
                }
            }
        }
    }
}