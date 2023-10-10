using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Online_Exam.Startup))]
namespace Online_Exam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
