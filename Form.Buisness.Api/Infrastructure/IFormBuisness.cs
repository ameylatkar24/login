using System;
using Form.Repository.Api.Infrastructure;
using Form.Repository.Api.Entities;
using Form.Buisness.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Form.Buisness.Api.Infrastructure
{
    public interface IFormBuisness
    {
        Task<form> Register(credentials user);
        Task<IEnumerable<form>> GetAllUsers();
        Task<bool> UpdateUser(credentials value);

        Task<bool> DeleteUser(string id);

        string Identity(string a);


    }
}