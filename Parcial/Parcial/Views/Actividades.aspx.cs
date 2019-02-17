using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        txtMateria.Enabled = false;
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
        if (this.FileUpload1.HasFile)
        {
            //string path = HttpContext.Current.Server.MapPath("~/Rubricas");
            string filname = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/Rubricas/") + filname);
            //this.FileUpload1.SaveAs("C:\\Users\\DELL\\source\\repos\\edwin363\\Control-de-PENSUM\\Parcial\\Parcial\\Rubricas" + FileUpload1.FileName);
            //Debug.WriteLine(path);
        }
    }
}