using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.DAL;
using LojaNet.Models;

namespace LojaNet.Test
{

    [TestClass]
    public class ProdutoDALTest
    {
        [TestMethod]
        public void IncluirTest()
        {
            var p = new Produto()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Produto Simples",
                Preco = 5.00m,
                Estoque = 500
            };

            var dal = new ProdutoDAL();
            dal.Incluir(p);

            var produto = dal.ObterPorId(p.Id);

            Assert.IsTrue(produto != null, "Erro na inclusão");
        }

        [TestMethod]
        public void AlterarTest()
        {
            var p = new Produto()
            {
                Id = "4a4856da-3198-49c2-9f13-4f3fc1586786",
                Nome = "Produto Alterado",
                Preco = 200.00m,
                Estoque = 1000
            };

            var dal = new ProdutoDAL();
            dal.Alterar(p);

            var produto = dal.ObterPorId(p.Id);

            Assert.IsTrue(produto.Nome == "Produto Alterado", "Erro na alteração");
        }

        [TestMethod]
        public void ExcluirTest()
        {
            var p = new Produto()
            {
                Id = "4a4856da-3198-49c2-9f13-4f3fc1586786"
            };

            var dal = new ProdutoDAL();
            dal.Excluir(p.Id);

            var produto = dal.ObterPorId(p.Id);

            Assert.IsTrue(produto == null, "Erro na exclusão");
        }

        [TestMethod]
        public void ListarTest()
        {
            var dal = new ProdutoDAL();
            var lista = dal.ObterTodos();
            foreach (var p in lista)
            {
                Console.WriteLine("Id: " + p.Id);
                Console.WriteLine("Nome: " + p.Nome);
                Console.WriteLine("Preço: " + p.Preco);
                Console.WriteLine("Estoque: " + p.Estoque);
                Console.WriteLine("-----------------------");
            }
            Assert.IsTrue(lista.Count > 0, "Lista vazia");
        }

    }
}
