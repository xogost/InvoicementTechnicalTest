using InvoicementTechincalData.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicementTechnicalTest.Objects
{
    public class InvoicementDataObject
    {
        public string CompanyId { get; set; }
        public string ClientId { get; set; }
        public CoreProduct[] Products { get; set; }
        public string Total { get; set; }
    }
}
