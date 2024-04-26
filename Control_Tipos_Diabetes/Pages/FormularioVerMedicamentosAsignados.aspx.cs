using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.Pages
{
    public partial class FormularioVerMedicamentosAsignados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }

        protected void gvmedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmedicamentos.PageIndex = e.NewPageIndex;
            CargarTabla(); // Llama al método para cargar los datos en el GridView
        }

        private void CargarTabla()
        {
            // Obtener el ID del paciente de la URL
            int idPaciente = ObtenerIdPaciente();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("sp_obtener_medicamentos_asignados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvmedicamentos.DataSource = dt;
                gvmedicamentos.DataBind();
            }
        }

        private int ObtenerIdPaciente()
        {
            // Aquí debes implementar la lógica para obtener el ID del paciente desde la URL.
            // Por ejemplo, si el ID del paciente se pasa como un parámetro en la URL, puedes obtenerlo así:
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
    }
}
