using Demo_Project.Model;
using Newtonsoft.Json;
using System;

namespace Demo_Project
{
    public partial class Layout : System.Web.UI.MasterPage
    {

        private MySqlDbHelper dbHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            divWarning.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            divWarning.Visible = false;

            String email = inputEmail.Value;
            String password = inputPassword.Value;

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "E-Mail or Password can't be empty !";
                return;
            }

            if (email.Length < 3 || password.Length < 3)
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "E-Mail or Password have at least 3 character !";
                return;
            }

            if (dbHelper == null)
                dbHelper = new MySqlDbHelper();

            User currentUser = dbHelper.Login(email, password);


            if (currentUser != null)
            {
                Session.Timeout = 120;
                Session["userData"] = JsonConvert.SerializeObject(currentUser);
                Response.Redirect("Pages/Home.aspx");
            } else
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "E-Mail or Password incorrect !";
                return;
            }

        }
    }
}