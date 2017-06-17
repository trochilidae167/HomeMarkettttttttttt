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

        public int Id { get; set; }


        public int DonHangId { get; set; }


        public int NguoiDiChoId { get; set; }

        public DateTime ThoiGianNhan { get; set; }

        public bool Status { get; set; }
    }
}
