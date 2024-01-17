
namespace Infrastructure.Data.Administration
{
	using Domain.Entities;
	using Domain.Entities.Libraries;
	using Domain.Administration;
	using Domain.Resources.Libraries.PagedData;
	using Infrastructure.Data.Core;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	/// <summary>
	/// RepositoryCheckpoint
	/// </summary>

	public partial class RepositoryCheckpoint : Repository<Checkpoint>, IRepositoryCheckpoint
		{
			public RepositoryCheckpoint(IQueriableUnitOfWork UnitOfWork)
				: base(UnitOfWork)
			{
			}
		}
}
