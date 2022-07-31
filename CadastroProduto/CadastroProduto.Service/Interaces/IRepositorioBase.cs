namespace CadastroProduto.Service.Interaces
{
    public interface IRepositorioBase<TEntity>
    {
        bool Atualizar(TEntity entity);

        bool Excluir(TEntity entity);

        Int64 Inserir(TEntity entity);

        TEntity BuscarPorId(long id);

        List<TEntity> BuscarTodos();

        void Commit();

        void Roolback();

        void IniciarTransacao();
    }
}
