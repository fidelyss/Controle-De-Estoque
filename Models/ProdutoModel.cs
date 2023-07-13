using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class ProdutoModel
{
    [Key]
    public int IdProduto { get; set; }
    public int Estoque { get; set; }
    public double Preco { get; set; }
    public string? Nome { get; set; }
    [ForeignKey("Categoria")]
    public int IdCategoria { get; set; }
    public CategoriaModel? Categoria { get; set; }
}