using Acr.UserDialogs;
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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace learn.ViewModels
{
	public class RegisterViewModel : BindableBase
	{
		private INavigationService _navigationService { get; }
		private IPageDialogService _dialogService { get; }
		public RegisterViewModel(INavigationService navigationService, IPageDialogService dialogService)
		{
			_navigationService = navigationService;
			_dialogService = dialogService;
		}

		private DelegateCommand _SignUpCommand;
		public DelegateCommand SignUpCommand =>
			_SignUpCommand ?? (_SignUpCommand = new DelegateCommand(SignUpCommandFunc));

		async void SignUpCommandFunc()
		{
            Xamarin.Forms.DependencyService.Get<IMessage>().ShortAlert("Signup Successful.");
            await _navigationService.NavigateAsync(nameof(Login));  
		}

		

		private string _txtName;
		public string txtName
		{
			get { return _txtName; }
			set { SetProperty(ref _txtName, value); }
		}

		private string _txtEmail;
		public string txtEmail
		{
			get { return _txtEmail; }
			set { SetProperty(ref _txtEmail, value); }
		}

		private string _txtMobile;
		public string txtMobile
		{
			get { return _txtMobile; }
			set { SetProperty(ref _txtMobile, value); }
		}

		private string _txtPassword;
		public string txtPassword
		{
			get { return _txtPassword; }
			set { SetProperty(ref _txtPassword, value); }
		}
	}
}
