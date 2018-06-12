using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {
	public class PrsDbContext: DbContext {
		public PrsDbContext() : base() {

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<PurchaseRequest> PurchaseRequest { get; set; }
		public DbSet<PurchaseRequestLineItem> PurchaseRequestLineItem { get; set; }
	}
}
