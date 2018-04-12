using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;

namespace BABurgessWebApp.Logins
{
    public class BABGoogleAuthenticationOptions
    {
        public OwinRequest googleOwinRequest = new OwinRequest();
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public IAppBuilder app { get; set; }

        public BABGoogleAuthenticationOptions()
        {
        }

    }
}
