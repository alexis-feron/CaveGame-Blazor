using Microsoft.AspNetCore.Components;

namespace BlazorApp.Component
{
    public partial class Card<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> CardBody { get; set; }

        [Parameter]
        public RenderFragment CardFooter { get; set; }

        [Parameter]
        public RenderFragment<TItem> CardHeader { get; set; }

        [Parameter]
        public TItem Item { get; set; }
    }
}

