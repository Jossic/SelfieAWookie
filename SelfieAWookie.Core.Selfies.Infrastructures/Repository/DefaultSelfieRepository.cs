using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Framework;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Repository
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        private readonly SelfiesContext _context = null;
        public DefaultSelfieRepository(SelfiesContext context)
        {
            _context = context;
        }


        public ICollection<Selfie> GetAll(int wookieId)
        {
            var query = _context.Selfies!.Include(item => item.Wookie).AsQueryable();
            if (wookieId > 0)
            {
                query = query.Where(item => item.WookieId == wookieId);
            }
            return query.ToList();
        }

        public Selfie AddOne(Selfie item) => _context.Selfies.Add(item).Entity;


        public IUnitOfWork UnitOfWork => _context;
    }
}
