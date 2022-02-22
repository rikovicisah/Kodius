using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Kodius.Modeli
{
    public class Stock
    {
        public int Id { get; set; }
        public int kolicina { get; set; }
        public int proizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        
    }
}
