namespace MovieApp.Core.Interfaces
{
    using MovieApp.Core.DTOs;
    using MovieApp.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMediaRepository
    {
        Task<List<Media>> GetMediaAsync(MediaParams movieParams);

        Task<Media> GetSingleMediaAync(int id);

        Task<bool> MediaExists(int id);

        Task<bool> UpdateAfterRating(int id);
    }
}
