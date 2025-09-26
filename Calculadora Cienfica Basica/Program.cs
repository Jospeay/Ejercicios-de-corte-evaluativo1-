using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Cienfica_Basica
{
    internal class Program
    {
        // Variable global para almacenar el último resultado
        static double ultimoResultado = 0;

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- Calculadora Científica ---");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Ver Último Resultado");
        }

        // Método para la suma
        static void Sumar(double a, double b)
        {
            ultimoResultado = a + b;
            Console.WriteLine($"Resultado de la suma: {ultimoResultado}");
        }

        // Método para la resta
        static void Restar(double a, double b)
        {
            ultimoResultado = a - b;
            Console.WriteLine($"Resultado de la resta: {ultimoResultado}");
        }

        // Método para realizar la multiplicación
        static void Multiplicar(double a, double b)
        {
            ultimoResultado = a * b;
            Console.WriteLine($"Resultado de la multiplicación: {ultimoResultado}");
        }

        // Método para realizar la división
        static void Dividir(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: División por cero.");
            }
            else
            {
                ultimoResultado = a / b;
                Console.WriteLine($"Resultado de la división: {ultimoResultado}");
            }
        

        }
        //para mosotrar el ultimo resultado
        static void Mostrarultimoresultado()
        {
            Console.WriteLine($"El ultimo resutado fue: {ultimoResultado}");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                MostrarMenu();
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el primer número: ");
                        double num1 = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese el segundo número: ");
                        double num2 = double.Parse(Console.ReadLine());
                        Sumar(num1, num2);
                        break;
                    case 2:
                        Console.Write("Ingrese el primer número: ");
                        num1 = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese el segundo número: ");
                        num2 = double.Parse(Console.ReadLine());
                        Restar(num1, num2);
                        break;
                    case 3:
                        Console.Write("Ingrese el primer número: ");
                        num1 = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese el segundo número: ");
                        num2 = double.Parse(Console.ReadLine());
                        Multiplicar(num1, num2);
                        break;
                    case 4:
                        Console.Write("Ingrese el primer número: ");
                        num1 = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese el segundo número: ");
                        num2 = double.Parse(Console.ReadLine());
                        Dividir(num1, num2);
                        break;
                    case 5:
                        Mostrarultimoresultado();
                        break;

                }
            }

        }
    }
}
