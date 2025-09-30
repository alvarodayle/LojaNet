using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.Test
{
    [TestClass]
    public class PedidoUnitTest
    {
        [TestMethod]
        public void Incluir()
        {
            var pedido = new Pedido();

            pedido.Data = DateTime.Now;
            pedido.Cliente = new Cliente() { Id = "83e61149-c9cc-4fde-9445-fd707101ffd1", Nome = "Álvaro B. Dayle", Email = "teste@teste.com.br", Telefone = "2962-8978" };
            pedido.FormaPagamento = FormaPagamentoEnum.Dinheiro;
            pedido.Items = new List<Pedido.Item>();


            var item = new Pedido.Item();
            item.Produto = new Produto() { Id = "4c45e66e-01ef-4694-9d48-534454fd10a7", Nome = "Caderno", Preco = Convert.ToDecimal(66.60), Estoque = 10 };
            item.Quantidade = 2;
            item.Ordem = 1;
            item.Preco = 100;

            pedido.Items.Add(item);

            var dal = new PedidoDAL();
            dal.Incluir(pedido);
               
        }
    }
}
