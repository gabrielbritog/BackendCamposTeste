using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Exceptions;
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

        //Criando um cliente
        public async Task<Cliente> Create(Cliente cliente)
        {     
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        //Pesquisando cliente via ID
        public async Task<Cliente> GetById(int id)
        {
            Cliente clienteDb = await _context.Clientes
                .SingleOrDefaultAsync(u => u.Id == id);
            if (clienteDb is null)
            {
                throw new KeyNotFoundException($"Cliente {id} não existe");
            }
            return clienteDb;
        }

        //Deletando um cliente
        public async Task Delete(int id)
        {
            Cliente clienteDb = await _context.Clientes
                .SingleOrDefaultAsync(p => p.Id == id);
            if(clienteDb is null)
            {
                throw new KeyNotFoundException($"Cliente {id} não existe");
            }

            _context.Clientes.Remove(clienteDb);
            await _context.SaveChangesAsync();
        }
        //Listando todos os clientes
        public async Task<List<Cliente>> GetAll() => await _context.Clientes.ToListAsync();
   
        //Listando clientes usando o nome como referência
        public async Task<List<Cliente>> GetByName(string nome)
        {
            List<Cliente> cliente = await _context.Clientes.Where(x => x.NmCliente.Contains(nome)).ToListAsync();
           
            if(cliente is null)
            {
                throw new KeyNotFoundException($"Cliente {nome} não existe");
            }
            return cliente;
        }
        //Atualizando dados do clientes
        public async Task Update(Cliente clienteIn, int id)
        {
            if(clienteIn.Id != id)
            {
                throw new BadRequestException("Rota incorreta");
            }
            Cliente clienteDb = await _context.Clientes
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);
            if(clienteDb is null)
            {
                throw new KeyNotFoundException($"Cliente{id} não existe");
            }
            //Atualizando estados do cliente
            _context.Entry(clienteIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
