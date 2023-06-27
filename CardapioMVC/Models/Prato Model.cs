

using System.Collections.Generic;


namespace CardapioMVC.Models
{
    public class Prato_Model
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public required List<ItemPratoModel> Itens { get; set; }
        public double CustoTotal { get; set; }
        public double PorcentagemLucro { get; set; }
    }
}
