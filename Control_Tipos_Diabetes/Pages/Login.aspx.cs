using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Control_Tipos_Diabetes.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (IsValidCredentials(username, password))
            {
                // Autenticación exitosa
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                // Mostrar mensaje de error
                // lblError.Text = "Usuario o contraseña incorrectos";
            }
        }

        private bool IsValidCredentials(string username, string password)
        {
            // Implementa tu lógica de autenticación aquí
            // Retorna true si las credenciales son válidas, de lo contrario false
            return (username == "usuario" && password == "contraseña");
        }
    }
}