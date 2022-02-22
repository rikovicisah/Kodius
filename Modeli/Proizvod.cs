namespace Kodius.Modeli
{
    public class Proizvod
    {
        public int Id { get; set; }
        public String? ProductName { get; set; }
        public decimal ProductPrice { get; set; }


        public ICollection<Stock> Stocks { get; set; }
        public ICollection<OrderProduct> OrderedProducts { get; set; }
    }
}
