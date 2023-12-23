using Domain.Interfaces.Generics;

namespace Infra.Repositorios.Generics
{
    public class RepoitoryGenerics<T> : InterfaceGeneric<T> where T : class
    {
        public async Task Add(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public async Task Update(T objeto)
        {
            throw new NotImplementedException();
        }
    }
}
