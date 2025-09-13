using LojaNet.UI.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel credenciais)
        {
            var usuarioStore = new UserStore<IdentityUser>();
            var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);

            var usuario = usuarioGerenciador.Find(credenciais.Login, credenciais.Senha);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválida");
            }
            else
            {
                var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;
                var identidade = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);

                gerenciadorDeAutenticacao.SignIn(new AuthenticationProperties() { }, identidade);

                return RedirectToAction("Index", "Home");
            }

            return View(credenciais);
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(NovoUsuarioViewModel novo)
        {
            if (string.IsNullOrEmpty(novo.Login))
            {
                ModelState.AddModelError("", "O login é obrigatório");
            }

            if (string.IsNullOrEmpty(novo.Senha))
            {
                ModelState.AddModelError("", "A senha é obrigatória");
            }

            if (!string.IsNullOrEmpty(novo.Senha) && novo.Senha != novo.ConfirmarSenha)
            {
                ModelState.AddModelError("", "As senhas e a confirmação devem ser iguais");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioStore = new UserStore<IdentityUser>();
                    var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);
                    var usuario = new IdentityUser() { UserName = novo.Login };

                    var resultado = usuarioGerenciador.Create(usuario, novo.Senha);
                    if (resultado.Succeeded)
                    {
                        var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;
                        var identidadeUsuario = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                        gerenciadorDeAutenticacao.SignIn(new AuthenticationProperties() { }, identidadeUsuario);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(novo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}