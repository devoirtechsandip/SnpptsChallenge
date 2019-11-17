using Prism;
using Prism.Ioc;
using learn.ViewModels;
using learn.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace learn
{
	public partial class App : PrismApplication
    {

        //protected override IContainerExtension CreateContainerExtension() => PrismContainerExtension.Current;

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */


        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
		{

            //Testing new branch

			InitializeComponent();		

            await NavigationService.NavigateAsync(nameof(MainPage));

            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
            

            containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LearnChat, LearnChatViewModel>();
            containerRegistry.RegisterForNavigation<Profile, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<SubjectList, SubjectListViewModel>();




                     containerRegistry.RegisterForNavigation<TabPage, TabPageViewModel>();
           
            containerRegistry.RegisterForNavigation<UserAccount, UserAccountViewModel>();
           
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Register, RegisterViewModel>();
           
            containerRegistry.RegisterForNavigation<DailyNews, DailyNewsViewModel>();
            containerRegistry.RegisterForNavigation<NewsCategory, NewsCategoryViewModel>();
        }
	}
}
