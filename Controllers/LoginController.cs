using login.DTOs;
using login.Repo.Login_Repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Ilogin _repo;
        public LoginController(Ilogin repo)
        {
          _repo = repo;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginAdd log)
        {
            var l = _repo.LoginFunction(log.Email, log.Password);
            return Ok(l);
        }
    }
}
