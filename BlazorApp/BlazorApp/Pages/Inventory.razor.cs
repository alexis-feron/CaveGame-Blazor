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
        Boolean sort=false;
        Boolean search = false;

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

            if (!String.IsNullOrEmpty(SearchTerm) && search == true)
            {
                DataSource = await DataService.List(e.Page, 336);
                DataSource = DataSource.FindAll(e => e.Name.StartsWith(SearchTerm));
                
            }

            else
            {
                if (String.IsNullOrEmpty(SearchTerm))
                {
                    DataSource = await DataService.List(e.Page, 336);
                }
            }
            if (sort == true)
            {
                DataSource = DataSource.OrderBy(o => o.DisplayName).ToList();
            }
            else
            {
                DataSource=DataSource.OrderBy(o => o.Id).ToList();
            }
            items = DataSource.Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();
            totalItem = DataSource.Count();
            search = false;
        }

        async Task OnInput()
        {
            search = true;
            await OnReadData(new DataGridReadDataEventArgs<Item>(DataGridReadDataMode.Paging, null, null, 1, 10, 0, 0, new CancellationToken() ));
        }

        async Task Sort()
        {
            sort = !sort;
            await OnReadData(new DataGridReadDataEventArgs<Item>(DataGridReadDataMode.Paging, null, null, 1, 10, 0, 0, new CancellationToken()));
        }
    }
}

