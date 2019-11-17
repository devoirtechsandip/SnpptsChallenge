using Acr.UserDialogs;
using learn.DBQueries;
using learn.Models;
using learn.Services;
using learn.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace learn.ViewModels
{
	public class MainPageViewModel : ViewModelBase
    {

		private INavigationService _navigationService { get; }

        private IPageDialogService _dialogService { get; }

        tbl_UserMaster_Queries _tbl_UserMaster_Queries;

		public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) :base(navigationService, dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            SignInCommand = new DelegateCommand(SignInCommandFunc);

			SignUpCommand = new DelegateCommand(SignUpCommandFunc);

			checkUserAccount();
		}


		private async void checkUserAccount()
		{

			try
			{
				_tbl_UserMaster_Queries = new tbl_UserMaster_Queries();

				var result = await _tbl_UserMaster_Queries.GetAllItems();
				if (result.Count > 0)					
					await _navigationService.NavigateAsync("/" +nameof(NavigationPage)+ "/" + nameof(TabPage));
				
			}
			catch (Exception ex)
			{
			}

		}



		public DelegateCommand SignInCommand { get; }

		public DelegateCommand SignUpCommand { get; }


		private async void SignInCommandFunc()
		{

			await _navigationService.NavigateAsync("NavigationPage/Login");
		}

		private async void SignUpCommandFunc()
		{

			await _navigationService.NavigateAsync("NavigationPage/Register");
		}


        private DelegateCommand _GSignInCommand;
        public DelegateCommand GSignInCommand =>
            _GSignInCommand ?? (_GSignInCommand = new DelegateCommand(ExecuteGSignInCommand));

        void ExecuteGSignInCommand()
        {
           

            
        }

       

      

    }
}
