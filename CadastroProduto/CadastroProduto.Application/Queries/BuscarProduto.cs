using MediatR;

namespace CadastroProduto.Application.Queries
{
    public class BuscarProduto : IRequest<List<BuscarProduto>>
    {
        public Int64 Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string? Categoria { get; set; }
    }
}
