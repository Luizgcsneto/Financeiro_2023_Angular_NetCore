using Domain.Interfaces.InterfacesServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;

namespace Domain.Servicos.UsuarioSistemaFinanceiro
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiro
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroServico(
            InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }
        public async Task CadastrarUsuarioSistema(Entities.Entidades.UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _interfaceUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
