using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Entities
{
    public class MedicineOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrescription { get; set; }
        public int TotalAmount { get; set; }
        public int Amount { get; set; }
        public double Cost { get; set; }
        public double TotalCost { get { return (double)(Amount * Convert.ToDecimal(Cost)); } set { } }
    }
}
