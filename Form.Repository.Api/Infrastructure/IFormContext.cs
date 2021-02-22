using Form.Repository.Api.Entities;
using MongoDB.Driver;

namespace Form.Repository.Api.Infrastructure
{
    public interface IFormContext
    {
        IMongoCollection<form> Users { get; }
    }
}