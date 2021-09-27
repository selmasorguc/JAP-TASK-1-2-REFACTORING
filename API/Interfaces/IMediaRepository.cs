namespace API.Interfaces
{
    using API.DTOs;
    using API.Entity;
    using API.Helpers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMediaRepository
    {
        Task<List<Media>> GetMediaAsync(MediaParams movieParams);
        Task<Media> GetSingleMediaAync(int id);
    }
}
