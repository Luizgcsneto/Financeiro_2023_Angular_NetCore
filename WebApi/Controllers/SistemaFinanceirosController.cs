using Domain.Interfaces.InterfacesServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceirosController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiro _iSistemaFinanceiro;
        public SistemaFinanceirosController(
            InterfaceSistemaFinanceiro interfaceSistemaFinanceiro,
            ISistemaFinanceiro iSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _iSistemaFinanceiro = iSistemaFinanceiro;
        }

        [HttpGet("/api/ListarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<Object> ListarSistemasUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListarSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiro.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiro.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinaneiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinaneiro(int id)
        {
            return _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            try
            {
                var sistema = await _interfaceSistemaFinanceiro.GetEntityById(sistemaFinanceiro.Id);

                await _interfaceSistemaFinanceiro.Delete(sistema);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
