namespace CadastroProduto.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria()
        {

        }

        public Categoria(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Int64 Id { get; private set; }
        public string Nome { get; private set; }
    }
}
