using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;
using CadastroProduto.Service.Maps;
using Shared.Data;
using Vendas.Service.Repositorios;
using static Slapper.AutoMapper;

namespace CadastroProduto.Service.Repositorios
{
    public class RepositorioProduto : RepositorioBase<Produto, ProdutoMap>, IRepositorioProduto
    {
        public bool AtualizarPreco(Int64 id, decimal preco)
        {
                var query = $"UPDATE cadastro.produto SET preco = '{preco}' WHERE id = {id};";

                return DBHelper<Produto>.InstanciaNpgsql.Get(query) != null;
        }

        public List<Produto> BuscarProdutos()
        {
            var query = $"SELECT * FROM cadastro.produto";

            return DBHelper<Produto>.InstanciaNpgsql.GetQuery(query);
        }

        public bool AtualizarQuantidade(Int64 id, int quantidade)
        {
            var query = $"UPDATE cadastro.produto SET quantidadeemestoque = '{quantidade}' WHERE id = {id};";

            return DBHelper<Produto>.InstanciaNpgsql.Get(query) != null;
        }

        public bool AtualizarProduto(long id, decimal preco, int quantidade)
        {
            var query = $"UPDATE cadastro.produto SET quantidadeemestoque = '{quantidade}', preco = '{preco}' WHERE id = {id};";

            return DBHelper<Produto>.InstanciaNpgsql.Get(query) != null;
        }

        public bool CodigoProdutoExiste(string codigo)
        {
            var query = $"select * from cadastro.produto where codigo = '{codigo}';";

            return DBHelper<Produto>.InstanciaNpgsql.GetQuery(query).Count > 0;
        }

        public bool IdProdutoExiste(long id)
        {
            var query = $"select * from cadastro.produto where id = {id};";

            return DBHelper<Produto>.InstanciaNpgsql.GetQuery(query).Count > 0;
        }

        public bool CategoriaAindaTemProduto(int idCategoria)
        {
            var query = $"select * from cadastro.produto where id_categoria = {idCategoria};";

            return DBHelper<Produto>.InstanciaNpgsql.GetQuery(query).Count > 0;
        }
    }
}
