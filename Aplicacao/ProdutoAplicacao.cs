using ExercícioEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercícioEntityFramework.Aplicacao
{
    public class ProdutoAplicacao
    {
        private ApiContext _context;

        public ProdutoAplicacao(ApiContext context)
        {
            _context = context;
        }

        public string InsereProduto(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    _context.Add(produto);
                    _context.SaveChanges();

                    return "Produto cadastrado";
                }
                else
                {
                    return "Produto inválido";
                }
            }
            catch (Exception)
            {
                return "Erro com conexão do banco";
            }
        }

        public string AtualizaProduto(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    _context.Update(produto);
                    _context.SaveChanges();

                    return "Produto atualizado com sucesso";
                }
                else
                {
                    return "Produto inválido";
                }
            }
            catch (Exception)
            {
                return "Erro na conexão do banco de dados";
            }
        }

        public string DeletaProduto(int CodProd)
        {
            Produto produto = new Produto();
            try
            {
                if (CodProd != 0)
                {
                    produto = BuscaProduto(CodProd);

                    if (produto != null)
                    {
                        _context.Produto.Remove(produto);
                        _context.SaveChanges();

                        return "Produto " + produto.NomeProd + " deletado";
                    }
                    else
                    {
                        return "Produto não encontrado";
                    }
                }
                else
                {
                    return "Insira um produto válido";
                }
            }
            catch (Exception)
            {
                return "Erro na conexão do banco de dados";
            }
        }

        public Produto BuscaProduto(int CodProd)
        {
            Produto produto = new Produto();

            produto = _context.Produto.Where(x => x.CodProd == CodProd).FirstOrDefault();

            if (produto != null)
            {
                return produto;
            }
            else
            {
                return null;
            }
        }

        public List<Produto> BuscaProdutos()
        {
            List<Produto> ProdutoList = new List<Produto>();

            try
            {
                ProdutoList = _context.Produto.Select(x => x).ToList();

                if (ProdutoList != null)
                {
                    return ProdutoList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
