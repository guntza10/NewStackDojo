using ConcertDemo.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

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
                concert = context.Concert.Where(it => it.Id == 6).FirstOrDefault();
                concertTicket = context.ConcertTicket.Where(it => it.Id == 4 && it.ConcertId == 6).FirstOrDefault();
            }

            var resultBooking = BookConcertTicket(concert, concertTicket, "P'pub");
            Console.WriteLine($"Booking Status : {resultBooking.StatusBooking}");
            Console.WriteLine($"Booking Message : {resultBooking.StatusMessage}");
        }

        public static BookTicketStatus BookConcertTicket(Concert concert, ConcertTicket concertTicket, string reservedBy)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (var context = new ConcertContext())
                    {
                        var allTicketNotBooking = context.ConcertTicket.Where(it => it.ConcertId == concert.Id && it.StatusId == 0).ToList();
                        var ticket = allTicketNotBooking
                        .Where(it => it.Id == concertTicket.Id)
                        .FirstOrDefault();

                        ticket.StatusId = 1;
                        ticket.ReservedBy = reservedBy;
                        ticket.ReservedDate = DateTime.Now;

                        context.SaveChanges();
                        scope.Complete();
                        return new BookTicketStatus
                        {
                            StatusBooking = 1, // StatusBooking ไม่เกี่ยวกับ StatusId ของ concertTicket เป็น 1 คือจองสำเร็จ
                            StatusMessage = $"Ticket Id : {ticket.Id} of {concert.Title} is booked."
                        };
                    }
                }
                catch
                {
                    scope.Dispose();
                    return new BookTicketStatus
                    {
                        StatusBooking = 0, // StatusBooking ไม่เกี่ยวกับ StatusId ของ concertTicket เป็น 0 คือจองไม่สำเร็จ
                        StatusMessage = "Unavaliable"
                    };
                }
            }
        }
    }
}
