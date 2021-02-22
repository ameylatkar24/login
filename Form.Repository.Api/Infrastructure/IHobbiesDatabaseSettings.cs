namespace Form.Repository.Api.Infrastructure
{
    public interface IHobbiesDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }

    }
}