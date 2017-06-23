using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeMarket.Models
{
    public class NhaCungUng
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungUng()
        {
            BangGiaCho = new HashSet<BangGiaCho>();
        }
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã")]
        public string Ma { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [StringLength(1024)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangGiaCho> BangGiaCho { get; set; }
    }
}