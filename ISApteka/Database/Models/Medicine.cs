using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISApteka.Entities.Enums;

namespace ISApteka.Database.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public string Instruction { get; set; }
        public bool IsPrescription { get; set; }
        public int? BrandId { get; set; }
        public string Amount { get; set; }
    }
}
