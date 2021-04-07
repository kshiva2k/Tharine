using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TharineWebApi.Models
{
    public partial class tharineContext : DbContext
    {
        public tharineContext()
        {
        }

        public tharineContext(DbContextOptions<tharineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientmaster> Clientmaster { get; set; }
        public virtual DbSet<Clientsubscriptions> Clientsubscriptions { get; set; }
        public virtual DbSet<Customermaster> Customermaster { get; set; }
        public virtual DbSet<Lookuppurchaseorder> Lookuppurchaseorder { get; set; }
        public virtual DbSet<Productcategorymaster> Productcategorymaster { get; set; }
        public virtual DbSet<Productmaster> Productmaster { get; set; }
        public virtual DbSet<Purchaseorder> Purchaseorder { get; set; }
        public virtual DbSet<Purchaseorderdetail> Purchaseorderdetail { get; set; }
        public virtual DbSet<Rolemaster> Rolemaster { get; set; }
        public virtual DbSet<Servicemaster> Servicemaster { get; set; }
        public virtual DbSet<Usermaster> Usermaster { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Mysql@2020;database=tharine");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientmaster>(entity =>
            {
                entity.ToTable("clientmaster");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .HasColumnName("emailid")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Gstinnumber)
                    .HasColumnName("gstinnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Minimumorderamount)
                    .HasColumnName("minimumorderamount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientsubscriptions>(entity =>
            {
                entity.ToTable("clientsubscriptions");

                entity.HasIndex(e => e.Clientid)
                    .HasName("cs_client_idx");

                entity.HasIndex(e => e.Serviceid)
                    .HasName("cs_service_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Clientid)
                    .HasColumnName("clientid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fromdate).HasColumnName("fromdate");

                entity.Property(e => e.Serviceid)
                    .HasColumnName("serviceid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Todate).HasColumnName("todate");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Clientsubscriptions)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("cs_client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Clientsubscriptions)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("cs_service");
            });

            modelBuilder.Entity<Customermaster>(entity =>
            {
                entity.ToTable("customermaster");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lookuppurchaseorder>(entity =>
            {
                entity.ToTable("lookuppurchaseorder");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productcategorymaster>(entity =>
            {
                entity.ToTable("productcategorymaster");

                entity.HasIndex(e => e.Clientid)
                    .HasName("pc_client_idx");

                entity.HasIndex(e => e.Serviceid)
                    .HasName("pc_service_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Clientid)
                    .HasColumnName("clientid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Serviceid)
                    .HasColumnName("serviceid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Productcategorymaster)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pc_client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Productcategorymaster)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("pc_service");
            });

            modelBuilder.Entity<Productmaster>(entity =>
            {
                entity.ToTable("productmaster");

                entity.HasIndex(e => e.Categoryid)
                    .HasName("p_category_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasColumnName("manufacturer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Productmaster)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("p_category");
            });

            modelBuilder.Entity<Purchaseorder>(entity =>
            {
                entity.ToTable("purchaseorder");

                entity.HasIndex(e => e.Clientid)
                    .HasName("po_client_idx");

                entity.HasIndex(e => e.Userid)
                    .HasName("po_user_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(5)");

                entity.Property(e => e.Clientid)
                    .HasColumnName("clientid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Createddate).HasColumnName("createddate");

                entity.Property(e => e.Deliveredby)
                    .HasColumnName("deliveredby")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");

                entity.Property(e => e.Ispaid)
                    .HasColumnName("ispaid")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Ponumber)
                    .HasColumnName("ponumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Totalamount)
                    .HasColumnName("totalamount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("po_client");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("po_user");
            });

            modelBuilder.Entity<Purchaseorderdetail>(entity =>
            {
                entity.ToTable("purchaseorderdetail");

                entity.HasIndex(e => e.Productid)
                    .HasName("pod_product_idx");

                entity.HasIndex(e => e.Purchaseorderid)
                    .HasName("pod_productmaster_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(5)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Purchaseorderid)
                    .HasColumnName("purchaseorderid")
                    .HasColumnType("bigint(5)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Purchaseorderdetail)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("pod_product");

                entity.HasOne(d => d.Purchaseorder)
                    .WithMany(p => p.Purchaseorderdetail)
                    .HasForeignKey(d => d.Purchaseorderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pod_productmaster");
            });

            modelBuilder.Entity<Rolemaster>(entity =>
            {
                entity.ToTable("rolemaster");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicemaster>(entity =>
            {
                entity.ToTable("servicemaster");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usermaster>(entity =>
            {
                entity.ToTable("usermaster");

                entity.HasIndex(e => e.Clientid)
                    .HasName("u_client_idx");

                entity.HasIndex(e => e.Customerid)
                    .HasName("u_customer_idx");

                entity.HasIndex(e => e.Roleid)
                    .HasName("u_role_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clientid)
                    .HasColumnName("clientid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Usermaster)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("u_client");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Usermaster)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("u_customer");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usermaster)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("u_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
