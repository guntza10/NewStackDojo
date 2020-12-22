using ConcertDemo.Models;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ConcertDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Concert concert;
            ConcertTicket concertTicket;
            using (var context = new ConcertContext())
            {
                concert = context.Concert.Where(it => it.Id == 2).FirstOrDefault();
                concertTicket = context.ConcertTicket.Where(it => it.Id == 16 && it.ConcertId == 2)?.FirstOrDefault();
            }

            var resultBooking = BookConcertTicket(concert, concertTicket, "Nerd");
            Console.WriteLine($"Book Status : {resultBooking.StatusBooking}");
            Console.WriteLine($"Book Message : {resultBooking.StatusMessage}");
        }

        public static BookTicketStatus BookConcertTicket(Concert concert, ConcertTicket concertTicket, string reservedBy)
        {
            using (var context = new ConcertContext())
            {
                if (concertTicket.StatusId == 0)
                {
                    var ticket = context.ConcertTicket
                    .Where(it => it.Id == concertTicket.Id && it.ConcertId == concertTicket.ConcertId)
                    .FirstOrDefault();
                    ticket.StatusId = 1;
                    ticket.ReservedBy = reservedBy;
                    ticket.ReservedDate = DateTime.Now;
                    context.SaveChanges();
                    return new BookTicketStatus
                    {
                        StatusBooking = ticket.StatusId,
                        StatusMessage = $"Ticket Id :  ${ticket.Id} of ${concert.Title} is booked."
                    };
                }
                return new BookTicketStatus
                {
                    StatusBooking = concertTicket.StatusId,
                    StatusMessage = "Unavaliable"
                };
            }
        }
    }
}
