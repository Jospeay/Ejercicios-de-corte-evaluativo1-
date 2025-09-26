using System;
using System.Collections.Generic;

class SistemaRegistro
{
    static List<string> usuarios = new List<string>();

    static void RegistrarUsuario()
{
    Console.Write("Ingrese el nombre de usuario a registrar: ");
    string nuevoUsuario = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nuevoUsuario))
    {
        Console.WriteLine("El nombre de usuario no puede estar vacío.");
    }
    else if (nuevoUsuario.Length < 3 || nuevoUsuario.Length > 15)
    {
        Console.WriteLine("El nombre de usuario debe tener entre 3 y 15 caracteres.");
    }
    else if (ValidarUsuario(nuevoUsuario))
    {
        Console.WriteLine("El usuario ya existe. No se puede registrar.");
    }
    else
    {
        usuarios.Add(nuevoUsuario);
        Console.WriteLine("Usuario registrado exitosamente.");
    }
}

    static bool ValidarUsuario(string usuario)
    {
        return usuarios.Contains(usuario);
    }

    static void MostrarUsuarios()
    {
        Console.WriteLine("\nUsuarios registrados:");
        if (usuarios.Count == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
        }
        else
        {
            foreach (string usuario in usuarios)
            {
                Console.WriteLine("- " + usuario);
            }
        }
    }

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Sistema de Registro de Usuarios ---");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Mostrar usuarios");
            Console.WriteLine("3. Salir");
            Console.Write("Elija una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarUsuario();
                    break;
                case 2:
                    MostrarUsuarios();
                    break;
                case 3:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 3);
    }
}
