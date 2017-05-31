namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanDonHang")]
    public partial class NhanDonHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string MaDonHang { get; set; }

        [StringLength(50)]
        public string MaNguoiDiCho { get; set; }

        public DateTime ThoiGianNhan { get; set; }

        public bool Status { get; set; }
    }
}
