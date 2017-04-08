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
        public string Ma { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(1024)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string NgaySinh { get; set; }

        [StringLength(250)]
        public string QuocTich { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string CMND { get; set; }

        [StringLength(1024)]
        public string DiaChi { get; set; }

        [StringLength(1024)]
        public string Email { get; set; }

        public double? DanhGia { get; set; }

        public double? TaiKhoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }
    }
}
