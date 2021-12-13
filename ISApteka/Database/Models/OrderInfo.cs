using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Database.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int Amount{ get; set; }
        public float Cost{ get; set; }
    }
}
