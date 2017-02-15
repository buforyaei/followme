using Ninject.Modules;
using WebServices.Services;
using WebServices.Services.Interfaces;

namespace Domain.Modules
{
    public class WebServicesModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IFollowMeWebService>().To<FollowMeWebService>().InSingletonScope();
        }
    }
}