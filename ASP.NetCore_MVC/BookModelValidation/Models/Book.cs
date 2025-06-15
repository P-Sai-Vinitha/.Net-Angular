using System.ComponentModel.DataAnnotations;

namespace BookModelValidation.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN cannot be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "ISBN must be a positive number")]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book Name cannot be blank")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Book Name length must be between 1 and 20 characters")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author Name cannot be blank")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author Name length must be between 1 and 50 characters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Published Date is required")]
        [PublishedDateValidation(ErrorMessage = "Published date cannot be in the future")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Book URL is required")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string BookUrl { get; set; }
    }
}
