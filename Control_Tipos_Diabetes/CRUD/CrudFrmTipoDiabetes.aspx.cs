using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.CRUD
{
    public partial class CrudFrmTipoDiabetes : System.Web.UI.Page
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
            SqlDataAdapter da = new SqlDataAdapter("sp_read_tipo_diabetes", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txttipodiabetes.Text = row[1].ToString();
            con.Close();
        }


        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txttipodiabetes.Text))
            {
                MostrarMensaje("Por favor, complete todos los campos antes de agregar.");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("sp_create_tipo_diabetes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = txttipodiabetes.Text;
                con.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    /*logica de redireccion*/
                    MostrarMensajeYRedirigir("Diabetes agregado correctamente.", "../pages/FormularioTipoDiabetes.aspx");
                    con.Close();
                   

                }

                else
                {
                    MostrarMensaje("Ocurrió un error al agregar el Dato.");
                }
            }
            

        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update_tipo_diabetes", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = txttipodiabetes.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("../pages/FormularioTipoDiabetes.aspx");
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete_tipo_diabetes", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("../pages/FormularioTipoDiabetes.aspx");

        }

        protected void btnvolver_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../pages/FormularioTipoDiabetes.aspx");

        }
        public void MostrarMensaje(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeScript", $"alert('{mensaje}');", true);
        }
        /*mensaje de rediccion tiene que especificar*/
        public void MostrarMensajeYRedirigir(string mensaje, string url)
        {
            string script = $@"alert('{mensaje}');
                      window.location = '{url}';";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "MensajeScript", script, true);
        }


    }
}