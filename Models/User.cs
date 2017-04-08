namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ma { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(1024)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string NgaySinh { get; set; }

        [StringLength(250)]
        public string QuocTich { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(1024)]
        public string DiaChi { get; set; }

        [StringLength(1024)]
        public string Email { get; set; }
        [StringLength(20)]
        public string GroupID { set; get; }
        public bool Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }
    }
}
