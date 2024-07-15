using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
