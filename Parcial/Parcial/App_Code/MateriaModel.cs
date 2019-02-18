using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MateriaModel
/// </summary>
public class MateriaModel
{
    public MateriaModel()
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
        cmd.CommandText = "select Codigo_Materia, Nombre, Ciclo, Unidades_Valorativas, Prerequisito, Descripcion," +
            " case when Teorico = 1 then 'Si' when Teorico = 0 then 'No' else 'Ni uno ni otro' end as Teorico, " +
            "case when Laboratorio = 1 then 'Si' when Laboratorio = 0 then 'No' else 'Ni uno ni otro' end  as Laboratorio " +
            "from materias";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Materias m = new Materias();
            m.CodMateria  = reader.GetString(0);
            m.Nombre = reader.GetString(1);
            m.Ciclo = reader.GetInt32(2);            
            m.UV = reader.GetInt32(3);
            m.Prerequisito = reader.GetString(4);
            m.Descripcion = reader.GetString(5);
            m.Teoric = reader.GetString(6);
            m.Laboratorio = reader.GetString(7);
            lista.Add(m);
        }
        reader.Close();
        con.Close();
        return lista;
        
    }

    public int InsertarMateria(Materias m)
    {
        int filas = 0;
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "insert into materias values (@cod, @nombre, @ciclo, @teorico, @laboratorio, @uv, @prerequisito, @descripcion)";
        cmd.Parameters.AddWithValue("cod", m.CodMateria);
        cmd.Parameters.AddWithValue("nombre", m.Nombre);
        cmd.Parameters.AddWithValue("ciclo", m.Ciclo);
        cmd.Parameters.AddWithValue("teorico", m.Teorico);
        cmd.Parameters.AddWithValue("laboratorio", m.Lab);
        cmd.Parameters.AddWithValue("uv", m.UV);
        cmd.Parameters.AddWithValue("prerequisito", m.Prerequisito);
        cmd.Parameters.AddWithValue("descripcion", m.Descripcion);
        filas = cmd.ExecuteNonQuery();
        con.Close();
        return filas;
    }

    public int ModificarMateria(Materias m)
    {
        int filas = 0;
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "update materias set Nombre=@nombre, Ciclo=@ciclo, Teorico=@teorico, Laboratorio=@laboratorio, Unidades_Valorativas=@uv, Prerequisito=@prerequisito, Descripcion=@descripcion where Codigo_Materia = @cod";
        cmd.Parameters.AddWithValue("nombre", m.Nombre);
        cmd.Parameters.AddWithValue("ciclo", m.Ciclo);
        cmd.Parameters.AddWithValue("teorico", m.Teorico);
        cmd.Parameters.AddWithValue("laboratorio", m.Lab);
        cmd.Parameters.AddWithValue("uv", m.UV);
        cmd.Parameters.AddWithValue("prerequisito", m.Prerequisito);
        cmd.Parameters.AddWithValue("descripcion", m.Descripcion);
        cmd.Parameters.AddWithValue("cod", m.CodMateria);
        filas = cmd.ExecuteNonQuery();
        con.Close();
        return filas;
    }

    public int EliminarMateria(string cod)
    {
        int filas = 0;
        SqlConnection con = Conexion.ObtenerConexion();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "delete from materias WHERE Codigo_Materia = @cod";
        cmd.Parameters.AddWithValue("cod", cod);
        filas = cmd.ExecuteNonQuery();
        con.Close();
        return filas;
    }
}