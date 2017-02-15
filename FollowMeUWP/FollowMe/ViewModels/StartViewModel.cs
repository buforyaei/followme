using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using Domain.Model;
using Domain.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WebServices.Consts;
using WebServices.Dto;

namespace FollowMe.ViewModels
{
    public class StartViewModel : FollowMeViewModelBase
    {
        private string _codeText;

        public StartViewModel(IDialogService dialogService,
            IFollowMeService followMeService,
            INavigationService navigationService)
            : base(dialogService, followMeService, navigationService)
        {
            InitializeCommands();
        }

        public ICommand LoadCmd { get; set; }

        public ICommand FollowCmd { get; set; }
        public ICommand GetCodeCmd { get; set; }

        public string CodeText
        {
            get { return _codeText; }
            set { Set(ref _codeText, value); }
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            FollowCmd = new RelayCommand(Follow);
            GetCodeCmd = new RelayCommand(GetCode);
        }

        private void Load()
        {
            CodeText = FollowMeConsts.DeffaultCodeText;
        }

        private async void Follow()
        {
            IsWorking = true;
            int parsedCode;
            try
            {
                parsedCode = int.Parse(CodeText);
            }
            catch
            {
                IsWorking = false;
                await DialogService.ShowMessage("Code is not corrected", "Error");
                return;
            }
            var driver = await FollowMeService.GetDriverAsync(parsedCode);
            if (driver.WebServiceStatus != WebServiceStatus.Success)
            {
                IsWorking = false;
                ShowWebResultCommunicate(driver.WebServiceStatus);
                return;
            }
            if (driver.Result == null)
            {
                IsWorking = false;
                await DialogService.ShowMessage("Code is not corrected", "Error");
                return;
            }
            NavigationService.NavigateTo("Follow");
            IsWorking = false;
        }

        private async void GetCode()
        {
            IsWorking = true;
            var code = await FollowMeService.GetCodeAsync();
            if (code.WebServiceStatus != WebServiceStatus.Success)
            {
                ShowWebResultCommunicate(code.WebServiceStatus);
                CodeText = FollowMeConsts.DeffaultCodeText;
                return;
            }
            if (code.Result?.Code != null)
            {
                CodeText = code.Result.Code.ToString();
            }

            IsWorking = false;
        }
    }
}