using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserModules.Data.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<UserRole> Roles { get; set; }
    }
}