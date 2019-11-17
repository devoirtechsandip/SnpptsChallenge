using Acr.UserDialogs;
using learn.Models;
using learn.Services;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace learn.ViewModels
{
	public class LearnChatViewModel : ViewModelBase
    {

       
        public LearnChatViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {

            TestChatClass = new ObservableRangeCollection<TestChat>();
            TestChatClass.Add(new TestChat {ChatBackgroundColor = Color.FromHex("#41c9ff"), ChatCornerRadious= new CornerRadius(15, 15, 15, 0), ChatText="Hi" });
            TestChatClass.Add(new TestChat { ChatBackgroundColor = Color.FromHex("#af6dec"), ChatCornerRadious = new CornerRadius(0, 15, 15, 15), ChatText = "Welcome" });
            TestChatClass.Add(new TestChat { ChatBackgroundColor = Color.FromHex("#41c9ff"), ChatCornerRadious = new CornerRadius(15, 15, 15, 0), ChatText = "How are you ?" });
            TestChatClass.Add(new TestChat { ChatBackgroundColor = Color.FromHex("#af6dec"), ChatCornerRadious = new CornerRadius(0, 15, 15, 15), ChatText = "Doing great! Thanks for asking." });



        }



        private ObservableRangeCollection<TestChat> _testchat;
        public ObservableRangeCollection<TestChat> TestChatClass
        {
            get { return _testchat; }
            set { SetProperty(ref _testchat, value); }
        }


        


    }

    public class TestChat
    {
        public string ChatText { get; set; }
        public Color ChatBackgroundColor { get; set; }
        public CornerRadius ChatCornerRadious { get; set; }
    }
}
