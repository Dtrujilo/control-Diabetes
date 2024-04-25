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
    public partial class FormularioTipoDiabetes : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Llama al método para cargar los datos en tu GridView al cargar la página por primera vez
                BindGridView();
            }
        }

        void BindGridView()
        {
            SqlCommand cmd;

            // Verifica si se ordena por "sp_OrdenarTipoDiabetes"
            if (ViewState["Ordenado"] != null && (bool)ViewState["Ordenado"])
            {
                cmd = new SqlCommand("sp_OrdenarTipoDiabetes", con);
            }
            // Verifica si se ordena por "sp_ordenarporID"
            else if (ViewState["OrdenadoID"] != null && (bool)ViewState["OrdenadoID"])
            {
                cmd = new SqlCommand("sp_ordenarporID", con);
            }
            else
            {
                // Carga los datos sin ordenar
                cmd = new SqlCommand("sp_load_tipo_diabetes", con);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }
        protected void gvusuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvusuarios.PageIndex = e.NewPageIndex;
            BindGridView(); // Llama al método para cargar los datos correspondientes a la página seleccionada
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ViewState["Ordenado"] = true; // Establece el estado de ordenación a verdadero por "sp_OrdenarTipoDiabetes"
            ViewState["OrdenadoID"] = false; // Restablece el estado de ordenación por "sp_ordenarporID"
            BindGridView();
        }

        void BindGridViewOrdenado()
        {
            SqlCommand cmd = new SqlCommand("sp_OrdenarTipoDiabetes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtOrdenado = new DataTable();
            da.Fill(dtOrdenado);
            gvusuarios.DataSource = dtOrdenado;
            gvusuarios.DataBind();
            con.Close();
        }
        protected void btnordenarID_Click(object sender, EventArgs e)
        {
            ViewState["Ordenado"] = false; // Restablece el estado de ordenación por "sp_OrdenarTipoDiabetes"
            ViewState["OrdenadoID"] = true; // Establece el estado de ordenación a verdadero por "sp_ordenarporID"
            BindGridView();
        }
        void OrdenarID()
        {
            SqlCommand cmd = new SqlCommand("sp_ordenarporID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtOrdenadoID = new DataTable();
            da.Fill(dtOrdenadoID);
            gvusuarios.DataSource = dtOrdenadoID;
            gvusuarios.DataBind();
            con.Close();
        }


        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/CRUD/CrudFrmTipoDiabetes.aspx?op=C");
        }

        protected void btnread_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmTipoDiabetes.aspx?id=" + id + "&op=R");
        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmTipoDiabetes.aspx?id=" + id + "&op=U");
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmTipoDiabetes.aspx?id=" + id + "&op=D");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string parametroBusqueda = txtSearch.Text;
            DataTable dataTable = BuscarUsuarios(parametroBusqueda);
            gvusuarios.DataSource = dataTable;
            gvusuarios.DataBind();
        }
        public DataTable BuscarUsuarios(string parametroBusqueda)
        {
            DataTable dataTable = new DataTable();

            {
                using (SqlCommand command = new SqlCommand("sp_buscarDatosDiabetes", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ParametroBusqueda", parametroBusqueda);

                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }


    }
}