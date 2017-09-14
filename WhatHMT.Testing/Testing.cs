using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WhatHMT.DA;

namespace WhatHMT.Testing
{
	public class Testing
	{
		private WhatHMT.DA.DA _da;

		[SetUp]
		public void Setup()
		{
			_da = new DA.DA("Test");
		}

		[Test]
		public void CanSaveImages()
		{
			Guid _storeGuid = Guid.NewGuid();

			StoreToys _st = new StoreToys() { StoreGUID = _storeGuid, ToyName = "Test Toy", ImageId = 1, LastUpdatedBy = "Tester", LastUpdated = DateTime.Now, Status = "Active" };

			_da.AddNewStoreToy(_st);

			var _listST = _da.GetStoreToysByStoreGuid(_storeGuid);

			Assert.That(_listST.Count == 1, "Add New Store Toy failed");
		}

		[Test]
		public void canUpdateStoreToyStatus()
		{
			Guid _storeGuid = Guid.NewGuid();

			StoreToys _st = new StoreToys() { StoreGUID = _storeGuid, ToyName = "Test Toy", ImageId = 1, LastUpdatedBy = "Tester", LastUpdated = DateTime.Now, Status = "Active" };

			_da.AddNewStoreToy(_st);

			var _listST = _da.GetStoreToysByStoreGuid(_storeGuid);

			Assert.That(_listST.Count == 1, "Add New Store Toy failed");

			StoreToys _addedST = _listST.First();


			_addedST.Status = "Inactive";

			_da.UpdateStoreToys(_addedST);

			StoreToys _updatedST = _da.GetStoreToysById(_addedST.Id);

			Assert.That(_updatedST.Status.Trim() == "Inactive", "Status Was Not Changed");
		}

		[OneTimeTearDown]
		public void TearDown() {
			_da.DeleteToysForTestTearDownOnly();
		}
	}
}
