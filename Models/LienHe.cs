namespace HomeMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public bool? TrangThai { get; set; }
    }
}
