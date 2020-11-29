using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreProduct")]
    public partial class CoreProduct
    {
        public CoreProduct()
        {
            CoreInvoiceCoreProducts = new HashSet<CoreInvoiceCoreProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? Cost { get; set; }
        [StringLength(100)]
        public string Reference { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        public byte[] UpdatedAt { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty(nameof(CoreCompany.CoreProducts))]
        public virtual CoreCompany Company { get; set; }
        [InverseProperty(nameof(CoreInvoiceCoreProduct.Product))]
        public virtual ICollection<CoreInvoiceCoreProduct> CoreInvoiceCoreProducts { get; set; }
    }
}
