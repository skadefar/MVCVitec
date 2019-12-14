using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string OwnerID { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Display(Name = "Efternavn")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Fornavn")]
        [Required]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fødselsdag")]
        public DateTime Birthday { get; set; }
        
        [Display(Name = "Postnummer")]
        public int ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefonnummer")]
        public int Phonenumber { get; set; }

        /* Do we need that?
        [Display(Name = "CPR-Nummer")]
        [Required]
        public int CPR_number { get; set; }
        */

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ICollection<Abonnoment> Abonnoments { get; set; }

        public UserLevel UserIs { get; set; }
    }

    public enum UserLevel
    {
        User,
        Moderator,
        Admin
    }
}

