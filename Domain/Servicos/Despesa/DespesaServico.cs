using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfacesServicos;
using Entities.Entidades;

namespace Domain.Servicos.Despesa
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Entities.Entidades.Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Mes = data.Month;
            despesa.Ano = data.Year;

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);
        }

        public async Task AtualizarDespesa(Entities.Entidades.Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }   

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Update(despesa);
        }
    }
}
