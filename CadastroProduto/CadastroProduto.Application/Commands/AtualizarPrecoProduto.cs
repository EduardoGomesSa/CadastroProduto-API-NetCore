using CadastroProduto.Service.Interfaces;
using CadastroProduto.Service.Services;
using FluentValidation;
using MediatR;

namespace CadastroProduto.Application.Commands
{
    public class AtualizarPrecoProduto : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public decimal Preco { get; set; }
    }

    public class ValidadorAtualizarPrecoProduto : AbstractValidator<AtualizarPrecoProduto>
    {
        private readonly IProdutoServices _produtoServices;
        public ValidadorAtualizarPrecoProduto(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;

            RuleFor(p => p).Must(a => _produtoServices.IdProdutoExiste(a.Id)).WithMessage("Produto não existe");
            RuleFor(p => p.Preco).NotEmpty().NotNull().WithMessage("O campo Preco não pode ser vazio ou nulo");
            RuleFor(p => p).Must(a => a.Preco > 0).WithMessage("O campo Preco não pode ser zero");
        }
    }
}
