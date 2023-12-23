using Entities.Entidades;

namespace Domain.Interfaces.InterfacesServicos
{
    public interface ISistemaFinanceiro
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}
