using System.Threading.Tasks;
using Form.Buisness.Api.Infrastructure;
using Form.Repository.Api.Entities;
using Form.Repository.Api.Infrastructure;
namespace Form.Buisness.Api
{
    public class HobbyBuisness : IHobbyBuisness
    {
        private readonly IHobbiesRepository _repository;
        public HobbyBuisness(IHobbiesRepository repository)
        {
            _repository = repository;
        }


    }
}