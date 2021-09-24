namespace API.Interfaces
{
    using API.DTOs;
    using API.Entity;
    using API.Helpers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMediaRepository
    {
        Task<bool> SaveAllAsync();
        Task<List<Media>> SearchMediaAsync(string query);
        Task<List<Media>> GetPagedAsync(MediaParams movieParams);
        Task<Media> GetMediaAync(int id);

    }
}
