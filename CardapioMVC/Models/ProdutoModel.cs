using System.ComponentModel.DataAnnotations;

namespace CardapioMVC.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }



        [Required(ErrorMessage ="Digite o nome do produto")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Digite o peso do produto")]

        public required string Kilos { get; set; }



        [Required(ErrorMessage = "Digite o preço do produto")]

        public double? Valor { get; set; }
    }
}
