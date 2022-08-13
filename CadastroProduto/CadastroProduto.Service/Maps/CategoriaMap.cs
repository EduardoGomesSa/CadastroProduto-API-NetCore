using CadastroProduto.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace CadastroProduto.Service.Maps
{
    public class CategoriaMap : ClassMapper<Categoria>
    {
        public CategoriaMap()
        {
            Schema("cadastro");
            Table("categoria");

            Map(c => c.Id)
                .Column("id")
                .Key(KeyType.Identity);

            Map(c => c.Nome)
                .Column("nome");

            AutoMap();
        }
    }
}
