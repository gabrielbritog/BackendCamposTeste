using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Exceptions;
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

        //Criando produto
        public async Task<Produto> Create(Produto produto)
        {
        
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        //Pesquisando produto via ID
        public async Task<Produto> GetById(int id)
        {
            Produto produtoDb = await _context.Produtos
                .SingleOrDefaultAsync(u => u.Id == id);
            if (produtoDb is null)
            {
                throw new KeyNotFoundException($"Produto {id} não existe");
            }
            return produtoDb;
        }

        //Deletando produto usando o Id como base
        public async Task Delete(int id)
        {
            Produto produtoDb = await _context.Produtos
                .SingleOrDefaultAsync(p => p.Id == id);
            if(produtoDb is null)
            {
                throw new KeyNotFoundException($"Produto{id} não existe");
            }

            _context.Produtos.Remove(produtoDb);
            await _context.SaveChangesAsync();
        }
        //Listando todos os produtos
        public async Task<List<Produto>> GetAll() => await _context.Produtos.ToListAsync();
   
        //Listando produtos usando o nome como referência
        public async Task<List<Produto>> GetByName(string nome)
        {
            //Filtrando produtos
            List<Produto> produto = await _context.Produtos.Where(x => x.DscProduto.Contains(nome)).ToListAsync();
    

            if (produto is null)
            {
                throw new KeyNotFoundException($"produto {nome} não existe");
            }
            return produto;
        }
        //Atualizando produtos
        public async Task Update(Produto produtoIn, int id)
        {
            if(produtoIn.Id != id)
            {
                throw new BadRequestException("Rota incorreta");
            }
            Produto produtoDb = await _context.Produtos
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);
            if(produtoDb is null)
            {
                throw new KeyNotFoundException($"Produto {id} não existe");
            }
            //Atualizando estados do produto
            _context.Entry(produtoIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
