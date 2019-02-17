using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Materias : System.Web.UI.Page
{
    MateriaModel model = new MateriaModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar();
    }
    public void Listar()
    {
        List<Materias> lista = model.ListarMaterias();
        resultado.InnerHtml = "<table class='table table-sm' id='table'> " +
            "<thead>" +
            "<tr><th>Codigo</th>" +
            "<th>Nombre</th>" +
            "<th>Ciclo</th>" +
            "<th>Prerequisito</th>" +
            "<th>Descripción</th>" +
            "<th>Unidades Valorativas</th>" +
            "<th>Teorico</th>" +
            "<th>Laboratorio</th>" +
            "<th>Acciones</th></tr></thead> ";
        foreach (Materias m in lista)
        {
            resultado.InnerHtml += "<tbody><tr><td>" + m.CodMateria +
               "</td><td>" + m.Nombre + "</td>" +
               "<td>" + m.Ciclo + "</td>" +
               "<td>" + m.Prerequisito + "</td>" +
               "<td>" + m.Descripcion + "</td>" +
               "<td>" + m.UV + "</td>" +
               "<td>" + m.Teorico + "</td>" +
               "<td>" + m.Laboratorio  + "</td>" +
               "<td><input id='btnModificar' type='button' class='btn btn-info' runat='server' value='seleccionar' /></td>" +
               "</tr></tbody>";
        }
        resultado.InnerHtml += "</table>";
    }
    public void MessageGuardar()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messages", "guardar();", true);
    }

    public void Limpiar()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtCiclo.Text = "";
        rdbTeorico.Checked = false;
        rdbLaboratorio.Checked = false;
        txtUV.Text = "";
        txtPrerequisito.Text = "";
        txtDescripcion.Text = "";

    }

    public void MessageEliminar()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messages", "eliminar();", true);
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Materias m = new Materias();        
        if (btnAgregar.Text  == "Agregar")
        {
            if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == false)
            {
                m.CodMateria = txtCodigo.Text;
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Laboratorio = 0;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                int v = model.InsertarMateria(m);
                Response.Write(v);
                if (v != 0)
                {
                    MessageGuardar();
                    Listar();
                    Limpiar();
                }
            }
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
                m.CodMateria = txtCodigo.Text;
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Laboratorio = 1;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                int v = model.InsertarMateria(m);
                Response.Write(v);
                if (v != 0)
                {
                    MessageGuardar();
                    Listar();
                    Limpiar();
                }
            }
            Response.Write("agreg");
            Response.Write(btnAgregar.Text);
        }
        else  if(!Page.IsPostBack)      {
             m.CodMateria = txtCodigo.Text;
             m.Nombre = txtNombre.Text;
             m.Ciclo = Int32.Parse(txtCiclo.Text);
             m.Teorico = 1;
             m.Laboratorio = 1;
             m.UV = Int32.Parse(txtUV.Text);
             m.Prerequisito = txtPrerequisito.Text;
             m.Descripcion = txtDescripcion.Text;
             int f = model.ModificarMateria(m);
             if (f != 0)
             {
                 MessageGuardar();
                 Listar();
                 Limpiar();
             }
            Response.Write("modif");
            Response.Write(btnAgregar.Text);

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        string cod = txtCodigo.Text;
        int s = model.EliminarMateria(cod);
        if (s != 0)
        {
            MessageEliminar();
            Listar();
            Limpiar();
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        Materias m = new Materias();
        if (btnModificar.Text == "Modificar")
        {
            if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == false)
            {
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Laboratorio = 0;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                m.CodMateria = txtCodigo.Text;
                int v = model.ModificarMateria(m);
                Response.Write(v);
                if (v != 0)
                {
                    MessageGuardar();
                    Listar();
                    Limpiar();
                }
            }
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Laboratorio = 1;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                m.CodMateria = txtCodigo.Text;
                int v = model.ModificarMateria(m);
                Response.Write(v);
                if (v != 0)
                {
                    MessageGuardar();
                    Listar();
                    Limpiar();
                }
            }
        }
    }

    protected void btnActividad_Click(object sender, EventArgs e)
    {
        if (txtCodigo.Text == "")
        {

        }
        else
        {
            Session["Materia"] = txtCodigo.Text;
            Response.Redirect("Actividades.aspx");
        }        
    }
}