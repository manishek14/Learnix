using System;

namespace UserModules.Core.DTOs
{
    public class RegisterUserCommand
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommand
    {
        public string PhoneNumber { get; set; } // ورود با موبایل
        public string Password { get; set; }
    }

    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}