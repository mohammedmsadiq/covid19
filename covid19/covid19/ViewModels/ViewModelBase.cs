using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace covid19.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected IPageDialogService PageDialogService { get; private set; }
        protected INavigationService NavigationService { get; private set; }
        public bool IsBusy { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        #region ExecuteAsyncTask

        protected async Task ExecuteAction(Action action)
        {
            Device.BeginInvokeOnMainThread(() => { this.IsBusy = true; });

            try
            {
                action();
            }
            catch (Exception ex)
            {
                await this.ShowErrorMessage(ex);
            }

            await Task.Delay(1000);
            Device.BeginInvokeOnMainThread(() => { this.IsBusy = false; });
        }

        protected async Task ExecuteAsyncTask(Func<Task> actionDelegate)
        {
            Device.BeginInvokeOnMainThread(() => { this.IsBusy = true; });

            try
            {
                await this.ExecuteAsyncTaskWithNoLoading(actionDelegate);
            }
            catch (Exception ex)
            {
                await this.ShowErrorMessage(ex);
            }

            Device.BeginInvokeOnMainThread(() => { this.IsBusy = false; });

        }

        protected async Task ExecuteAsyncTaskWithNoLoading(Func<Task> actionDelegate)
        {
            try
            {
                await actionDelegate();
            }
            catch (Exception ex)
            {
                await this.ShowErrorMessage(ex);
            }
        }

        protected async Task ShowErrorMessage(Exception ex)
        {
            //Dialog service, show error. 
            await this.PageDialogService.DisplayAlertAsync("Error", ex.Message, "OK");
        }


        #endregion ExecuteAsyncTask

        public virtual void Destroy()
        {

        }
    }
}
