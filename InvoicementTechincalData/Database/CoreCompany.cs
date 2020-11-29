using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreCompany")]
    public partial class CoreCompany
    {
        public CoreCompany()
        {
            CoreClients = new HashSet<CoreClient>();
            CoreInvoices = new HashSet<CoreInvoice>();
            CoreProducts = new HashSet<CoreProduct>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Identification { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        public byte[] UpdatedAt { get; set; }

        [InverseProperty(nameof(CoreClient.Company))]
        public virtual ICollection<CoreClient> CoreClients { get; set; }
        [InverseProperty(nameof(CoreInvoice.Company))]
        public virtual ICollection<CoreInvoice> CoreInvoices { get; set; }
        [InverseProperty(nameof(CoreProduct.Company))]
        public virtual ICollection<CoreProduct> CoreProducts { get; set; }
    }
}
