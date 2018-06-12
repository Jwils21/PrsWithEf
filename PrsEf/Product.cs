using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {
	public class Product {
		public int Id { get; set; }
		public int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }
		[Required]
		[StringLength(50)]
		public string PartNumber { get; set; }
		[Required]
		[StringLength(150)]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[StringLength(50)]
		public string Unit { get; set; }
		[StringLength(255)]
		public string PhotoPath { get; set; }
		public bool Active { get; set; }

	}
}
