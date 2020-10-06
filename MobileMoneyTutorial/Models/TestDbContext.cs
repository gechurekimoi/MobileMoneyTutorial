using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileMoneyTutorial.Models
{
    public class TestDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TestMpesaTutorial.db");

        public DbSet<ConfirmationResponse> ConfirmationResponses { get; set; }
    }
}
