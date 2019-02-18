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
    Actividades actividades = new Actividades();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar();
        listar2();
        txtMateria.Text = Session["Materia"].ToString();
        decimal valor = am.ObtenerPorcentaje(txtMateria.Text);
        if(valor < 100)
        {
            respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
        }
        else
        {
            respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje ya esta al 100%</h4>";
            respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
            btnAgregar.Enabled = false;
        }
    }
     
    //Metodo para listar los datos de la materia
    public void Listar()
    {
        //Crea una lista
        List<Materias> lista = am.ListarMaterias();
        
        //Se inserta una tabla con los headers 
        table.InnerHtml = "<table class='table table-bordered' id='table'>" +
            "<tr><th>Codigo</th>" +
            "<th>Materia</th>" +
            "<th>Ciclo</th>" +
            "<th>UV</th>" +
            "<th>Laboratorio</th></tr>";
        //Se recorre la lista y se añaden a la tabla desde la base de datos
        foreach (Materias m in lista)
        {
            table.InnerHtml += "<tr><td>" + m.CodMateria +
                "</td><td>" + m.Nombre + "</td>" +
                "<td>" + m.Ciclo + "</td>" +
                "<td>" + m.UV + "</td>" +
                "<td>" + m.Laboratorio + "</td></tr>";
        }
        table.InnerHtml += "</table>";
    }

    //Metodo para listar los datos de las actividades
    public void listar2()
    {
        //Se crea la lista
        List<Actividades> lista = am.ListarActividades();

        //Se inserta una tabla con los headers
        table2.InnerHtml = "<table class='table table-bordered' id='table2'>" +
           "<tr><th>Codigo</th>" +
           "<th>Nombre</th>" +
           "<th>Porcentaje</th>" +
           "<th>Codigo materia</th>" +
           "<th>Rubrica</th>" +
           "<th>Laboratorio</th>"+
           "<th>Teoria</th></tr>";
        //Se recorre la lista y se añaden a la tabla desde la base de datos
        foreach (Actividades v in lista)
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

    //Metodo para limpiar los campos y reestablecer valores
    public void limpiar()
    {
        txtMateria.Text = "";
        txtNombre.Text = "";
        txtPorcentaje.Text = "";
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
        txtid.Text = "";
    }

    //Mensaje de realizado
    public void MessageSuccess()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messages", "getSuccess();", true);
    }

    //Mensaje de error
    public void MessageError()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "messagesActividad", "getError();", true);
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //Se obtiene el valor de la materia por medio de sesion
        txtMateria.Text = Session["Materia"].ToString();

        //Se obtiene el porcentaje total de la materia
        decimal valor = am.ObtenerPorcentaje(txtMateria.Text);
        Debug.WriteLine("Tu valor antes de ingresar es de "+valor);

        //Se valida que el % actual sea menor o igual que 100
        if (valor <= 100)
        {
            //Se suma e igual el valor del textbox y se suma al porcentaje que se tiene en base de datos de la suma anterior 
            valor += (Convert.ToDecimal(txtPorcentaje.Text)*100);
            //Se valida que el nuevo porcentaje sea menor o igual que 100
            if (valor <= 100)
            {
                //Mensaje de alerta
                respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
                int id = 0;

                //Validacion
                if (int.TryParse(txtid.Text, out id))
                {
                    Debug.WriteLine("Es numero");
                }
                else
                {
                    //Valida que tenga un archivo para adjuntar
                    if (this.FileUpload1.HasFile)
                    {
                        //Se validan los campos vacios
                        if (txtNombre.Text.Equals("") || CheckBox1.Checked || CheckBox2.Checked || txtPorcentaje.Text.Equals("") || txtMateria.Text.Equals(""))
                        {
                            //Se obtiene la ruta del archivo y se guarda en la carpeta
                            string filname = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/Rubricas/") + filname);
                            //Se obtienen y se mandan los datos como parametros al modelo
                            int teo = (CheckBox1.Checked == true) ? 1 : 0;
                            int lab = (CheckBox2.Checked == true) ? 1 : 0;
                            actividades.Nombre = txtNombre.Text;
                            actividades.Teo = teo;
                            actividades.Lab = lab;
                            actividades.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                            actividades.RubricaEvaluacion = filname;
                            actividades.IdMateria = txtMateria.Text;
                            int result = am.InsertarActividad(actividades);
                            //Si el resultado fue exitoso se limpian y recargan los datos
                            if (result != 0)
                            {
                                listar2();
                                limpiar();
                                MessageSuccess();

                            }
                            else
                            {
                                MessageError();
                            }
                        }
                    }
                    else
                    {
                        MessageError();
                    }
                }
            }
            else
            {
                //Mensaje de error
                respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje supera al 100%</h4>";
                respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
                btnAgregar.Enabled = true;
                Debug.WriteLine("Mi nuevo valor supera el 100" + valor);
            }
            Debug.WriteLine("Menor que 100");
        }else{
            respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje supera al 100%</h4>";
            btnAgregar.Enabled = true;
            Debug.WriteLine("Supera el 100");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        //Se obtiene el valor de la materia por medio de sesion
        txtMateria.Text = Session["Materia"].ToString();

        //Se obtiene el porcentaje total de la materia
        decimal valor = am.ObtenerPorcentaje(txtMateria.Text);
        Debug.WriteLine("Tu valor antes de ingresar es de " + valor);

        //Se valida que el % actual sea menor o igual que 100
        if (valor <= 100)
        {
            /*Se toma el porcentaje total en base de datos y se resta con el valor del % del perfil que posee el que se va a modificar, por 
            ejemplo si mi % total es 100 y quiero modificar una actividad que vale 30, entonces tomo el 100 que tengo y lo resto con el % de la 
            actividad es decir 30, eso vuelve  mi % total a 70, permitiendo asignarle un nuevo porcentaje sin sobrepasarme del 100
             */
            decimal valor1 = (valor - Convert.ToDecimal(txtPorcentaje.Text));
            //valor += (Convert.ToDecimal(txtPorcentaje.Text) * 100);
            
            //Se valida que el nuevo % sea menor o igual que 100
            if (valor1 <= 100)
            {
                //Se valida campos vacios
                if (txtid.Text.Equals("") || txtMateria.Text.Equals("") || txtNombre.Text.Equals("") || txtPorcentaje.Text.Equals("") || CheckBox1.Checked == false && CheckBox2.Checked == false)
                {
                    MessageError();
                }
                else
                {
                    //Se obtienen y se mandan los datos como parametros al modelo
                    int teo = (CheckBox1.Checked == true) ? 1 : 0;
                    int lab = (CheckBox2.Checked == true) ? 1 : 0;
                    actividades.IdActividad = Convert.ToInt32(txtid.Text);
                    actividades.Nombre = txtNombre.Text;
                    actividades.Teo = teo;
                    actividades.Lab = lab;
                    actividades.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                    actividades.IdMateria = txtMateria.Text;
                    int result = am.ModificarActividad(actividades);
                    //Si el resultado fue exitoso se limpian y recargan los datos
                    if (result != 0)
                    {
                        listar2();
                        limpiar();
                        MessageSuccess();
                        txtMateria.Text = Session["Materia"].ToString();
                        decimal valor2 = am.ObtenerPorcentaje(txtMateria.Text);
                        if (valor2 <= 100)
                        {
                            respuesta.InnerHtml = "<h4 class='text-danger'> " + valor2 + "% </h4>";
                        }
                        else
                        {
                            respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje ya esta al 100%</h4>";
                            respuesta.InnerHtml = "<h4 class='text-danger'> " + valor2 + "% </h4>";
                        }

                    }
                    else
                    {
                        MessageError();
                    }
                }
            }
            else
            {
                respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje supera al 100%</h4>";
                respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
                btnAgregar.Enabled = true;
                Debug.WriteLine("Mi nuevo valor supera el 100" + valor);
            }
            Debug.WriteLine("Menor que 100");
        }
        else
        {
            respuesta2.InnerHtml = "<h4 class='text-danger'>El porcentaje supera al 100%</h4>";
            btnAgregar.Enabled = true;
            Debug.WriteLine("Supera el 100");
        }       
    }

    //Metodo para eliminar
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        //Se valida que el id no este vacio
        if (!txtid.Text.Equals(""))
        {
            Debug.WriteLine("no esta vacio");
            int id = Convert.ToInt32(txtid.Text);
            int result = am.EliminarActividad(id);
            if(result != 0)
            {
                listar2();
                limpiar();
                MessageSuccess();
                txtMateria.Text = Session["Materia"].ToString();
                decimal valor = am.ObtenerPorcentaje(txtMateria.Text);
                respuesta.InnerHtml = "<h4 class='text-danger'> " + valor + "% </h4>";
            }
        }
        else
        {
            Debug.WriteLine("Esta vacio");
        }
    }
}