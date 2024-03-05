using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airbnb.Models;

namespace Airbnb.Models
{
    public class Tariff
    {
        public int PriceId { get; set; }
        public int RentalRatePerDay  { get; set; }

        public int Discounts  { get; set; }

        [ForeignKey("RoomModel")]
        public int RoomModelId { get; set; }
        public RoomModel? RoomModel {get;set;}
    }
}