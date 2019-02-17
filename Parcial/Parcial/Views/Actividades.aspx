﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actividades.aspx.cs" Inherits="Views_Actividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion de actividades</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8.0.7/dist/sweetalert2.all.min.js"></script>
</head>
<body>
    <ul class="nav nav-tabs" id="myTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Profile</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Contact</a>
        </li>
    </ul>
    <br />
    <div class="container-fluid">
       <div class="row">
        <div class="col-5">
            <div class="card border-info">
                <div class="card-header">Gestion de actividades</div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTipoClase" runat="server" Text="Se le asignara a:"></asp:Label>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Teoria" CssClass="form-check" Enabled="true"/>
                                </div>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Laboratorio" CssClass="form-check" Enabled="true"/>
                                </div>
                            </div>
                            <asp:Button ID="btnEnabled" runat="server" Text="cancelar" CssClass="btn btn-warning" OnClientClick="habilitar()"/>
                            <br />
                            <asp:Label ID="lblPorcentaje" runat="server" Text="Agregar porcentaje"></asp:Label>
                            <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblArchivo" runat="server" Text="Seleccione su rubrica:"></asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file"/>
                            <br />
                            <asp:Label ID="lblMateria" runat="server" Text="Codigo materia:"></asp:Label>
                            <asp:TextBox ID="txtMateria" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                            <br />
                            <div class="row">
                                <div class="col-3">
                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click"/>
                                </div>
                                <div class="col-3">
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
                                </div>
                                <div class="col-3">
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-warning"/>
                                </div>
                                <div class="col-3">
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-info" Visible="false" OnClick="btnModificar_Click"/>
                                </div>
                            </div>
                        </div>
                    </form>
                    <br />
                </div>
            </div>
        </div>
           <br />
        <div class="col-7">
           <div class="card border-dark">
               <div class="card-header">Materias</div>
               <div class="card-body" id="table" runat="server">
                   
               </div>
           </div>
        </div>
       </div>
        <br />
        <div class="row">
            <div class="col-12">
               <div class="card border-primary">
                   <div class="card-header">Actividades</div>
                   <div class="card-body" id="table2" runat="server">
                   </div>
               </div>
           </div>
        </div>
    </div>
    <script src="../HelpersJS/ObtencionDatos.js"></script>
    <script src="../HelpersJS/Enableds.js"></script>
</body>
</html>
