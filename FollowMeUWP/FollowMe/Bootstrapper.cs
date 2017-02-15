using System;
using Domain.Modules;
using FollowMe.Modules;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace FollowMe
{
    public class Bootstrapper : IDisposable
    {
        public IKernel Kernel { get; set; }

        public void Dispose()
        {
            Kernel.Dispose();
        }

        public void Initialize()
        {
            Kernel = ConfigureAppKernel();
        }

        private IKernel ConfigureAppKernel()
        {
            var kernel = new StandardKernel();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                kernel.Load<WebServicesModule>();
                kernel.Load<DomainModule>();
                kernel.Load<UiModule>();
            }
            else
            {
                kernel.Load<WebServicesModule>();
                kernel.Load<DomainModule>();
                kernel.Load<UiModule>();
            }
            return kernel;
        }
    }
}