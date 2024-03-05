using System.Collections.Generic;
using Airbnb.Models;

namespace Airbnb.Models
{
public class RoomModel

{

    public int RoomModelId { get; set; }

    public string RoomSize { get; set; }

    public string RoomType { get; set; }

    public decimal RentalPrice { get; set; }

    public string AvailabilityStatus { get; set; }

    public List<Tariff> Tariffs { get; set; }

}
}