using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.WsFederation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jimmy_oidc_test_0402.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public void SignIn()
        {
            //Send an OpenID Connect sign-in request
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
                {
                    RedirectUri = "/"    //Not OIDC/OAuth2 RedirectUri parameter. This is a OWIN parameter and here the redireturi is a local URI
                },
                //OpenIdConnectAuthenticationDefaults.AuthenticationType

                //Send Ws-federation sign in request
                WsFederationAuthenticationDefaults.AuthenticationType
                );
                
            }
        
        }

        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(

                //OpenIdConnectAuthenticationDefaults.AuthenticationType,     //OIDC logout, send logout request to AAD

                WsFederationAuthenticationDefaults.AuthenticationType,      //Ws-federation logout

                CookieAuthenticationDefaults.AuthenticationType             //clear cookie

            );
        }
    }
}