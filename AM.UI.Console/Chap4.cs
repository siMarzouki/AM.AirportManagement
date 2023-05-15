using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;

namespace AM.UI.Console
{
	public class Chap4
	{
		public static void Test1()
		{
			using (var unitOfWork  = new UnitOfWork())
			{
				unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing1);
				unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing2);
				unitOfWork.Commit();
				unitOfWork.Repository<Plane>().Add(InMemorySource.Airbus);
			}
		}
	}
}
