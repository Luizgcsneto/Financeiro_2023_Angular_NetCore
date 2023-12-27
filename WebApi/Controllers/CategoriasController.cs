using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfacesServicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private ICategoriaServico _iCategoriaServico;
        public CategoriasController(InterfaceCategoria interfaceCategoria,
                ICategoriaServico iCategoriaServico)
        {
            _interfaceCategoria = interfaceCategoria;
            _iCategoriaServico = iCategoriaServico;
        }

        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }
    }
}
