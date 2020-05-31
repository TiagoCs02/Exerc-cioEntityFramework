using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercícioEntityFramework.Aplicacao;
using ExercícioEntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercícioEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private ApiContext _context;

        public ClienteController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> BuscaClientes()
        {
            List<Cliente> ClienteList = new List<Cliente>();
            ClienteAplicacao ClienteAplicacao = new ClienteAplicacao(_context);
            ClienteList = ClienteAplicacao.BuscaClientes();
            return ClienteList;
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public Cliente BuscaCliente(int id)
        {
            Cliente Cliente = new Cliente();
            ClienteAplicacao ClienteAplicacao = new ClienteAplicacao(_context);
            Cliente = ClienteAplicacao.BuscaCliente(id);
            return Cliente;
        }

        // POST: api/Cliente
        [HttpPost]
        public string InsereCliente([FromForm] Cliente cliente)
        {
            ClienteAplicacao aplicacao = new ClienteAplicacao(_context);
            string resultado = aplicacao.InsereCliente(cliente);

            return resultado;

        }

        // PUT: api/Cliente/
        [HttpPut]
        public string AtualizaCliente([FromForm] Cliente cliente)
        {

            ClienteAplicacao aplicacao = new ClienteAplicacao(_context);
            string resultado = aplicacao.AtualizaCliente(cliente);

            return resultado;

        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public string DeletaCliente(int id)
        {
            ClienteAplicacao aplicacao = new ClienteAplicacao(_context);
            string resultado = aplicacao.DeletaCliente(id);

            return resultado;
        }
    }
}
