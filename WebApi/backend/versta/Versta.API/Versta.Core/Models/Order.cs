using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Versta.Core.Models
{
    [Table("orders")]
    public class Order
    {
        public Order() 
        {
        }

        public const int MAX_NOTE_LEN = 100;
        private Order(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string? specialNote)
        { 
            Id = id;
            CityFrom = cityFrom;
            AdressFrom = adressFrom;
            CityTo = cityTo;
            AdressTo = adressTo;
            Weight = weight;
            Date = date;
            SpecialNote = specialNote;
        }


        [Key]
        [Column("id")]
        public Guid Id { get; }

        [Column("cityfrom")]
        public string CityFrom { get; } = string.Empty;

        [Column("adressfrom")]
        public string AdressFrom { get; } = string.Empty;

        [Column("cityto")]
        public string CityTo { get; } = string.Empty;

        [Column("adressto")]
        public string AdressTo { get; } = string.Empty;

        [Column("weight")]
        public decimal Weight { get; } = 0;

        [Column("date")]
        public DateTime Date { get; }

        [Column("specialnote")]
        public string? SpecialNote { get; } = string.Empty;

        public static (Order order, string Error) Create(
            Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string? specialNote)
        {
            var error = string.Empty;
            if (specialNote?.Length > MAX_NOTE_LEN)
            {
                error = "Сократите примечание до 100 знаков";
            }
            //var dateTimeOffset = DateTimeOffset.Parse(date.ToString(), null);
            var order = new Order(id, cityFrom, adressFrom, cityTo, adressTo,
                weight, date, specialNote);
            return (order, error);
        }
    }
}
