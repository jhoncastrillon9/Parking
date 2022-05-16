using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext (DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>? Movie { get; set; }

        public DbSet<ParkingCellStatus> ParkingCellStatus { get; set; }

        public DbSet<ParkingCell> ParkingCell { get; set; }
        public DbSet<CheckIngCheckOut> CheckIngCheckOut { get; set; }
    }
}
