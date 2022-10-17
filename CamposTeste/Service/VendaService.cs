using CamposTeste.Data;
using CamposTeste.Entities;
using CamposTeste.Exceptions;
using CamposTeste.Interface;
using Microsoft.EntityFrameworkCore;

namespace CamposTeste.Service
{
    public class VendaService : IDefaultService<Venda>
    {
        //
        private readonly DataContext _context;
        public VendaService(DataContext context) 
        {
            _context = context;
        }

        //Realizando uma venda
        public async Task<Venda> Create(Venda venda)
        {
          
            DateTime now = DateTime.Now;

            Produto produto = await _context.Produtos
                .SingleOrDefaultAsync(x => x.Id == venda.ProdutoId);

            //Adicionando data atual na venda
            venda.DthVend = now;
            //Cálculo da venda
            venda.VlrTotalVenda = produto.VlrUnitario * venda.QtdVenda;
            //Incrementando o valor unitário do produto
            venda.VlrUnitarioVenda = produto.VlrUnitario;
             _context.Vendas.Add(venda);
            
            await _context.SaveChangesAsync();
            return venda;
        }

        //Pesquisando venda via ID
        public async Task<Venda> GetById(int id)
        {
            Venda vendaDb = await _context.Vendas
                .SingleOrDefaultAsync(u => u.Id == id);
            if (vendaDb is null)
            {
                throw new KeyNotFoundException($"Venda {id} não existe");
            }
            return vendaDb;
        }
        //Deletendo Venda usando usando o ID como referência
        public async Task Delete(int id)
        {
            Venda vendaDb = await _context.Vendas
                .SingleOrDefaultAsync(p => p.Id == id);
            if(vendaDb is null)
            {
                throw new KeyNotFoundException($"Venda{id} não existe");
            }

            _context.Vendas.Remove(vendaDb);
            await _context.SaveChangesAsync();
        }

        //Listando todos as vendas
        public async Task<List<Venda>> GetAll() => await _context.Vendas.ToListAsync();
   

        //Listando as vendas com base na descrição do produto ou no nome do cliente
        public async Task<List<Venda>> GetByName(string nome)
        {
            //Filtrando clientes
            List<Cliente> clienteDb = await _context.Clientes.Where(p => p.NmCliente.Contains(nome)).ToListAsync();
            //Filtrando produtos
            List<Produto> produtoDb = await _context.Produtos.Where(p => p.DscProduto.Contains(nome)).ToListAsync();
      
            //Filtrando vendas
            List<Venda> model =  _context.Vendas.ToList().Where(x => produtoDb.Any(p => x.ProdutoId == p.Id) || clienteDb.Any(c => x.ClienteId == c.Id)).ToList();


            if (model is null)
            {
                throw new KeyNotFoundException($"Venda {nome} não localizada");
            }
           

            

                return model;

            }

        //Atualizando venda
        public async Task Update(Venda vendaIn, int id)
        {
            if(vendaIn.Id != id)
            {
                throw new BadRequestException("Rota incorreta");
            }
            //Venda vendaDb = await _context.Vendas.SingleOrDefaultAsync(u => u.Id == id);
            Venda vendaDb = await _context.Vendas
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);

            Produto produto = await _context.Produtos
                .SingleOrDefaultAsync(x => x.Id == vendaIn.ProdutoId);

            if (vendaDb is null)
            {
                throw new KeyNotFoundException($"Venda {id} não existe");
            }
            vendaIn.DthVend = vendaDb.DthVend;
            vendaIn.VlrUnitarioVenda = produto.VlrUnitario;
            vendaIn.VlrTotalVenda = vendaIn.VlrUnitarioVenda * vendaIn.QtdVenda;

            //Atualizando estados da venda
            //vendaDb.DthVend = vendaIn.DthVend; ;
            _context.Entry(vendaIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
