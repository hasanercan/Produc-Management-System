using System;
namespace Pms.Core.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task CommitAsync();
		void Commit();
	}
}

