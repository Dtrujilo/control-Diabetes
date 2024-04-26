using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.Pages
{
    public partial class FormularioAsignarMedicamentos : System.Web.UI.Page
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

        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            int idPaciente = ObtenerIdPaciente();

            foreach (GridViewRow row in gvmedicamentos.Rows)
            {
                CheckBox chkMedicamento = row.FindControl("chkMedicamento") as CheckBox;
                if (chkMedicamento.Checked)
                {
                    int idMedida = Convert.ToInt32(row.Cells[1].Text);
                    if (!ExisteMedidaEnPaciente(idPaciente, idMedida))
                    {
                        InsertarMedidaEnPaciente(idPaciente, idMedida);
                    }
                }
            }

            Response.Redirect("~/Pages/FormularioDiagnosticoDiabetes.aspx");
        }

        private void CargarTabla()
        {
            int idPaciente = ObtenerIdPaciente();
            List<int> medidasExistentes = ObtenerMedidasExistentes(idPaciente);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("sp_view_medicamentos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvmedicamentos.DataSource = dt;
                gvmedicamentos.DataBind();
            }
        }


        private List<int> ObtenerMedidasExistentes(int idPaciente)
        {
            List<int> medidasExistentes = new List<int>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID_MEDIDA FROM PACIENTE_MEDIDA WHERE ID_PACIENTE = @IdPaciente", con);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medidasExistentes.Add(Convert.ToInt32(reader["ID_MEDIDA"]));
                }
            }
            return medidasExistentes;
        }

        private bool ExisteMedidaEnPaciente(int idPaciente, int idMedida)
        {
            bool existe = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PACIENTE_MEDIDA WHERE ID_PACIENTE = @IdPaciente AND ID_MEDIDA = @IdMedida", con);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@IdMedida", idMedida);
                int count = (int)cmd.ExecuteScalar();
                existe = (count > 0);
            }
            return existe;
        }

        private void InsertarMedidaEnPaciente(int idPaciente, int idMedida)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO PACIENTE_MEDIDA (ID_PACIENTE, ID_MEDIDA) VALUES (@IdPaciente, @IdMedida)", con);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@IdMedida", idMedida);
                cmd.ExecuteNonQuery();
            }
        }

        private int ObtenerIdPaciente()
        {
            if (Request.QueryString["idPaciente"] != null)
            {
                return Convert.ToInt32(Request.QueryString["idPaciente"]);
            }
            else
            {
                return 1; // Valor predeterminado
            }
        }
    }
}
