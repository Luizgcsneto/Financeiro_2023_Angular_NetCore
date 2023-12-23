using Entities.Entidades;

namespace Domain.Interfaces.InterfacesServicos
{
    public interface IUsuarioSistemaFinanceiro 
    {
        Task CadastrarUsuarioSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
