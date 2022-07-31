using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interaces;

namespace CadastroProduto.Service.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ProdutoServices(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public bool Adicionar(Produto produto)
        {
            return _repositorioProduto.Inserir(produto) > 0;
        }

        public bool Atualizar(long id, decimal preco, int quantidade)
        {
            return _repositorioProduto.AtualizarProduto(id, preco, quantidade);
        }

        public bool AtualizarPreco(long id, decimal preco)
        {
            return _repositorioProduto.AtualizarPreco(id, preco);
        }

        public bool AtualizarQuantidadeEmEstoque(long id, int quantidade)
        {
            return _repositorioProduto.AtualizarQuantidade(id, quantidade);
        }
        
        public bool Deletar(long id)
        {
            var produto = _repositorioProduto.BuscarPorId(id);

            return _repositorioProduto.Excluir(produto);
        }

        public Produto MostrarPorId(long id)
        {
            return _repositorioProduto.BuscarPorId(id);
        }

        public List<Produto> MostrarTodos()
        {
            return _repositorioProduto.BuscarProdutos();
        }

        // Validações
        public bool CodigoProdutoExiste(string codigo)
        {
            return _repositorioProduto.CodigoProdutoExiste(codigo);
        }
    }
}
