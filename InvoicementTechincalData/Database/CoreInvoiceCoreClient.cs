using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreInvoice_CoreClient")]
    public partial class CoreInvoiceCoreClient
    {
        [Key]
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? InvoiceId { get; set; }
        public int? Total { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty(nameof(CoreClient.CoreInvoiceCoreClients))]
        public virtual CoreClient Client { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(CoreInvoice.CoreInvoiceCoreClients))]
        public virtual CoreInvoice Invoice { get; set; }
    }
}
