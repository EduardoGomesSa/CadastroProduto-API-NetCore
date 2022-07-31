
using CadastroProduto.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace CadastroProduto.Service.Maps
{
    public class ProdutoMap : ClassMapper<Produto>
    {
        public ProdutoMap()
        {
            Table("produto");
            Schema("cadastro");
            Map(p => p.Id).Column("id").Key(KeyType.Identity);
            Map(P => P.Codigo).Column("codigo");
            Map(p => p.Nome).Column("nome");
            Map(p => p.Descricao).Column("descricao");
            Map(p => p.Preco).Column("preco");
            Map(p => p.QuantidadeEmEstoque).Column("quantidadeemestoque");
            Map(p => p.Categoria).Column("categoria");
        }
    }
}
