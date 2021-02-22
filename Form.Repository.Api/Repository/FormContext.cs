using Form.Repository.Api.Entities;
using Form.Repository.Api.Infrastructure;
using MongoDB.Driver;
namespace Form.Repository.Api.Repository
{
    public class FormContext : IFormContext
    {

        public FormContext(IFormDatabaseSettings settings)
        {



            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.Users = database.GetCollection<form>(settings.CollectionName);



        }
        public IMongoCollection<form> Users { get; set; }

    }
}