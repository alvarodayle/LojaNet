using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    public class ProdutoBLL : IProdutosDados
    {
        private IProdutosDados dal;

        public ProdutoBLL(IProdutosDados produtoDados)
        {
            this.dal = produtoDados;
        }

        public void Validar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                throw new Exception("O nome do produto não pode ser vazio.");
            }

            if (produto.Preco < 0)
            {
                throw new Exception("O preço do produto deve ser maior que zero.");
            }
        }

        public void Alterar(Produto produto)
        {
            Validar(produto);
            dal.Alterar(produto);
        }

        public void Excluir(string Id)
        {
            dal.Excluir(Id);
        }

        public void Incluir(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }

            Validar(produto);
            dal.Incluir(produto);
        }

        public Produto ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Produto> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
