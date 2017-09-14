using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatHMT.DA
{
	public interface iRepo
	{
		void UpdateStoreToyStatus();
		void AddNewStoreToy();
	}

	public interface iDA
	{
		void SaveImage();
		void GetImage();

	}
}
