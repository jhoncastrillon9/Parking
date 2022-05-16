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

        public DbSet<Parking.Models.Movie>? Movie { get; set; }

        public DbSet<Parking.Models.ParkingCellStatus>? ParkingCellStatus { get; set; }

        public DbSet<Parking.Models.ParkingCell>? ParkingCell { get; set; }
    }
}
