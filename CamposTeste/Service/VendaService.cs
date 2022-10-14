using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Interface;
using Microsoft.EntityFrameworkCore;

namespace CamposTeste.Service
{
    public class VendaService : IDefaultService<Venda>
    {
        private readonly DataContext _context;
        public VendaService(DataContext context) 
        {
            _context = context;
        }


        public async Task<Venda> Create(Venda venda)
        {
           
            DateTime now = DateTime.Now;

            Produto produto = await _context.Produtos
                .SingleOrDefaultAsync(x => x.Id == venda.ProdutoId);

            venda.DthVend = now;
            venda.VlrTotalVenda = produto.VlrUnitario * venda.QtdVenda;
            _context.Vendas.Add(venda);
            
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task Delete(int id)
        {
            Venda vendaDb = await _context.Vendas
                .SingleOrDefaultAsync(p => p.Id == id);
            if(vendaDb is null)
            {
                throw new Exception($"Venda{id} não existe");
            }

            _context.Vendas.Remove(vendaDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Venda>> GetAll() => await _context.Vendas.ToListAsync();
   

        public async Task<List<Venda>> GetByName(string nome)
        {
           
            List<Cliente> clienteDb = await _context.Clientes.Where(p => p.NmCliente.Contains(nome)).ToListAsync();

            List<Produto> produtoDb = await _context.Produtos.Where(p => p.DscProduto.Contains(nome)).ToListAsync();

            List<Venda> model = await _context.Vendas.ToListAsync();

            model.Where(x => produtoDb.Any(p => x.ProdutoId == p.Id) || clienteDb.Any(c => x.ClienteId == c.Id));



            if (clienteDb is null && clienteDb is null)
            {
                throw new Exception($"Venda {nome} não localizada");
            }
           

            

                return model;

            }

        public async Task Update(Venda vendaIn, int id)
        {
            if(vendaIn.Id != id)
            {
                throw new Exception("Rota incorreta");
            }
            Produto produtoDb = await _context.Produtos
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);
            if(produtoDb is null)
            {
                throw new Exception($"Produto{id} não existe");
            }
            _context.Entry(vendaIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
