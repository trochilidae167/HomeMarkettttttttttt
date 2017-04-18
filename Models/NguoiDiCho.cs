namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDiCho")]
    public partial class NguoiDiCho
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Mã")]
        public string Ma { get; set; }

        [StringLength(250)]
        [Display(Name = "Họ và tên")]
        public string Ten { get; set; }

        [StringLength(1024)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string NgaySinh { get; set; }

        [StringLength(250)]
        [Display(Name = "Quốc tịch")]
        public string QuocTich { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(10)]
        [Display(Name = "Chứng minh nhân dân")]
        public string CMND { get; set; }

        [StringLength(1024)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(1024)]
        public string Email { get; set; }

        [Display(Name = "Đánh giá")]
        public double? DanhGia { get; set; }

        [Display(Name = "Tài khoản")]
        public double? TaiKhoan { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đăng ký")]
        public DateTime? NgayDangKy { get; set; }
    }
}
