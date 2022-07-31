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
        public ValidadorAtualizarPrecoProduto()
        {
            RuleFor(p => p.Preco).NotEmpty().NotNull().WithMessage("O campo Preco não pode ser vazio ou nulo");
            RuleFor(p => p).Must(a => a.Preco > 0).WithMessage("O campo Preco não pode ser zero");
        }
    }
}
