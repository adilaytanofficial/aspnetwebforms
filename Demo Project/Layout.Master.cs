using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_Project
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divWarning.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            divWarning.Visible = false;

            if (String.IsNullOrEmpty(inputEmail.Value) || String.IsNullOrEmpty(inputPassword.Value))
            {
                divWarning.Visible = true;
                lblWarning.InnerText = "E-Mail or Password can't be empty !";
            }
        }
    }
}