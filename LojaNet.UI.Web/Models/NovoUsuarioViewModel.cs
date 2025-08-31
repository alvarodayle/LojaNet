using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaNet.UI.Web.Models
{
    public class NovoUsuarioViewModel
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public string ConfirmarSenha { get; set; }
    }
}