using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LMS.DAL.Entity;

namespace LMS.DAL.Database
{
    public partial class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ramymaghrabylt\\SQLEXPRESS22; database = LMSWorkShop; integrated security = true; TrustServerCertificate = true");
        }

        
    }
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
        public DbSet<ReservationTransaction> ReservationTransactions { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
