using Demo_Project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_Project.Pages
{
    public partial class Register : System.Web.UI.Page
    {

        private MySqlDbHelper dbHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbHelper = new MySqlDbHelper();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            divWarning.Visible = false;

            String name = inputName.Value;
            String surname = inputSurname.Value;
            String email = inputEmail.Value;
            String password = inputPassword.Value;
            String retypePassword = inputRetypePassword.Value;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(retypePassword))
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "All Fields should have value !";
                return;
            }

            if (password != retypePassword)
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "Passwords doesn't match !";
                return;
            }

            User user = dbHelper.InsertUser(name, surname, email, password);

            if (user != null)
            {
                Session.Timeout = 120;
                Session["userData"] = JsonConvert.SerializeObject(user);
                Response.Redirect("Home.aspx");
            }

        }
    }
}