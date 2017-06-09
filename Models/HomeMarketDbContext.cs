namespace HomeMarket.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HomeMarketDbContext : DbContext
    {
        public HomeMarketDbContext()
            : base("name=HomeMaketDbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BangGiaCho> BangGiaCho { get; set; }
        public virtual DbSet<BangGiaSieuThi> BangGiaSieuThi { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<DonHangChiTiet> DonHangChiTiet { get; set; }
        public virtual DbSet<GiaDonHang> GiaDonHang { get; set; }
        public virtual DbSet<GioiThieu> GioiThieu { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LienHe> LienHe { get; set; }
        public virtual DbSet<NguoiDiCho> NguoiDiCho { get; set; }
        public virtual DbSet<NguoiDiChoOnlines> NguoiDiChoOnline { get; set; }
        public virtual DbSet<NhaCungUng> NhaCungUng { get; set; }
        public virtual DbSet<NhanDonHang> NhanDonHang { get; set; }
        public virtual DbSet<PhanHoi> PhanHoi { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagram> sysdiagram { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDiCho>()
                .Property(e => e.CMND)
                .IsFixedLength();
        }
    }
}
