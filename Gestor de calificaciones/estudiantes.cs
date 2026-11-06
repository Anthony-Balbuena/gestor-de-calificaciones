using System.Collections.Generic;

public class Estudiante
{
    public string Matricula { get; set; }
    public string Nombre { get; set; }
    public List<double> Calificaciones { get; set; }

    // Constructor para inicializar al estudiante
    public Estudiante(string matricula, string nombre)
    {
        Matricula = matricula;
        Nombre = nombre;
        Calificaciones = new List<double>();
    }

    // Método para agregar una calificación
    public void AgregarCalificacion(double nota)
    {
        Calificaciones.Add(nota);
    }

    // Método para calcular el promedio
    public double CalcularPromedio()
    {
        if (Calificaciones.Count == 0)
        {
            return 0;
        }

        double suma = 0;
        foreach (var nota in Calificaciones)
        {
            suma += nota;
        }
        return suma / Calificaciones.Count;
    }

    // Método para obtener el estado del estudiante
    public string ObtenerEstado()
    {
        if (Calificaciones.Count == 0)
        {
            return "Sin calificaciones";
        }

        double promedio = CalcularPromedio();
        return promedio >= 70 ? "Aprobado" : "Reprobado";
    }
}
