using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatHMT.DA
{
	public class StoreToys
	{
		[Key]
		public int Id { get; set; }
		public Guid StoreGUID { get; set; }
		public string ToyName { get; set; }
		public int ImageId { get; set; }
		public string LastUpdatedBy { get; set; }
		public DateTime LastUpdated { get; set; }
		public string Status { get; set; }

	}

	public class ToyImage
	{
		[Key]
		public int Id { get; set; }
		public byte[] Image { get; set; }
		public string ImageName { get; set; }
	}

	public enum DB_Type {
		Test,
		Azure
	}
}
