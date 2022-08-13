using CadastroProduto.Service.Interfaces;
using FluentValidation;
using MediatR;

namespace CadastroProduto.Application.Commands
{
    public class AtualizarParcialProduto : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }

    public class ValidadorAtualizarParcialProduto : AbstractValidator<AtualizarParcialProduto>
    {
        private readonly IProdutoServices _produtoServices;

        public ValidadorAtualizarParcialProduto(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;

            RuleFor(p => p).Must(a => _produtoServices.IdProdutoExiste(a.Id)).WithMessage("Produto não existe");
            RuleFor(p => p).Must(a => a.Id > 0).WithMessage("O campo Id não pode ser zero");
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("O campo Id não pode ser nulo ou vazio");
            RuleFor(p => p.Preco).NotEmpty().NotNull().WithMessage("O campo Preco não pode ser nulo ou vazio");
            RuleFor(p => p).Must(a => a.Preco > 0).WithMessage("O campo Preco não pode ser zero");
            RuleFor(p => p.QuantidadeEmEstoque).NotEmpty().NotNull().WithMessage("O campo Quantidade não pode ser nulo ou vazio");
            RuleFor(p => p).Must(a => a.QuantidadeEmEstoque > 0).WithMessage("O campo Quantidade não pode ser zero");
        }
    }
}
