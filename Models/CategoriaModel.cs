using System.ComponentModel.DataAnnotations;

public class CategoriaModel
{
    [Key]
    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "Coloque no minimo 1 caracter"), MaxLength(128)]
    public string Nome { get; set; }
}