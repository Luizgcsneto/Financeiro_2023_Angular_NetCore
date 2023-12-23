using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfacesServicos;

namespace Domain.Servicos.Categoria
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        public CategoriaServico(
            InterfaceCategoria interfaceCategoria)
        {
            _interfaceCategoria = interfaceCategoria;
        }

        public async Task AdicionarCategoria(Entities.Entidades.Categoria categoria)
        {
            var valida = categoria.ValidaPropriedadeString(categoria.Nome,"Nome");
            if (valida)
                await _interfaceCategoria.Add(categoria);
        }

        public async Task AtualizarCategoria(Entities.Entidades.Categoria categoria)
        {
            var valida = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valida)
                await _interfaceCategoria.Update(categoria);
        }
    }
}
