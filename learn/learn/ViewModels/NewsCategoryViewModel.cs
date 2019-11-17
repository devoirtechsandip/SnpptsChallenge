using learn.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using Acr.UserDialogs;
using Xamarin.Essentials;
using System.Net.Http;
using Newtonsoft.Json;
using Prism.Services.Dialogs;
using Prism.Services;
using System.Threading.Tasks;
using System.Drawing;
using Xamarin.Forms;

namespace learn.ViewModels
{
    public class NewsCategoryViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; }
        private IPageDialogService _dialogService { get; }
        public NewsCategoryViewModel(INavigationService navigationService, IPageDialogService dialogservice)
        {
            _navigationService = navigationService;
            _dialogService = dialogservice;
        }

        

        private ObservableRangeCollection<tbl_NewsMaster> _lst_tbl_NewsMaster;
        public ObservableRangeCollection<tbl_NewsMaster> lst_tbl_NewsMaster
        {
            get { return _lst_tbl_NewsMaster; }
            set { SetProperty(ref _lst_tbl_NewsMaster, value); }
        }



        private tbl_NewsCategory _Selected_tbl_NewsCategory;
        public tbl_NewsCategory Selected_tbl_NewsCategory
        {
            get { return _Selected_tbl_NewsCategory; }
            set { SetProperty(ref _Selected_tbl_NewsCategory, value); }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }


        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Selected_tbl_NewsCategory"))
            {
                Selected_tbl_NewsCategory = (tbl_NewsCategory)parameters["Selected_tbl_NewsCategory"];

                GetNewArticles(Selected_tbl_NewsCategory.pk);
            }
        }

        private async void GetNewArticles(string pk)
        {
            UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black);

            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    var url = string.Concat(Preferences.Get("webapiurl", "test_val"), "tbl_NewsMaster/get_tbl_NewsMaster?pk="+pk+"");
                    var uri = new Uri(string.Format(url, string.Empty));

                    //var jsonData = JsonConvert.SerializeObject(_tbl_Transaction);

                    //var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();

                    client.MaxResponseContentBufferSize = 256000;

                    ////for post with data
                    //var response = await client.PostAsync(uri, stringContent);

                    //for get without data
                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        //var content2 = "[{\"pk\":\"1\",\"loc\":\"Loc 1\",\"modulepk\":\"1\" }]";
                        var Items = JsonConvert.DeserializeObject<List<tbl_NewsMaster>>(content);

                        if (Items[0].title != "false")
                        {
                            lst_tbl_NewsMaster = new ObservableRangeCollection<tbl_NewsMaster>();
                            lst_tbl_NewsMaster.ReplaceRange(Items);

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

        private tbl_NewsMaster _SelectedArticle;
        public tbl_NewsMaster SelectedArticle
        {
            get { return _SelectedArticle; }
            set { SetProperty(ref _SelectedArticle, value); }
        }

        private DelegateCommand _SelectArticleCommand;
        public DelegateCommand SelectArticleCommand =>
            _SelectArticleCommand ?? (_SelectArticleCommand = new DelegateCommand(ExecuteSelectArticleCommand));

        async void ExecuteSelectArticleCommand()
        {
            await OpenBrowser(new Uri(string.Format(SelectedArticle.url, string.Empty)));
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show
                //PreferredToolbarColor = (System.Drawing.Color) Application.Current.Resources["GradientStartColor"],
                //PreferredControlColor = (System.Drawing.Color)Application.Current.Resources["ButtonWhiteBackgroundColor"]
            });
        }
    }
}
