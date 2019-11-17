
using learn.DBQueries;
using learn.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace learn.ViewModels
{
	public class ProfileViewModel : ViewModelBase
    {
		private INavigationService _navigationService { get; }
		tbl_UserMaster_Queries _tbl_UserMaster_Queries;
		public ProfileViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
			_navigationService = navigationService;
			_tbl_UserMaster_Queries = new tbl_UserMaster_Queries();
		}

		private DelegateCommand delegateCommand;
		public DelegateCommand LogoutCommand =>
			delegateCommand ?? (delegateCommand = new DelegateCommand(ExecuteLogoutCommand));

		async void ExecuteLogoutCommand()
		{
			await _tbl_UserMaster_Queries.DeleteAll();
			await _navigationService.NavigateAsync("/" + nameof(Login));

		}
	}
}
