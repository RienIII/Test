using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WA.BookStore.Site.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<Member> Members { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Member>()
				.Property(e => e.Mobile)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.ConfimCode)
				.IsUnicode(false);
		}
	}
}
