using Kenana.ExamTask.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kenana.ExamTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        return Ok("Authenticated");
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
