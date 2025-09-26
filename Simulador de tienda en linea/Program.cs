using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_de_tienda_en_linea
{
    internal class Program
    {
        // Variable global: total del carrito
        static decimal carritoTotal = 0;

        // Lista global para almacenar los productos agregados
        static List<Producto> productos = new List<Producto>();

        static void Main(string[] args)
        {
            int opcion;

            // Menú principal
            do
            {
                Console.WriteLine("\n--- Simulador de Tienda en Línea ---");
                Console.WriteLine($"Total actual del carrito: {carritoTotal:C}");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Consultar productos y total");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        EliminarProducto();
                        break;
                    case 3:
                        ConsultarProductos();
                        break;
                    case 4:
                        Console.WriteLine("Gracias por usar la tienda. ¡Adiós!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 4);
        }

        // Procedimiento: Agregar un producto
        static void AgregarProducto()
        {
            Console.Write("Ingrese el precio del producto a agregar: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal precio) && precio > 0)
            {
                Producto nuevo = new Producto
                {
                    Precio = precio
                };

                carritoTotal += precio;        // Se suma al total
                productos.Add(nuevo);          // Se guarda el producto en la lista

                ReasignarProductos(); // Reordenar nombres después de agregar
                Console.WriteLine($"Producto agregado. Precio: {precio:C}. Nuevo total: {carritoTotal:C}");
            }
            else
            {
                Console.WriteLine("Error: Ingrese un precio válido y mayor que 0.");
            }
        }

        // Procedimiento: Eliminar un producto
        static void EliminarProducto()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No puede eliminar porque no hay productos en el carrito.");
                return;
            }

            Console.WriteLine("Productos en el carrito:");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Nombre}: {p.Precio:C}");
            }

            Console.Write("Ingrese el número del producto a eliminar (ej: 1, 2, 3...): ");

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Producto productoAEliminar = productos.Find(p => p.Numero == numero);

                if (productoAEliminar != null)
                {
                    carritoTotal -= productoAEliminar.Precio; // Restar del total
                    productos.Remove(productoAEliminar);      // Eliminar de la lista
                    ReasignarProductos();                     // Reordenar nombres después de eliminar
                    Console.WriteLine($"Producto eliminado. Nuevo total: {carritoTotal:C}");
                }
                else
                {
                    Console.WriteLine("Error: No existe un producto con ese número en el carrito.");
                }
            }
            else
            {
                Console.WriteLine("Error: Ingrese un número válido.");
            }
        }

        // Procedimiento: Consultar productos
        static void ConsultarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("\n--- Productos en el carrito ---");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Nombre}: {p.Precio:C}");
            }
            Console.WriteLine($"Total actual de la compra: {carritoTotal:C}");
        }

        // Método para reasignar nombres tipo "Producto 1, Producto 2..."
        static void ReasignarProductos()
        {
            for (int i = 0; i < productos.Count; i++)
            {
                productos[i].Numero = i + 1;
                productos[i].Nombre = $"Producto {i + 1}";
            }
        }
    }

    // Clase Producto
    class Producto
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}

