using System;
namespace Form.Repository.Api.Infrastructure
{
    public interface IFormDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }

    }
}