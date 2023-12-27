using Domain.Interfaces.InterfacesServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiro _iUsuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroController(
            InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiro iUsuarioSistemaFinanceiro
            )
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _iUsuarioSistemaFinanceiro = iUsuarioSistemaFinanceiro;
        }

        [HttpGet("/api/ListarUsuarioSistemas")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarioSistemas(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuarioSistemas(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioSistema(int idSistema, 
                                                          string emailUsuario)
        {
            try
            {
                await _iUsuarioSistemaFinanceiro.CadastrarUsuarioSistema(
               new UsuarioSistemaFinanceiro
               {
                   IdSistema = idSistema,
                   EmailUsuario = emailUsuario,
                   Administrador = false,
                   SistemaAtual = true
               });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeletarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> DeletarUsuarioSistema(int id)
        {
            try
            {
               var usuarioSistema = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistema);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
