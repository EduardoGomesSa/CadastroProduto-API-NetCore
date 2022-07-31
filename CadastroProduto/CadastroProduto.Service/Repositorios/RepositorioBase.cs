using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Service.Interaces;
using DapperExtensions.Mapper;
using Shared.Data;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Vendas.Service.Repositorios
{
    public class RepositorioBase<TEntity, TMap> : IRepositorioBase<TEntity>
        where TEntity : class
    {
        public RepositorioBase()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(TMap).Assembly });
        }

        public virtual bool Atualizar(TEntity entity)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Atualizar(entity);
        }

        public virtual bool Excluir(TEntity entity)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Excluir(entity);
        }

        public virtual Int64 Inserir(TEntity entity)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Inserir(entity);
        }

        public virtual TEntity BuscarPorId(long id)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Get(id);

        }

        public virtual List<TEntity> BuscarTodos()
        {
            return DBHelper<TEntity>.InstanciaNpgsql.GetAll();

        }

        public void Commit()
        {
            DBHelper<TEntity>.InstanciaNpgsql.CommitTransaction();
        }

        public void Roolback()
        {
            DBHelper<TEntity>.InstanciaNpgsql.RollbackTransaction();
        }

        public void IniciarTransacao()
        {
            DBHelper<TEntity>.InstanciaNpgsql.BeginTransaction();
        }
    }
}
