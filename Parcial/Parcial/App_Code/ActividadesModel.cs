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
}