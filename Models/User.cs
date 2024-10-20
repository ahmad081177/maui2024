using System;
namespace FinalProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName{ get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; } = false;
        public bool IsMale { get; set; } = true;

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthdate.Year;
            return age;
        }
    }
}