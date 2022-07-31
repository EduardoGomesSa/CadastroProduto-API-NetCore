using CadastroProduto.Application.Queries;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interaces;
using MediatR;

namespace CadastroProduto.Application.Control
{
    public class ProdutoQueryHandler :  IRequestHandler<BuscarProduto, List<BuscarProduto>>,
                                        IRequestHandler<BuscarProdutoPorId, BuscarProduto>
    {
        private readonly IProdutoServices _produtoService;

        public ProdutoQueryHandler(IProdutoServices produtoService)
        {
            _produtoService = produtoService;
        }

        public Task<List<BuscarProduto>> Handle(BuscarProduto request, CancellationToken cancellationToken)
        {
            List<BuscarProduto> listaProdutos = new List<BuscarProduto>();

            foreach(var produto in _produtoService.MostrarTodos())
            {
                listaProdutos.Add(this.ConverterParaBuscarProduto(produto));
            }

            return Task.FromResult(listaProdutos);
        }

        public Task<BuscarProduto> Handle(BuscarProdutoPorId request, CancellationToken cancellationToken)
        {
            var produto = _produtoService.MostrarPorId(request.Id);

            if (produto == null) return Task.FromResult(new BuscarProduto());

            return Task.FromResult(this.ConverterParaBuscarProduto(produto));
        }

        // Converter para produto
        private BuscarProduto ConverterParaBuscarProduto(Produto produto)
        {
            return new BuscarProduto()
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                Categoria = produto.Categoria
            };
        } 
    }
}
