namespace Nodos;
using System;

public class Nodo
{
    public string Data { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(string data)
    {
        Data = data;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    public void Agregar(string data)
    {
        Nodo nuevoNodo = new Nodo(data);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public void Eliminar(string data)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Data == data)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine($"Nodo con valor '{data}' eliminado.");
            return;
        }

        Nodo actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Data != data)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente == null)
        {
            Console.WriteLine($"El nodo con valor '{data}' no se encontró.");
        }
        else
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            Console.WriteLine($"Nodo con valor '{data}' eliminado.");
        }
    }

    public bool Buscar(string data)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Data == data)
            {
                Console.WriteLine($"Nodo con valor '{data}' encontrado.");
                return true;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Nodo con valor '{data}' no se encontró.");
        return false;
    }

    public void Modificar(string valorAntiguo, string valorNuevo)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Data == valorAntiguo)
            {
                actual.Data = valorNuevo;
                Console.WriteLine($"Nodo con valor '{valorAntiguo}' modificado a '{valorNuevo}'.");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Nodo con valor '{valorAntiguo}' no se encontró.");
    }

    public void Imprimir()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza;
        Console.Write("Lista enlazada: ");
        while (actual != null)
        {
            Console.Write(actual.Data + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        int opcion;
        do
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Modificar");
            Console.WriteLine("5. Imprimir");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a agregar: ");
                    string valorAgregar = Console.ReadLine();
                    lista.Agregar(valorAgregar);
                    break;

                case 2:
                    Console.Write("Ingrese el valor a eliminar: ");
                    string valorEliminar = Console.ReadLine();
                    lista.Eliminar(valorEliminar);
                    break;

                case 3:
                    Console.Write("Ingrese el valor a buscar: ");
                    string valorBuscar = Console.ReadLine();
                    lista.Buscar(valorBuscar);
                    break;

                case 4:
                    Console.Write("Ingrese el valor a modificar: ");
                    string valorAntiguo = Console.ReadLine();
                    Console.Write("Ingrese el nuevo valor: ");
                    string valorNuevo = Console.ReadLine();
                    lista.Modificar(valorAntiguo, valorNuevo);
                    break;

                case 5:
                    lista.Imprimir();
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}
