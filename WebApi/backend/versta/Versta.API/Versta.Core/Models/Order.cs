using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// бизнес модель + логика (например валидация)


namespace Versta.Core.Models
{
    public class Order
    {
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
        public Guid Id { get; }
        public string CityFrom { get; } = string.Empty;
        public string AdressFrom { get; } = string.Empty;
        public string CityTo { get; } = string.Empty;
        public string AdressTo { get; } = string.Empty;
        public decimal Weight { get; } = 0;
        public DateTime Date { get; }       
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
