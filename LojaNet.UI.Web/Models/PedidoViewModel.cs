using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaNet.UI.Web.Models
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.Clientes = new List<Cliente>();
            this.Produtos = new List<Produto>();
            this.Itens = new List<Item>();
            this.FormasPagamento = new List<string>();
            this.Data = DateTime.Now;
        }

        public DateTime Data { get; set; }

        public List<Cliente> Clientes { get; set; }

        public string ClienteId { get; set; }

        public List<Item> Itens { get; set; }

        public List<Produto> Produtos { get; set; }

        public FormaPagamentoEnum FormaPagamento { get; set; }

        public List<string> FormasPagamento { get; set; }

        public class Item
        {
            public int Quantidade { get; set; }
            public string ProdutoId { get; set; }
            public string ProdutoNome { get; set; }
            public decimal Preco { get; set; }
            public decimal Total { get { return Quantidade * Preco; } }
        }

    }
}