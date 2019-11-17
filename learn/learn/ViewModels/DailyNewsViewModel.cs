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
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace learn.ViewModels
{
    public class DailyNewsViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; }

        private IPageDialogService _dialogService { get; }
        public DailyNewsViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            GetNewsCategories();

            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "business" , ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "entertainment", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "general", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "health", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "science", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "sports", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
            //lst_tbl_NewsCategory.Add(new tbl_NewsCategory { category = "technology", ImageUrl = "https://images.pexels.com/photos/2766006/pexels-photo-2766006.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" });
        }

        private ObservableRangeCollection<tbl_NewsCategory> _lst_tbl_NewsCategory;
        public ObservableRangeCollection<tbl_NewsCategory> lst_tbl_NewsCategory
        {
            get { return _lst_tbl_NewsCategory; }
            set { SetProperty(ref _lst_tbl_NewsCategory, value); }
        }

        

        private tbl_NewsCategory _SubjectMaster;
        public tbl_NewsCategory SelectedSubject
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
            parms.Add("Selected_tbl_NewsCategory", SelectedSubject);

            await _navigationService.NavigateAsync(nameof(NewsCategory), parms);
        }

        private async Task GetNewsCategories()
        {
            UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black);

            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    var url = string.Concat(Preferences.Get("webapiurl", "test_val"), "tbl_NewsCategory/get_tbl_NewsCategory");
                    var uri = new Uri(string.Format(url, string.Empty));

                    //var jsonData = JsonConvert.SerializeObject(_tbl_Transaction);

                    //var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();

                    client.MaxResponseContentBufferSize = 256000;

                    ////for post with data
                    //var response = await client.PostAsync(uri, stringContent);

                    //for get without date
                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        //var content2 = "[{\"pk\":\"1\",\"loc\":\"Loc 1\",\"modulepk\":\"1\" }]";
                        var Items = JsonConvert.DeserializeObject<List<tbl_NewsCategory>>(content);

                        if (Items[0].category != "false")
                        {
                            lst_tbl_NewsCategory = new ObservableRangeCollection<tbl_NewsCategory>();

                            lst_tbl_NewsCategory.ReplaceRange(Items);

                            //lstDashBoardData.ReplaceRange(null);

                        }
                        else
                        {
                            //await _dialogService.DisplayAlertAsync("Error", "Error while downloading database", "OK");
                        }
                    }

                }
                else
                {
                    await _dialogService.DisplayAlertAsync("No Internet", "Please check your internet connection", "OK");
                }
            }
            catch (Exception ex)
            { }

            UserDialogs.Instance.HideLoading();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
