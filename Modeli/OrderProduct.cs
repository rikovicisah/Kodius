namespace Kodius.Modeli
{
    public class OrderProduct
    {
        public int proizvodId { get; set; }
        public Proizvod? Proizvod { get; set; }

        public int NarudzbaId { get; set; }
        public Order Narudzba { get; set; }
    }
}
