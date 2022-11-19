using BlazorApp.Model;

namespace BlazorApp.Component
{
    public class CraftingRecipe
    {
        public Item Give { get; set; }
        public List<List<string>> Have { get; set; }
    }
}
