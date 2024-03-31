<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmInfoPaciente.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmInfoPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style>
        .card-header {
            background-color: #20c997; /* Color de fondo azul */
            color: #fff; /* Color del texto blanco */
            padding: 10px; /* Añadir relleno al encabezado */
            font-size: 20px; /* Tamaño de fuente */
            font-weight: bold; /* Negrita */
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container my-4">
        <div class="card text-black" style="margin: 0 auto; max-width: 600px; background-color: #e6fffa">
            <div class="card-header">
                <asp:Label runat="server" ID="lbltitulo" />
            </div>
            <div class="card-body">
                <div class="form-group mt-2">
                    <label class="col-4">Nombre del Paciente:</label>
                    <asp:TextBox ID="txtnombrePaciente" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                </div>
                <div class="form-group mt-2">
                    <label class="col-4">Apellidos del Paciente:</label>
                    <asp:TextBox ID="txtapellidoPaciente" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                </div>
                <div class="form-group row mt-2">
                    <div class="form-group col">
                        <label class="col">Fecha de Registro:</label>
                        <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtfecharegistro" />
                    </div>
                    <div class="form-group col">
                        <label class="col">Fecha de Nacimiento:</label>
                        <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtfechanacimiento" />
                    </div>
                </div>
                <div class="form-group row mt-2">
                    <div class="form-group col">
                        <label class="col-4">Edad:</label>
                        <asp:TextBox ID="txtedad" runat="server" type="number" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                    </div>
                    <div class="form-group mt-2">
                        <label class="col-4">Genero:</label>
                        <asp:TextBox ID="txtgenero" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>
                    </div>
                    <div class="form-group mt-2">
                        <label class="col-4">Dirección:</label>
                        <asp:TextBox ID="txtdireccion" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                    </div>
                    <div class="form-group row mt-2">
                        <div class="form-group col">
                            <label class="col-4">Teléfono 1:</label>
                            <asp:TextBox ID="txttelefono1" runat="server" type="number" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                        </div>
                        <div class="form-group col">
                            <label class="col-4">Teléfono 2:</label>
                            <asp:TextBox ID="txttelefono2" runat="server" type="number" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                        </div>
                    </div>
                    <div class="mt-5" id="datosEncargado" style="display: none;">
                        <h2 class="text-center" style="font-size: 1.2rem; font-weight: 700; text-transform: uppercase;">Datos del Encargado</h2>
                        
                        <div class="form-group mt-2">
                            <label class="col-4">Nombre del Encargado:</label>
                            <asp:TextBox ID="txtnombreEncargado" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                        </div>
                        <div class="form-group mt-2">
                            <label class="col-4">Apellidos del Encargado:</label>
                            <asp:TextBox ID="txtapellidoEncargado" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                        </div>
                        <div class="form-group mt-2">
                            <label class="col-4">Parentesco:</label>
                            <asp:TextBox ID="txtparentesco" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                        </div>
                        <div class="form-group row mt-2">
                            <div class="form-group col">
                                <label class="col">DPI:</label>
                                <asp:TextBox ID="txtdpi" runat="server" type="number" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>

                            </div>
                            <div class="form-group col">
                                <label class="col">Teléfono del Encargado:</label>
                                <asp:TextBox ID="txttelefonoEncargado" runat="server" type="number" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>


                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false">
                    <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                    Guardar
                </button>
                <button id="btnupdate" type="button" runat="server" class="button is-warning has-text-white" visible="false">
                    <i class="fa fa-edit" style="margin-right: 0.5em;"></i>
                    Editar
                </button>
                <button id="btndelete" type="button" runat="server" class="button is-danger has-text-white" visible="false">
                    <i class="fa fa-trash" style="margin-right: 0.5em;"></i>
                    Eliminar
                </button>
                <button id="btnvolver" type="button" runat="server" class="button is-dark has-text-white" visible="true">
                    <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                    Volver
                </button>
            </div>
        </div>
    </div>

    <%--  <script>
        function calcularEdadYMostrarEncargado() {
            let fechaNacimiento = document.getElementById('fechaNacimiento').value;

            if (fechaNacimiento === "") {
                return;
            }

            fechaNacimiento = new Date(fechaNacimiento);
            let hoy = new Date();

            let edadAnios = hoy.getFullYear() - fechaNacimiento.getFullYear();

            if (fechaNacimiento.getMonth() > hoy.getMonth() ||
                (fechaNacimiento.getMonth() === hoy.getMonth() && fechaNacimiento.getDate() > hoy.getDate())) {
                edadAnios--;
            }

            document.getElementById('edad').value = edadAnios;

            if (edadAnios < 18) {
                document.getElementById('datosEncargado').style.display = 'block';
            } else {
                document.getElementById('datosEncargado').style.display = 'none';
            }
        }

        document.addEventListener('DOMContentLoaded', calcularEdadYMostrarEncargado);

        document.getElementById('fechaNacimiento').addEventListener('change', calcularEdadYMostrarEncargado);


        //Fecha Registro
        let inputFechaRegistro = document.getElementById('fechaRegistro');
        let fechaActual = new Date();
        let year = fechaActual.getFullYear();
        let month = String(fechaActual.getMonth() + 1).padStart(2, '0');
        let day = String(fechaActual.getDate()).padStart(2, '0');
        let fechaFormateada = year + '-' + month + '-' + day;

        inputFechaRegistro.value = fechaFormateada;

    </script>--%>

    <script>
        function calcularEdadYMostrarEncargado() {
            let fechaNacimiento = document.getElementById('<%= txtfechanacimiento.ClientID %>').value;

            if (fechaNacimiento === "") {
                return;
            }

            fechaNacimiento = new Date(fechaNacimiento);
            let hoy = new Date();

            let edadAnios = hoy.getFullYear() - fechaNacimiento.getFullYear();

            if (fechaNacimiento.getMonth() > hoy.getMonth() ||
                (fechaNacimiento.getMonth() === hoy.getMonth() && fechaNacimiento.getDate() > hoy.getDate())) {
                edadAnios--;
            }

            document.getElementById('<%= txtedad.ClientID %>').value = edadAnios;

            if (edadAnios < 18) {
                document.getElementById('datosEncargado').style.display = 'block';
            } else {
                document.getElementById('datosEncargado').style.display = 'none';
            }
        }

        document.addEventListener('DOMContentLoaded', calcularEdadYMostrarEncargado);

        document.getElementById('<%= txtfechanacimiento.ClientID %>').addEventListener('change', calcularEdadYMostrarEncargado);

        // Fecha de Registro
        let inputFechaRegistro = document.getElementById('<%= txtfecharegistro.ClientID %>');
        let fechaActual = new Date();
        let year = fechaActual.getFullYear();
        let month = String(fechaActual.getMonth() + 1).padStart(2, '0');
        let day = String(fechaActual.getDate()).padStart(2, '0');
        let fechaFormateada = year + '-' + month + '-' + day;

        inputFechaRegistro.value = fechaFormateada;
    </script>

</asp:Content>
