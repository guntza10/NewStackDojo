using ConcertDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertDemo
{
    public class ConcertContext : DbContext
    {
        public DbSet<Concert> Concert { get; set; }
        public DbSet<ConcertTicket> ConcertTicket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U976KNE\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;");
        }
    }
}