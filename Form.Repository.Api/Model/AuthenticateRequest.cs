using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Form.Repository.Api.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }



    }
}