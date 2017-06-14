namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHangChiTiet")]
    public partial class DonHangChiTiet
    {
        public int Id { get; set; }

        public int DonHangId { get; set; }

        public int ThucPhamId { get; set; }

        [StringLength(250)]
        public string TenThucPham { get; set; }

        public double SoLuong { get; set; }

        public double Gia { get; set; }

        public int NCUId { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
