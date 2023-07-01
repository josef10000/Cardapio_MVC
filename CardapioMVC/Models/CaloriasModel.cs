namespace CardapioMVC.Models
{
    public class CaloriasModel
    {
        public IdModel Id { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string Calorias { get; set; }
    }

    public class IdModel
    {
        public long Timestamp { get; set; }
        public string Date { get; set; }
    }

}
