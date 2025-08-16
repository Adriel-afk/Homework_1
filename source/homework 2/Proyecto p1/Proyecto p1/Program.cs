using System;
using System.Collections.Generic;
using Proyecto_p1;

namespace Proyecto_P1
{
    class progrram
    {
        static void Main(string[] args)

        {

            Console.WriteLine("BIENVENIDO AL SISTEMA DE GESTION DE TAREAS Y PROYECTOS ESTUDIANTILES");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();


            Console.WriteLine("--------------------------------------------------------------------");

            Console.Write("Ingrese sus apellidos: ");
            string apellidos = Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------------------");


            Console.Write("Ingrese su carrera: ");
            string carrera = Console.ReadLine();


            Console.WriteLine("Ingrese su Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("--------------------------------------------------------------------");


            Console.WriteLine("Bienvenido/a " + nombre + " " + apellidos + " " +  id);

            Console.WriteLine("-MENU PRINCIPAL-");
            Console.WriteLine("----------------------");

            Console.WriteLine(" 1. Registrar tarea");
            Console.WriteLine(" 2. Registrar proyecto");
            Console.WriteLine(" 3. Consultar tareas registradas");
            Console.WriteLine(" 4. Consultar proyectos registrados");

            Console.Write("Elija una de las opciones con un numero del 1 al 4");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)

            {
                Console.Write("Registrar tarea: ");
                string tarea = Console.ReadLine();

                Console.Write("Agregue la descripcion de la tarea: ");
                string descripcion = Console.ReadLine();

                Console.WriteLine("1. Matematicas");
                Console.WriteLine("2. Lengua y literatura");
                Console.WriteLine("3. Ciencias sociales");
                Console.WriteLine("4. Ciencias naturales");
                Console.WriteLine("5.Ingles");


                Console.Write("Ingrese la materia de la tarea: ");
                    string materia = Console.ReadLine();


             switch (materia)
                {   case "1":materia = "Matematicas"; break;
                    case "2":materia = "lengua y literatura"; break;
                    case "3": materia = "ciencias sociales"; break;
                    case "4": materia = "ciencias naturales"; break;
                    case "5":materia = "Ingles";break;
                    default:Console.WriteLine("Materia no valida, por favor ingrese un numero del 1 al 5"); break;
                }

                Console.Write("Ingrese la fecha de entrega de la tarea: ");
                string entrega = Console.ReadLine();

                Console.WriteLine("Su tarea " + tarea + "ha sido registrada correctamente.");





            }  

            if (opcion ==2)
            {
                Console.Write("Registrar proyecto: ");
                string proyecto = Console.ReadLine();

                Console.Write("Agregue la descripcion de la  proyecto: ");
                string descripcion = Console.ReadLine();

                Console.WriteLine("1. Matematicas");
                Console.WriteLine("2. Lengua y literatura");
                Console.WriteLine("3. Ciencias sociales");
                Console.WriteLine("4. Ciencias naturales");
                Console.WriteLine("5.Ingles");


                Console.Write("Ingrese la materia de la proyecto: ");
                string materia = Console.ReadLine();


                switch (materia)
                {
                    case "1": materia = "Matematicas"; break;
                    case "2": materia = "lengua y literatura"; break;
                    case "3": materia = "ciencias sociales"; break;
                    case "4": materia = "ciencias naturales"; break;
                    case "5": materia = "Ingles"; break;
                    default: Console.WriteLine("Materia no valida, por favor ingrese un numero del 1 al 5"); break;
                }

                Console.Write("Ingrese la fecha de entrega de la proyecto: ");
                string entrega = Console.ReadLine();

                Console.WriteLine("Su tarea " + proyecto + " sido registrada correctamente.");

            }


            






















































        }

















    }

























}



























