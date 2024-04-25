using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.Pages
{
    public partial class FormularioAsignarMedicamentos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla(); // Movemos la llamada aquí para asegurarnos de que los datos se carguen en cada carga de página
        
        }

        void cargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_view_medicamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvmedicamentos.DataSource = dt;
            gvmedicamentos.DataBind();
            con.Close();
        }

        protected void gvmedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmedicamentos.PageIndex = e.NewPageIndex;
            cargarTabla(); // Llama al método para cargar los datos en el GridView
        }

        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvmedicamentos.Rows)
            {
                CheckBox chkMedicamento = (CheckBox)row.FindControl("chkMedicamento");
                if (chkMedicamento.Checked)
                {
                    // Obtener el ID del medicamento seleccionado
                    string idMedicamento = gvmedicamentos.DataKeys[row.RowIndex].Value.ToString();

                    // Insertar el medicamento seleccionado en la tabla PACIENTE_MEDIDA
                    InsertarMedicamentoEnPacienteMedida(idMedicamento);
                }
            }

            // Opcional: Mostrar un mensaje o realizar una redirección después de guardar los medicamentos
        }

        private void InsertarMedicamentoEnPacienteMedida(string idMedicamento)
        {
            // Conexión a la base de datos (debes configurar tu conexión según corresponda)
            string connectionString = ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ConnectionString;

            // Consulta SQL para insertar el medicamento en la tabla PACIENTE_MEDIDA
            string query = "INSERT INTO PACIENTE_MEDIDA (ID_PACIENTE, ID_MEDICAMENTO) VALUES (@IdPaciente, @IdMedicamento)";

            // ID del paciente (debes obtenerlo de alguna manera, por ejemplo, desde la sesión o un parámetro)
            int idPaciente = ObtenerIdPaciente();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Agregar parámetros a la consulta SQL
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@IdMedicamento", idMedicamento);

                    // Abrir la conexión y ejecutar la consulta
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int ObtenerIdPaciente()
        {
            // Aquí debes implementar la lógica para obtener el ID del paciente.
            // Puedes obtenerlo desde la sesión, un parámetro en la URL, o de donde sea que estés almacenando la información del paciente.
            // Por ejemplo, si lo estás pasando como parámetro en la URL, podrías obtenerlo así:
            if (Request.QueryString["idPaciente"] != null)
            {
                return Convert.ToInt32(Request.QueryString["idPaciente"]);
            }
            else
            {
                // Si no se proporciona un ID de paciente válido, podrías devolver un valor predeterminado o lanzar una excepción.
                // En este caso, simplemente devolveré un valor predeterminado de 1.
                return 1;
            }
        }


        protected void btnread_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=R");
        }

        //protected void btnupdate_ServerClick(object sender, EventArgs e)
        //{
        //    string id;
        //    System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
        //    GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
        //    id = selectedrow.Cells[1].Text;
        //    Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=U");
        //}

        //protected void btndelete_ServerClick(object sender, EventArgs e)
        //{
        //    string id;
        //    System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
        //    GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
        //    id = selectedrow.Cells[1].Text;
        //    Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=D");
        //}

        //protected void gvmedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //gvmedicamentos.PageIndex = e.NewPageIndex;
        //    cargarTabla(); // Llama al método para cargar los datos correspondientes a la página seleccionada
        //}
    }
}