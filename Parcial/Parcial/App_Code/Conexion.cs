using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    public Conexion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static SqlConnection ObtenerConexion()
    {
        string connectionString = "Data Source=DESKTOP-0VM43UK\\DELL;Initial Catalog=Parcial;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(connectionString);
        return conexion;
    }
}