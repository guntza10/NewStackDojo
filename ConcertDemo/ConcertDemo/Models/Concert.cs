using System;

namespace ConcertDemo.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ShowDate { get; set; }
        public string Location { get; set; }
    }
}