using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IDefaultService<Cliente> _service;
        public ClienteController(IDefaultService<Cliente> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente) => Ok(await _service.Create(cliente));



        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());



        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName(string nome) => Ok(await _service.GetByName(nome));


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Cliente clienteIn, int id)
        {
            await _service.Update(clienteIn, id);
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
