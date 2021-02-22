using System;
using Microsoft.AspNetCore.Mvc;
using Form.Buisness.Api.Infrastructure;
using Form.Buisness.Api.Responces;
using System.Threading.Tasks;
//using Form.Repository.Api.Entities;
using Form.Buisness.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Form.Buisness.Api.Mapper;
using Form.Repository.Api.Model;
using Form.Repository.Api.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Form.Repository.Api.Repository;
using Microsoft.Owin.Host.SystemWeb;
using System.Web;
using System.Security.Claims;
using Form.Repository.Api.Entities;
//using System.Web.HttpContext.Current;
//using System.Web.HttpContext.Current.GetOwinContext().GetUserId<GeneralExtentions>();

namespace Form.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormBuisness _buisness;
        private readonly IFormRepository _repository;
        private readonly IHobbiesRepository _repo;

        //private readonly GeneralExtentions _ge;


        public FormController(IFormBuisness buisness, IFormRepository repository, IHobbiesRepository repo)
        {
            _buisness = buisness;
            _repository = repository;
            _repo = repo;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> DisplayAllUsers()
        {
            var products = await _buisness.GetAllUsers();
            return Ok(products);
        }


        [HttpPost("Register")]
        //[ProducesResponseType(typeof(MapperClass), (int)System.Net.HttpStatusCode.Created)]

        [AllowAnonymous]
        // [Route("GetAll")]
        public async Task<ActionResult<InsertResponse>> Addnew([FromBody] credentials user)
        {
            var result = await _buisness.Register(user);
            //Console.WriteLine(result);
            if (user == null)
            {
                return Ok(new InsertResponse() { Status = false, Message = "Failed to insert!", Data = null });
            }
            return Ok(new InsertResponse() { Status = true, Message = "Request Proceeded", Data = result.ToString() });
        }
        [HttpPut("UpdateUsers")]
        public async Task<IActionResult> UpdateProductById(credentials value)
        {
            return Ok(await _buisness.UpdateUser(value));
        }
        [HttpDelete("DeleteUser/{id:length(24)}")]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _buisness.DeleteUser(id));

        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _repository.AuthenticateUser(request);
            Console.WriteLine("responce:", response);
            if (response == null)
            {
                return BadRequest(new { message = "Login failed!" });
            }

            return Ok(response);
        }
    }
}