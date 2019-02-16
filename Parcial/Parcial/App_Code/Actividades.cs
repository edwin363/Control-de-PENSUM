using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Actividades
/// </summary>
public class Actividades
{

    private int idActividad;

    public int IdActividad
    {
        get { return idActividad; }
        set { idActividad = value; }
    }

    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private int teorico;

    public int Teorico
    {
        get { return teorico; }
        set { teorico = value; }
    }

    private int laboratorio;

    public int Laboratorio
    {
        get { return laboratorio; }
        set { laboratorio = value; }
    }

    private double procentaje;

    public double Porcentaje
    {
        get { return procentaje; }
        set { procentaje = value; }
    }

    private string rubricaEvaluacion;

    public string RubricaEvaluacion
    {
        get { return rubricaEvaluacion; }
        set { rubricaEvaluacion = value; }
    }

    private int idMateria;

    public int IdMateria
    {
        get { return idMateria; }
        set { idMateria = value; }
    }


    public Actividades()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}