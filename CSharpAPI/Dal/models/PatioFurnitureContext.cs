using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class PatioFurnitureContext : DbContext
{
    public PatioFurnitureContext()
    {
    }

    public PatioFurnitureContext(DbContextOptions<PatioFurnitureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=patio_furniture;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__buy__3213E83F965C828A");

            entity.ToTable("buy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeClient)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("codeClient");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.StatusBuy)
                .HasDefaultValueSql("((0))")
                .HasColumnName("statusBuy");
            entity.Property(e => e.SumPrice).HasColumnName("sumPrice");

            entity.HasOne(d => d.CodeClientNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.CodeClient)
                .HasConstraintName("FK__buy__codeClient__412EB0B6");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83FBDDD863B");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("img");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client__3213E83FC13973D7");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BearthDate)
                .HasColumnType("datetime")
                .HasColumnName("bearthDate");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company__3213E83F6C689423");

            entity.ToTable("company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("companyName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F6FE6728A");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CodeCat).HasColumnName("codeCat");
            entity.Property(e => e.CodeCom).HasColumnName("codeCom");
            entity.Property(e => e.Descrip)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descrip");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.NameP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameP");
            entity.Property(e => e.Pic)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pic");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.CodeCatNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CodeCat)
                .HasConstraintName("FK__product__codeCat__3B75D760");

            entity.HasOne(d => d.CodeComNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CodeCom)
                .HasConstraintName("FK__product__codeCom__3C69FB99");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__purchase__3213E83F51B8F025");

            entity.ToTable("purchaseDetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CodeBuy).HasColumnName("codeBuy");
            entity.Property(e => e.CodeProd).HasColumnName("codeProd");

            entity.HasOne(d => d.CodeBuyNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.CodeBuy)
                .HasConstraintName("FK__purchaseD__codeB__440B1D61");

            entity.HasOne(d => d.CodeProdNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.CodeProd)
                .HasConstraintName("FK__purchaseD__codeP__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
