using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using covid19.Interfaces;
using covid19.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace covid19.ViewModels
{
    public class ByCountryPageViewModel : ViewModelBase
    {
        readonly IWorldStatsService WorldStatsService;
        private ObservableCollection<CountryModel> data;
        private bool loading;

        public ObservableCollection<CountryModel> Data { get; set; }

        public ByCountryPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IWorldStatsService worldStatsService) : base(navigationService, pageDialogService)
        {
            this.WorldStatsService = worldStatsService;
            this.Data = new ObservableCollection<CountryModel>();           
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            this.ExecuteAsyncTask(async () =>
            {
                this.GetData();
            });
        }

        public bool Loading
        {
            get
            {
                return this.loading;
            }
            set
            {
                this.SetProperty(ref this.loading, value);
            }
        }

        public DelegateCommand ReloadData => new DelegateCommand(async () => await GetData());

        private async Task GetData()
        {
            this.Loading = true;
            this.ExecuteAsyncTask(async () =>
            {
                var result = await this.WorldStatsService.GetByCountryListAsync();
                this.Data.Clear();
                if (result != null && result.Count() != 0)
                {
                    foreach (var item in result)
                    {
                        var itemToAdd = new CountryModel
                        {
                            country = item.country,
                            Flag = item.countryInfo.flag,
                            cases = item.cases,
                            todayCases = item.todayCases,
                            deaths = item.deaths,
                            todayDeaths = item.todayDeaths,
                            recovered = item.recovered,
                            active = item.active,
                            critical = item.critical,
                            casesPerOneMillion = item.casesPerOneMillion,
                            deathsPerOneMillion = item.deathsPerOneMillion,
                            tests = item.tests,
                            testsPerOneMillion = item.testsPerOneMillion,
                            continent = item.continent,
                        };
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            this.Data.Add(itemToAdd);
                        });
                    };
                }
            });
            this.Loading = false;
        }
    }
}