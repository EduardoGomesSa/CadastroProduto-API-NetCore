using CadastroProduto.Dominio.Entidades;

namespace CadastroProduto.Service.Interfaces
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        bool AtualizarPreco(Int64 id, decimal preco);
        List<Produto> BuscarProdutos();
        bool AtualizarQuantidade(Int64 id, int quantidade);
        bool AtualizarProduto(Int64 id, decimal preco, int quantidade);
        bool CodigoProdutoExiste(string codigo);
        bool IdProdutoExiste(Int64 id);
        bool CategoriaAindaTemProduto(int idCategoria);
    }
}
