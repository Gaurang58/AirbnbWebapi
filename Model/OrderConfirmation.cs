using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class OrderConfirmation
    {
        public string OrderId { get; set; }
        public string RentalStartDate { get; set; }

        public string RentalEndDate { get; set; }

        public string Price { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer{get;set;}

        [ForeignKey("RoomModel")]
        public int RoomModelId { get; set; }
        public RoomModel? RoomModel {get;set;}
       
        // public List<Enrollment>? Enrollments { get; set; }
    }
}