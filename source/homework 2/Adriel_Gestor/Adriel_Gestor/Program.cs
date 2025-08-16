using System;
using System.Data.SqlClient;

namespace Adriel_Gestor
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellidos: ");
            string apellidos = Console.ReadLine();

            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();

            Estudiante estudiante = new Estudiante
            {
                Nombre = nombre,
                Apellido = apellido,
                Carrera = carrera
            };

            try
            {
                estudiante.Guardar();
                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar: " + ex.Message);
            }
        }
    }
}