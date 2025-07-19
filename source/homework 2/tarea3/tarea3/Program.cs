using System;
using System.Collections.Generic;

class Program
{
    class ContactoS
    {
        public int Id;
        public string Nombre;
        public string Apellido;
        public string Direccion;
        public string Telefono;
        public string Email;
        public int Edad;
        public bool EsMejorAmigo;
    }
    static List<ContactoS> contactos = new List<ContactoS>();
    static int siguienteId = 1;

    static void Main()
    {
        Console.WriteLine("Bienvenido a la Agenda de Contactes");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine(@"
-----------------------------
1. Agregar contacto
2. Ver todos los contactos
3. Buscar contacto por nombre o apellido
4. Modificar contacto por ID
5. Eliminar contacto por ID
6. Salir
-----------------------------");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Entrada inválida.\n");
                continue;
            }

            switch (opcion)
            {
                case 1: AgregarContacto(); break;
                case 2: VerContactos(); break;
                case 3: BuscarContacto(); break;
                case 4: ModificarContacto(); break;
                case 5: EliminarContacto(); break;
                case 6: continuar = false; break;
                default: Console.WriteLine("Opción no válida.\n"); break;
            }
        }
    }

    static void AgregarContacto()
    {
        ContactoS nuevo = new ContactoS();
        nuevo.Id = siguienteId++;

        Console.Write("Nombre: "); nuevo.Nombre = Console.ReadLine();
        Console.Write("Apellido: "); nuevo.Apellido = Console.ReadLine();
        Console.Write("Dirección: "); nuevo.Direccion = Console.ReadLine();
        Console.Write("Teléfono: "); nuevo.Telefono = Console.ReadLine();
        Console.Write("Email: "); nuevo.Email = Console.ReadLine();

        Console.Write("Edad: ");
        while (!int.TryParse(Console.ReadLine(), out nuevo.Edad))
        {
            Console.Write("Edad inválida. Ingrese un número: ");
        }

        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        nuevo.EsMejorAmigo = Console.ReadLine() == "1";

        contactos.Add(nuevo);
        Console.WriteLine("Contacto agregado exitosamente.\n");
    }

    static void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos registrados.\n");
            return;
        }

        Console.WriteLine("\nLista de contactos:");
        Console.WriteLine("ID\tNombre\tApellido\tTeléfono\tEdad\t¿Mejor Amigo?");
        Console.WriteLine("---------------------------------------------------------------");

        foreach (var c in contactos)
        {
            string bf = c.EsMejorAmigo ? "Sí" : "No";
            Console.WriteLine($"{c.Id}\t{c.Nombre}\t{c.Apellido}\t{c.Telefono}\t{c.Edad}\t{bf}");
        }
        Console.WriteLine();
    }

    static void BuscarContacto()
    {
        Console.Write("🔍 Buscar por nombre o apellido: ");
        string buscar = Console.ReadLine().ToLower();

        bool encontrado = false;

        foreach (var c in contactos)
        {
            if (c.Nombre.ToLower().Contains(buscar) || c.Apellido.ToLower().Contains(buscar))
            {
                MostrarContacto(c);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron coincidencias.\n");
        }
    }

    static void ModificarContacto()
    {
        Console.Write("Digite el ID del contacto a modificar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.\n");
            return;
        }

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.\n");
            return;
        }

        Console.Write("Nuevo nombre: "); contacto.Nombre = Console.ReadLine();
        Console.Write("Nuevo apellido: "); contacto.Apellido = Console.ReadLine();
        Console.Write("Nueva dirección: "); contacto.Direccion = Console.ReadLine();
        Console.Write("Nuevo teléfono: "); contacto.Telefono = Console.ReadLine();
        Console.Write("Nuevo email: "); contacto.Email = Console.ReadLine();

        Console.Write("Nueva edad: ");
        while (!int.TryParse(Console.ReadLine(), out contacto.Edad))
        {
            Console.Write("Edad inválida. Ingrese un número: ");
        }

        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        contacto.EsMejorAmigo = Console.ReadLine() == "1";

        Console.WriteLine("Contacto actualizado correctamente.\n");
    }

    static void EliminarContacto()
    {
        Console.Write("Digite el ID del contacto a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.\n");
            return;
        }

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado.\n");
        }
        else
        {
            Console.WriteLine("ID no encontrado.\n");
        }
    }

    static void MostrarContacto(ContactoSimple c)
    {
        Console.WriteLine($@"
----------------------------------------
ID: {c.Id}
Nombre: {c.Nombre}
Apellido: {c.Apellido}
Dirección: {c.Direccion}
Teléfono: {c.Telefono}
Email: {c.Email}
Edad: {c.Edad}
¿Mejor amigo?: {(c.EsMejorAmigo ? "Sí" : "No")}
----------------------------------------");
    }
}