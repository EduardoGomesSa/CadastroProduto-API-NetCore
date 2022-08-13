using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;

namespace CadastroProduto.Service.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRepositorioProduto _repositorioProduto;
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ProdutoServices(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
        {
            _repositorioProduto = repositorioProduto;
            _repositorioCategoria = repositorioCategoria;
        }

        public bool Adicionar(Produto produto)
        {
            var categoriaExiste = _repositorioCategoria.BuscarCategoriaPorNome(produto.Categoria.Nome);
            Int64 idCategoria = 0;

            if(categoriaExiste == null)
            {
                idCategoria = _repositorioCategoria.Inserir(produto.Categoria);
            }
            else
            {
                idCategoria = categoriaExiste.Id;
            }

            produto.SetIdCategoria(idCategoria);

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

            var produtoExcluido = _repositorioProduto.Excluir(produto);

            var categoriaAindaTemProdutos = _repositorioProduto.CategoriaAindaTemProduto((int)produto.IdCategoria);

            if (categoriaAindaTemProdutos == false)
            {
                var categoria = _repositorioCategoria.BuscarPorId(produto.IdCategoria);

                _repositorioCategoria.Excluir(categoria);
            }

            return produtoExcluido;
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

        public bool IdProdutoExiste(long id)
        {
            return _repositorioProduto.IdProdutoExiste(id);
        }
    }
}
