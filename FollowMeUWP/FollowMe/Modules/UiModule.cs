using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Pages;
using FollowMe.ViewModels;
using GalaSoft.MvvmLight.Views;
using Ninject.Modules;

namespace FollowMe.Modules
{
    public class UiModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<StartViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<FollowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<IDialogService>().To<DialogService>();
            Kernel.Bind<INavigationService>().ToConstant(CreateNavigationService());
        }

        private static NavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Start", typeof(StartPage));
            navigationService.Configure("Follow", typeof(FollowPage));
            return navigationService;
        }
    }
}