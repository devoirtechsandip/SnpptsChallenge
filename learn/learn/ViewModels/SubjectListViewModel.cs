using Acr.UserDialogs;
using learn.Models;
using learn.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Essentials;

namespace learn.ViewModels
{
	public class SubjectListViewModel : ViewModelBase
    {
		private INavigationService _navigationService { get; }
		private IPageDialogService _dialogService { get; }

		public SubjectListViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
			_navigationService = navigationService;
			_dialogService = dialogService;
			
            QuoteClassList = new ObservableRangeCollection<QuoteClass>();
            QuoteClassList.Add(new QuoteClass { QuoteAuthor = "Malcolm X", QuoteImage = "https://images.pexels.com/photos/235985/pexels-photo-235985.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", QuoteText = "Education is the passport to the future, for tomorrow belongs to those who prepare for it today." });
            QuoteClassList.Add(new QuoteClass { QuoteAuthor = "Mark Twain", QuoteImage = "https://images.pexels.com/photos/1363876/pexels-photo-1363876.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", QuoteText = "The man who does not read books has no advantage over the one who cannot read them." });
            QuoteClassList.Add(new QuoteClass { QuoteAuthor = "Chinese proverb", QuoteImage = "https://images.pexels.com/photos/326311/pexels-photo-326311.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", QuoteText = "Teachers can open the door, but you must enter it yourself." });
            QuoteClassList.Add(new QuoteClass { QuoteAuthor = "B.B. King", QuoteImage = "https://images.pexels.com/photos/1040473/pexels-photo-1040473.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", QuoteText = "The beautiful thing about learning is that no one can take it away from you." });
            QuoteClassList.Add(new QuoteClass { QuoteAuthor = "B.B. King", QuoteImage = "https://images.pexels.com/photos/1509534/pexels-photo-1509534.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", QuoteText = "Education is the most powerful weapon you can use to change the world." });

            lstDashBoardData = new ObservableRangeCollection<tbl_SubjectMaster>();
            lstDashBoardData.Add(new tbl_SubjectMaster { ImageUrl = "https://images.pexels.com/photos/672630/pexels-photo-672630.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", Name = "Ancient Indian History" });
            lstDashBoardData.Add(new tbl_SubjectMaster { ImageUrl = "https://images.pexels.com/photos/1260801/pexels-photo-1260801.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", Name = "Modern Indian History" });
            lstDashBoardData.Add(new tbl_SubjectMaster { ImageUrl = "https://cdn.pixabay.com/photo/2017/07/31/21/35/geography-2561299_960_720.jpg", Name = "Indian Geography" });
            lstDashBoardData.Add(new tbl_SubjectMaster { ImageUrl = "https://cdn.pixabay.com/photo/2018/11/21/13/16/cash-3829601_960_720.jpg", Name = "Indian Economy" });
            

        }

        private ObservableRangeCollection<tbl_SubjectMaster> _lstDashBoardData;
		public ObservableRangeCollection<tbl_SubjectMaster> lstDashBoardData
		{
			get { return _lstDashBoardData; }
			set { SetProperty(ref _lstDashBoardData, value); }
		}

        private tbl_SubjectMaster _SubjectMaster;
        public tbl_SubjectMaster SelectedSubject
        {
            get { return _SubjectMaster; }
            set { SetProperty(ref _SubjectMaster, value); }
        }

        private DelegateCommand _SelectMenuItemCommand;
        public DelegateCommand SelectMenuItemCommand =>
            _SelectMenuItemCommand ?? (_SelectMenuItemCommand = new DelegateCommand(ExecuteSelectMenuItemCommand));

        async void ExecuteSelectMenuItemCommand()
        {
            NavigationParameters parms = new NavigationParameters();
            parms.Add("Selected_tbl_SubjectMaster", SelectedSubject);

            
        }

 

        private ObservableRangeCollection<QuoteClass> _QuoteClassList;
        public ObservableRangeCollection<QuoteClass> QuoteClassList
        {
            get { return _QuoteClassList; }
            set { SetProperty(ref _QuoteClassList, value); }
        }

    }
}
