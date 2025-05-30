using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta.DataAccess.Repo
{
    public record OrderDto(
        Guid Id,
        string CityFrom,
        string AdressFrom,
        string CityTo,
        string AdressTo,
        decimal Weight,
        DateTime Date,
        string? SpecialNote
    );
}

