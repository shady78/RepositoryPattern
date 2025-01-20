using DataAccess.EfCore.Data;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCore.Repositories;
public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
{
    public DeveloperRepository(ApplicationDbContext context) : base(context)
    {
    }
    public IEnumerable<Developer> GetDevelopersWithMoreFollowers(int followers)
    {
        return _context.Developers.OrderByDescending(d => d.Followers).Take(followers).ToList();
    }
}
