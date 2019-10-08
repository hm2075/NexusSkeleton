using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.Cookies;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // if username not present in session,  send user back to login page
        if (string.IsNullOrEmpty((string)Session["Username"]))
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            lblusername.Text = Session["Username"].ToString();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clears any cookies used by the OWIN middleware
        HttpContext.Current.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);

        Session.Clear();
        
        // should redirect based on line 16 as session now clear,   reloading page should prove session has gone
        Response.Redirect("Default.aspx");


    }
}