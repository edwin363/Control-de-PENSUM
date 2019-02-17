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
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1>Materias del Pensum</h1>
            </div>
            <div class="card col-md-12">
                <div>
                    <h3>Agregar materias</h3>
                    <div class="form-group">
                        <label for="txtCodigo">Codigo:</label>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCodigo" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNombre" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtCiclo">Ciclo:</label>
                        <asp:TextBox ID="txtCiclo" TextMode="Number" runat="server" CssClass="form-control form-control-sm" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCiclo" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="rdbTeorico" class="form-check-label">Teorico:</label>
                        <asp:RadioButton ID="rdbTeorico" runat="server" Enabled="true" />
                    </div>
                    <div class="form-group">
                        <label for="rdbLaboratorio" class="form-check-label">Laboratorio:</label>
                        <asp:RadioButton ID="rdbLaboratorio" runat="server" Enabled="true" />
                    </div>
                    <div class="form-group">
                        <label for="txtUV">Unidades valorativas:</label>
                        <asp:TextBox ID="txtUV" TextMode="Number" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtUV" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtPrerequisito">Prerequisito:</label>
                        <asp:TextBox ID="txtPrerequisito" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtPrerequisito" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtDescripcion">Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtDescripcion" runat="server" ErrorMessage="Campo Requeridor"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" AutoPostBack="true" OnClick="btnAgregar_Click" />

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Enabled="true" />

            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" Enabled="true" />

            <asp:Button ID="btnActividad" runat="server" Text="Agregar Actividad" CssClass="btn btn-primary" OnClick="btnActividad_Click" Enabled="true" />
            <div class="card col-md-12">
                <div class="card-body">
                    <div class="col-md-12" id="resultado" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../JS/modifi.js"></script>
</body>
</html>
