using System.Collections.Generic;
using System.Threading.Tasks;
using Form.Repository.Api.Entities;
using Form.Repository.Api.Infrastructure;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Form.Repository.Api.Model;
using System.Text;
using System;
using Form.Repository.Api.Helpers;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace Form.Repository.Api.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly IFormContext _context;
        private readonly AppSettings _appSettings;

        public FormRepository(IFormContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<string> AddUser(form user)
        {
            string user_allready_exist = "User allready Exist";
            FilterDefinition<form> filter =
             Builders<form>.Filter.Eq(x => x.UserId, user.UserId);

            var newadd = _context.Users.Find(filter).FirstOrDefault();
            //Console.WriteLine(newadd);
            if (newadd == null)
            {
                await _context.Users.InsertOneAsync(user);

                return user.Id;
            }
            return user_allready_exist;
        }
        public AuthenticateResponse AuthenticateUser(AuthenticateRequest request)
        {
            FilterDefinition<form> filter = Builders<form>.Filter.And(
            Builders<form>.Filter.Eq(x => x.UserId, request.UserId),
            Builders<form>.Filter.Eq(x => x.Password, request.Password)
        );
            var user = _context.Users.Find(filter).FirstOrDefault();

            if (user == null)
            {
                return null;
            }
            else
            {
                var token = generateJwtToken(user);
                return new AuthenticateResponse(token);
            }
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<form> filter = Builders<form>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Users
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<form>> GetUsers()
        {
            return await _context.Users.Find(p => true).ToListAsync();
        }

        // [Obsolete]
        [Obsolete]
        public async Task<bool> Update(form user)
        {
            // var updateResult = await _context.Users.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user, new UpdateOptions { IsUpsert = true });

            var updateResult = await _context.Users.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user, new UpdateOptions { IsUpsert = true });

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public form GetUserById(string id)
        {
            var user = _context.Users.Find(x => x.Id == id).FirstOrDefault();
            return user;
        }
        public string IId(string id)
        {
            Console.WriteLine(id);
            return id;
        }
        private string generateJwtToken(form user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Console.WriteLine(token);
            return tokenHandler.WriteToken(token).ToString();
        }
    }
}