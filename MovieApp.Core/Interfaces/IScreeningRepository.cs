using MovieApp.Core.Entities;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IScreeningRepository
    {
        public Task<Screening> UpdateScreening(int id);
        public Task<Screening> GetScreening(int id);
    }
}
