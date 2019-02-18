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
        //String de conexion 
        string connectionString = "Data Source=DESKTOP-IS3NLRB;Initial Catalog=Parcial;User ID=sa;Password=123456";
        SqlConnection conexion = new SqlConnection(connectionString);
        return conexion;
    }
}