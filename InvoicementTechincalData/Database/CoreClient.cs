using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InvoicementTechincalData.Database
{
    [Table("CoreClient")]
    public partial class CoreClient
    {
        public CoreClient()
        {
            CoreInvoiceCoreClients = new HashSet<CoreInvoiceCoreClient>();
        }

        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public byte[] UpdatedAt { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty(nameof(CoreCompany.CoreClients))]
        public virtual CoreCompany Company { get; set; }
        [InverseProperty(nameof(CoreInvoiceCoreClient.Client))]
        public virtual ICollection<CoreInvoiceCoreClient> CoreInvoiceCoreClients { get; set; }
    }
}
