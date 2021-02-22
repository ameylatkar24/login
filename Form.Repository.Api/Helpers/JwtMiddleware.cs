using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form.Repository.Api.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Form.Repository.Api.Entities;


namespace Form.Repository.Api.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;



        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IFormRepository _repository, IHobbiesRepository _repo)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, _repository, token, _repo);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IFormRepository _repository, string token, IHobbiesRepository _repo)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var Id = jwtToken.Claims.First(x => x.Type == "id").Value;


                //attach user to context on successful jwt validation
                context.Items["form"] = _repository.GetUserById(Id);
            }

            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}