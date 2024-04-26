<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="FormularioDiagnosticoDiabetes.aspx.cs" Inherits="Control_Tipos_Diabetes.Pages.FormularioDiagnosticoDiabetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Diagnostico
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
    <div class="container mt-5">
        <div class="card" style="max-width: 1500px; margin: 0 auto; background-color: #e6fffa;">
            <div class="card-header">
                Resultado de Examenes
            </div>
            <div class="card-body">
                <button id="btnsave" type="button" runat="server" class="button is-primary has-text-white" onserverclick="btnsave_ServerClick">
                    <i class="fa fa-regular fa-floppy-disk" style="margin-right: 0.5em;"></i>
                    Crear
                </button>
            </div>
            <br />
            <div class="container">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvdiagnostico" CssClass="table table-borderless table-hover table-sm"
                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvdiagnostico_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones del administrador">
                                <ItemTemplate>

                                    <button id="btnread" type="button" runat="server" class="button form-control-sm is-info has-text-white" onserverclick="btnread_ServerClick">
                                        <i class="fa fa-eye" style="margin-right: 0.5em;"></i>
                                        Leer
                                    </button>
                                    <button id="btnassignmed" type="button" runat="server" class="button form-control-sm is-info has-text-white" onserverclick="btnassignmed_ServerClick">
                                        <i class="fa fa-pills" style="margin-right: 0.5em;"></i>
                                        Asignar Med
                                    </button>
                                    <button id="Button1" type="button" runat="server" class="button form-control-sm is-link has-text-white">
                                        <a href="FormularioVerMedicamentosAsignados.aspx" class="text-light">
                                            <i class="fa-solid fa-notes-medical" style="margin-right: 0.5em;"></i>
                                            Ver Med
                                        </a>
                                    </button>
                                    <%--<button id="btndelete" type="button" runat="server" class="button form-control-sm is-danger has-text-white" onserverclick="btndelete_ServerClick">
                                    <i class="fa fa-trash-alt" style="margin-right: 0.5em;"></i>
                                    Eliminar
                                </button>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Siguiente" PreviousPageText="Anterior" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
