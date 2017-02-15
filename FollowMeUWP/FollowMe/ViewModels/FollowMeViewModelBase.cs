using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace FollowMe.ViewModels
{
    public class FollowMeViewModelBase : ViewModelBase
    {
        protected readonly IDialogService DialogService;
        protected readonly IFollowMeService FollowMeService;
        protected readonly INavigationService NavigationService;
        private bool _isWorking;

        public FollowMeViewModelBase(
            IDialogService dialogService,
            IFollowMeService followMeService,
            INavigationService navigationService)
        {
            DialogService = dialogService;
            FollowMeService = followMeService;
            NavigationService = navigationService;
        }

        public bool IsWorking
        {
            get { return _isWorking; }
            set { Set(ref _isWorking, value); }
        }

        protected void ShowWebResultCommunicate(WebServiceStatus status)
        {
            string message = null;
            switch (status)
            {
                case WebServiceStatus.ConnectionError:
                    message = "Service is not available.";
                    break;

                case WebServiceStatus.ServiceError:
                    message = "Internal server error.";
                    break;

                case WebServiceStatus.Unauthorized:
                    message = "Wrong login or password.";
                    break;
            }
            DialogService.ShowMessageBox(message, string.Empty);
        }
    }
}