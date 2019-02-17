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

    private string teorico;

    public string Teorico
    {
        get { return teorico; }
        set { teorico = value; }
    }

    private string laboratorio;

    public string Laboratorio
    {
        get { return laboratorio; }
        set { laboratorio = value; }
    }

    private int teo;

    public int Teo
    {
        get { return teo; }
        set { teo = value; }
    }

    private int lab;

    public int Lab
    {
        get { return lab; }
        set { lab = value; }
    }


    private decimal procentaje;

    public decimal Porcentaje
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

    private string idMateria;

    public string IdMateria
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