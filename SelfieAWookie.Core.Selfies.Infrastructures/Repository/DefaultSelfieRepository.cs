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


        public ICollection<Selfie> GetAll() => _context.Selfies!.Include(item => item.Wookie).ToList();

        public Selfie AddOne(Selfie item) => _context.Selfies.Add(item).Entity;

        public IUnitOfWork UnitOfWork => _context;
    }
}
