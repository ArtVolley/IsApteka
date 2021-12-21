using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public double TotalCost{ get; set; }
        public int IsPassed{ get; set; }
        public int UserId { get; set; }
    }
}
