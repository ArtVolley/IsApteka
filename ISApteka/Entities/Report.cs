using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Entities
{
    public class Report
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Cost { get; set; }
        public double FullCost { get { return (double)(Amount * Convert.ToDecimal(Cost)); } set { } }
    }
}
