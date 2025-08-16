using System;

class Persona
{
    private string nombre;
    private int edad;
    private string direccion;
    private string numero;
    private string email;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Edad
    {
        get { return edad; }
        set { edad = value; }
    }

    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

    public string Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    // Constructor dentro de la clase
    public Persona()
    {
        nombre = "sin nombre";
        edad = 0;
        direccion = "sin direccion";
        numero = "sin numero";
        email = "sin email";
    }
}


public void mostrarinformacioncompleta()
{ Console.WriteLine($"Nombre")}
internal class Program
{
    static void Main(string[] args)
    {
        Persona persona1 = new Persona();
        Console.WriteLine("Nombre: " + persona1.Nombre);
        Console.WriteLine("Edad: " + persona1.Edad);
        Console.WriteLine("Direccion: " + persona1.Direccion);
        Console.WriteLine("Numero: " + persona1.Numero);
        Console.WriteLine("Email: " + persona1.Email);
    }
}
