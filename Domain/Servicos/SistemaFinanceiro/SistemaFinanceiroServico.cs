using Domain.Interfaces.InterfacesServicos;
using Domain.Interfaces.ISistemaFinanceiro;

namespace Domain.Servicos.SistemaFinanceiro
{
    public class SistemaFinanceiroServico : ISistemaFinanceiro
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        public SistemaFinanceiroServico(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }
        public async Task AdicionarSistemaFinanceiro(Entities.Entidades.SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                var data = DateTime.UtcNow;
                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
            }
        }

        public async Task AtualizarSistemaFinanceiro(Entities.Entidades.SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
            {
                sistemaFinanceiro.DiaFechamento = 1;
                await _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}
