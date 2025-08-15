using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;

namespace LojaNet.DAL
{
    public class ProdutoDAL : IProdutosDados
    {
        private LojaContext db = new LojaContext();

        public void Alterar(Produto produto)
        {
            var produtoOrginal = ObterPorId(produto.Id);

            if (produto != null)
            {
                produtoOrginal.Nome = produto.Nome;
                produtoOrginal.Preco = produto.Preco;
                produtoOrginal.Estoque = produto.Estoque;

                db.SaveChanges();
            }
        }

        public void Excluir(string id)
        {
            var produto = ObterPorId(id);

            if(produto != null)
            {
                db.Produtos.Remove(produto);
                db.SaveChanges();
            }
        }

        public void Incluir(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        public Produto ObterPorId(string Id)
        {
            var produto = db.Produtos.Where(m => m.Id == Id).FirstOrDefault();
            return produto;
        }

        public List<Produto> ObterTodos()
        {
            return db.Produtos.ToList();
        }
    }
}
