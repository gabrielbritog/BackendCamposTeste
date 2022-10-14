using CamposTeste.Entities;

namespace CamposTeste.Interface
{
    public interface IDefaultService<T>
    {
        public Task<T> Create(T classeAReceber);
        public Task<List<T>> GetByName(string nome);
        public Task<List<T>> GetAll();
        public Task Update (T classeAReceber, int id);
        public Task Delete(int id);
    }
}
