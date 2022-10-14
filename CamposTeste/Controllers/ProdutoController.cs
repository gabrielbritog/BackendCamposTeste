using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IDefaultService<Produto> _service;
        public ProdutoController(IDefaultService<Produto> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto) => Ok(await _service.Create(produto));



        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());



        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName(string nome) => Ok(await _service.GetByName(nome));


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Produto produtoIn, int id)
        {
            await _service.Update(produtoIn, id);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}
