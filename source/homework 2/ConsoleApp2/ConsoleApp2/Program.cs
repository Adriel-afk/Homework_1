namespace ConsoleApp2
{
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
            int matricula = int.Parse(Console.ReadLine());

            Estudiante estudiantes = new Estudiante();
            estudiantes.Nombre = nombre;
            estudiantes.Apellido = apellido;
            estudiantes.Matricula = matricula;


            Console.WriteLine(nombre + " " + apellido + " " + matricula);


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

                Console.WriteLine("-------------------------------");

                switch (materia)
                {
                    case "1":
                        materia = "calculo integral";
                        break;

                    case "2":
                        materia = "programacion 1";
                        break;

                    case "3":
                        materia = "Analisis";
                        break;

                    case "4":
                        materia = "Base de datos";
                        break;

                    default:
                        Console.WriteLine("Materia no valida, por favor ingrese una materia valida.");
                        break;

                }

                Console.Write("Diga la fecha de entrega de la tarea: ");
                string fechaentrega = Console.ReadLine();




                Tarea tarea = new Tarea();
                 tarea.Materia = materia;
                tarea.Titulo = titulo;
                tarea.Descripcion = descripcion;
                tarea.Fechaentrega = fechaentrega;

                Console.WriteLine("su tarea " + titulo + "materia " + materia + " fecha de entrega  " + fechaentrega + " ha sido agregada correctamente.");

            }


            if (opcion == "2")
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

                Console.WriteLine("-------------------------------");

                switch (materia)
                {
                    case "1":
                        materia = "calculo integral";
                        break;

                    case "2":
                        materia = "programacion 1";
                        break;

                    case "3":
                        materia = "Analisis";
                        break;

                    case "4":
                        materia = "Base de datos";
                        break;

                    default:
                        Console.WriteLine("Materia no valida, por favor ingrese una materia valida.");
                        break;

                }

                Console.Write("Diga la fecha de entrega de su proyecto: ");
                string fechaentrega = Console.ReadLine();




                Proyecto proyecto = new Proyecto();
                proyecto.Materia = materia;
                proyecto.Titulo = titulo;
                proyecto.Descripcion = descripcion;
                proyecto.Fechaentrega = fechaentrega;

                Console.WriteLine("su proyecto " + titulo + "materia " + materia + " fecha de entrega  " + fechaentrega + " ha sido agregado correctamente.");

            }














        }
    }
}



            












        
    

