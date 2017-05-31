namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangGiaSieuThi")]
    public partial class BangGiaSieuThi
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã thực phẩm")]
        public string MaThucPham { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên thực phẩm")]
        public string TenThucPham { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại thực phẩm")]
        public string LoaiThucPham { get; set; }
        [Display(Name = "Giá thực phẩm")]
        public double GiaThucPham { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
