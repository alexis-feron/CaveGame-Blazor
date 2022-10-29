using BlazorApp.Model;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;

public partial class List
{
    private List<Item> items;

    private int totalItem;

    [Inject]
    public HttpClient Http { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private async Task OnReadData(DataGridReadDataEventArgs<Item> e)
    {
        if (e.CancellationToken.IsCancellationRequested)
        {
            return;
        }

        // When you use a real API, we use this follow code
        //var response = await Http.GetJsonAsync<Item[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
        var response = (await Http.GetFromJsonAsync<Item[]>($"{NavigationManager.BaseUri}fake-data.json")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

        if (!e.CancellationToken.IsCancellationRequested)
        {
            totalItem = (await Http.GetFromJsonAsync<List<Item>>($"{NavigationManager.BaseUri}fake-data.json")).Count;
            items = new List<Item>(response); // an actual data for the current page
        }
    }
}
