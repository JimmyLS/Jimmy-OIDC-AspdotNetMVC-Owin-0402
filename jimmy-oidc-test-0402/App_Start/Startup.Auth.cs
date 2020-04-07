using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.WsFederation;

namespace jimmy_oidc_test_0402
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);    //The auth mehtod order here is very important

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            //Use AAD for OIDC authentication
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = "7eeec2f7-335b-4736-8358-f624ff232944",
                Authority = "https://login.microsoftonline.com/common",
                PostLogoutRedirectUri = "https://localhost:44376/",     //This is where AAD will redirect back to after log out. 
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false
                }

            });

            //Use ADFS for Ws-Federation authentication
            app.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
            {
                Wtrealm = "https://localhost:44376/",
                MetadataAddress = "https://sts.azurehybrid.tk/FederationMetadata/2007-06/FederationMetadata.xml",
                Wreply = "https://localhost:44376/",
                SignOutWreply = "https://localhost:44376/"

            });
        
        }
    }
}