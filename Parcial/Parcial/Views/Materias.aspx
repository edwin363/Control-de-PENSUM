<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Materias.aspx.cs" Inherits="Views_Materias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Materias</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/StyleSheet.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8.0.6/dist/sweetalert2.all.min.js"></script>
    <script src="../Helpers/messages.js"></script>
</head>
<body>
    <ul class="nav nav-tabs" id="myTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="home-tab" data-toggle="tab" href="Materias.aspx" role="tab" aria-controls="home" aria-selected="true">Materias</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="profile-tab" data-toggle="tab" href="Actividades.aspx" role="tab" aria-controls="profile" aria-selected="false">Actividades</a>
        </li>
    </ul>
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-4">
                <div class="card border-info">
                    <div class="card-header">Gestión de materias</div>
                    <div class="card-body">
                        <form id="form1" runat="server">
                            <div class="form-group">
                                <div id="errores" runat="server">
                                    
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <label for="txtCodigo">Codigo:</label>
                                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtCodigo" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El formato ingresado es incorrecto" ControlToValidate="txtCodigo" ValidationExpression="^[A-Z]{3}\d{3}$"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col">
                                        <label for="txtNombre">Nombre:</label>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtNombre" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <label for="txtCiclo">Ciclo:</label>
                                        <asp:TextBox ID="txtCiclo" TextMode="Number" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtCiclo" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col">
                                        <label for="rdbTeorico" class="form-check-label">Teorico:</label>
                                        <asp:RadioButton ID="rdbTeorico" runat="server" Enabled="true" />
                                        <br />
                                        <label for="rdbLaboratorio" class="form-check-label">Laboratorio:</label>
                                        <asp:RadioButton ID="rdbLaboratorio" runat="server" Enabled="true" />
                                    </div>
                                    <div class="col">
                                        <label for="txtUV">Unidades valorativas:</label>
                                        <asp:TextBox ID="txtUV" TextMode="Number" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="txtUV" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <label for="txtPrerequisito">Prerequisito:</label>
                                <asp:TextBox ID="txtPrerequisito" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="txtPrerequisito" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                                <br />
                                <label for="txtDescripcion">Descripción:</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ControlToValidate="txtDescripcion" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success btn-sm" AutoPostBack="true" OnClick="btnAgregar_Click" />

                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" Enabled="true" />

                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary btn-sm" OnClick="btnModificar_Click" Enabled="true" />

                            <asp:Button ID="btnActividad" runat="server" Text="Agregar Actividad" CssClass="btn btn-primary btn-sm" OnClick="btnActividad_Click" Enabled="true" />
                        </form>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-8">
                <div class="card border-info">
                    <div class="card-header">Materias</div>
                    <div class="card-body" id="resultado" runat="server">

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Helpers/modifi.js"></script>
</body>
</html>
