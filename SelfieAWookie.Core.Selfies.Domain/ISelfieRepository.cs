using SelfieAWookie.Core.Framework;

namespace SelfieAWookie.Core.Selfies.Domain
{
    public interface ISelfieRepository : IRepository
    {
        ICollection<Selfie> GetAll();

        Selfie AddOne(Selfie item);
    }
}
