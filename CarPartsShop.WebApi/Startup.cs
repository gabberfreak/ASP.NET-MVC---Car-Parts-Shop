using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarPartsShop.WebApi.Startup))]
namespace CarPartsShop.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
