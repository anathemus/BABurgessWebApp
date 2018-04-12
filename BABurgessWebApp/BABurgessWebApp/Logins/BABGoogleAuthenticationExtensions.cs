using System;
using Owin;

namespace BABurgessWebApp.Logins
{
    public static class BABGoogleAuthenticationExtensions
    {
        public static void UseBABGoogleAuthentication(this IAppBuilder app, BABGoogleAuthenticationOptions options = null)
        {
           if (options == null)
            {
                options = new BABGoogleAuthenticationOptions();
            }

            app.Use<BABGoogleAuthentication>(options);
        }
    }
}
