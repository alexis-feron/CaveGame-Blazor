using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Model
{
    public class ItemModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The display name must not exceed 50 characters.")]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name must not exceed 50 characters.")]
        [RegularExpression(@"^[a-z''-'\s]{1,40}$", ErrorMessage = "Only lowercase characters are accepted.")]
        public string Name { get; set; }

        [Required]
        [Range(1, 64)]
        public int StackSize { get; set; }

        [Required]
        [Range(1, 125)]
        public int MaxDurability { get; set; }

        public List<string> EnchantCategories { get; set; }

        public List<string> RepairWith { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms.")]
        public bool AcceptCondition { get; set; }

        [Required(ErrorMessage = "The image of the item is mandatory!")]
        public byte[] ImageContent { get; set; }

        public string ImageBase64 { get; set; }
    }
}
