using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyThuChi.Startup))]
namespace QuanLyThuChi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
