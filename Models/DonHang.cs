namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();
            GiaDonHangs = new HashSet<GiaDonHang>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Mã")]
        public string Ma { get; set; }

        [Display(Name = "Khách hàng")]
        public int KhachHangId { get; set; }

        [Display(Name = "Nhà cung ứng")]
        public int NCUId { get; set; }

        [Display(Name = "Thời gian đặt")]
        public DateTime ThoiGianDat { get; set; }

        [Display(Name = "Đã nhận")]
        public bool DaNhan { get; set; }

        public double X { get; set; }

        public double Y { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaDonHang> GiaDonHangs { get; set; }
    }
}
