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

        public DbSet<ParkingCellStatus> ParkingCellStatus { get; set; }
        public DbSet<ParkingCell> ParkingCell { get; set; }
        public DbSet<CheckIngCheckOut> CheckIngCheckOut { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TypeCheck> TypeCheck { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Payments> Payments { get; set; }        
    }
}
