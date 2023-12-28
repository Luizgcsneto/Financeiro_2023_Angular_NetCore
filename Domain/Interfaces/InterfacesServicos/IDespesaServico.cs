using Entities.Entidades;

namespace Domain.Interfaces.InterfacesServicos
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);
        Task AtualizarDespesa(Despesa despesa);

        Task<object> CarregaGraficos(string emailUsuario);
    }
}
