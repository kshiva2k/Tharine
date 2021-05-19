using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Productcategorymaster> Productcategorymaster { get; set; }
        public virtual DbSet<Productmaster> Productmaster { get; set; }
        public virtual DbSet<Purchaseorder> Purchaseorder { get; set; }
        public virtual DbSet<Purchaseorderdetail> Purchaseorderdetail { get; set; }
        public virtual DbSet<Purchaseorderdraft> Purchaseorderdraft { get; set; }
        public virtual DbSet<Rolemaster> Rolemaster { get; set; }
        public virtual DbSet<Servicemaster> Servicemaster { get; set; }
        public virtual DbSet<Subcategorymaster> Subcategorymaster { get; set; }
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
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

                entity.Property(e => e.Minimumorderamount).HasColumnName("minimumorderamount");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Fromdate).HasColumnName("fromdate");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
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

            modelBuilder.Entity<Productcategorymaster>(entity =>
            {
                entity.ToTable("productcategorymaster");

                entity.HasIndex(e => e.Clientid)
                    .HasName("pc_client_idx");

                entity.HasIndex(e => e.Serviceid)
                    .HasName("pc_service_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

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

                entity.HasIndex(e => e.Subcategoryid)
                    .HasName("product_subcategory_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Bigimage)
                    .HasColumnName("bigimage")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cgstpercent)
                    .HasColumnName("CGSTPercent")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Expirydate).HasColumnName("expirydate");

                entity.Property(e => e.Image1)
                    .HasColumnName("image1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image2)
                    .HasColumnName("image2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image3)
                    .HasColumnName("image3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image4)
                    .HasColumnName("image4")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasColumnName("manufacturer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Marketprice)
                    .HasColumnName("marketprice")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Sgstpercent)
                    .HasColumnName("SGSTPercent")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Productmaster)
                    .HasForeignKey(d => d.Subcategoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_subcategory");
            });

            modelBuilder.Entity<Purchaseorder>(entity =>
            {
                entity.ToTable("purchaseorder");

                entity.HasIndex(e => e.Clientid)
                    .HasName("pod_client_idx");

                entity.HasIndex(e => e.Userid)
                    .HasName("pod_user_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate).HasColumnName("createddate");

                entity.Property(e => e.Deliveredby)
                    .HasColumnName("deliveredby")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");

                entity.Property(e => e.Ispaid)
                    .HasColumnName("ispaid")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Ponumber)
                    .HasColumnName("ponumber")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Totalamount)
                    .HasColumnName("totalamount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("pod_client");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchaseorder)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("pod_user");
            });

            modelBuilder.Entity<Purchaseorderdetail>(entity =>
            {
                entity.ToTable("purchaseorderdetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cgsttotal)
                    .HasColumnName("cgsttotal")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Purchaseorderid).HasColumnName("purchaseorderid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sgsttotal)
                    .HasColumnName("sgsttotal")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Purchaseorderdraft>(entity =>
            {
                entity.ToTable("purchaseorderdraft");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Cgsttotal)
                    .HasColumnName("cgsttotal")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sgsttotal)
                    .HasColumnName("sgsttotal")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Rolemaster>(entity =>
            {
                entity.ToTable("rolemaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicemaster>(entity =>
            {
                entity.ToTable("servicemaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subcategorymaster>(entity =>
            {
                entity.ToTable("subcategorymaster");

                entity.HasIndex(e => e.Categoryid)
                    .HasName("cat_subcategory_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategorymaster)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cat_subcategory");
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
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
