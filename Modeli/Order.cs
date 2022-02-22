namespace Kodius.Modeli
{
    public class Order
    {
        public int Id { get; set; }
        public int NarudzbaRef { get; set; }
        public string Adresa { get; set; }
        public string Adresa2 { get; set; }
        public string Grad { get; set; }
        public string PostanskiBroj { get; set; }
        public string Drzava { get; set; }


        public ICollection<OrderProduct> Stocks { get; set; }
    }
}
