using Form.Repository.Api.Infrastructure;
namespace Form.Repository.Api.Repository
{
    public class HobbiesDatabaseSettings : IHobbiesDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }

    }
}