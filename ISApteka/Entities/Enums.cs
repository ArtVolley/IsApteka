using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka.Entities
{
    public class Enums
    {
        public enum Role
        {
            Admin,
            Pharmacist,
            SeniorPharmacist
        }

        public enum Mode
        {
            Read,
            Edit,
            Add
        }

        public enum Bool
        {
            True,
            False
        }

        public enum ReportType
        {
            General,
            Month
        }
    }
}
