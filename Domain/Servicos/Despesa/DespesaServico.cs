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

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesaUsuario = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
            var despesaAnteriores = await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnteriores(emailUsuario);

            var despesasAnterioresNaoPagas = despesaAnteriores.Any() ? 
                despesaAnteriores.ToList().Sum(x => x.Valor) : 0;

            var despesasPagas = despesaUsuario
                .Where(x => x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var despesasNaoPagas = despesaUsuario
               .Where(x => !x.Pago && x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
               .Sum(x => x.Valor);

            var investimentos = despesaUsuario
               .Where(x => x.TipoDespesa == Entities.Enums.EnumTipoDespesa.Investimento)
               .Sum(x => x.Valor);

            return new
            {
                sucesso = "Ok",
                despesaUsuario = despesaUsuario,
                despesasPagas = despesasPagas,
                despesasNaoPagas = despesasNaoPagas,
                investimentos = investimentos
            };
        }
    }
}
