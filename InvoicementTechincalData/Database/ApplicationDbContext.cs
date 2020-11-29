using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InvoicementTechincalData.Database
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoreClient> CoreClients { get; set; }
        public virtual DbSet<CoreCompany> CoreCompanies { get; set; }
        public virtual DbSet<CoreInvoice> CoreInvoices { get; set; }
        public virtual DbSet<CoreInvoiceCoreClient> CoreInvoiceCoreClients { get; set; }
        public virtual DbSet<CoreInvoiceCoreProduct> CoreInvoiceCoreProducts { get; set; }
        public virtual DbSet<CoreProduct> CoreProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HC75JJL\\SQLEXPRESS;Database=InvoicementTestDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreClient>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength(true);

                entity.Property(e => e.UpdatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CoreClients)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CoreClient_CoreCompany");
            });

            modelBuilder.Entity<CoreCompany>(entity =>
            {
                entity.Property(e => e.UpdatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CoreInvoice>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CoreInvoices)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CoreInvoice_CoreCompany");
            });

            modelBuilder.Entity<CoreInvoiceCoreClient>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CoreInvoiceCoreClients)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CoreInvoice_CoreClient_CoreClient");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.CoreInvoiceCoreClients)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_CoreInvoice_CoreClient_CoreInvoice");
            });

            modelBuilder.Entity<CoreInvoiceCoreProduct>(entity =>
            {
                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.CoreInvoiceCoreProducts)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoreInvoice_CoreProduct_CoreInvoice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CoreInvoiceCoreProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoreInvoice_CoreProduct_CoreProduct");
            });

            modelBuilder.Entity<CoreProduct>(entity =>
            {
                entity.Property(e => e.UpdatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CoreProducts)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CoreProduct_CoreCompany");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
