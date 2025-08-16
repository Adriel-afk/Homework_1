//Adriel Castillo Peguero 20242582


using System;
using System.Collections.Generic;

namespace ProyectoAgendaPersonal
{
    public class Contacto
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public Contacto(int id, string nombre, string telefono, string email, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nNombre: {Nombre}\nTeléfono: {Telefono}\nEmail: {Email}\nDirección: {Direccion}\n-------------------------";
        }
    }

    public class Agenda
    {
        private List<Contacto> contactos;
        private int contadorId;

        public Agenda()
        {
            contactos = new List<Contacto>();
            contadorId = 1;
        }

        public void AgregarContacto(string nombre, string telefono, string email, string direccion)
        {
            Contacto nuevo = new Contacto(contadorId++, nombre, telefono, email, direccion);
            contactos.Add(nuevo);
        }

        public List<Contacto> ObtenerContactos()
        {
            return contactos;
        }

        public Contacto BuscarContactoPorId(int id)
        {
            return contactos.Find(c => c.Id == id);
        }

        public bool ModificarContacto(int id, string nombre, string telefono, string email, string direccion)
        {
            var contacto = BuscarContactoPorId(id);
            if (contacto != null)
            {
                contacto.Nombre = nombre;
                contacto.Telefono = telefono;
                contacto.Email = email;
                contacto.Direccion = direccion;
                return true;
            }
            return false;
        }

        public bool EliminarContacto(int id)
        {
            var contacto = BuscarContactoPorId(id);
            if (contacto != null)
            {
                contactos.Remove(contacto);
                return true;
            }
            return false;
        }
    }

    public class InterfazUsuario
    {
        private Agenda agenda;

        public InterfazUsuario()
        {
            agenda = new Agenda();
        }

        public void Ejecutar()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Agregar();
                        break;
                    case "2":
                        Mostrar();
                        break;
                    case "3":
                        Buscar();
                        break;
                    case "4":
                        Modificar();
                        break;
                    case "5":
                        Eliminar();
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }

            Console.WriteLine("Agenda cerrada.");
        }

        private void MostrarMenu()
        {
            Console.WriteLine("\n--- Menú Agenda Personal ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Ver contactos");
            Console.WriteLine("3. Buscar contacto por ID");
            Console.WriteLine("4. Modificar contacto");
            Console.WriteLine("5. Eliminar contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
        }

        private void Agregar()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            agenda.AgregarContacto(nombre, telefono, email, direccion);
            Console.WriteLine("Contacto agregado exitosamente.");
        }

        private void Mostrar()
        {
            var lista = agenda.ObtenerContactos();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay contactos.");
                return;
            }

            foreach (var contacto in lista)
            {
                Console.WriteLine(contacto);
            }
        }

        private void Buscar()
        {
            Console.Write("ID del contacto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contacto = agenda.BuscarContactoPorId(id);
                if (contacto != null)
                {
                    Console.WriteLine(contacto);
                }
                else
                {
                    Console.WriteLine("No se encontró el contacto.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void Modificar()
        {
            Console.Write("ID del contacto a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Nuevo nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Nuevo teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Nuevo email: ");
                string email = Console.ReadLine();
                Console.Write("Nueva dirección: ");
                string direccion = Console.ReadLine();

                bool resultado = agenda.ModificarContacto(id, nombre, telefono, email, direccion);
                Console.WriteLine(resultado ? "Contacto modificado." : "No se encontró el contacto.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void Eliminar()
        {
            Console.Write("ID del contacto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool eliminado = agenda.EliminarContacto(id);
                Console.WriteLine(eliminado ? "Contacto eliminado." : "No se encontró el contacto.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.Ejecutar();
        }
    }
}
