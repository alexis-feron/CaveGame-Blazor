using BlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Component
{
    public partial class ShowItems<TItem>
    {
        [Parameter]
        public List<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> ShowTemplate { get; set; }
    }
}
