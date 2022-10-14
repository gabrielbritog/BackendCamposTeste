using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Interface;
using Microsoft.EntityFrameworkCore;

namespace CamposTeste.Service
{
    public class ProdutoService : IDefaultService<Produto>
    {
        private readonly DataContext _context;
        public ProdutoService(DataContext context) 
        {
            _context = context;
        }


        public async Task<Produto> Create(Produto produto)
        {
           /* Produto produtoDb = await _context.Produtos
                .SingleOrDefaultAsync(p => p.DscProduto == produto.DscProduto);
            if(produtoDb is not null)
            {
                throw new Exception($"Descrição já existente");
            }*/

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int id)
        {
            Produto produtoDb = await _context.Produtos
                .SingleOrDefaultAsync(p => p.Id == id);
            if(produtoDb is null)
            {
                throw new Exception($"Produto{id} não existe");
            }

            _context.Produtos.Remove(produtoDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAll() => await _context.Produtos.ToListAsync();
   

        public async Task<List<Produto>> GetByName(string nome)
        {

            List<Produto> produto = await _context.Produtos.Where(x => x.DscProduto.Contains(nome)).ToListAsync();
    

            if (produto is null)
            {
                throw new Exception($"produto{nome} não existe");
            }
            return produto;
        }

        public async Task Update(Produto produtoIn, int id)
        {
            if(produtoIn.Id != id)
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
            _context.Entry(produtoIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
