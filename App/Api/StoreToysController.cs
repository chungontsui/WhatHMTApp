using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatHMT.DA;

namespace App.Api
{
	public class StoreToysController : ApiController
	{
		private DA _da = new DA("Test");

		public IEnumerable<StoreToys> Get(string StoreGuid)
		{
			Guid _storeGuid = new Guid(StoreGuid);
			return _da.GetStoreToysByStoreGuid(_storeGuid);
		}

		public StoreToys Get(int id)
		{
			return _da.GetStoreToysById(id);
		}

		public void Post(StoreToys NewStoreToy)
		{
			_da.AddNewStoreToy(NewStoreToy);
		}

		public void Put(StoreToys ModStoreToy)
		{
			_da.UpdateStoreToys(ModStoreToy);
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}