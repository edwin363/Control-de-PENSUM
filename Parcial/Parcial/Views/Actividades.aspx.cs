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
        listar2();
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
                "<td><input id='btnSelect1' type='button' class='btn btn-info' value='seleccionar' /></td></tr>";
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
           "<th>Codigo materia</th>" +
           "<th>Rubrica</th>" +
           "<th>Laboratorio</th>"+
           "<th>Teoria</th></tr>";
        foreach(Actividades v in lista)
        {
            table2.InnerHtml += "<tr><td>" + v.IdActividad +
                "</td><td>" + v.Nombre + "</td>" +
                "<td>" + v.Porcentaje + "</td>" +
                 "<td>" + v.IdMateria + "</td>" +
                "<td>" + v.RubricaEvaluacion + "</td>" +
                "<td>" + v.Laboratorio + "</td>" +
                "<td>" + v.Teorico + "</td>" +
                "<td><input id='btnSelect2' type='button' class='btn btn-info' value='seleccionar' /></td></tr>";
        }
    }

    public void limpiar()
    {
        txtMateria.Text = "";
        txtNombre.Text = "";
        txtPorcentaje.Text = "";
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
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
            actividades.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
            actividades.RubricaEvaluacion = filname;
            actividades.IdMateria = txtMateria.Text;
            am.InsertarActividad(actividades);
            listar2();
            limpiar();
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }
}