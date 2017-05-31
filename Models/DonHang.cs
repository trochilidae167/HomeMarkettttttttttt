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
        public string Ma { get; set; }

        public int KhachHangId { get; set; }

        public int NCUId { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public bool DaNhan { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaDonHang> GiaDonHangs { get; set; }
    }
}
