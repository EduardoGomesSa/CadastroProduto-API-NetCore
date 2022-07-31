using FluentValidation;
using MediatR;

namespace CadastroProduto.Application.Commands
{
    public class DeletarProduto :IRequest<bool>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorDeletarProduto : AbstractValidator<DeletarProduto>
    {
        public ValidadorDeletarProduto()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("O campo Id não pode ser nulo ou vazio");
            RuleFor(p => p).Must(d => d.Id > 0).WithMessage("O campo Id não pode ser zero");
        }
    }
}
