using covid19.Interfaces;
using covid19.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace covid19.ViewModels
{
    public class WorldStatsPageViewModel : ViewModelBase
    {
        readonly IWorldStatsService worldStatsService;
        private int cases;
        private int deaths;
        private int recovered;
        private bool loading;
        private int todayCases;
        private int todayDeath;
        private int active;
        private int critical;
        private double casesPerOneMillion;
        private double deathsPerOneMillion;
        private int affectedCountries;
        private double testsPerOneMillion;
        private int tests;
        private ObservableCollection<WorldDataModel> worldData;

        public WorldStatsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IWorldStatsService worldStatsService)
            : base(navigationService, pageDialogService)
        {
            this.worldStatsService = worldStatsService;
            worldData = new ObservableCollection<WorldDataModel>();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            this.ExecuteAsyncTask(async () =>
            {
                await this.GetData();
            });
        }

        public ObservableCollection<WorldDataModel> WorldData
        {
            get => this.worldData;
            set => SetProperty(ref this.worldData, value);
        }

        private async Task GetData()
        {
            this.ExecuteAsyncTask(async () =>
            {
                this.Loading = true;

                var result = await this.worldStatsService.GetWorldAsync();
                Cases = result.cases;
                TodayCases = result.todayCases;
                Deaths = result.deaths;
                TodayDeath = result.todayCases;
                Active = result.active;
                Critical = result.critical;
                CasesPerOneMillion = result.casesPerOneMillion;
                DeathsPerOneMillion = result.deathsPerOneMillion;
                Tests = result.tests;
                TestsPerOneMillion = result.testsPerOneMillion;
                AffectedCountries = result.affectedCountries;
                Recovered = result.recovered;

                worldData.Clear();

                worldData.Add(new WorldDataModel { CTitle = "Total Case", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Cases) });
                worldData.Add(new WorldDataModel { CTitle = "Today Cases", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", TodayCases) });
                worldData.Add(new WorldDataModel { CTitle = "Total Deaths", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Deaths) });
                worldData.Add(new WorldDataModel { CTitle = "Today Deaths", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", TodayDeath) });
                worldData.Add(new WorldDataModel { CTitle = "Active Cases", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Active) });
                worldData.Add(new WorldDataModel { CTitle = "Today Recovered", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Recovered) });
                worldData.Add(new WorldDataModel { CTitle = "Total Tests", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Tests) });
                worldData.Add(new WorldDataModel { CTitle = "Affected Countries", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", AffectedCountries) });
                worldData.Add(new WorldDataModel { CTitle = "Cases Per One Million", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", CasesPerOneMillion) });
                worldData.Add(new WorldDataModel { CTitle = "Deaths Per One Million", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", DeathsPerOneMillion) });
                worldData.Add(new WorldDataModel { CTitle = "Tests Per One Million", Result = string.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", TestsPerOneMillion) });

                this.Loading = false;
            });
        }

        public int Cases
        {
            get => cases;
            set => SetProperty(ref cases, value);
        }

        public int TodayCases
        {
            get => todayCases;
            set => SetProperty(ref todayCases, value);
        }

        public int Deaths
        {
            get => deaths;
            set => SetProperty(ref deaths, value);
        }

        public int TodayDeath
        {
            get => todayDeath;
            set => SetProperty(ref todayDeath, value);
        }

        public int Active
        {
            get => active;
            set => SetProperty(ref active, value);
        }

        public int Critical
        {
            get => critical;
            set => SetProperty(ref critical, value);
        }

        public double CasesPerOneMillion
        {
            get => casesPerOneMillion;
            set => SetProperty(ref casesPerOneMillion, value);
        }

        public double DeathsPerOneMillion
        {
            get => deathsPerOneMillion;
            set => SetProperty(ref deathsPerOneMillion, value);
        }

        public int Tests
        {
            get => tests;
            set => SetProperty(ref tests, value);
        }

        public double TestsPerOneMillion
        {
            get => testsPerOneMillion;
            set => SetProperty(ref testsPerOneMillion, value);
        }

        public int AffectedCountries
        {
            get => affectedCountries;
            set => SetProperty(ref affectedCountries, value);
        }

        public int Recovered
        {
            get => recovered;
            set => SetProperty(ref recovered, value);
        }

        public bool Loading
        {
            get => loading;
            set => SetProperty(ref loading, value);
        }

        public DelegateCommand ReloadDataCommand => new DelegateCommand(async () => await GetData());


    }
}