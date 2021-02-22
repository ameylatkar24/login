using Form.Repository.Api.Entities;
using Form.Repository.Api.Infrastructure;
using MongoDB.Driver;
using Form.Repository.Api.Model;

namespace Form.Repository.Api.Repository
{
    public class HobbiesContext : IHobbiesContext
    {

        public HobbiesContext(IHobbiesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.Hobby = database.GetCollection<Hobbies>(settings.CollectionName);

        }
        public IMongoCollection<Hobbies> Hobby { get; set; }
    }
}