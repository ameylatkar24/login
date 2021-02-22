using Form.Repository.Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace Form.Repository.Api.Model
{
    public class AuthenticateResponse
    {

        public string Token { get; set; }


        public AuthenticateResponse(string token)
        {
            this.Token = token;
        }
    }
}