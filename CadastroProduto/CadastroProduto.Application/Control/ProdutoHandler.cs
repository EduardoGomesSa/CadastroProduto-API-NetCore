
using CadastroProduto.Application.Commands;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CadastroProduto.Application.Control
{
    public class ProdutoHandler :   IRequestHandler<AdicionarProduto, bool>,
                                    IRequestHandler<DeletarProduto, bool>,
                                    IRequestHandler<AtualizarPrecoProduto, bool>,
                                    IRequestHandler<AtualizarQuantidadeProduto, bool>,
                                    IRequestHandler<AtualizarParcialProduto, bool>
    {
        private readonly IProdutoServices _produtoServices;

        public ProdutoHandler(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        public Task<bool> Handle(AdicionarProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var produtoAdicionado = _produtoServices.Adicionar(this.ConverterParaProduto(request));

            return Task.FromResult(produtoAdicionado);
        }

        public Task<bool> Handle(DeletarProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var produtoDeletado = _produtoServices.Deletar(request.Id);

            return Task.FromResult(produtoDeletado);
        }

        public Task<bool> Handle(AtualizarPrecoProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var produtoPrecoAtualiado = _produtoServices.AtualizarPreco(request.Id, request.Preco);

            return Task.FromResult(produtoPrecoAtualiado);
        }

        public Task<bool> Handle(AtualizarQuantidadeProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var produtoQuantidadeAtualizado = _produtoServices.AtualizarQuantidadeEmEstoque(request.Id, request.QuantidadeEmEstoque);

            return Task.FromResult(produtoQuantidadeAtualizado);
        }

        public Task<bool> Handle(AtualizarParcialProduto request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var produtoAtualizado = _produtoServices.Atualizar(request.Id, request.Preco, request.QuantidadeEmEstoque);

            return Task.FromResult(produtoAtualizado);
        }

        // Conversões
        private Produto ConverterParaProduto(AdicionarProduto adicionarProduto)
        {
            return new Produto(
                                0,
                                adicionarProduto.Codigo,
                                adicionarProduto.Nome,
                                adicionarProduto.Descricao,
                                adicionarProduto.Preco,
                                adicionarProduto.QuantidadeEmEstoque,
                                0,
                                new Categoria(0, adicionarProduto.Categoria.Nome)
                               );
        }

        // Validações
        public ValidationResult ObterResultadoValidacao(AdicionarProduto adicionarProduto)
        {
            return new ValidadorAdicionarProduto(_produtoServices).Validate(adicionarProduto);
        }

        public ValidationResult ObterResultadoValidacao(DeletarProduto deletarProduto)
        {
            return new ValidadorDeletarProduto(_produtoServices).Validate(deletarProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarPrecoProduto atualizarPrecoProduto)
        {
            return new ValidadorAtualizarPrecoProduto(_produtoServices).Validate(atualizarPrecoProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarQuantidadeProduto atualizarQuantidadeProduto)
        {
            return new ValidadorAtualizarQuantidadeProduto(_produtoServices).Validate(atualizarQuantidadeProduto);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarParcialProduto atualizarParcialProduto)
        {
            return new ValidadorAtualizarParcialProduto(_produtoServices).Validate(atualizarParcialProduto);
        }
    }
}
