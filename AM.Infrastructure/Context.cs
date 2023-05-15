using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
	public class Context : DbContext
	{
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Passenger> Passengers { get; set; }
		public DbSet<Plane> Planes { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Traveller> Travellers { get; set; }

		public DbSet<Ticket> tickets { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
			base.OnConfiguring(optionsBuilder);
		}
		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
			base.ConfigureConventions(configurationBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Passenger>().Property(e => e.TelNumber).HasColumnName("NumTel");
			modelBuilder.ApplyConfiguration(new PlaneConfiguration());
			modelBuilder.ApplyConfiguration(new TicketConfiguration());
			/*modelBuilder.Entity<Passenger>().HasDiscriminator<int>("PassengerTypeValue")
				.HasValue<Staff>(1).HasValue<Traveller>(2).HasValue<Passenger>(0);*/

			modelBuilder.Entity<Passenger>().OwnsOne(e => e.FullName, e =>
			{
				e.Property(e => e.FirstName).HasColumnName("FullNameFirst");
				e.Property(e => e.LastName).HasColumnName("FullNameLast");
			});


			modelBuilder.Entity<Staff>().ToTable("Staffs");
			modelBuilder.Entity<Traveller>().ToTable("Travellers");
			base.OnModelCreating(modelBuilder);
		}
	}
}
