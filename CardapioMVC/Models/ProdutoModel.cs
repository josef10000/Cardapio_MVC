namespace CardapioMVC.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public required string Kilos { get; set; }


        public double Valor { get; set; }
    }
}
