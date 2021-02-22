using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Form.Repository.Api.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Form.Repository.Api.Model;


namespace Form.Repository.Api.Infrastructure
{
    public interface IFormRepository
    {

        Task<string> AddUser(form user);
        Task<IEnumerable<form>> GetUsers();
        Task<bool> Update(form user);
        Task<bool> Delete(string id);

        AuthenticateResponse AuthenticateUser(AuthenticateRequest model);
        string IId(string id);
        form GetUserById(string id);



    }
}