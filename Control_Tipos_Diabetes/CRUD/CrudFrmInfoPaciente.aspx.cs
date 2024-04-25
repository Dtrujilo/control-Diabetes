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
    public partial class CrudFrmInfoPaciente : System.Web.UI.Page
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
                    txtfechanacimiento.TextMode = TextBoxMode.DateTime;


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
                        case "U":
                            this.lbltitulo.Text = "Consulta de Modificacion";
                            this.btnupdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Consulta de Eliminacion";
                            this.btndelete.Visible = true;
                            break;
                    }
                }
            }
        }
        void cargarDatos()
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_ObtenerPacienteEncargados", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IDPaciente", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtnombrePaciente.Text = row[1].ToString();
            txtapellidoPaciente.Text = row[2].ToString();
            txtedad.Text = row[3].ToString();
            txtgenero.Text = row[4].ToString();
            DateTime d = (DateTime)row[5];
            txtfechanacimiento.Text = d.ToString("dd/MM/yyyy");
            txtdireccion.Text = row[6].ToString();
            txttelefono1.Text = row[7].ToString();
            txttelefono2.Text = row[8].ToString();
            txtnombreEncargado.Text = row[13].ToString();
            txtapellidoEncargado.Text = row[14].ToString();
            txtparentesco.Text = row[15].ToString();
            txtdpi.Text = row[16].ToString();
            txttelefonoEncargado.Text = row[17].ToString();
            con.Close();

        }
        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtnombrePaciente.Text))
            {
                MostrarMensaje("Por favor, complete todos los campos antes de agregar.");
            }
            else
            {

                con.Open();

                SqlCommand command = new SqlCommand("sp_InsertarPacienteEncargado", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombres", txtnombrePaciente.Text);
                command.Parameters.AddWithValue("@Apellidos", txtapellidoPaciente.Text);
                command.Parameters.AddWithValue("@Edad", txtedad.Text);
                command.Parameters.AddWithValue("@Genero", txtgenero.Text);
                command.Parameters.AddWithValue("@FechaNacimiento", txtfechanacimiento.Text);
                command.Parameters.AddWithValue("@Direccion", txtdireccion.Text);
                command.Parameters.AddWithValue("@Telefono1", txttelefono1.Text);
                command.Parameters.AddWithValue("@Telefono2", txttelefono2.Text ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NombresEncargado", txtnombreEncargado.Text ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ApellidosEncargado", txtapellidoEncargado.Text ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Parentesco", txtparentesco.Text ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DPI", txtdpi.Text ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TelefonoEncargado", txttelefonoEncargado.Text ?? (object)DBNull.Value);

                if (command.ExecuteNonQuery() > 0)
                {
                    MostrarMensaje("Datos del Paciente agregado correctamente.");
                    con.Close();
                    /*buscar logica de redireccionamiento*/
                    // Response.Redirect("../pages/FormularioTipoDiabetes.aspx");

                }

                else
                {
                    MostrarMensaje("Ocurrió un error al agregar el Dato.");
                }

            }
        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand command = new SqlCommand("sp_ActualizarPacienteEncargado", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDPaciente", SqlDbType.Int).Value = sID;
            command.Parameters.AddWithValue("@Nombres", txtnombrePaciente.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Apellidos", txtapellidoPaciente.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Edad", txtedad.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Genero", txtgenero.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FechaNacimiento", txtfechanacimiento.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Direccion", txtdireccion.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefono1", txttelefono1.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefono2", txttelefono2.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NombresEncargado", txtnombreEncargado.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ApellidosEncargado", txtapellidoEncargado.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Parentesco", txtparentesco.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DPI", txtdpi.Text ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TelefonoEncargado", txttelefonoEncargado.Text ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarPacienteEncargado", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDPaciente", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("../pages/FormularioMedicamentos.aspx");
        }

        protected void btnvolver_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../pages/FormularioMedicamentos.aspx");
        }
        public void MostrarMensaje(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeScript", $"alert('{mensaje}');", true);
        }

    }
}