using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios.Generics
{
    public class RepoitoryGenerics<T> : InterfaceGeneric<T> where T : class
    {
        private readonly DbContextOptions<ContextoBase> _optionsBuilder;
        public RepoitoryGenerics()
        {
            _optionsBuilder = new DbContextOptions<ContextoBase>();
        }
        public async Task Add(T objeto)
        {
            using (var data = new ContextoBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextoBase(_optionsBuilder))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextoBase(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextoBase(_optionsBuilder))
            {
              return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextoBase(_optionsBuilder))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }
    }
}
