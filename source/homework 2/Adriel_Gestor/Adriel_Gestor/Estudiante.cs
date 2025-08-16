using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Adriel_Gestor
{
    internal class Estudiante
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Carrera { get; set; }


        //CONSTRUCTOR
        public Estudiante(string Matricula, string Nombre, string Apellido, string Carerra)
        {
            Matricula = Matricula;
            Nombre = Nombre;
            Apellido = Apellido; ;
            Carerra = Carrera;

        }

        //CONEXION BD
        private string connectionString = @"Server=TU_SERVIDOR;Database=Gestor_estudiantil;Trusted_Connection=True;";

        // Método para guardar un estudiante en la base de datos
        public void Guardar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "INSERT INTO Estudiante (Matricula, Nombre, Apellido, Carrera) VALUES (@Matricula, @Nombre, @Apellido, @Edad, @Carrera)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Matricula", Matricula);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Carrera", Carrera);

                    cmd.ExecuteNonQuery();
                }




            }
        }
    }
}


