using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Entities
{
    class MedicineOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrescription { get; set; }
        public int Amount { get; set; }
        public float Cost { get; set; }
        public float TotalCost { get { return Amount * Convert.ToSingle(Cost); } set { } }
    }
}
