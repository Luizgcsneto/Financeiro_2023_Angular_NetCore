﻿using Entities.Entidades;

namespace Domain.Interfaces.InterfacesServicos
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);
        Task AtualizarDespesa(Despesa despesa);
    }
}
