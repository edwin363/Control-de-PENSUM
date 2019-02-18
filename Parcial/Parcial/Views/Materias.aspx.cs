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

    //Listar datos en la tabla
    public void Listar()
    {
        //Crea una lista
        List<Materias> lista = model.ListarMaterias();

        //Se inserta una tabla con los encabezados
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
        //Se recorren las filas en bd y se agregan a la tabla
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

    //Mensaje de guardar
    public void MessageGuardar()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messages", "guardar();", true);
    }

    //Metodo para limpiar y resetear campos
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

    //Mensaje de eliminar
    public void MessageEliminar()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messages", "eliminar();", true);
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //Se instancia la clase
        Materias m = new Materias();        
        //Se valida que el boton sea agregar
        if (btnAgregar.Text  == "Agregar")
        {
            //Si solo tiene teorico y no posee laboratorio
            if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == false)
            {
                //Las unidades valorativas tienen que ser entre 2 y 4
                if (Int32.Parse(txtUV.Text) >= 2 && Int32.Parse(txtUV.Text) <= 4)
                {
                    //El ciclo debe ser de 1 a 4
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        //Se obtienen los valores de los campos y se envian como parametros al modelo
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

                        //Si todo sale bien se limpian los campos
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
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese UV entre 2 y 4 </div>";
                }
            }
            //Si la materia tiene teorico y laboratorio
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
                //Las unidades valorativas deben de ser por ley 4
                if (Int32.Parse(txtUV.Text) == 4)
                { 
                    //El ciclo debe de ser de 1 a 4
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        //Se obtiene los valores de los campos y se envian a la clase
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

                        //Si todo sale bien se reestablecen los valores
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

    //Metodo para eliminar
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        //Se toma el valor del codigo de la materia
        string cod = txtCodigo.Text;
        int s = model.EliminarMateria(cod);
        //Si todo sale bien se reestablece
        if (s != 0)
        {
            MessageEliminar();
            Listar();
            Limpiar();
        }
    }

    //Metodo para modifica
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        //Se instancia la clase
        Materias m = new Materias();
        //Se valida que el boton se modificar
        if (btnModificar.Text == "Modificar")
        {
            //La materia solo tiene teoricos y no laboratorio
            if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == false)
            {
                //Las unidades valorativas deben ser de 2 a 4
                if (Int32.Parse(txtUV.Text) >= 2 && Int32.Parse(txtUV.Text) <= 4)
                {
                    //El ciclo debe ser de 1 a 4
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        //Se obtienen y se mandan los valores de los campos al modelo
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

                        //Se reestablencen valores
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
                    errores.InnerHtml = "<div class='alert alert-danger' role='alert' >Ingrese UV entre 2 y 4 </div>";
                }
            }
            //La materia posee teorico y laboratorios
            else if (rdbTeorico.Checked == true && rdbLaboratorio.Checked == true)
            {
                //Las unidades valorativas deben ser de 4 por ley
                if (Int32.Parse(txtUV.Text) == 4)
                {
                    //El ciclo debe de ser de 1 a 4
                    if (Int32.Parse(txtCiclo.Text) >= 1 && Int32.Parse(txtCiclo.Text) <= 4)
                    {
                        //Se obtienen y se mandan los valores de los campos al modelo
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
                        
                        //Se reestablecen valores
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

    //Metodo para agregar actividades
    protected void btnActividad_Click(object sender, EventArgs e)
    {
        //Validar que lleve un codigo de materia
        if (txtCodigo.Text == "")
        {

        }
        else
        {
            //Se crea variable de sesion para el codigo de la materia 
            Session["Materia"] = txtCodigo.Text;
            //Se redirecciona a la pagina de actividades
            Response.Redirect("Actividades.aspx");
        }        
    }
}