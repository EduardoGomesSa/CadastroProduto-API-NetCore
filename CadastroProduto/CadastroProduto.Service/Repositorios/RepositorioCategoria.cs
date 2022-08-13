using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interfaces;
using CadastroProduto.Service.Maps;
using Shared.Data;
using Vendas.Service.Repositorios;

namespace CadastroProduto.Service.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria, CategoriaMap>, IRepositorioCategoria
    {
        public Categoria BuscarCategoriaPorNome(string nome)
        {
            var query = $"select * from cadastro.categoria where nome = '{nome}';";

            return DBHelper<Categoria>.InstanciaNpgsql.GetQuery(query).FirstOrDefault();
        }
    }
}
