using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatHMT.DA
{
	public class Context:DbContext
	{
		public Context(string connStr = "HMTDatabase") :base(connStr)
		{
			
		}

		public virtual DbSet<StoreToys> dsStoreToys { get; set; }

		public virtual DbSet<ToyImage> dsToyImage { get; set; }
	}
}
