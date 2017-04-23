namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
            PhanHois = new HashSet<PhanHoi>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Mã khách hàng")]
        public string Ma { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên khách hàng")]
        public string Ten { get; set; }


        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(1024)]
        [Display(Name = "Avatar")]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [StringLength(250)]
        [Display(Name = "Quốc tịch")]
        public string QuocTich { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(1024)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(1024)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đăng ký")]
        public DateTime? NgayDangKy { get; set; }

        [Display(Name = "Người đi chợ")]
        public bool? NguoiDiCho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
