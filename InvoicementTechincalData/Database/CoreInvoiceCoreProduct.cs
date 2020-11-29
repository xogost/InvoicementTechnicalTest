using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreInvoice_CoreProduct")]
    public partial class CoreInvoiceCoreProduct
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(CoreInvoice.CoreInvoiceCoreProducts))]
        public virtual CoreInvoice Invoice { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(CoreProduct.CoreInvoiceCoreProducts))]
        public virtual CoreProduct Product { get; set; }
    }
}
