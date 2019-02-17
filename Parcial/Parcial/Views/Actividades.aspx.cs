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

    public void listar2()
    {
        List<Actividades> lista = am.ListarActividades();
        table2.InnerHtml = "<table class='table table-bordered' id='table2'>" +
           "<tr><th>Codigo</th>" +
           "<th>Nombre</th>" +
           "<th>Porcentaje</th>" +
           "<th>Rubrica</th>" +
           "<th>Codigo materia</th>" +
           "<th>Laboratorio</th>"+
           "<th>Teoria</th></tr>";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Actividades actividades = new Actividades();
        if (this.FileUpload1.HasFile)
        {
            string filname = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/Rubricas/") + filname);
            int teo = (CheckBox1.Checked == true) ? 1 : 0;
            int lab = (CheckBox2.Checked == true) ? 1 : 0;
            actividades.Nombre = txtNombre.Text;
            actividades.Teo = teo;
            actividades.Lab = lab;
            actividades.Porcentaje = Convert.ToDouble(txtPorcentaje.Text);
            actividades.RubricaEvaluacion = filname;
            actividades.IdMateria = txtMateria.Text;
            am.InsertarActividad(actividades);
        }
    }
}