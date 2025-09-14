using LojaNet.Models;
using LojaNet.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        [HttpPost]
        public ActionResult Incluir(PedidoViewModel pedido)
        {
                var bllProduto = AppContainer.ObterProdutoBLL();
                var bllCliente = AppContainer.ObterClienteBLL();

                pedido.Clientes = bllCliente.ObterTodos();
                pedido.Produtos = bllProduto.ObterTodos();
                pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            if (Request.Form["IncluirProduto"] == "Incluir")
            {
                var item = new PedidoViewModel.Item();
                item.ProdutoId = pedido.NovoItemProdutoId;
                item.Quantidade = pedido.NovoItemQuantidade;

                
                var produto = bllProduto.ObterPorId(item.ProdutoId);

                item.Preco = produto.Preco;
                item.ProdutoNome = produto.Nome;
                pedido.Itens.Add(item);
            }

            if (Request.Form["GravarPedido"] == "Gravar")
            {
                //var bll= AppContainer.ObterPedidoBLL();
                // Gravar o pedido
            }

            return View(pedido);
        }

        public ActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();

            var pedido = new PedidoViewModel();
            pedido.Clientes = bllCliente.ObterTodos();
            pedido.Produtos = bllProduto.ObterTodos();

            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            return View(pedido);
        }
    }
}