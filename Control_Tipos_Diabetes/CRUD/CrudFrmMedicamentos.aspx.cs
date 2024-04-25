using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.CRUD
{
    public partial class CrudFrmMedicamentos : System.Web.UI.Page
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
            da.SelectCommand.Parameters.Add("@IDMedida", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtnombreMedicamento.Text = row[1].ToString();
            txtMedida.Text = row[2].ToString();
            txtDescripcion.Text = row[3].ToString();
            txtTipoDiabetes.Text = row[4].ToString();
            con.Close();

        }

        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtnombreMedicamento.Text))
            {
                MostrarMensaje("Por favor, complete todos los campos antes de agregar.");
            }
            else
            {
                con.Open();

                SqlCommand command = new SqlCommand("sp_InsertarMedicamento", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NombreMedicamento", txtnombreMedicamento.Text);
                command.Parameters.AddWithValue("@Medida", txtMedida.Text);
                command.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                command.Parameters.AddWithValue("@TipoDiabetes", txtTipoDiabetes.Text);

                if (command.ExecuteNonQuery() > 0)
                {
                    MostrarMensaje("Datos del Medicamento agregado correctamente.");
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

            SqlCommand command = new SqlCommand("sp_ActualizarMedicamento", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDMedida", SqlDbType.Int).Value = sID;
            command.Parameters.AddWithValue("@Nombres", txtnombreMedicamento.Text);
            command.Parameters.AddWithValue("@Apellidos", txtMedida.Text);
            command.Parameters.AddWithValue("@Edad", txtDescripcion.Text);
            command.Parameters.AddWithValue("@Genero", txtTipoDiabetes.Text);


            command.ExecuteNonQuery();
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarMedicamento", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = sID;
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