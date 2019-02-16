using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Views_Actividades : System.Web.UI.Page
{

    ActividadesModel am = new ActividadesModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar();
    }

    public void Listar()
    {
        List<Materias> lista = am.ListarMaterias();
        table.InnerHtml = "<table class='table table-bordered' id='table'>" +
            "<tr><th>Codigo</th>" +
            "<th>Materia</th>" +
            "<th>Ciclo</th>" +
            "<th>UV</th>" +
            "<th>Laboratorio</th>"+
            "<th>Acciones</th></tr>";
        foreach (Materias m in lista)
        {
            table.InnerHtml += "<tr><td>" + m.CodMateria +
                "</td><td>" + m.Nombre + "</td>" +
                "<td>" + m.Ciclo + "</td>" +
                "<td>" + m.UV + "</td>" +
                "<td>" + m.Laboratorio + "</td>"+
                "<td><input id='btnModificar' type='button' class='btn btn-info' value='seleccionar' /></td></tr>";
        }
        table.InnerHtml += "</table>";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {

    }
}