namespace CadastroProduto.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
                
        }

        public Produto(Int64 id, string? codigo, string? nome, string? descricao, decimal preco, int quantidadeEmEstoque, int idCategoria, Categoria categoria)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            IdCategoria = idCategoria;
            Categoria = categoria;
        }
        public Int64 Id { get; private set; }
        public string? Codigo { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public Int64 IdCategoria { get; private set; }
        public Categoria? Categoria { get; private set; }

        public void SetIdCategoria(Int64 idCategoria)
        {
            this.IdCategoria = idCategoria;
            Categoria = null;
        }
    }
}
