namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiThieu")]
    public partial class GioiThieu
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name ="Tiêu đề")]
        public string Ten { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name ="Nội dung")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Ngày tạo")]
        public DateTime? NgayTao { get; set; }

        [Display(Name ="Người sử dụng")]
        public bool? NguoiSuDung { get; set; }
        [Display(Name = "Khách hàng")]
        public bool? KhachHang { get; set; }
        [Display(Name = "Người đi chợ")]
        public bool? NguoiDiCho { get; set; }
    }
}
