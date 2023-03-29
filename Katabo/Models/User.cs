namespace Katabo.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        // User Table, below are the table columns

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(50, ErrorMessage = "The username must be between 1 and 50 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "The first name must be between 1 and 50 characters long.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(50, ErrorMessage = "The last name must be between 1 and 50 characters long.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [Remote(action: "IsEmailUnique", controller: "Validation", ErrorMessage = "Email address already exists.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(50, ErrorMessage = "The password must be between 1 and 50 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        

        [Compare("Password", ErrorMessage ="Password doesnt match! Please try again")]
        public string cPassword { get; set; }


        [Required(ErrorMessage = "Please enter Birthday.")]
        public DateTime Birthday { get; set; }


        [Required(ErrorMessage = "Please enter Gender.")]
        public string Gender { get; set; }


        [Required]
        public string Role { get; set; }

        [Required(ErrorMessage ="Please enter Phone Number")]
        [Remote(action: "IsPhoneUnique", controller: "Validation", ErrorMessage = "Phone number already exists.")]
        public string PhoneNmber { get; set; }


        public int? AddressId { get; set; }
        public Address? Address { get; set; }


        // relationship between the User and Order classes
        public virtual ICollection<Order> Orders { get; set; }

    }

 
}
