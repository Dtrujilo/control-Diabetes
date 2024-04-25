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
    public partial class CrudFrmCitas : System.Web.UI.Page
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
                    txtfecha.TextMode = TextBoxMode.DateTime;

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
            SqlDataAdapter da = new SqlDataAdapter("sp_readCitas", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            DateTime d = (DateTime)row[1];
            txtfecha.Text = d.ToString("dd/MM/yyyy");
            txtmotivo.Text = row[2].ToString();
            txtnombre.Text = row[3].ToString();
            con.Close();
        }


        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
           
                con.Open();

                if (string.IsNullOrEmpty(txtfecha.Text) || string.IsNullOrEmpty(txtmotivo.Text) || string.IsNullOrEmpty(txtnombre.Text))
                {
                    MostrarMensaje("Por favor, complete todos los campos antes de agregar.");
                }
                else
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_InsertarCitas", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@NombrePaciente", SqlDbType.VarChar).Value = txtnombre.Text;

                            DateTime fechaCita;
                            if (DateTime.TryParse(txtfecha.Text, out fechaCita))
                            {
                                cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fechaCita;
                            }
                            else
                            {
                                MostrarMensaje("El formato de fecha no es válido.");
                                return;
                            }

                            cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtmotivo.Text;

                            // Agregar el parámetro de salida
                            SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                            resultadoParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(resultadoParam);

                            cmd.ExecuteNonQuery();

                            int resultado = (int)resultadoParam.Value;

                            if (resultado == 1)
                            {
                                MostrarMensaje("Cita agregada correctamente.");
                            }
                            else
                            {
                                MostrarMensaje("El paciente no existe.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MostrarMensaje("Error al agregar la cita: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error al agregar la cita: " + ex.Message);
                    }
                }

                con.Close();
            

        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_updateCitas", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = txtfecha.Text;
            cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtmotivo.Text;
            cmd.Parameters.Add("@Id_Paciente", SqlDbType.VarChar).Value = txtnombre.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("../pages/FormularioCitas.aspx");
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete_Citas", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("../pages/FormularioCitas.aspx");
        }

        protected void btnvolver_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../pages/FormularioCitas.aspx");
        }
        public void MostrarMensaje(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeScript", $"alert('{mensaje}');", true);
        }
    }
}