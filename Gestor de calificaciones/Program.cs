using System;
using System.Collections.Generic;

public static class Program
{
    // Punto de entrada del programa (obligatorio para un proyecto de tipo Exe)
    public static void Main()
    {
        var estudiantes = new List<Estudiante>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Gestor de calificaciones ===");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Agregar calificacion");
            Console.WriteLine("3. Ver estudiantes");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    AgregarEstudiante(estudiantes);
                    break;
                case "2":
                    AgregarCalificacion(estudiantes);
                    break;
                case "3":
                    MostrarEstudiantes(estudiantes);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }
    }

    private static void AgregarEstudiante(List<Estudiante> estudiantes)
    {
        Console.Write("Matricula: ");
        string matricula = (Console.ReadLine() ?? "").Trim();

        Console.Write("Nombre: ");
        string nombre = (Console.ReadLine() ?? "").Trim();

        if (matricula == "" || nombre == "")
        {
            Console.WriteLine("La matricula y el nombre no pueden estar vacios.");
            return;
        }

        if (estudiantes.Exists(e => e.Matricula == matricula))
        {
            Console.WriteLine("Ya existe un estudiante con esa matricula.");
            return;
        }

        estudiantes.Add(new Estudiante(matricula, nombre));
        Console.WriteLine("Estudiante agregado.");
    }

    private static void AgregarCalificacion(List<Estudiante> estudiantes)
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("Primero agrega un estudiante.");
            return;
        }

        Console.Write("Matricula del estudiante: ");
        string matricula = (Console.ReadLine() ?? "").Trim();

        Estudiante? estudiante = estudiantes.Find(e => e.Matricula == matricula);
        if (estudiante == null)
        {
            Console.WriteLine("No existe un estudiante con esa matricula.");
            return;
        }

        Console.Write("Calificacion (0-100): ");
        string entrada = (Console.ReadLine() ?? "").Trim();

        if (!double.TryParse(entrada, out double nota) || nota < 0 || nota > 100)
        {
            Console.WriteLine("Calificacion invalida.");
            return;
        }

        estudiante.AgregarCalificacion(nota);
        Console.WriteLine("Calificacion agregada.");
    }

    private static void MostrarEstudiantes(List<Estudiante> estudiantes)
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"Matricula",-12} {"Nombre",-20} {"Promedio",9}  {"Estado"}");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine(
                $"{estudiante.Matricula,-12} {estudiante.Nombre,-20} {estudiante.CalcularPromedio(),9:F2}  {estudiante.ObtenerEstado()}");
        }
    }
}
