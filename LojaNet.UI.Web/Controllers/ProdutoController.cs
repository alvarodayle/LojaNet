using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private IProdutosDados bll;

        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }

        public ActionResult Excluir(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Excluir(string Id, FormCollection form)
        {
            try
            {
                bll.Excluir(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(Id);
                return View(produto);
            }
        }

        public ActionResult Alterar(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Detalhes(string Id)
        {
            var cli = bll.ObterPorId(Id);
            return View(cli);
        }

        // GET: produto
        public ActionResult Incluir()
        {
            var cli = new Produto();
            return View(cli);
        }

        // POST: produto
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}