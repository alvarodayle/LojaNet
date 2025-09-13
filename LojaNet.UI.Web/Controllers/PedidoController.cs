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
        public ActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();

            var pedido = new PedidoViewModel();
            pedido.Clientes = bllCliente.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            return View(pedido);
        }
    }
}