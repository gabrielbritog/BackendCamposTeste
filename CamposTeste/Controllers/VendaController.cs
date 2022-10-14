using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {

        private readonly IDefaultService<Venda> _service;
        public VendaController(IDefaultService<Venda> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Venda venda) => Ok(await _service.Create(venda));



        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());



        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName(string nome) => Ok(await _service.GetByName(nome));


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Venda vendaIn, int id)
        {
            await _service.Update(vendaIn, id);
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
