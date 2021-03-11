using System;
using System.ComponentModel.DataAnnotations;

//book info model, becomes the basis of the db BookModel table
namespace assignment5.Models
{
    public class BookModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorMiddleName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}(-[0-9]{10})$", ErrorMessage = "Please use the specified ISBN format")] 
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Classification { get; set; }

        public static explicit operator BookModel(Cart.CartLine v)
        {
            throw new NotImplementedException();
        }

        [Required]
        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
