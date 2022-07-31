namespace CadastroProduto.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
                
        }

        public Produto(Int64 id, string? codigo, string? nome, string? descricao, decimal preco, int quantidadeEmEstoque, string? categoria)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Categoria = categoria;
        }
        public Int64 Id { get; private set; }
        public string? Codigo { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public string? Categoria { get; private set; }
    }
}
