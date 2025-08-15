using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;
using System.Data;

namespace LojaNet.BLL
{
    public class ClienteBLL : IClienteDados
    {
        private IClienteDados dal;

        public ClienteBLL(IClienteDados clientedados)
        {
            this.dal = clientedados;
        }

        public void Alterar(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new Exception("O Id deve ser informado");
            }

            dal.Alterar(cliente);
        }

        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O Id deve ser informado");
            }

            dal.Excluir(Id);
        }

        public void Incluir(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(cliente);
        }

        private static void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome deve ser informado!");
            }
            if (string.IsNullOrEmpty(cliente.Email))
            {
                throw new ApplicationException("O email deve ser informado!");
            }
            if (string.IsNullOrEmpty(cliente.Telefone))
            {
                throw new ApplicationException("O telefone deve ser informado!");
            }
        }

        public Cliente ObterPorEmail(string email)
        {
            return dal.ObterPorEmail(email);
        }

        public Cliente ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Cliente> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
