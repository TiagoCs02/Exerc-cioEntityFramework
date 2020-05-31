using ExercícioEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercícioEntityFramework.Aplicacao
{
    public class ClienteAplicacao
    {

        private ApiContext _context;

        public ClienteAplicacao(ApiContext context)
        {
            _context = context;
        }

        public string InsereCliente(Cliente cliente)
        {
            try
            {
                if(cliente != null)
                {
                    _context.Add(cliente);
                    _context.SaveChanges();

                    return "Cliente cadastrado";
                }
                else
                {
                    return "Cliente inválido";
                }
            }
            catch (Exception)
            {
                return "Erro com conexão do banco";
            }
        }

        public string AtualizaCliente(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    _context.Update(cliente);
                    _context.SaveChanges();

                    return "Cliente atualizado com sucesso";
                }
                else
                {
                    return "Cliente inválido";
                }
            }
            catch (Exception)
            {
                return "Erro na conexão do banco de dados";
            }
        }
        
        public string DeletaCliente(int CodCli)
        {
            Cliente cliente = new Cliente();
            try
            {
                if (CodCli != 0)
                {
                    cliente = BuscaCliente(CodCli);

                    if (cliente != null)
                    {
                        _context.Cliente.Remove(cliente);
                        _context.SaveChanges();

                        return "Cliente " + cliente.NomeCli + " deletado";
                    }
                    else
                    {
                        return "Cliente não encontrado";
                    }
                }
                else
                {
                    return "Insira um cliente válido";
                }
            }
            catch (Exception)
            {
                return "Erro na conexão do banco de dados";
            }
        }

        public Cliente BuscaCliente(int CodCli)
        {
            Cliente cliente = new Cliente();

            cliente = _context.Cliente.Where(x => x.CodCli == CodCli).FirstOrDefault();

            if(cliente != null)
            {
                return cliente;
            }
            else
            {
                return null;
            }
        }

        public List<Cliente> BuscaClientes()
        {
            List<Cliente> ClienteList = new List<Cliente>();

            try
            {
                ClienteList = _context.Cliente.Select(x => x).ToList();

                if(ClienteList != null)
                {
                    return ClienteList;
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
