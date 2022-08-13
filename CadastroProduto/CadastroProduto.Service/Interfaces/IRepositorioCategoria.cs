using CadastroProduto.Dominio.Entidades;

namespace CadastroProduto.Service.Interfaces
{
    public interface IRepositorioCategoria : IRepositorioBase<Categoria>
    {
        Categoria BuscarCategoriaPorNome(string nome);
    }
}
