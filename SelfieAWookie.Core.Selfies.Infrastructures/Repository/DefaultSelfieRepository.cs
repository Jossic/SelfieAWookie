using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Repository
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        private readonly SelfiesContext _context = null;
        public DefaultSelfieRepository(SelfiesContext context)
        {
            _context = context;
        }

        public ICollection<Selfie> GetAll()
        {
            return _context.Selfies!.Include(item => item.Wookie).ToList()
        }
    }
}
