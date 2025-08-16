
/*QUIERO PONER TAMBIEN UNA OPCION 3 Y UNA OPCION 4, OPCION 3 PARA PONER QUE YA SE MANDO LA TAREA Y APAREZCA QUE YA HA SIDO ENVIADA
 Y UNA OPCION 4 PARA PONER LO MISMO PERO CON LOS PROYECTOS (IDEA: OTRAS DOS OPCIONES PARA VER LA LISTA DE TAREAS Y PROYECTOS PENDIENTES)
*/


using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class sistema

{
    public string nombrecompleto { get; set; }
    public int matricula { get; set; }



    class Tarea
    {
        public string descripcion { get; set; }
        public string materia { get; set; }
        public string fechaentrega { get; set; }

        public string tareaspendientes { get; set; }
        public bool completada { get; set; }

    }


    class Proyecto
    {
        public string nombre { get; set; }
        public string materia { get; set; }
        public string fechaentrega { get; set; }
        public string proyectospendientes { get; set; }
        public bool completada { get; set; }

    }


    static void Main(string[] args)

    {

        Console.WriteLine("BIENVENIDO POR FAVOR INGRESE SUS DATOS PARA AGREGAR TAREAS Y PROYECTOS");
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        Console.Write("Ingrese su nombre completo: ");
        string nombrecompleto = Console.ReadLine();

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        Console.Write("Ingrese su matricula: ");
        int matricula = int.Parse(Console.ReadLine());

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        Console.WriteLine("Nombre: " + nombrecompleto + ", matricula: " + matricula + "," + " Estudiante agregado exitosamente.");

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        Console.Write("Si desea agregar una tarea precione /1/  ...  Si desea agregar un proyecto precione /2/:  ");
        string opcion = Console.ReadLine();

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        List<Tarea> tareaspendientes = new List<Tarea>();
        List<Proyecto> proyectopendientes = new List<Proyecto>();


        if (opcion == "1")
        {
            Console.WriteLine("Su eleccion fue tarea.");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.Write("Ingrese su tarea : ");
            string tarea = Console.ReadLine();
            Console.WriteLine("La tarea " + tarea + " fue guardada exitosamente!");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.Write("Ingrese un numero del 1 al 6 para escoger la materia de su tarea : ");

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Calculo integral (1)");
            Console.WriteLine("Base de datos avanzada (2)");
            Console.WriteLine("Programacion 1 (3)");
            Console.WriteLine("Fisica general (4)");
            Console.WriteLine("Laboratorio de fisica general (5)");
            Console.WriteLine("Ingles (6)");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            string materia = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            switch (materia)
            {
                case "1":
                    Console.WriteLine("La materia de su tarea " + tarea + " seleccionada es calculo integral.");
                    break;

                case "2":
                    Console.WriteLine("La materia  de su tarea " + tarea + " seleccionada es Base de Datos avanzada.");
                    break;

                case "3":
                    Console.WriteLine("La materia de su tarea " + tarea + " seleccionada es Programacion 1");
                    break;

                case "4":
                    Console.WriteLine("La materia de su tarea " + tarea + " seleccionada fue Fisica general.");
                    break;

                case "5":
                    Console.WriteLine("La materia de su tarea " + tarea + " seleccionada fue Laboratorio de fisica general.");
                    break;

                case "6":
                    Console.WriteLine("La materia  de su tarea " + tarea + " seleccionada fue Ingles.");
                    break;

                default:
                    Console.WriteLine("La materia de su tarea " + tarea + "no fue encontraada, por favor ingrese un numero valido.");
                    break;




            }


            Console.WriteLine("-----------------------------------------------------------------------------------------");


            Console.Write("Ingrese la fecha de su tarea :");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            string fechaentrega = Console.ReadLine();

            Console.WriteLine("-----------------------------------------------------------------------------------------");


            Console.WriteLine("La fecha de entrega de su tarea " + tarea + " es el " + fechaentrega);

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.Write("Desea marcar la tarea como completada? (responda con 1 para marcar si o 0 para marcar no): ");
            int respuesta = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            if (respuesta == 1)
            {
                Console.WriteLine("La tarea " + tarea + " ha sido marcada como completada.");
            }

            else if (respuesta == 2)
            {
                Console.WriteLine("La tarea " + tarea + " Esta pendiente.");
            }
        }




        Console.WriteLine("-----------------------------------------------------------------------------------------");


        if (opcion == "2")
        {
            Console.WriteLine("Su eleccion fue proyecto.");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.Write("ingrese su proyecto: ");
            string proyecto = Console.ReadLine();
            Console.WriteLine("El Proyecto " + proyecto + " fue agregado exitosamente!");
            Console.WriteLine("-----------------------------------------------------------------------------------------");


            Console.Write("Ingrese un numero del 1 al 6 para escoger la materia de su proyecto : ");

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Calculo integral (1)");
            Console.WriteLine("Base de datos avanzada (2)");
            Console.WriteLine("Programacion 1 (3)");
            Console.WriteLine("Fisica general (4)");
            Console.WriteLine("Laboratorio de fisica general (5)");
            Console.WriteLine("Ingles (6)");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            string materia = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------");



            switch (materia)
            {
                case "1":
                    Console.WriteLine("La materia de su proyecto " + proyecto + " seleccionada es calculo integral.");
                    break;

                case "2":
                    Console.WriteLine("La materia  de su proyecto " + proyecto + " seleccionada es Base de Datos avanzada.");
                    break;

                case "3":
                    Console.WriteLine("La materia de su proyecto " + proyecto + " seleccionada es Programacion 1");
                    break;

                case "4":
                    Console.WriteLine("La materia de su proyecto " + proyecto + " seleccionada fue Fisica general.");
                    break;

                case "5":
                    Console.WriteLine("La materia de su proyecto " + proyecto + " seleccionada fue Laboratorio de fisica general.");
                    break;

                case "6":
                    Console.WriteLine("La materia  de su proyecto " + proyecto + " seleccionada fue Ingles.");
                    break;

                default:
                    Console.WriteLine("La materia de su proyecto " + proyecto + " no fue encontraada, por favor ingrese un numero valido.");
                    break;




            }


            Console.WriteLine("-----------------------------------------------------------------------------------------");



            Console.Write("Ingrese la fecha de su proyecto :");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            string fechaentrega = Console.ReadLine();

            Console.WriteLine("La fecha de entrega de su tarea " + proyecto + " es el" + fechaentrega);
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.Write("Desea marcar el proyecto como completado? (responda con 1 para marcar si o 0 para marcar no): ");
            int respuesta = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            if (respuesta == 1)
            {
                Console.WriteLine("El proyecto " + proyecto + " ha sido marcada como completado.");
                
            }

            else if (respuesta == 0)
            {
                Console.WriteLine("El proyecto " + proyecto + " esta pendiente.");
            }

        }

        Console.WriteLine("-----------------------------------------------------------------------------------------");




        
    }

        
















    
}











        
        
        
        
        
        
      






