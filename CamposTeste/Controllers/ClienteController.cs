using Microsoft.AspNetCore.Mvc;
using CamposTeste.Interface;
using CamposTeste.Entities;

namespace CamposTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        //Lendo interface genérica
        private readonly IDefaultService<Cliente> _service;
        public ClienteController(IDefaultService<Cliente> service)
        {
            _service = service;
        }
        //Método Http: Post, coletando as informações pelo Body e criando cliente
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente) => Ok(await _service.Create(cliente));


        //Método Http: Get, listando todos os clientes

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        //Método Http: Get, exibir cliente com base no Id
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));

        //Método Http: Get, listando clientes com base da informação que receberá na rota
        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByName(string nome) => Ok(await _service.GetByName(nome));

        //Método Http: Put, alterando clientes com base da informação que receberá na rota

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Cliente clienteIn, int id)
        {
            await _service.Update(clienteIn, id);
            return NoContent();//Retorno sem conteúdo
        }

        //Método Http: Delete, deletando cliente com base da informação que receberá na rota

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();//Retorno sem conteúdo
        }

    }
}
