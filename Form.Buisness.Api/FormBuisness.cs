using System.Threading.Tasks;
using Form.Buisness.Api.Infrastructure;
using Form.Repository.Api.Infrastructure;
using Form.Buisness.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore;
using Form.Repository.Api.Entities;
using System.Collections.Generic;

namespace Form.Buisness.Api
{
    public class FormBuisness : IFormBuisness
    {
        private readonly IFormRepository _repository;
        private readonly IMapper _mapper;
        public FormBuisness(IFormRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteUser(string id)
        {
            credentials prod = new credentials();
            var prodEntity = _mapper.Map<form>(prod);

            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<form>> GetAllUsers()
        {
            var users = await _repository.GetUsers();
            return users;
        }

        public string Identity(string a)
        {
            return a;
        }

        public async Task<form> Register(credentials user)
        {
            var prodent = _mapper.Map<form>(user);
            await _repository.AddUser(prodent);
            return prodent;


        }

        public async Task<bool> UpdateUser(credentials value)
        {
            var prodent = _mapper.Map<form>(value);
            return (await _repository.Update(prodent));

        }
    }
}