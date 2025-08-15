using LojaNet.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LojaNet.Test
{
    [TestClass]
    public class ClienteDALTest
    {
        [TestMethod]
        public void ObterPorEmailNullTest()
        {
            string email = null;

            var dal = new ClienteDAL();
            bool validacao = false;

            try
            {
                var cliente = dal.ObterPorEmail(email);
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "O e-mail deve ser informado")
                {
                    validacao = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Parâmetro não informado: " + ex.Message);
            }

            Assert.IsTrue(validacao, "Deveria ter sido gerado um ApplicationException");
        }

        [TestMethod]
        public void ObterPorEmailTest()
        {
            string email = "teste2@teste.com.br";

            var dal = new ClienteDAL();
            var cliente = dal.ObterPorEmail(email);

            if (cliente != null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente.Id);
                Console.WriteLine(cliente.Nome);
                Console.WriteLine(cliente.Email);
                Console.WriteLine(cliente.Telefone);
            }

            Assert.IsTrue(cliente != null, "Cliente não encontrado");
        }
    }
}
