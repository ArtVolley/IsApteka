using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Database.Models
{
    public class Store 
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int? Amount { get; set; }
        public float Cost { get; set; }
        public string Place { get; set; }
    }
}
