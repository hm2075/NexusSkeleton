using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if(LdapAuthenticate(txtUsername.Text, txtpassword.Text))
        {

             Session["Username"] = txtUsername.Text;
            Response.Redirect("Default.aspx");

        }
    }



    // authenticate against LDAP,  pass in username, password
    protected bool LdapAuthenticate(string username, string password)
    {
        // always return true
        return true;
    }
}