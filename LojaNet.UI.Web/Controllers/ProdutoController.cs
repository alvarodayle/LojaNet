using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutosDados bll;

        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}