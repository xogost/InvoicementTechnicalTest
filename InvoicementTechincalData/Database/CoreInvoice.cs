using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreInvoice")]
    public partial class CoreInvoice
    {
        public CoreInvoice()
        {
            CoreInvoiceCoreClients = new HashSet<CoreInvoiceCoreClient>();
            CoreInvoiceCoreProducts = new HashSet<CoreInvoiceCoreProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? Number { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty(nameof(CoreCompany.CoreInvoices))]
        public virtual CoreCompany Company { get; set; }
        [InverseProperty(nameof(CoreInvoiceCoreClient.Invoice))]
        public virtual ICollection<CoreInvoiceCoreClient> CoreInvoiceCoreClients { get; set; }
        [InverseProperty(nameof(CoreInvoiceCoreProduct.Invoice))]
        public virtual ICollection<CoreInvoiceCoreProduct> CoreInvoiceCoreProducts { get; set; }
    }
}
