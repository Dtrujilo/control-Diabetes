using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.CRUD
{
    public partial class CrudFrmDiagnosticoDiabetes : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString());
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    cargarDatos();

                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Consulta de Creacion";
                            this.btncreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de Lectura";
                            break;
                        //case "U":
                        //    this.lbltitulo.Text = "Consulta de Modificacion";
                        //    this.btnupdate.Visible = true;
                        //    break;
                        //case "D":
                        //    this.lbltitulo.Text = "Consulta de Eliminacion";
                        //    this.btndelete.Visible = true;
                        //    break;
                    }
                }
            }
        }
        void cargarDatos()
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read_diagnostico", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtayunas.Text = row[1].ToString();
            txtaleatorio.Text = row[2].ToString();
            txthbA1c.Text = row[3].ToString();
            txtsobrecargo.Text = row[4].ToString();
            txttolerancia.Text = row[5].ToString();
            txtnombrepaciente.Text = row[6].ToString();
            con.Close();
        }
        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtaleatorio.Text)|| string.IsNullOrEmpty(txtayunas.Text) ||
                string.IsNullOrEmpty(txthbA1c.Text) || string.IsNullOrEmpty(txtnombrepaciente.Text) ||
                string.IsNullOrEmpty(txtsobrecargo.Text) || string.IsNullOrEmpty(txttolerancia.Text))
            {
                MostrarMensaje("Por favor, complete todos los campos antes de agregar.");
            }
            else
            {
                using (SqlCommand command = new SqlCommand("sp_insertar_datos_examen_y_calcular_tipo_diabetes", con))
                {
                    // Establecer el tipo de comando como procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@NombrePaciente", txtnombrepaciente.Text);
                    command.Parameters.AddWithValue("@niv_glucosa", Convert.ToDecimal(txtayunas.Text));
                    command.Parameters.AddWithValue("@niv_alt_glucosa", Convert.ToDecimal(txtaleatorio.Text));
                    command.Parameters.AddWithValue("@niv_hemoglobina_a1c", Convert.ToDecimal(txthbA1c.Text));
                    command.Parameters.AddWithValue("@niv_sobre_carg_oral_gluc", Convert.ToDecimal(txtsobrecargo.Text));
                    command.Parameters.AddWithValue("@niv_tol_oral_gluc", Convert.ToDecimal(txttolerancia.Text));

                    // Abrir la conexión
                    con.Open();

                    // Verificar si el paciente existe antes de ejecutar el procedimiento almacenado
                    bool pacienteExiste = VerificarExistenciaPaciente(con, txtnombrepaciente.Text);

                    // Si el paciente existe, ejecutar el procedimiento almacenado
                    if (pacienteExiste)
                    {
                        command.ExecuteNonQuery();
                        MostrarMensaje("Diabetes agregado correctamente.");
                    }
                    else
                    {
                        MostrarMensaje("El nombre del paciente no existe.");
                    }

                    // Cerrar la conexión
                    con.Close();
                }
            }
        }
        static bool VerificarExistenciaPaciente(SqlConnection connection, string nombrePaciente)
        {
            bool pacienteExiste = false;

            // Crear el comando para verificar la existencia del paciente
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PACIENTES WHERE NOMBRES = @NombrePaciente", connection))
            {
                command.Parameters.AddWithValue("@NombrePaciente", nombrePaciente);

                // Ejecutar el comando y verificar si se encontró el paciente
                int count = Convert.ToInt32(command.ExecuteScalar());
                pacienteExiste = (count > 0);
            }

            return pacienteExiste;
        }


        //protected void btnupdate_ServerClick(object sender, EventArgs e)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_update_diagnostico", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
        //    cmd.Parameters.Add("@Nivel_1", SqlDbType.Decimal).Value = txtaleatorio.Text; 
        //    cmd.Parameters.Add("@Nivel_2", SqlDbType.Decimal).Value = txtayunas.Text;
        //    cmd.Parameters.Add("@Nivel_3", SqlDbType.Decimal).Value = txthbA1c.Text;
        //    cmd.Parameters.Add("@Nivel_4", SqlDbType.Decimal).Value = txtsobrecargo.Text;
        //    cmd.Parameters.Add("@Nivel_5", SqlDbType.Decimal).Value = txttolerancia.Text;
        //    cmd.Parameters.Add("@Id_Paciente", SqlDbType.VarChar).Value = txtnombrepaciente.Text;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
         
        //}

        //protected void btndelete_ServerClick(object sender, EventArgs e)
        //{

        //}

        protected void btnvolver_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../pages/FormularioDiagnosticoDiabetes.aspx");
        }
        public void MostrarMensaje(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeScript", $"alert('{mensaje}');", true);

        }

    }
}