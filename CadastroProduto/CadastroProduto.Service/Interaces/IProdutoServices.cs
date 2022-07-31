
using CadastroProduto.Dominio.Entidades;

namespace CadastroProduto.Service.Interaces
{
    public interface IProdutoServices
    {
        bool Adicionar(Produto produto);
        bool Deletar(Int64 id);
        bool Atualizar(Int64 id, decimal preco, int quantidade);
        bool AtualizarPreco(Int64 id, decimal preco);
        bool AtualizarQuantidadeEmEstoque(Int64 id, int quantidade);
        List<Produto> MostrarTodos();
        Produto MostrarPorId(Int64 id);
        bool CodigoProdutoExiste(string codigo);
    }
}
