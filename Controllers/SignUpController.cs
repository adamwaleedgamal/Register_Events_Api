using login.DTOs;
using login.Repo.Login_Repo;
using login.Repo.Signup_Repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUP _repo;
        public SignUpController(ISignUP repo)
        {
            _repo = repo;
        }
        [HttpGet("get/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { Status = false, Message = "User not found", Owner = "Cycleny" });
            }
            return Ok(user);
        }

        [HttpPost("signup")]
        public IActionResult SignUp(SignUpAdd log)
        {
            var l = _repo.SignUpFunction(log);
            return Ok(l);
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] SignUpUpadte sign)
        {
            var response = _repo.UpdateUser(id, sign);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var response = _repo.DeleteUser(id);
            return Ok(response);
        }
    }
}
