using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.SessionState;
using Microsoft.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(Startup))]

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        ConfigureAuth(app);
    }

    public void ConfigureAuth(IAppBuilder app)
    {
        app.Use((context, next) =>
        {
            var httpContext = context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);
            httpContext.SetSessionStateBehavior(SessionStateBehavior.Required);
            return next();
        });

        app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseOpenIdConnectAuthentication(
            new OpenIdConnectAuthenticationOptions
            {
                ClientId = "nexus", // we will give you a unique ID to use here
                Authority = "https://localhost", // we will give you a URL to use here
                RedirectUri = "http://localhost:60461/", // this should be the root URL of your web app
                ResponseType = "id_token",
                TokenValidationParameters = new TokenValidationParameters { NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" },
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                     SecurityTokenValidated = async context => {

                         HttpContext.Current.Session["Username"] = context.AuthenticationTicket.Identity.Name;
                         return;
                     },
                     AuthenticationFailed = async context => {

                         // Handle errors however you see fit, can redirect somewhere using the following:
                         // context.HandleResponse();
                         // HttpContext.Current.Response.Redirect("/error");

                         return;
                     }
                }
            });
    }
}
