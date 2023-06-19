using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Entities
{
    public class Users
    {
        public Users()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }


        [MaxLength(25)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public string FullName { get => $"{FirstName} {MiddleName} {LastName}"; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
