using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        //Lendo interface genérica
        private readonly IDefaultService<Produto> _service;
        public ProdutoController(IDefaultService<Produto> service)
        {
            _service = service;
        }
        //Método Http: Post, coletando as informações pelo Body e criando produto

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto) => Ok(await _service.Create(produto));


        //Método Http: Get, listando todos os produtos

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        //Método Http: Get, exibir produto com base no Id
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));

        //Método Http: Get, listando produtos com base da informação que receberá na rota

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName(string nome) => Ok(await _service.GetByName(nome));

        //Método Http: Put, alterando produtos com base da informação que receberá na rota

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Produto produtoIn, int id)
        {
            await _service.Update(produtoIn, id);
            return NoContent();//Retorno sem conteúdo
        }

        //Método Http: Delete, deletando produtos com base da informação que receberá na rota

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();//Retorno sem conteúdo
        }

    }
}
