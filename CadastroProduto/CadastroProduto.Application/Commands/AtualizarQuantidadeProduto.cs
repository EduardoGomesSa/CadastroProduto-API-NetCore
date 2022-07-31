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
        public ValidadorAtualizarQuantidadeProduto()
        {
            RuleFor(c => c.QuantidadeEmEstoque).NotEmpty().NotNull().WithMessage("O campo Quantidade não pode ser nulo");
            RuleFor(c => c).Must(a => a.QuantidadeEmEstoque > 0).WithMessage("O campo Quantidade não pode ser zero");
        }
    }
}
