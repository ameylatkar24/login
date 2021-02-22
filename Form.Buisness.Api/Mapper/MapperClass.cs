using AutoMapper;
using Form.Buisness.Api.Entities;
using Form.Repository.Api.Entities;
namespace Form.Buisness.Api.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<credentials, form>();
        }
    }
}