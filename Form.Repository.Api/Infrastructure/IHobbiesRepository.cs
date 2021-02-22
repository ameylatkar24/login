using Form.Repository.Api.Infrastructure;
using Form.Repository.Api.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Form.Repository.Api.Model;
namespace Form.Repository.Api.Infrastructure
{
    public interface IHobbiesRepository
    {
        // Task<HobbyRequest> AddUserHobby(HobbyRequest request);
        Hobbies AddUserHobby(Hobbies hobby);

        Task<bool> DeleteHobby(string id);

        //   HobbyResponce NewHobby(HobbyRequest request);

    }
}