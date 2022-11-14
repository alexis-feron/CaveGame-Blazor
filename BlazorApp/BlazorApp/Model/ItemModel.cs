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
    }
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [ClassicMovie(1960)]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public Genre Genre { get; set; }

        public bool Preorder { get; set; }
    }
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Classic movies must have a release year no later than {Year}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (movie.Genre == Genre.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
