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
        resultado.InnerHtml = "<table class='table table-bordered' id ='table'> " +
            "<thead>" +
            "<tr><th class='th-sm'>Codigo</th>" +
            "<th class='th-sm'>Nombre</th>" +
            "<th class='th-sm'>Ciclo</th>" +
            "<th class='th-sm'>Prerrequisito</th>" +
            "<th class='th-sm'>Descripción</th>" +
            "<th class='th-sm'>UV</th>" +
            "<th class='th-sm'>Teorico</th>" +
            "<th class='th-sm'>Lab</th>" +
            "<th class='th-sm'>Acciones</th></tr></thead> ";
        foreach (Materias m in lista)
        {
            resultado.InnerHtml += "<tbody><tr><td>" + m.CodMateria +
               "</td><td>" + m.Nombre + "</td>" +
               "<td>" + m.Ciclo + "</td>" +
               "<td>" + m.Prerequisito + "</td>" +
               "<td>" + m.Descripcion + "</td>" +
               "<td>" + m.UV + "</td>" +
               "<td>" + m.Teoric + "</td>" +
               "<td>" + m.Laboratorio  + "</td>" +
               "<td><input id='btnModificar' type='button' class='btn btn-info btn-sm' runat='server' value='seleccionar' /></td>" +
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
        errores.InnerHtml = "";
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
<<<<<<< HEAD
                m.CodMateria = txtCodigo.Text;
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Lab = 0;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                int v = model.InsertarMateria(m);
                Response.Write(v);
                if (v != 0)
=======
                if (Int32.Parse(txtUV.Text) >= 2 && Int32.Parse(txtUV.Text) <= 4)
                {
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        m.CodMateria = txtCodigo.Text;
                        m.Nombre = txtNombre.Text;
                        m.Ciclo = Int32.Parse(txtCiclo.Text);
                        m.Teorico = 1;
                        m.Lab = 0;
                        m.UV = Int32.Parse(txtUV.Text);
                        m.Prerequisito = txtPrerequisito.Text;
                        m.Descripcion = txtDescripcion.Text;
                        int v = model.InsertarMateria(m);
                       // Response.Write(v);
                        if (v != 0)
                        {
                            MessageGuardar();
                            Listar();
                            Limpiar();
                        }
                    }
                    else
                    {
                        errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese el ciclo entre 1 y 4 </div>";
                    }                   
                }
                else
>>>>>>> 4baf2fc1eea974a8402cae225d674c6f4ec63399
                {
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese UV entre 2 y 4 </div>";
                }
            }
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
<<<<<<< HEAD
                m.CodMateria = txtCodigo.Text;
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Lab = 1;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                int v = model.InsertarMateria(m);
                Response.Write(v);
                if (v != 0)
=======
                if (Int32.Parse(txtUV.Text) == 4)
                {
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        m.CodMateria = txtCodigo.Text;
                        m.Nombre = txtNombre.Text;
                        m.Ciclo = Int32.Parse(txtCiclo.Text);
                        m.Teorico = 1;
                        m.Lab = 1;
                        m.UV = Int32.Parse(txtUV.Text);
                        m.Prerequisito = txtPrerequisito.Text;
                        m.Descripcion = txtDescripcion.Text;
                        int v = model.InsertarMateria(m);
                       // Response.Write(v);
                        if (v != 0)
                        {
                            MessageGuardar();
                            Listar();
                            Limpiar();
                        }
                    }
                    else
                    {
                        errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese el ciclo entre 1 y 4 </div>";
                    }                   
                }
                else
>>>>>>> 4baf2fc1eea974a8402cae225d674c6f4ec63399
                {
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Las UV de una materia con laboratorio son de 4 </div>";
                }
            }
            else
            {
                errores.InnerHtml = "<div class='alert alert-danger' role='alert' >La materia debe tener clases teoricas</div>";
            }            
        }/*
        else  if(!Page.IsPostBack)      {
             m.CodMateria = txtCodigo.Text;
             m.Nombre = txtNombre.Text;
             m.Ciclo = Int32.Parse(txtCiclo.Text);
             m.Teorico = 1;
             m.Lab = 1;
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

        }*/
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
<<<<<<< HEAD
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Lab = 0;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                m.CodMateria = txtCodigo.Text;
                int v = model.ModificarMateria(m);
                Response.Write(v);
                if (v != 0)
=======
                if (Int32.Parse(txtUV.Text) >= 2 && Int32.Parse(txtUV.Text) <= 4)
                {
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        m.Nombre = txtNombre.Text;
                        m.Ciclo = Int32.Parse(txtCiclo.Text);
                        m.Teorico = 1;
                        m.Lab = 0;
                        m.UV = Int32.Parse(txtUV.Text);
                        m.Prerequisito = txtPrerequisito.Text;
                        m.Descripcion = txtDescripcion.Text;
                        m.CodMateria = txtCodigo.Text;
                        int v = model.ModificarMateria(m);
                        //Response.Write(v);
                        if (v != 0)
                        {
                            MessageGuardar();
                            Listar();
                            Limpiar();
                        }
                    }
                    else
                    {
                        errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese el ciclo entre 1 y 4 </div>";
                    }
                }
                else
>>>>>>> 4baf2fc1eea974a8402cae225d674c6f4ec63399
                {
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese UV entre 2 y 4 </div>";
                }
            }
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
<<<<<<< HEAD
                m.Nombre = txtNombre.Text;
                m.Ciclo = Int32.Parse(txtCiclo.Text);
                m.Teorico = 1;
                m.Lab = 1;
                m.UV = Int32.Parse(txtUV.Text);
                m.Prerequisito = txtPrerequisito.Text;
                m.Descripcion = txtDescripcion.Text;
                m.CodMateria = txtCodigo.Text;
                int v = model.ModificarMateria(m);
                Response.Write(v);
                if (v != 0)
=======
                if (Int32.Parse(txtUV.Text) == 4)
>>>>>>> 4baf2fc1eea974a8402cae225d674c6f4ec63399
                {
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        m.Nombre = txtNombre.Text;
                        m.Ciclo = Int32.Parse(txtCiclo.Text);
                        m.Teorico = 1;
                        m.Lab = 1;
                        m.UV = Int32.Parse(txtUV.Text);
                        m.Prerequisito = txtPrerequisito.Text;
                        m.Descripcion = txtDescripcion.Text;
                        m.CodMateria = txtCodigo.Text;
                        int v = model.ModificarMateria(m);
                        //Response.Write(v);
                        if (v != 0)
                        {
                            MessageGuardar();
                            Listar();
                            Limpiar();
                        }
                    }
                    else
                    {
                        errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese el ciclo entre 1 y 4 </div>";
                    }
                }
                else
                {
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Las UV de una materia con laboratorio son de 4 </div>";
                }
            }
            else
            {
                errores.InnerHtml = "<div class='alert alert-danger' role='alert' >La materia debe tener clases teoricas</div>";
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