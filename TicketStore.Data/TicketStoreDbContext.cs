using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Data.Models;

namespace TicketStore.Data
{
	internal class TicketStoreDbContext : DbContext
	{
		public TicketStoreDbContext() : base(GetConnectionString())
		{
			
		}
		public DbSet<Attendant> Attendants { get; set; }

		public DbSet<Event> Events { get; set; }

		public DbSet<Ticket> Tickets { get; set; }

		public DbSet<User> Users { get; set; }

		private static string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["TicketStoreDbConnectionString"].ConnectionString;
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
			//foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			//{
			//	relationship.DeleteBehavior = DeleteBehavior.Restrict;
			//}

			base.OnModelCreating(modelBuilder);
		}
	}
}
