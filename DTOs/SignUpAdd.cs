using System.ComponentModel.DataAnnotations;

namespace login.DTOs
{
    public class SignUpAdd
    {
            [Required(ErrorMessage = "Name is required")]
            [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string? Email { get; set; }

            [Range(0, int.MaxValue, ErrorMessage = "User points cannot be negative")]
            public int? UserPoints { get; set; }

            [Url(ErrorMessage = "Invalid image URL format")]
            public string? ImageP { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
            public string? PhoneNum { get; set; }

            [Required(ErrorMessage = "Age is required")]
            [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
            public int? Age { get; set; }

            [Required(ErrorMessage = "Location is required")]
            public string? Location { get; set; }

            [Required(ErrorMessage = "School is required")]
            public string? School { get; set; }

            [Required(ErrorMessage = "Country is required")]
            public string? Country { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Confirm password is required")]
            [Compare("Password", ErrorMessage = "Passwords do not match")]
            public string? ConfairmPassword { get; set; }
        }
        public class SignUpUpadte
        {
                [Required(ErrorMessage = "Name is required")]
                [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
                public string? Name { get; set; }

                [Required(ErrorMessage = "Email is required")]
                [EmailAddress(ErrorMessage = "Invalid email format")]
                public string? Email { get; set; }

                [Url(ErrorMessage = "Invalid image URL format")]
                public string? ImageP { get; set; }

                [Required(ErrorMessage = "Phone number is required")]
                [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
                public string? PhoneNum { get; set; }

                [Required(ErrorMessage = "Age is required")]
                [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
                public int? Age { get; set; }

                [Required(ErrorMessage = "Location is required")]
                public string? Location { get; set; }

                [Required(ErrorMessage = "School is required")]
                public string? School { get; set; }

                [Required(ErrorMessage = "Country is required")]
                public string? Country { get; set; }

                [Required(ErrorMessage = "Password is required")]
                [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
                public string? Password { get; set; }
                public bool Status { get; set; }
                public string? Message { get; set; }
                public string? Owner { get; set; }

    }
}

