using System;
using Form.Repository.Api.Infrastructure;
namespace Form.Repository.Api.Repository
{
    public class FormDatabaseSettings : IFormDatabaseSettings
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}