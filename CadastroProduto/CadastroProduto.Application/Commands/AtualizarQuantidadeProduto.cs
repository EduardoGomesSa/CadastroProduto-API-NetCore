using CadastroProduto.Service.Interfaces;
using CadastroProduto.Service.Services;
using FluentValidation;
using MediatR;

namespace CadastroProduto.Application.Commands
{
    public class AtualizarQuantidadeProduto : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }

    public class ValidadorAtualizarQuantidadeProduto : AbstractValidator<AtualizarQuantidadeProduto>
    {
        private readonly IProdutoServices _produtoServices;
        public ValidadorAtualizarQuantidadeProduto(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;

            RuleFor(p => p).Must(a => _produtoServices.IdProdutoExiste(a.Id)).WithMessage("Produto não existe");
            RuleFor(c => c.QuantidadeEmEstoque).NotEmpty().NotNull().WithMessage("O campo Quantidade não pode ser nulo");
            RuleFor(c => c).Must(a => a.QuantidadeEmEstoque > 0).WithMessage("O campo Quantidade não pode ser zero");
        }
    }
}
