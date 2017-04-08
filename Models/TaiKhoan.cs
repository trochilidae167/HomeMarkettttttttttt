namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ma { get; set; }

        [StringLength(50)]
        public string MaNguoiDiCho { get; set; }

        [Column("TaiKhoan")]
        public double? TaiKhoan1 { get; set; }
    }
}
