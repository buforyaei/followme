using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Maps;
using Domain.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace FollowMe.ViewModels
{
    public class FollowViewModel : FollowMeViewModelBase
    {
        private MapControl _map;

        public FollowViewModel(IDialogService dialogService,
            IFollowMeService followMeService,
            INavigationService navigationService)
            : base(dialogService, followMeService, navigationService)
        {
            InitializeCommands();
        }

        public ICommand LoadCmd { get; set; }
        public ICommand ZoomMoreCmd { get; set; }
        public ICommand ZoomLessCmd { get; set; }

        public MapControl Map
        {
            get { return _map; }
            set { Set(ref _map, value); }
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand<MapControl>(Load);
            ZoomMoreCmd = new RelayCommand(ZoomMore);
            ZoomLessCmd = new RelayCommand(ZoomLess);
        }

        private void Load(MapControl map)
        {
            Map = map;
            Map.ZoomLevel = 10;
        }

        private void ZoomMore()
        {
            if (Map.ZoomLevel == Map.MaxZoomLevel) return;
            Map.ZoomLevel += 1;
        }

        private void ZoomLess()
        {
            if (Map.ZoomLevel == Map.MinZoomLevel) return;
            Map.ZoomLevel -= 1;
        }
    }
}