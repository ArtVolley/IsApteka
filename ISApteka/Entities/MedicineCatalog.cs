using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Entities
{
    public class MedicineCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public bool IsPrescription { get; set; }
        public int Amount { get; set; }
        public bool IsAdded { get; set; }
    }
}
