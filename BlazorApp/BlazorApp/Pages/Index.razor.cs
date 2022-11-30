using BlazorApp.Component;
using BlazorApp.Model;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<List> Localizer { get; set; }
    }
}
