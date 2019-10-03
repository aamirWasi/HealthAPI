using HealthAPIPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPIPractice.Data
{
    public class HealthContext:DbContext
    {
        public HealthContext(DbContextOptions<HealthContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<Medication> Medications { get; set; }
    }
}
