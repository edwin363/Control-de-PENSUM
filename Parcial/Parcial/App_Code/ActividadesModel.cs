using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MateriasModel
/// </summary>
public class ActividadesModel
{
    public ActividadesModel()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<Materias> ListarMaterias()
    {
        List<Materias> lista = new List<Materias>();
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "select Codigo_Materia, Nombre, Ciclo, Unidades_Valorativas," +
            "CASE WHEN Laboratorio = 1 THEN 'SI' WHEN Laboratorio = 0 THEN 'NO' ELSE 'Ni uno ni otro'" +
            "end as Laboratorio from materias";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Materias m = new Materias();
            m.CodMateria = reader.GetString(0);
            m.Nombre = reader.GetString(1);
            m.Ciclo = reader.GetInt32(2);
            m.UV = reader.GetInt32(3);
            m.Laboratorio = reader.GetString(4);
            lista.Add(m);
        }
        reader.Close();
        con.Close();
        return lista;
    }

    public List<Actividades> ListarActividades()
    {
        List<Actividades> lista = new List<Actividades>();
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "select Id_Actividad, Nombre, Porcentaje, Rubrica_Evaluacion, Id_Materia," +
            "case when Laboratorio = 1 then 'SI' when Laboratorio = 0 then 'NO'" +
            "end as Lab, case when Teorico = 1 then 'SI' when Teorico = 0 then 'NO'" +
            "end as Teo from actividades";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Actividades a = new Actividades();
            a.IdActividad = reader.GetInt32(0);
            a.Nombre = reader.GetString(1);
            a.Porcentaje = reader.GetDecimal(2);
            a.RubricaEvaluacion = reader.GetString(3);
            a.IdMateria = reader.GetString(4);
            a.Laboratorio = reader.GetString(5);
            a.Teorico = reader.GetString(6);
            lista.Add(a);
        }
        reader.Close();
        con.Close();
        return lista;
    }

    public int InsertarActividad(Actividades a)
    {
        int filas = 0;
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "INSERT INTO actividades VALUES (@nombre, @teo, @lab, @porce, @rubrica, @idmateria)";
        cmd.Parameters.AddWithValue("nombre", a.Nombre);
        cmd.Parameters.AddWithValue("teo", a.Teo);
        cmd.Parameters.AddWithValue("lab", a.Lab);
        cmd.Parameters.AddWithValue("porce", a.Porcentaje);
        cmd.Parameters.AddWithValue("rubrica", a.RubricaEvaluacion);
        cmd.Parameters.AddWithValue("idmateria", a.IdMateria);
        filas = cmd.ExecuteNonQuery();
        con.Close();
        return filas;
    }

    public int ModificarActividad(Actividades a)
    {
        int filas = 0;
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE actividades SET Nombre = @nombre, SET Teorico = @teo, SET Laboratorio = @lab, SET Porcentaje = @porce, SET Id_Materia = @cod WHERE Id_Actividad = @id";
        cmd.Parameters.AddWithValue("nombre", a.Nombre);
        cmd.Parameters.AddWithValue("teo", a.Teo);
        cmd.Parameters.AddWithValue("lab", a.Lab);
        cmd.Parameters.AddWithValue("porce", a.Porcentaje);
        cmd.Parameters.AddWithValue("idmateria", a.IdMateria);
        filas = cmd.ExecuteNonQuery();
        con.Close();
        return filas;
    }
}