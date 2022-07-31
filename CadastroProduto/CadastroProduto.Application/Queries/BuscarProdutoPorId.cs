using MediatR;

namespace CadastroProduto.Application.Queries
{
    public class BuscarProdutoPorId : IRequest<BuscarProduto>
    {
        public Int64 Id { get; set; }
    }
}
