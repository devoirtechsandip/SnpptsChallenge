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
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace learn.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        private IPageDialogService _dialogService { get; }

        private tbl_UserMaster_Queries _tbl_UserMaster_Queries;
        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;           
        }

        private DelegateCommand _SignInCommand;
        public DelegateCommand SignInCommand =>
            _SignInCommand ?? (_SignInCommand = new DelegateCommand(SignInCommandFunc));



        private async void SignInCommandFunc()
        {
                await _navigationService.NavigateAsync("/" + nameof(NavigationPage) + "/" + nameof(TabPage));
        }

        private DelegateCommand _SignUpCommand;
        public DelegateCommand SignUpCommand =>
            _SignUpCommand ?? (_SignUpCommand = new DelegateCommand(SignUpCommandFunc));

        private async void SignUpCommandFunc()
        {
            await _navigationService.NavigateAsync(nameof(Register));
        }

        private string _txtEmail;
        public string txtEmail
        {
            get { return _txtEmail; }
            set { SetProperty(ref _txtEmail, value); }
        }

        private string _txtPassword;
        public string txtPassword
        {
            get { return _txtPassword; }
            set { SetProperty(ref _txtPassword, value); }
        }

        private DelegateCommand _GSignInCommand;
        public DelegateCommand GSignInCommand =>
            _GSignInCommand ?? (_GSignInCommand = new DelegateCommand(ExecuteGSignInCommand));



        void ExecuteGSignInCommand()
        {
            
        }

        
        
       



    }
}
