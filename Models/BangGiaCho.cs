namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangGiaCho")]
    public partial class BangGiaCho
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MaThucPham { get; set; }

        [StringLength(250)]
        public string TenThucPham { get; set; }

        [StringLength(50)]
        public string LoaiThucPham { get; set; }

        public double? GiaThucPham { get; set; }
    }
}
