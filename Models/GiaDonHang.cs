namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaDonHang")]
    public partial class GiaDonHang
    {
        public int Id { get; set; }

        public int? DonHangId { get; set; }

        public double? TongTien { get; set; }

        public double? PhiDichVu { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
