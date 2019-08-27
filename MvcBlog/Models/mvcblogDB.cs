namespace MvcBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mvcblogDB : DbContext
    {
        public mvcblogDB()
            : base("name=mvcblogDB")
        {
        }

        public virtual DbSet<Etiket> Etiket { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .Property(e => e.EtiketAdi)
                .IsFixedLength();

            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makale)
                .WithMany(e => e.Etiket)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketId").MapRightKey("MakaleId"));

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);
        }
    }
}
