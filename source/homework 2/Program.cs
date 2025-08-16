using System;

namespace GestorEstudiantil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Gestor Estudiantil ===\n");

            Console.Write("Ingrese su matricula: ");
            string matricula = Console.ReadLine();

            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese su edad: ");
            int edad = int.Parse(Console.ReadLine());

            Estudiante estudiante = new Estudiante
            {
                Matricula = matricula,
                Nombre = nombre,
                Edad = edad
            };
            estudiante.Guardar();

            Console.WriteLine("MENU PRINCIPAL\n");
            Console.WriteLine("1. Guardar tarea");
            Console.WriteLine("2. Guardar proyecto");
            Console.WriteLine("3. Listar estudiantes");
            Console.WriteLine("4. Listar tareas");
            Console.WriteLine("5. Listar proyectos");

            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GuardarTarea();
                    break;

                case "2":
                    GuardarProyecto();
                    break;

                case "3":
                    ListarEstudiantes();
                    break;

                case "4":
                    ListarTareas();
                    break;

                case "5":
                    ListarProyectos();
                    break;

                default:
                    Console.WriteLine("Opcion no valida, por favor intente de nuevo");
                    break;
            }
        }

        static void GuardarTarea()
        {
            Console.Write("Ingrese el titulo de la tarea: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese la descripcion de la tarea: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese la fecha de entrega de su tarea (yyyy-MM-dd): ");
            string fechaentrega = Console.ReadLine();

            Tarea tarea = new Tarea
            {
                Titulo = titulo,
                Descripcion = descripcion,
                FechaEntrega = DateTime.Parse(fechaentrega)
            };
            tarea.Guardar();

            Console.WriteLine("Tarea guardada exitosamente.\n");
        }

        static void GuardarProyecto()
        {
            Console.Write("Ingrese el titulo del proyecto: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese la descripcion del proyecto: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese la fecha de entrega del proyecto (yyyy-MM-dd): ");
            string fechaentrega = Console.ReadLine();

            Proyecto proyecto = new Proyecto
            {
                Titulo = titulo,
                Descripcion = descripcion,
                FechaEntrega = DateTime.Parse(fechaentrega)
            };
            proyecto.Guardar();

            Console.WriteLine("Proyecto guardado exitosamente.\n");
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("Lista de estudiantes: ");
            Estudiante.Listar();
        }

        static void ListarTareas()
        {
            Console.WriteLine("Lista de tareas: ");
            Tarea.Listar();
        }

        static void ListarProyectos()
        {
            Console.WriteLine("Lista de proyectos: ");
            Proyecto.Listar();
        }
    }
}
