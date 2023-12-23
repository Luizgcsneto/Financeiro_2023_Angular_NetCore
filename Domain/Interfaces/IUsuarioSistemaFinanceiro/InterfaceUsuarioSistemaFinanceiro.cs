﻿using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistemas(int idSistema);

        Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios);

        Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail (string emailUsuario);
    }
}
