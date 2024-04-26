<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="FormularioVerMedicamentosAsignados.aspx.cs" Inherits="Control_Tipos_Diabetes.Pages.FormularioVerMedicamentosAsignados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Medicamentos
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
        <div class="card text-black" style="margin: 0 auto; max-width: 2000px; background-color: #e6fffa">
            <div class="card-header">
                <h2 class="card-title text-white text-center" style="text-transform: uppercase; font-weight: 700;">Medicamentos</h2>
            </div>
            <br />
            <div class="container">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvmedicamentos" CssClass="table table-borderless table-hover table-sm"
                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvmedicamentos_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField></asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Siguiente" PreviousPageText="Anterior" />
                    </asp:GridView>
                    <a id="btnvolver" href="FormularioDiagnosticoDiabetes.aspx" class="button is-dark has-text-white mb-3">
                        <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                        Volver
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
