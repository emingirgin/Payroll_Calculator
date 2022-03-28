using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollCalculator.Models;
using Microsoft.EntityFrameworkCore;


namespace PayrollCalculator.Contexts
{
    public class PieceworkWorkerContext : DbContext
    {
        public PieceworkWorkerContext(DbContextOptions<PieceworkWorkerContext> options) : base(options)
        {

        }

        public DbSet<PieceworkWorkerModel> Workers { get; set; }
    }
}
