using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Form.Repository.Api.Entities;
using Form.Repository.Api.Helpers;
using Form.Repository.Api.Infrastructure;
using Form.Repository.Api.Model;
using Form.Repository.Api.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Form.Repository.Api.Repository
{
    public class HobbiesRepository : IHobbiesRepository
    {
        private readonly IHobbiesContext _contexto;
        private readonly IFormContext _context;
        private readonly AppSettings _appSettings;


        public HobbiesRepository(IFormContext context, IHobbiesContext contexto, IOptions<AppSettings> appSettings)
        {
            _contexto = contexto;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public Hobbies AddUserHobby(Hobbies hobby)
        {
            _contexto.Hobby.InsertOne(hobby);
            return hobby;
        }

        public async Task<bool> DeleteHobby(string id)
        {
            FilterDefinition<Hobbies> filter = Builders<Hobbies>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _contexto
                                                .Hobby
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}