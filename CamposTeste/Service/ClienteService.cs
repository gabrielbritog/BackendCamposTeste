using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Interface;
using Microsoft.EntityFrameworkCore;

namespace CamposTeste.Service
{
    public class ClienteService : IDefaultService<Cliente>
    {
        private readonly DataContext _context;
        public ClienteService(DataContext context) 
        {
            _context = context;
        }


        public async Task<Cliente> Create(Cliente cliente)
        {
            /*Cliente produtoDb = await _context.Clientes
                .SingleOrDefaultAsync(p => p.NmCliente == cliente.NmCliente);
            if(produtoDb is not null)
            {
                throw new Exception($"Nome já existente");
            }*/

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            Cliente clienteDb = await _context.Clientes
                .SingleOrDefaultAsync(p => p.Id == id);
            if(clienteDb is null)
            {
                throw new Exception($"Cliente{id} não existe");
            }

            _context.Clientes.Remove(clienteDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAll() => await _context.Clientes.ToListAsync();
   

        public async Task<List<Cliente>> GetByName(string nome)
        {
            List<Cliente> cliente = await _context.Clientes.Where(x => x.NmCliente.Contains(nome)).ToListAsync();
           
            if(cliente is null)
            {
                throw new Exception($"Cliente{nome} não existe");
            }
            return cliente;
        }

        public async Task Update(Cliente clienteIn, int id)
        {
            if(clienteIn.Id != id)
            {
                throw new Exception("Rota incorreta");
            }
            Cliente clienteDb = await _context.Clientes
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);
            if(clienteDb is null)
            {
                throw new Exception($"Cliente{id} não existe");
            }
            _context.Entry(clienteIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
