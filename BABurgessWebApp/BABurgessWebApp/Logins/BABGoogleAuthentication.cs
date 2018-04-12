using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using AppFunc = System.Func<
                      System.Collections.Generic.IDictionary<string, object>,
                      System.Threading.Tasks.Task
                            >;

namespace BABurgessWebApp.Logins
{
    public class BABGoogleAuthentication
    {
        AppFunc _next;
        BABGoogleAuthenticationOptions _options;

        public BABGoogleAuthentication(AppFunc next, BABGoogleAuthenticationOptions options)
        {
            _next = next;
            _options = options;
            _options.app = (Owin.IAppBuilder)this;
            string authenticationType = "BABGoogle";
            OwinContext _context = new OwinContext();
            AppBuilderSecurityExtensions.SetDefaultSignInAsAuthenticationType(_options.app, authenticationType);


            if (_options.googleOwinRequest.Method == null)
            {
                _options.googleOwinRequest.Method = "GET";
            }


        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            await _next(environment);
        }
    }
}
