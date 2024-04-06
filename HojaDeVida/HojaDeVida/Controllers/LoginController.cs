using HojaDeVida.Constants;
using HojaDeVida.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HojaDeVida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                //Creación del token 
                return Ok("Usuario logueado");
            }

            return NotFound("Usuario no encontrado");
        }

        private UserModel Authenticate(LoginUser userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.UserName.ToLower() == userLogin.UserName.ToLower() &&
            user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser; 
            }

            return null;
        }
    }
}
