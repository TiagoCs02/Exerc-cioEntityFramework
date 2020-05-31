using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercícioEntityFramework.Models;
using ExercícioEntityFramework.Aplicacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercícioEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ApiContext _context;

        public ProdutoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> BuscaProdutos()
        {
            List<Produto> ProdutoList = new List<Produto>();
            ProdutoAplicacao ProdutoAplicacao = new ProdutoAplicacao(_context);
            ProdutoList = ProdutoAplicacao.BuscaProdutos();
            return ProdutoList;
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public Produto BuscaProduto(int id)
        {
            Produto Produto = new Produto();
            ProdutoAplicacao ProdutoAplicacao = new ProdutoAplicacao(_context);
            Produto = ProdutoAplicacao.BuscaProduto(id);
            return Produto;
        }

        // POST: api/Produto
        [HttpPost]
        public string InsereProduto([FromForm] Produto produto)
        {
            ProdutoAplicacao aplicacao = new ProdutoAplicacao(_context);
            string resultado = aplicacao.InsereProduto(produto);

            return resultado;

        }

        // PUT: api/Produto/
        [HttpPut]
        public string AtualizaProduto([FromForm] Produto produto)
        {

            ProdutoAplicacao aplicacao = new ProdutoAplicacao(_context);
            string resultado = aplicacao.AtualizaProduto(produto);

            return resultado;

        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public string DeletaProduto(int id)
        {
            ProdutoAplicacao aplicacao = new ProdutoAplicacao(_context);
            string resultado = aplicacao.DeletaProduto(id);

            return resultado;
        }
    }
}
