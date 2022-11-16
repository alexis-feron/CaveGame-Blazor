using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public partial class Card
    {
        [Parameter]
        public RenderFragment CardBody { get; set; }

        [Parameter]
        public RenderFragment CardFooter { get; set; }

        [Parameter]
        public RenderFragment CardHeader { get; set; }
    }
}
