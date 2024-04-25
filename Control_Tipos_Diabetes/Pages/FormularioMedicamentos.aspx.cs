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
    public partial class FormularioMedicamentos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SISTEMA_DIABETESConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }
       

        void cargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load_medicamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvmedicamentos.DataSource = dt;
            gvmedicamentos.DataBind();
            con.Close();
        }

        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?op=C");
        }

        protected void btnread_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=R");
        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=U");
        }

        protected void btndelete_ServerClick(object sender, EventArgs e)
        {
            string id;
            System.Web.UI.HtmlControls.HtmlButton BtnConsultar = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/CRUD/CrudFrmMedicamentos.aspx?id=" + id + "&op=D");
        }

        protected void gvmedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmedicamentos.PageIndex = e.NewPageIndex;
            cargarTabla(); // Llama al método para cargar los datos correspondientes a la página seleccionada
        }
    }
}