using LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Test
{
    public class ClienteDALMock : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            
        }

        public void Excluir(string Id)
        {
            
        }

        public void Incluir(Cliente cliente)
        {

        }

        public Cliente ObterPorEmail(string email)
        {
            return null;
        }

        public Cliente ObterPorId(string Id)
        {
            return null;
        }

        public List<Cliente> ObterTodos()
        {
            return null;
        }
    }


    [TestClass]
    public class ClienteBLLTest
    {
        [TestMethod]
        public void IncluirClienteNullTest()
        {
            var cliente = new Cliente()
            {
                Nome = null,
                Email = "teste@teste.com.br",
                Telefone = "123456789"
            };

            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            var validacao = false;

            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException)
            {
                validacao = true;
            }

            Assert.IsTrue(validacao, "Deveria ter sido acionado um ApplicationException");
        }

        [TestMethod]
        public void IncluirClienteNotNullTest()
        {
            var cliente = new Cliente()
            {
                Nome = "Carlos Sanchez de Carvalho",
                Email = "teste@teste.com.br",
                Telefone = "123456789"
            };

            var dal = new ClienteDALMock();
            var bll = new ClienteBLL(dal);
            var validacao = false;

            try
            {
                bll.Incluir(cliente);
                validacao = true;
            }
            catch (ApplicationException)
            {
                validacao = false;
            }

            Assert.IsTrue(validacao, "Deveria ter sido acionado um ApplicationException");
        }
    }
}
