using BlazorApp.Model;
using BlazorApp.Services;
using Blazored.Modal.Services;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorApp.Pages
{
    public partial class Inventory
    {

        string SearchTerm { get; set; }

        [Inject]
        public IStringLocalizer<List> Localizer { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        List<Item> items = new List<Item>();
        List<Item> DataSource = new List<Item>();

        private int totalItem;

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                DataSource = await DataService.List(e.Page, 336);
                items = await DataService.List(e.Page, e.PageSize);
                totalItem = await DataService.Count();
            }
        }

        void OnInput()
        {
            items = DataSource.FindAll(e => e.Name.StartsWith(SearchTerm));
            totalItem = items.Count();
        }
    }
}
