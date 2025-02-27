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
                var claims = new List<Claim>
                {
                    new Claim("Department", "HR") // Example claim
                };

    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

    return Ok("Login successful.");
            return Ok(l);
        }
    }
}
