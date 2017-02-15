using Domain.Services;
using Domain.Services.Interfaces;
using Ninject.Modules;

namespace Domain.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IFollowMeService>().To<FollowMeService>().InSingletonScope();
        }
    }
}