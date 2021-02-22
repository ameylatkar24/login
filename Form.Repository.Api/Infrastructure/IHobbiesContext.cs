using Form.Repository.Api.Entities;
using MongoDB.Driver;
using Form.Repository.Api.Model;
namespace Form.Repository.Api.Infrastructure
{
    public interface IHobbiesContext
    {
        IMongoCollection<Hobbies> Hobby { get; }

    }
}