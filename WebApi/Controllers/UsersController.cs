using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) ||
                string.IsNullOrWhiteSpace(input.Senha) ||
                string.IsNullOrWhiteSpace(input.CPF))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.Email,
                CPF = input.CPF
            };

            var result = await _userManager.CreateAsync(user, input.Senha);
            if (result.Errors.Any()) 
            {
                return Ok(result.Errors);
            }


            //geração de confirmação
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


            //retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_retorn = await _userManager.ConfirmEmailAsync(user, code); 

            if (response_retorn.Succeeded)
            {
                return Ok("Usuário Adicionado");
            } else
            {
                return Ok("Erro ao cadastrar Usuário");
            }
        }
    }
}
