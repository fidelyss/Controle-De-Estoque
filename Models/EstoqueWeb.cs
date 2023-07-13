using Microsoft.EntityFrameworkCore;

public class EstoqueWeb : DbContext
{
    public EstoqueWeb(DbContextOptions<EstoqueWeb> options) : base(options) { }
    public DbSet<CategoriaModel> Categorias { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
}