using Prism;
using Prism.Ioc;
using covid19.ViewModels;
using covid19.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using covid19.Interfaces;
using covid19.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace covid19
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MasterTabPage?selectedTab=MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterTabPage, MasterTabPageViewModel>();
            containerRegistry.RegisterForNavigation<ByCountryPage, ByCountryPageViewModel>();
            containerRegistry.RegisterForNavigation<WorldStatsPage, WorldStatsPageViewModel>();

            containerRegistry.RegisterSingleton<IWorldStatsService, WorldStatsService>();
        }
    }
}
