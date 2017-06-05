using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeMarket.Models
{
    public class NguoiDiChoOnlines
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public bool Online { get; set; }

        public int Refuse { get; set; }
    }
}