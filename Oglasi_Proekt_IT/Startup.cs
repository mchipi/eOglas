using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Oglasi_Proekt_IT.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oglasi_Proekt_IT.Startup))]
namespace Oglasi_Proekt_IT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
        }*/
    }
}
