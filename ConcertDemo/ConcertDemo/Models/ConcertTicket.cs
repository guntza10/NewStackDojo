using System;

namespace ConcertDemo.Models
{
    public class ConcertTicket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public int StatusId { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}