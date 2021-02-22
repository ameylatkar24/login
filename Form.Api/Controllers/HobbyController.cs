using Microsoft.AspNetCore.Mvc;
using Form.Repository.Api.Entities;
using Form.Buisness.Api.Infrastructure;
using Form.Repository.Api.Infrastructure;
using Form.Buisness.Api.Responces;
using Form.Buisness.Api.Entities;
using System.Threading.Tasks;
using System.Linq;
using Form.Repository.Api.Model;
using System.Security.Claims;
using Form.Repository.Api.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Form.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyBuisness _buisness;
        private readonly IHobbiesRepository _repository;
        private readonly IFormRepository _repo;
        public HobbyController(IHobbiesRepository repository, IFormRepository repo)
        {
            _repository = repository;
            _repo = repo;
        }
        [Authorize]

        [HttpPost("AddLoggedUsersHobby")]
        public IActionResult AddHobby([FromBody] HobbyRequest request)
        {
            var value = (form)HttpContext.Items["form"];
            var id = value.Id;
            var Hobby = new Hobbies
            {
                Id = id,
                Hobby = request.Hobby
            };
            var responce = _repository.AddUserHobby(Hobby);
            return Ok(responce);
        }
        [HttpDelete("DeleteLoggedUsersHobby")]
        public async Task<IActionResult> DeleteProductById()
        {
            var value = (form)HttpContext.Items["form"];
            var id = value.Id;
            return Ok(await _repository.DeleteHobby(id));
        }
    }
}
