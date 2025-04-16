using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Versta.DataAccess.Entities
{
    [Table("orders")]
    public class OrderEntity
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("cityfrom")]
        public string CityFrom { get; set; } = string.Empty;
        [Column("adressfrom")]
        public string AdressFrom { get; set; } = string.Empty;
        [Column("cityto")]
        public string CityTo { get; set; } = string.Empty;
        [Column("adressto")]
        public string AdressTo { get; set; } = string.Empty;
        [Column("weight")]
        public decimal Weight { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("specialnote")]
        public string? SpecialNote { get; set; } = string.Empty;
    }
}
