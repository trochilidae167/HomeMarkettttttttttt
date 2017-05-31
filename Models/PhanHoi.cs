namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        public int Id { get; set; }

        [Display(Name = "Mã khách hàng")]
        public int? KhachHangId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nôi dung")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày gửi")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
