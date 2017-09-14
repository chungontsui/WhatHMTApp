using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WhatHMT.DA
{

	

	public class DA
	{
		private string _connectStr ;

		public DA(string dbType)
		{
			if (string.Equals(dbType, "Test", StringComparison.InvariantCultureIgnoreCase))
			{
				_connectStr = @"Data Source = CHUNGT2016\SQL2012; Initial Catalog = WhatHMT_TEST; Integrated Security = True";
			}
		}

		public List<StoreToys> GetStoreToysByStoreGuid(Guid StoreGuid)
		{
			List<StoreToys> _result = new List<StoreToys>();
			try
			{
				using (var _context = new Context(_connectStr))
				{
					var st = _context.dsStoreToys;

					if (StoreGuid != Guid.Empty)
					{
						st.Where(t => t.Id == 1);
					}

					_result = st.ToList();
				}

				return _result;
			}
			catch (Exception e)
			{
				throw new Exception("Fatal: getStoreToysByStoreGuid " + e.Message, e.InnerException);
			}
		}

		public StoreToys AddNewStoreToy(StoreToys newStoreToy)
		{
			try
			{
				using (var _context = new Context(_connectStr))
				{
					_context.dsStoreToys.Add(newStoreToy);
					_context.SaveChanges();
				}

				return newStoreToy;
			}
			catch (Exception e)
			{
				throw new Exception("Fatal: addNewStoreToys " + e.Message, e.InnerException);
			}

		}
		public void UpdateStoreToys(StoreToys updateStoreToy)
		{
			try
			{
				var _storeToysProperties = updateStoreToy.GetType().GetProperties();

				using (var _context = new Context(_connectStr))
				{
					//var _storeToy = _context.dsStoreToys.First(s => s.Id == updateStoreToy.Id);
					_context.Entry(updateStoreToy).State = EntityState.Modified;
					_context.dsStoreToys.Attach(updateStoreToy);

					foreach (var ep in _storeToysProperties)
					{
						if (ep.Name != "Id")
						{
							_context.Entry(updateStoreToy).Property(ep.Name).IsModified = true;
						}
					}

					_context.SaveChanges();
				}

			}
			catch (Exception e)
			{
				throw new Exception("Fatal: addNewStoreToys " + e.Message, e.InnerException);
			}
		}

		public void DeleteToysForTestTearDownOnly()
		{
			using (Context _context = new Context(@"Data Source = CHUNGT2016\SQL2012; Initial Catalog = WhatHMT_TEST; Integrated Security = True"))
			{
				_context.Database.ExecuteSqlCommand("TRUNCATE TABLE [StoreToys]");
			}
		}

		public StoreToys GetStoreToysById(int id)
		{
			using (Context _context = new Context(_connectStr))
			{
				return _context.dsStoreToys.FirstOrDefault(st => st.Id == id);
			}
		}
	}
}
