using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Materias
/// </summary>
public class Materias
{
    private string codMateria;

    public string CodMateria
    {
        get { return codMateria; }
        set { codMateria = value; }
    }

    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private int ciclo;

    public int Ciclo
    {
        get { return ciclo; }
        set { ciclo = value; }
    }

    private int teorico;

    public int Teorico
    {
        get { return teorico; }
        set { teorico = value; }
    }

    private string teoric;

    public string Teoric
    {
        get { return teoric; }
        set { teoric = value; }
    }


    private int lab;

    public int Lab
    {
        get { return lab; }
        set { lab = value; }
    }


    private string laboratorio;

    public string Laboratorio
    {
        get { return laboratorio; }
        set { laboratorio = value; }
    }

    private int uv;

    public int UV
    {
        get { return uv; }
        set { uv = value; }
    }

    private string prerequisito;

    public string Prerequisito
    {
        get { return prerequisito; }
        set { prerequisito = value; }
    }

    private string descripcion;

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public Materias()
    {
        this.codMateria = String.Empty;
        this.nombre = "";
        this.ciclo = 0;
        this.teorico = 0;
        this.lab = 0;
        this.uv = 0;
        this.prerequisito = "";
        this.descripcion = "";
        this.UV = 0;
    }
}