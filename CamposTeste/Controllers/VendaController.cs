using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        //Lendo interface genérica
        private readonly IDefaultService<Venda> _service;
        public VendaController(IDefaultService<Venda> service)
        {
            _service = service;
        }
        //Método Http: Post, coletando as informações pelo Body e criando venda

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Venda venda) => Ok(await _service.Create(venda));


        //Método Http: Get, listando todos as vendas
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        //Método Http: Get, exibir venda com base no Id
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));

        //Método Http: Get, listando vendas com base da informação que receberá na rota

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName([FromRoute]string nome) => Ok(await _service.GetByName(nome));

        //Método Http: Put, alterando vendas com base da informação que receberá na rota
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Venda vendaIn, int id)
        {
            await _service.Update(vendaIn, id);
            return NoContent();//Retorno sem conteúdo
        }

        //Método Http: Delete, deletando vendas com base da informação que receberá na rota

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();//Retorno sem conteúdo
        }

    }
}
