using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlarmOS.Models;

namespace AlarmOS.Models
{
    public class AlarmOSContext : DbContext
    {
        public AlarmOSContext(DbContextOptions<AlarmOSContext> options)
            : base(options)
        {
        }
        public DbSet<AlarmOS.Models.Alarmy> Alarmy { get; set; }
    }
}
