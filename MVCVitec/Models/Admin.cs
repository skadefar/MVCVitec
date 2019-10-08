using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace UCLVitecMV.Models
{
    public class Admin
    {
        public int AdminID { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]

        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Bruger navn")]
        [Required]
        public string User_Name { get; set; }

        [Display(Name = "Efternavn")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Fornavn")]
        [Required]
        public string FirstMidName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        [Required]
        public int Phonenumber { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public enum Position { Support, Marketing, Boss, Moderater }
    }
}
