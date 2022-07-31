using CadastroProduto.Application.Commands;
using CadastroProduto.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AdicionarProduto adicionarProduto)
        {
            try
            {
                var produtoAdicionado = await _mediator.Send(adicionarProduto);

                if (produtoAdicionado) return Ok(produtoAdicionado);

                return BadRequest(produtoAdicionado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var produtoDeletado = await _mediator.Send(new DeletarProduto() { Id = id });

                if (produtoDeletado) return Ok(produtoDeletado);

                return BadRequest(produtoDeletado);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Int64 id, [FromBody] decimal preco, int quantidade)
        {
            try
            {
                var produtoAtualizado = await _mediator.Send(new AtualizarParcialProduto() { Id = id, Preco = preco, QuantidadeEmEstoque = quantidade });

                if (produtoAtualizado) return Ok();

                return BadRequest(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        } 

        [HttpPatch("patchpreco")]
        public async Task<IActionResult> PatchPreco(Int64 id, [FromBody] decimal preco)
        {
            try
            {
                var produtoAtualizado = await _mediator.Send(new AtualizarPrecoProduto() { Id = id, Preco = preco });

                if (produtoAtualizado) return Ok(produtoAtualizado);

                return BadRequest(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("patchquantidadeemestoque")]
        public async Task<IActionResult> PatchQuantidadeEmEstoque(Int64 id, [FromBody] int quantidade)
        {
            try
            {
                var produtoAtualizado = await _mediator.Send(new AtualizarQuantidadeProduto() { Id = id, QuantidadeEmEstoque = quantidade });

                if (produtoAtualizado) return Ok(produtoAtualizado);

                return BadRequest(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _mediator.Send(new BuscarProduto());

                if (produtos.Count > 0) return Ok(produtos);

                return NotFound(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            try
            {
                var produto = await _mediator.Send(new BuscarProdutoPorId() { Id = id });

                if (produto.Id > 0) return Ok(produto);

                return BadRequest(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
