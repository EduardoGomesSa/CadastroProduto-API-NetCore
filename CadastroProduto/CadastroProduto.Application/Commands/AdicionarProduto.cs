
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;
using FluentValidation;
using MediatR;

namespace CadastroProduto.Application.Commands
{
    public class AdicionarProduto : IRequest<bool>
    {
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public AdicionarCategoria Categoria { get; set; }
    }

    public class ValidadorAdicionarProduto : AbstractValidator<AdicionarProduto>
    {
        private readonly IProdutoServices _produtoServices;
        public ValidadorAdicionarProduto(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;

            RuleFor(p => p).Must(a => !_produtoServices.CodigoProdutoExiste(a.Codigo)).WithMessage("Codigo do produto já cadastrado");
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
            RuleFor(p => p.Nome).MinimumLength(3).MaximumLength(30).WithMessage("Nome deve conter de 3 a 30 caracteres");
            RuleFor(p => p.Codigo).NotEmpty().NotNull().WithMessage("Codigo não pode ser nulo ou vazio");
            RuleFor(p => p.Codigo).MinimumLength(5).MaximumLength(5).WithMessage("Codigo deve conter 5 caracteres");
            RuleFor(p => p.Descricao).NotEmpty().NotNull().WithMessage("Descrição não pode ser nulo ou vazio");
            RuleFor(p => p.Descricao).MinimumLength(10).MaximumLength(100).WithMessage("Descrição deve conter de 3 a 30 caracteres");
            RuleFor(p => p.Preco).NotEmpty().NotNull().WithMessage("Preço não pode ser nulo ou vazio");
            RuleFor(p => p).Must(a => a.Preco > 0).WithMessage("Preço não pode ser 0");
            RuleFor(p => p.QuantidadeEmEstoque).NotEmpty().NotNull().WithMessage("QuantidadeEmEstoque não pode ser nulo ou vazio");
            RuleFor(p => p).Must(a => a.QuantidadeEmEstoque > 0).WithMessage("QuantidadeEmEstoque não pode ser 0");

            RuleFor(p => p.Categoria.Nome).NotEmpty().NotNull().WithMessage("Categoria não pode ser nulo ou vazio");
            RuleFor(p => p.Categoria.Nome).MinimumLength(3).MaximumLength(30).WithMessage("O nome da categoria deve ser de 3 a 30 caracteres");
        }
    }
}
